using System.Diagnostics;

namespace ChronometerApp
{
    public class Chronometer : IChronometer
    {
        private Stopwatch stopwatch;
        private List<string> laps;

        public Chronometer()
        {
            stopwatch = new Stopwatch();
            laps = new List<string>();
        }

        public string GetTime => stopwatch.Elapsed.ToString(@"mm\:ss\.ffff");

        public List<string> Laps => laps;

        public string Lap()
        {
            string result = GetTime;
            laps.Add(result);

            return result;
        }

        public void Reset()
        {
            stopwatch.Reset();
            laps.Clear();
        }

        public void Start()
        {
            laps.Clear();
            stopwatch.Start();
        }

        public void Stop()
        {
            stopwatch.Stop();
        }
    }
}
