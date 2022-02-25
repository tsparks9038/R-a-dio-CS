using System;
using System.Threading;

namespace Radio
{
    class Program
    {
        static void Main(string[] args)
        {
            SongInfo info = new();
            long end, curr, timeLeft;
            string[] nameArt;

            while (true)
            {
                Console.Clear();

                nameArt = info.GetSongName().Split(" - ");
                Console.WriteLine("Song: {0}\n", nameArt[1]);
                Console.WriteLine("Artist: {0}\n", nameArt[0]);

                end = info.GetEndTime();
                curr = info.GetCurrent();

                timeLeft = end - curr;

                DateTime defaultUnix = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
                DateTime timeUnix = defaultUnix.AddSeconds(timeLeft).ToLocalTime();

                DateTimeOffset timeMill = timeUnix;

                int timeInt = (int)timeMill.ToUnixTimeMilliseconds();

                Thread.Sleep(timeInt + 2000);
            }
        }
    }
}
