using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.Reflection.Emit;
using System.IO;
using System.Reflection;

namespace Lab15
{
    class Program
    {
        static string oneToMany(string str, int count)
        {
            string rc = "";
            for (int i = 0; i < count; i++)
                rc += str;
            return rc;
        }

        static void Main(string[] args)
        {

            //foreach (Process item in Process.GetProcesses())
            //{
            //    try
            //    {
            //        Console.WriteLine(oneToMany("$",15));
            //        Console.WriteLine($"\tID: {item.Id}\n\tName: {item.ProcessName}\n\tStarting time: {item.StartTime}\n\tCPU usage time: {item.TotalProcessorTime}");
            //    }
            //    catch (Exception e)
            //    {
            //        Console.WriteLine(oneToMany(">",5)+"Error" + oneToMany("<", 5) + $"\n\t{e.Message}: {item.ProcessName}");
            //    }
            //}
            //Console.WriteLine(oneToMany("$", 15));


            //Console.WriteLine('\n'+oneToMany(oneToMany("Domain ", 5) + '\n', 3));

            //AppDomain mydomain = AppDomain.CurrentDomain;
            //Console.WriteLine($"\tName: {mydomain.FriendlyName}\t\tID: {mydomain.Id}" +
            //    $"\n\tConfiguration:\n\tConfigurationFile: {mydomain.SetupInformation.ConfigurationFile}" +
            //    $"\n\tAplication Base: {mydomain.SetupInformation.ApplicationBase}");
            //Console.WriteLine("All assemblies:");
            //var allAssemblies = from littleassebly in mydomain.GetAssemblies()
            //                 orderby littleassebly.GetName().Name
            //                 select littleassebly;
            //foreach (var littleassebly in allAssemblies)
            //{
            //    Console.WriteLine($"\tAssembly name: {littleassebly.GetName().Name}\tVersion: {littleassebly.GetName().Version}");
            //}


            //Console.WriteLine('\n' + oneToMany(oneToMany("New Domain ", 4)+'\n', 3));


            //AppDomain newDomain = AppDomain.CreateDomain("SomeNewDomain");

            //Assembly asm = Assembly.GetExecutingAssembly();
            //newDomain.Load(asm.FullName);
            //Console.WriteLine($"\tName: {newDomain.FriendlyName}\t\tID: {newDomain.Id}" +
            //    $"\n\tConfiguration:\n\tConfigurationFile: {newDomain.SetupInformation.ConfigurationFile}" +
            //    $"\n\tAplication Base: {newDomain.SetupInformation.ApplicationBase}");
            //Console.WriteLine("All assemblies:");
            //var allAssembliesNew = from littleassebly in newDomain.GetAssemblies()
            //                    orderby littleassebly.GetName().Name
            //                    select littleassebly;
            //foreach (var littleassebly in allAssembliesNew)
            //{
            //    Console.WriteLine($"\tAssembly name: {littleassebly.GetName().Name}\tVersion: {littleassebly.GetName().Version}");
            //}
            //AppDomain.Unload(newDomain);

            Console.WriteLine('\n' + oneToMany(oneToMany("Threads ", 4) + '\n', 3));


            //Console.WriteLine("Enter count: ");
            //int n = Convert.ToInt32(Console.ReadLine());

            Thread myThread = new Thread(new ParameterizedThreadStart(Count));
            Thread myThread2 = new Thread(new ParameterizedThreadStart(Even));
            Thread myThread3 = new Thread(new ParameterizedThreadStart(NEven));

            //myThread.Start(n);
            //myThread3.Start(n);
            //myThread2.Start(n);
            //myThread3.Join();
            //myThread2.Join();


            //Thread threadx = new Thread(new ParameterizedThreadStart(someret));
            //threadx.Start(n);
            //threadx.Join();
            //Console.WriteLine(randnumb);

            //Console.ReadKey();
            //timer.Change(2000, 2000);
            //Console.WriteLine("Every 2 seconds a new js framework appears");

            Console.ReadKey();
        }

