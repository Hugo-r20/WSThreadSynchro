using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WSThreadSynchro
{
    class Question5
    {
        private delegate void DELG(object o);

/*        static void Main(string[] args)
        {
            Console.WriteLine("Program Question 5 start");

            Thread t1, t2, t3;
            DELG deleg = (o) =>
            {
                string msg = (string)o;
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("Work -> " + msg + ":" + i);
                    Thread.Sleep(1000);
                }
            };

            t1 = new Thread(new ParameterizedThreadStart(deleg.Invoke));
            t2 = new Thread(new ParameterizedThreadStart(deleg.Invoke));
            t3 = new Thread(new ParameterizedThreadStart(deleg.Invoke));

            ThreadPool.QueueUserWorkItem(delegate { t1.Start((object)("T1")); });
            ThreadPool.QueueUserWorkItem(delegate { t2.Start((object)("T2")); });
            ThreadPool.QueueUserWorkItem(delegate { t3.Start((object)("T3")); });

            Console.Read();
        }*/
    }
}

