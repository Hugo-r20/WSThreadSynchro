using System;
using System.Threading;
using System.Runtime.Remoting.Messaging;
using System.Runtime.CompilerServices;

namespace CorbeilleThreadEtSynchro
{


    class Question9
    {
        private delegate void DELG(object state);
        private static int var = 0;
        private static Mutex mutex;

        static void Main(string[] args)
        {
            mutex = new Mutex(false);
            DELG deleg = (state) =>
            {
                mutex.WaitOne();
                for (int i = 0; i<3; i++) {
                    string name_thread = (string)state;
                    ++var;
                    Console.WriteLine("Thread -> " + name_thread + " -- var -> " + var.ToString());
                    Thread.Sleep(2000);
                }
                mutex.ReleaseMutex();
            };
            Thread t1 = new Thread(deleg.Invoke);
            Thread t2 = new Thread(deleg.Invoke);
            t1.Start((object)("T1"));
            t2.Start((object)("T2"));

            Console.Read();
        }
    }
}