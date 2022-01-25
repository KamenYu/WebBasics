namespace TaskAndThread
{
    public class StartUp
    {
        public static void Main()
        {
            //var task = Task.Run(() =>
            //{
            //    for (int i = 0; i < 100; i++)
            //    {
            //        Console.WriteLine("Task " + i);
            //    }
            //});

            //for (int i = 0; i < 100; i++) // i < 10 seems that the task and for are synchronous
            //{
            //    Console.WriteLine(i);
            //}

            //task.Wait();

            TaskReturnsAValue();
        }

        private static void TaskReturnsAValue()
        {
            var task = Task.Run(() => // it takes time for this to start
            {
                int sum = 0;

                for (int i = 0; i < 100; i++)
                {
                    sum += i;
                }

                return sum;
            });

            for (int i = 0; i < 100; i++)
            {
                Console.WriteLine(i);
            }

            Console.WriteLine(task.Result + " is the result!");
        }

        private static void TasksTest()
        {
            Task even = Task.Run(() =>
            {
                for (int i = 0; i <= 100; i += 2)
                {
                    Console.WriteLine(i);
                    //Thread.Sleep(1);
                }
            });

            Task odd = Task.Run(() =>
            {
                for (int i = 1; i <= 100; i += 2)
                {
                    Console.WriteLine(i);
                    //Thread.Sleep(1);

                }
            });


            Task.WaitAll(even, odd);

            Console.WriteLine("Tasks done!");
        }
    }
}
