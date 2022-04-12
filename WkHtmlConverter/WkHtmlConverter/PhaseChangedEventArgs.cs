using System;

namespace WkHtmlConverter
{
    public class PhaseChangedEventArgs : EventArgs
    {
        public PhaseChangedEventArgs(int currentPhase, int phaseCount, string phaseDescription)
        {
            CurrentPhase = currentPhase;
            PhaseCount = phaseCount;
            PhaseDescription = phaseDescription;
        }

        public int CurrentPhase { get; }
        public int PhaseCount { get; }
        public string PhaseDescription { get; }
    }
}