using System;
using System.Runtime.InteropServices;
using System.Text;

namespace WkHtmlConverter
{
    internal static class BufferExtensions
    {
        public static string ToUtf8String(this byte[] buffer, int offset = 0)
        {
            var nullTerminatorIndex = Array.FindIndex(buffer, 0, (x) => x == 0);
            nullTerminatorIndex = (nullTerminatorIndex == -1) ? buffer.Length : nullTerminatorIndex;
            return Encoding.UTF8.GetString(buffer, 0, nullTerminatorIndex);
        }

        public static string InvokeBufferToUtf8Action(Action<byte[]> bufferAction, int bufferSize = 2048)
        {
            var buffer = new byte[bufferSize];
            bufferAction(buffer);
            return buffer.ToUtf8String();
        }

        public static byte[] MarshalReturnBuffer(Func<(IntPtr, long)> apiFunction)
        {
            var (dataPointer, bufferLength) = apiFunction();
            var buffer = new byte[bufferLength];
            Marshal.Copy(dataPointer, buffer, 0, (int)bufferLength);
            return buffer;
        }
    }
}