namespace ChronometerApp
{
    public class StartUp
    {
        public static void Main()
        {
            Chronometer c = new Chronometer();

            string line;
            while ((line = Console.ReadLine()) != "exit")
            {
                if (line.ToLower() == "start")
                {
                    Task.Run(() =>
                    {
                        c.Start();
                    });
                }
                else if(line.ToLower() == "stop")
                {
                    c.Stop();
                }
                else if (line.ToLower() == "lap")
                {
                    Console.WriteLine(c.Lap());
                }
                else if (line.ToLower() == "laps")
                {
                    if (c.Laps.Count == 0)
                    {
                        Console.WriteLine("Laps: no laps");
                        continue;
                    }

                    Console.WriteLine("Laps: ");

                    for (int i = 0; i < c.Laps.Count; i++)
                    {
                        Console.WriteLine($"{i}. {c.Laps[i]}");
                    }
                }
                else if (line.ToLower() == "reset")
                {
                    c.Reset();
                }
                else if (line.ToLower() == "time")
                {
                    Console.WriteLine(c.GetTime);
                }
                else
                {
                    Console.WriteLine("Incorrect command, Try one of these: ");
                    Console.WriteLine("start");
                    Console.WriteLine("stop");
                    Console.WriteLine("lap");
                    Console.WriteLine("laps");
                    Console.WriteLine("time");
                    Console.WriteLine("reset");
                    Console.WriteLine("exit");
                }
            }

            c.Stop();
        }
    }
}
