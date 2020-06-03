using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WSThreadSynchro
{
    class Question4
    {
        
        static void Main(string[] args)
        {
            Console.WriteLine("Program start");
            
            Thread thread = new Thread(new ThreadStart(
                    () =>
                    {
                        for (int i = 0; i < 10; i++)
                        {
                            Console.WriteLine("Work... " + i);
                            Thread.Sleep(1000);
                        }
                    }
                ));
            thread.Start();
            Console.Read();
        }
    }
}

