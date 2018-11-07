using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace FirstSemesterExamProject
{
    class Client
    {
        private static Client instance;
        TcpClient client;
        public static readonly object key = new object();
        int sleepDelay = 17;
        public int port = 25565;//The port to connect to
        StreamWriter sWriter;
        StreamReader sReader;
        private bool validIp = false;
        private IPAddress iP;
        PlayerTeam team;
        Boolean bClientConnected = false;

        public bool ValidIp
        {
            get { return validIp; }
            set { validIp = value; }
        }

        public IPAddress IP
        {
            get { return iP; }
            set { iP = value; }
        }

        /// <summary>
        /// server Singleton
        /// </summary>
        public static Client Instance
        {
            get
            {
                if (instance != null)
                {

                    return instance;
                }
                else
                {
                    instance = new Client();
                    return instance;
                }
            }
        }

        public bool ValidIp1 { get => validIp; set => validIp = value; }

        private Client() { }

        /// <summary>
        /// checks if connection is successfull
        /// </summary>
        public void ConnectClient()
        {
            // retrieve connect to server
            client = new TcpClient();
            bool error = false;
            try
            {
                client.Connect(iP, port);
                Console.WriteLine("Connected");
            }
            catch (Exception)
            {
                error = true;
                Console.WriteLine("Server unavaible");
            }

            if (error != true)
            {
                ClientHandler();
            }
        }

        /// <summary>
        /// handles each client
        /// </summary>
        /// <param name="obj"></param>
        private void ClientHandler()
        {
            // sets two streams
            sWriter = new StreamWriter(client.GetStream(), Encoding.ASCII);
            sReader = new StreamReader(client.GetStream(), Encoding.ASCII);

            ReceiveTeamAssignment();// sets the team

            ReaderThread();
        }

        /// <summary>
        /// the loop that the clients thread come into
        /// </summary>
        private void ReaderThread()
        {
            string sData;
            bClientConnected = true;
            while (bClientConnected)
            {
                sData = ReceiveFromHost();
                UseServerData(sData);
                Thread.Sleep(sleepDelay);
            }
        }

        /// < summary >
        /// Receive an immediate respons from Server, assigning client to a team
        /// </ summary >
        private void ReceiveTeamAssignment()
        {
            ThreadPool.QueueUserWorkItem(new WaitCallback(ReceiveTeamInt));
        }

        /// <summary>
        /// sets the team
        /// </summary>
        private void ReceiveTeamInt(object callback)
        {
            team = (PlayerTeam)Convert.ToInt32(ReceiveFromHost());
            //Then host would be Red, 1st: Blue, 2nd: Green, 3rd: Yellow
        }

        /// <summary>
        /// Write to Host
        /// </summary>
        /// <param name="message"></param>
        private void SendToHost(string message)
        {
            sWriter.WriteLine(message);
            sWriter.Flush();
        }

        /// <summary>
        /// Read from stream
        /// </summary>
        /// <returns></returns>
        private string ReceiveFromHost()
        {
            string sData;
            sData = sReader.ReadLine();
            return sData;
        }

        /// <summary>
        /// Method that handles the recieved Data
        /// </summary>
        /// <param name="Data"></param>
        private void UseServerData(string sData)
        {

        }
    }
}
