using System;
using System.Threading;
using System.Runtime.Remoting.Messaging;

namespace CorbeilleThreadEtSynchro
{


    class Question6
    {
        private delegate void DELG(object o);

        static void Main(string[] args)
        {
            IAsyncResult asyncR;

            DELG deleg = (o) =>
            {
                string msg = (string)o;
                for (int i = 0; i < 10; i++)
                {
                    Console.WriteLine("Work -> " + i + "::" + msg);
                    Thread.Sleep(1000);
                }
            };

            asyncR = deleg.BeginInvoke(((object)("T1")), (asr) =>
            {
                DELG delg = (DELG)((AsyncResult)asr).AsyncDelegate;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("Callback");
                Console.ForegroundColor = ConsoleColor.Gray;
            }, deleg);

            while (!asyncR.IsCompleted)
            {
                Console.WriteLine("Le thread principal attend le callback end");
                Thread.Sleep(2000);
                if (asyncR.IsCompleted)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Callback end");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }

            Console.Read();

        }
    }
}
