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
        private delegate void DELG();

        static void Main(string[] args)
        {
            Console.WriteLine("Program start");
            
            DELG deleg = new DELG(CLpara.method_para);
            Thread thread = new Thread(deleg.Invoke);
            thread.Start();
            Console.Read();
        }
    }

    static class CLpara
    {
        public static void method_para()
        {
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Work... " + i);
                Thread.Sleep(1000);
            }
        }
    }
}

