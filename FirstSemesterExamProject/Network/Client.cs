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
        public static readonly object key = new object();
        int sleepDelay = 17;
        public int port = 25565;//The port to connect to
        StreamWriter sWriter;
        StreamReader sReader;
        public string ip = "192.168.1.1";
        public IPAddress iP;
        private Boolean _isRunning;
        PlayerTeam team;

        /// <summary>
        /// handles each client
        /// </summary>
        /// <param name="obj"></param>
        public void ClientHandler()
        {
            IPAddress.TryParse(ip, out iP);
            // retrieve connect to server
            TcpClient client = new TcpClient();
            client.Connect(iP, port);
            // sets two streams
            sWriter = new StreamWriter(client.GetStream(), Encoding.ASCII);
            sReader = new StreamReader(client.GetStream(), Encoding.ASCII);

            ReceiveTeamAssignment();// sets the team

            // you could use the NetworkStream to read and write, 
            // but there is no forcing flush, even when requested
            IPEndPoint endPoint = (IPEndPoint)client.Client.RemoteEndPoint;
            IPEndPoint localPoint = (IPEndPoint)client.Client.LocalEndPoint;

            Console.WriteLine("Connected");

            Thread readerThread = new Thread(ReaderThread);
            readerThread.Start();
            readerThread.IsBackground = true;

        }

        private void ReaderThread()
        {
            Boolean bClientConnected = true;
            while (bClientConnected)
            {

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
    }
}
