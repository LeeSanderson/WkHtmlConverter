using System;
using System.Collections.Concurrent;
using System.Threading;
using System.Threading.Tasks;

namespace WkHtmlConverter
{
    /// <summary>
    /// Image and PDF conversion must be run on the same thread to avoid errors with the QT library
    /// (such as "QObject: Cannot create children for a parent that is in a different thread").
    /// The executor is implemented as a thread-safe, lazy loaded singleton as described here: https://jonskeet.uk/csharp/singleton.html
    /// </summary>
    internal class WkConversionExecutor
    {
        private readonly BlockingCollection<Task> _conversionsTasks = new();
        // ReSharper disable once PrivateFieldCanBeConvertedToLocalVariable
        private readonly Thread _conversionThread;

        public static WkConversionExecutor Instance => Nested.LazyInstance;

        private WkConversionExecutor()
        {
            _conversionThread = new Thread(RunConversionThread)
            {
                IsBackground = true,
                Name = "WkHtmlConverter worker thread"
            };

            _conversionThread.SetApartmentState(ApartmentState.STA);

            _conversionThread.Start();
        }

        public async Task<TResult> Queue<TResult>(Func<TResult> func)
        {
            var task = new Task<TResult>(func);
            _conversionsTasks.Add(task);
            return await task;
        }

        private void RunConversionThread(object obj)
        {
            while (true)
            {
                if (_conversionsTasks.TryTake(out var task))
                {
                    try
                    {
                        task.RunSynchronously();
                    }
                    catch (Exception)
                    {
                        // Ignore exceptions
                    }
                }
            }
            // ReSharper disable once FunctionNeverReturns
        }

        // ReSharper disable once ClassNeverInstantiated.Local
        private class Nested
        {
            static Nested()
            {
                // Explicit static constructor to tell C# compiler
                // not to mark type as beforefieldinit
            }

            internal static readonly WkConversionExecutor LazyInstance = new();
        }
    }
}
