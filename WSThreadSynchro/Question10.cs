using System;
using System.Threading;
using System.Runtime.Remoting.Messaging;
using System.Runtime.CompilerServices;

namespace CorbeilleThreadEtSynchro
{


    class Question10
    {
        private delegate void DELG(object state);
        private static string simu_cnx_db = "Utilisation de la base de données";
        private static Semaphore semaphore;
        

        static void Main(string[] args)
        {
            semaphore = new Semaphore(2,2) ;
            DELG deleg = (state) =>
            {
                semaphore.WaitOne();
                for (int i = 0; i < 3; i++)
                {
                    string name_thread = (string)state;
                    Console.WriteLine("Thread -> " + name_thread + " -- Etat -> " + simu_cnx_db.ToString());
                    Thread.Sleep(2000);
                }
                semaphore.Release();
            };
            Thread t1 = new Thread(deleg.Invoke);
            Thread t2 = new Thread(deleg.Invoke);
            Thread t3 = new Thread(deleg.Invoke);
            t1.Start((object)("T1"));
            t2.Start((object)("T2"));
            t3.Start((object)("T3"));

            Console.Read();
        }
    }
}