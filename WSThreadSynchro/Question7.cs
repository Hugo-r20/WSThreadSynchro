using System;
using System.Threading;
using System.Runtime.Remoting.Messaging;
using System.Runtime.CompilerServices;

namespace CorbeilleThreadEtSynchro
{


    class Question7
    {
        private delegate void DELG(object o);
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Initialisation du thread principal...ok");
            DELG delg;
            NS_SERVER.CLserver server = new NS_SERVER.CLserver();
            NS_CLIENT.CLclient client1 = new NS_CLIENT.CLclient(server, "C1");
            NS_CLIENT.CLclient client2 = new NS_CLIENT.CLclient(server, "C2");
            string[] messages = { "msg1", "msg2", "msg3" };
            delg = (o) =>
            {
                for (int i = 0; i < messages.Length; i++)
                {
                    server.msg = messages[i];
                    System.Threading.Thread.Sleep(4000);
                }
            };
            Console.WriteLine("Début traitement asynchrone...ok");
            IAsyncResult asr = delg.BeginInvoke(((object)("nostate")),
                (asR) =>
                {
                    delg.EndInvoke(asR);
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("Fin traitement asynchrone...ok");
                }, delg);
            while (!asr.IsCompleted)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Traitement en cours sur le thread principal");
                System.Threading.Thread.Sleep(3000);
            }
            Console.Read();
        }
    }
}

namespace NS_CLIENT
{
    class CLclient
    {
        private NS_SERVER.CLserver server;
        private string client_name;
        
        public CLclient (NS_SERVER.CLserver server, string client_name)
        {
            this.server = server;
            this.client_name = client_name;
            this.server.evt_server += new NS_SERVER.CLserver.DELG(this.display_msg);
            Console.WriteLine("Initialisation du client "+this.client_name+" ........ OK");
        }

        private void display_msg()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Message reçu par " + this.client_name + " : " + this.server.msg);

        }
    }
}


namespace NS_SERVER
{
    class CLserver
    {
        private string _msg;
        public delegate void DELG();
        public DELG evt_server;

        public CLserver()
        {
            this._msg = "Aucun message";
            Console.WriteLine("Initialisation du serveur .... ok");
        }

        public string msg
        {
            get { return _msg; }
            set { _msg = value; this.evt_server.Invoke(); }
        }
    }
}