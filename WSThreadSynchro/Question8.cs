using System;
using System.Threading;
using System.Runtime.Remoting.Messaging;
using System.Runtime.CompilerServices;

namespace CorbeilleThreadEtSynchro
{


    class Question8
    {
        private delegate void DELG(object state);
        private static int var = 0;
        private static object _lock;

        static void Main(string[] args)
        {
            _lock = new object();
            DELG deleg = (state) =>
            {
                lock (_lock)
                {
                    string name_thread = (string)state;
                    ++var;
                    Console.WriteLine("Thread -> " + name_thread + " -- var -> " + var.ToString());
                    Thread.Sleep(2000);
                }
            };
            Thread t1 = new Thread(deleg.Invoke);
            Thread t2 = new Thread(deleg.Invoke);
            t1.Start((object)("T1"));
            t2.Start((object)("T2"));

            Console.Read();
        }
    }
}