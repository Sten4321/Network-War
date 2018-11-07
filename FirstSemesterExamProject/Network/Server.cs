using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FirstSemesterExamProject
{
    class Server
    {
        private readonly object clientsListKey = new object();
        private readonly object receivedDataKey = new object();



        public int port = 13000;
        public bool isOnline = false;

        private bool shouldLookForClients = true;


        private List<TcpClient> clients = new List<TcpClient>();
        private TcpClient lastClientToSendMessage = null;




        private Queue<Data> receivedDataQueue = new Queue<Data>();


        private static Server instance;

        public TcpListener tcpListener;

        public string serverIp;


        private readonly byte clientsMaxAmount = 3;

        /// <summary>
        /// server Singleton
        /// </summary>
        public static Server Instance
        {
            get
            {
                if (instance != null)
                {

                    return instance;
                }
                else
                {
                    instance = new Server();
                    return instance;
                }
            }
        }


        private Server()
        {
            //Finds the local Ip
            serverIp = FindLocalIp(NetworkInterfaceType.Wireless80211);

           
        }

        /// <summary>
        /// Called when hosting a Lobby
        /// </summary>
        public void StartServer()
        {
            // starts the actual server
            tcpListener = new TcpListener(IPAddress.Any, port);
            tcpListener.Start();
            //
            
            isOnline = true;

            //a thread to handle server logic
            Thread serverUpdateThread = new Thread(ServerUpdate)
            {
                IsBackground = true
            };
            serverUpdateThread.Start();

            //a thread to handle new clients
            Thread searchForClientsThread = new Thread(FindNewClients)
            {
                IsBackground = true
            };
            searchForClientsThread.Start();

            System.Diagnostics.Debug.WriteLine("Server online status: " + isOnline);
            System.Diagnostics.Debug.WriteLine("IP: " + serverIp + "     Port:" + port);
        }

        public static string FindLocalIp(NetworkInterfaceType _networkType)
        {
            //string hostName = Dns.GetHostName(); // Retrive the Name of HOST  

            //// Get the IP
            //IPHostEntry host = Dns.GetHostEntry(hostName);


            //return host.AddressList[1].ToString(); //IP


            string output = "";


            foreach (NetworkInterface item in NetworkInterface.GetAllNetworkInterfaces())
            {
                if (item.NetworkInterfaceType == _networkType && item.OperationalStatus == OperationalStatus.Up)
                {
                    foreach (UnicastIPAddressInformation ip in item.GetIPProperties().UnicastAddresses)
                    {
                        if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                        {
                            output = ip.Address.ToString();
                        }
                    }
                }
            }

            if (output == "")
            {
                System.Diagnostics.Debug.WriteLine("IP Error!");
            }
            return output;
        }

        /// <summary>
        /// Updates server logic - Distributes the latest information to all clients
        /// </summary>
        private void ServerUpdate()
        {
            while (isOnline)
            {
                // Sends the latest data to all clients but the one who sent it
                SendDataToOtherClients();


            }

        }

        /// <summary>
        /// Sends the latest data to all clients but the one who sent it
        /// </summary>
        private void SendDataToOtherClients()
        {
            if (receivedDataQueue.Count > 0) // there is data to send
            {
                lock (receivedDataKey)
                {
                    Data data = receivedDataQueue.Dequeue(); // Queue -> chronologically 

                    lock (clientsListKey)
                    {
                        for (int i = 0; i < clients.Count; i++)
                        {
                            if (clients[i] != data.client) //if the client is not the sender of the data
                            {
                                //Writes to the specefic client
                                StreamWriter sWriter = new StreamWriter(clients[i].GetStream(), Encoding.ASCII);


                                //sends data
                                sWriter.WriteLine(data.information);

                                //Clears buffer
                                sWriter.Flush();


                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Continuesly searches for new clients, untill max amount has been reached, or it is told not to.
        /// </summary>
        private void FindNewClients()
        {
            while (LessThanMaxClients() && shouldLookForClients)
            {
                SearchAndAddClient();

            }
        }
        /// <summary>
        /// Listens for clients, and adds them to the server
        /// </summary>
        private void SearchAndAddClient()
        {
            // wait for client connection
            TcpClient newClient = tcpListener.AcceptTcpClient();

            // client found.
            clients.Add(newClient);

            AssignNewClientToTeam(newClient);

            // create a thread to handle communication
            Thread clientThread = new Thread(new ParameterizedThreadStart(ClientUpdate));
            clientThread.Start(newClient);
        }

        private void AssignNewClientToTeam(TcpClient client)
        {
            StreamWriter sWriter = new StreamWriter(client.GetStream(), Encoding.ASCII);

            //sends data
            sWriter.WriteLine(clients.Count);

            //Clears buffer
            sWriter.Flush();

        }





        /// <summary>
        /// returns whether or not we have reached the maximum amount of clients
        /// </summary>
        /// <returns></returns>
        private bool LessThanMaxClients()
        {
            return clients.Count < clientsMaxAmount;

        }

        public void ClientUpdate(object obj)
        {
            // retrieve client from parameter passed to thread
            TcpClient client = (TcpClient)obj;

            // sets two streams
            StreamReader sReader = new StreamReader(client.GetStream(), Encoding.ASCII);

            bool isConnected = true;
            string sData = null;

            IPEndPoint endPoint = (IPEndPoint)client.Client.RemoteEndPoint;
            IPEndPoint localPoint = (IPEndPoint)client.Client.LocalEndPoint;

            while (isConnected)
            {
                // reads from stream
                try
                {
                    //Reading untill data is received..
                    sData = sReader.ReadLine();
                }
                catch (Exception)
                {
                    //if client disconnects

                    System.Diagnostics.Debug.WriteLine(endPoint.Port.ToString() + " " + localPoint.Port.ToString() + " lukkede forbindelsen");
                    lock (clientsListKey)
                    {
                        clients.Remove(client);
                    }
                    Thread.CurrentThread.Abort();
                }

                //when data has arrived or client has disconnected
                if (sData != null)
                {
                    //evaluate the Data and the client who sent it
                    EvaluateData(sData, client);
                }
            }
        }

        /// <summary>
        /// handles the received data and its client. 
        /// </summary>
        /// <param name="sData">the data received</param>
        /// <param name="client">the client who sent it</param>
        private void EvaluateData(string sData, TcpClient client)
        {
            Data data = new Data(sData, client);

            lock (receivedDataKey)
            {
                receivedDataQueue.Enqueue(data);
            }
        }


        /// <summary>
        /// For testing purposes
        /// </summary>
        /// <param name="message"></param>
        public void WriteToAllClients(string message)
        {
            lock (clientsListKey)
            {
                foreach (TcpClient client in clients)
                {

                    //Writes to the specefic client
                    StreamWriter sWriter = new StreamWriter(client.GetStream(), Encoding.ASCII);


                    //sends data
                    sWriter.WriteLine(message);

                    //Clears buffer
                    sWriter.Flush();
                }
            }
        }
    }
}