        public static TimerCallback tm = new TimerCallback(js);
        public static Timer timer = new Timer(tm,randnumb, System.Threading.Timeout.Infinite, 2000);
        
        static public int randnumb=0;

        public static void someret(object x)
        {
            randnumb = (int)x - 1;
        }

        public static void js(object x)
        {
            Console.WriteLine("Hello new js framework "+randnumb);
            randnumb++;
            if (randnumb > 10) timer.Change(System.Threading.Timeout.Infinite, 0);
        }

        public static void Even(object x)
        {

            if ((int)x > 1)
            {
                StreamWriter streamWriter = new StreamWriter("Even.txt");
                string outstr =
                        $"Even\n" +
                        $"Thread : {Thread.CurrentThread}\n" +
                        $"Thread state: {Thread.CurrentThread.ThreadState}\n" +
                        $"Thread ID: {Thread.CurrentThread.ManagedThreadId}\n" +
                        $"Thread priority: {Thread.CurrentThread.Priority}\n";
                Console.WriteLine(outstr);
                Thread.CurrentThread.Priority = ThreadPriority.Normal;
                Thread.Sleep(110);

                for (int i = 1; i <= (int)x; i++)
                {
                    if (i % 2 == 0)
                    {
                        streamWriter.WriteLine('e'+i.ToString());
                        Console.WriteLine('e' + i.ToString());
                        //Thread.CurrentThread.Suspend();
                        //Thread.CurrentThread.Interrupt();
                        //Thread.Yield();
                        Thread.Sleep(1000);
                        //Thread.CurrentThread.Resume();

                    }
                }
                streamWriter.Close();
            }
            else
            {
                Console.WriteLine("Wrong input parameter");
            }
        }

        public static void NEven(object x)
        {

            if ((int)x > 1)
            {
                StreamWriter streamWriter = new StreamWriter("NEven.txt");
                string outstr =
                        $"NEven\n" +
                        $"Thread : {Thread.CurrentThread}\n" +
                        $"Thread state: {Thread.CurrentThread.ThreadState}\n" +
                        $"Thread ID: {Thread.CurrentThread.ManagedThreadId}\n" +
                        $"Thread priority: {Thread.CurrentThread.Priority}\n";
                Console.WriteLine(outstr);

                Thread.CurrentThread.Priority = ThreadPriority.Normal;
                Thread.Sleep(100);

                for (int i = 1; i <= (int)x; i++)
                {
                    if (i % 2 != 0)
                    {
                        streamWriter.WriteLine('n' + i.ToString());
                        Console.WriteLine('n' +i.ToString());
                        //Thread.CurrentThread.Suspend();
                        //Thread.CurrentThread.Interrupt();
                        //Thread.Yield();
                        Thread.Sleep(1000);
                        //Thread.CurrentThread.Resume();

                    }
                }
                streamWriter.Close();
            }
            else
            {
                Console.WriteLine("Wrong input parameter");
            }
        }

        public static void Count(object x)
        {
            if ((int)x > 1)
            {
                StreamWriter streamWriter = new StreamWriter("count.txt");
                string outstr =
                        $"Count\n" +
                        $"Thread : {Thread.CurrentThread}\n" +
                        $"Thread state: {Thread.CurrentThread.ThreadState}\n" +
                        $"Thread ID: {Thread.CurrentThread.ManagedThreadId}\n" +
                        $"Thread priority: {Thread.CurrentThread.Priority}\n";
                Console.WriteLine(outstr);

                Thread.CurrentThread.Priority = ThreadPriority.Lowest;

                for (int i = 1; i <= (int)x; i++)
                {
                    streamWriter.WriteLine('c' +i.ToString());
                    Console.WriteLine('c' + i.ToString());
                    //Thread.CurrentThread.Suspend();
                    //Thread.CurrentThread.Interrupt();
                    Thread.Yield();
                    Thread.Sleep(100);
                    //Thread.CurrentThread.Resume();
                }
                streamWriter.Close();
            }
            else
            {
                Console.WriteLine("Wrong input parameter");
            }
        }
    }
}
