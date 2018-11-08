using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace FirstSemesterExamProject
{
    class Server
    {
        //Server Settings / info
        public string serverIp;
        public int port = 13000;
        public bool isOnline = false;
        private readonly byte clientsMaxAmount = 3;
        private static TcpListener tcpListener;

        //Collections
        private List<ClientStruct> clientStructs = new List<ClientStruct>(); //Client Structs contain the clients TcpClient and Team (could add ip ect.)
        private Queue<Data> receivedDataQueue = new Queue<Data>(); // Datas contains messages and the clients who sent them 

        //Threading
        private readonly object clientsListKey = new object(); //Two keys for threads to make sure only one can get in at a time
        private readonly object receivedDataKey = new object();
        List<Thread> serverThreads = new List<Thread>();



        //Singleton Instance 
        private static Server instance;

        //Host info
        public PlayerTeam serverTeam = PlayerTeam.RedTeam;
        public bool isReady = false;
        public bool turn = false;


        /// <summary>
        /// server Singleton Property
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

        /// <summary>
        /// Private Singleton constructor used by property to make sure there can never be more than one server.
        /// </summary>
        private Server()
        {

        }

        /// <summary>
        /// Called when hosting a Lobby
        /// </summary>
        public void StartServer()
        {
            //Finds the local Ip
            serverIp = FindLocalIp();

            // starts the actual server
            if (tcpListener == null)
            {
                tcpListener = new TcpListener(IPAddress.Any, port);
                tcpListener.Start();
                //
            }


            isOnline = true;

            StartServerThreads();


            //Prints Status and info to debug output
            System.Diagnostics.Debug.WriteLine("Server online status: " + isOnline);
            System.Diagnostics.Debug.WriteLine("IP: " + serverIp + "     Port:" + port);
        }

        private void StartServerThreads()
        {
            //a thread to handle server logic
            Thread serverUpdateThread = new Thread(ServerUpdate)
            {
                IsBackground = true
            };
            serverUpdateThread.Start();
            serverThreads.Add(serverUpdateThread);

            //a thread to handle new clients
            Thread searchForClientsThread = new Thread(FindNewClients)
            {
                IsBackground = true
            };
            searchForClientsThread.Start();
            serverThreads.Add(searchForClientsThread);
        }
        private static string FindLocalIp()
        {

            string output = "";


            foreach (NetworkInterface networkInterface in NetworkInterface.GetAllNetworkInterfaces())
            {
                //If Wifi or Ethernet and is online
                if ((networkInterface.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 ||
                    networkInterface.NetworkInterfaceType == NetworkInterfaceType.Ethernet)
                    && networkInterface.OperationalStatus == OperationalStatus.Up)
                {

                    foreach (UnicastIPAddressInformation ip in networkInterface.GetIPProperties().UnicastAddresses)
                    {

                        if (ip.Address.AddressFamily == AddressFamily.InterNetwork)
                        {
                            output = ip.Address.ToString();

                            //Writes whether what kind of internet connection you have
                            System.Diagnostics.Debug.WriteLine("Internet type: " + networkInterface.NetworkInterfaceType.ToString());
                        }
                    }
                }
            }

            if (output == "")
            {
                output = "No connection found";
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
                    Data _data = receivedDataQueue.Dequeue(); // Queue -> chronologically 

                    SendDataToAllOtherClients(_data);
                }

            }
        }

        /// <summary>
        /// Continuesly searches for new clients, untill max amount has been reached, or it is told not to.
        /// </summary>
        private void FindNewClients()
        {
            while (LessThanMaxClients() && isOnline)
            {
                SearchAndAddClient();

                System.Diagnostics.Debug.WriteLine("Clients found: " + clientStructs.Count);

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

            ClientStruct _clientStruct = new ClientStruct(newClient);

            //add to collection
            _clientStruct.Team = (PlayerTeam)clientStructs.Count + 1;
            clientStructs.Add(_clientStruct);

            //Tells the client what team it's assigned to
            AssignNewClientToTeam(_clientStruct);

            // create a thread to handle communication
            Thread clientThread = new Thread(new ParameterizedThreadStart(ClientUpdate));
            clientThread.Start(_clientStruct);
        }

        /// <summary>
        /// Writes a team assignment message to the client
        /// </summary>
        /// <param name="_clientStruct">client to assign</param>
        private void AssignNewClientToTeam(ClientStruct _clientStruct)
        {
            StreamWriter sWriter = new StreamWriter(_clientStruct.client.GetStream(), Encoding.ASCII);

            //sends data
            sWriter.WriteLine(clientStructs.Count);

            //Clears buffer
            sWriter.Flush();


        }





        /// <summary>
        /// returns whether or not we have reached the maximum amount of clients
        /// </summary>
        /// <returns></returns>
        private bool LessThanMaxClients()
        {
            return clientStructs.Count < clientsMaxAmount;

        }

        public void ClientUpdate(object obj)
        {
            // retrieve client from parameter passed to thread
            ClientStruct _clientStruct = (ClientStruct)obj;

            // sets two streams
            StreamReader sReader = new StreamReader(_clientStruct.client.GetStream(), Encoding.ASCII);

            bool isConnected = true;
            string sData = null;

            IPEndPoint endPoint = (IPEndPoint)_clientStruct.client.Client.RemoteEndPoint;
            IPEndPoint localPoint = (IPEndPoint)_clientStruct.client.Client.LocalEndPoint;

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
                        clientStructs.Remove(_clientStruct);
                    }
                    Thread.CurrentThread.Abort();
                }

                //when data has arrived or client has disconnected
                if (sData != null)
                {
                    //evaluate the Data and the client who sent it
                    EvaluateData(sData, _clientStruct);
                }
            }
        }

        /// <summary>
        /// handles the received data and its client. 
        /// </summary>
        /// <param name="sData">the data received</param>
        /// <param name="client">the client who sent it</param>
        private void EvaluateData(string sData, ClientStruct client)
        {
            Data data = new Data(sData, client);

            lock (receivedDataKey)
            {
                receivedDataQueue.Enqueue(data);
            }

            //Applies data to own game - if it's not a message to the server (Ready, EndTurn ect)

            if (MessageDirectlyToServer(data) == false)
            {
                DataConverter.ApplyDataToself(data.information);
            }

        }
        private bool MessageDirectlyToServer(Data data)
        {

            if (data.information == "Ready;")
            {
                ReadyMessageHandler(data);
                return true;
            }

            return false;
        }

        private void ReadyMessageHandler(Data data)
        {
            //This client is ready

            foreach (ClientStruct _client in clientStructs)
            {
                if (_client.client == data.clientStruct.client)
                {
                    _client.SetReady();

                }
            }

            if (AllIsReady())
            {

                // TODO: StartGameButton.IsVisible = true; => StartGame();
            }
        }
        private bool AllIsReady()
        {
            int readyCount = 0;

            //Check if all clients are ready
            foreach (ClientStruct client in clientStructs)
            {
                if (client.ready)
                {
                    readyCount++;
                }
                else
                {
                    break;
                }
            }
            if (readyCount == clientStructs.Count && /*host*/ isReady)
            {
                System.Diagnostics.Debug.WriteLine("All is ready!");

                return true;
            }

            return false;
        }

        private void StartGame()
        {
            Random rnd = new Random();
            int mapNum = rnd.Next(1, 7 + 1);

            WriteServerMessage("Map;" + mapNum.ToString());






            // TODO: Start Game based on map, ClientStructs.Count
        }


        /// <summary>
        /// Sends data to all other clients but the one who sent it
        /// </summary>
        /// <param name="message"></param>
        private void SendDataToAllOtherClients(Data _data)
        {
            lock (clientsListKey)
            {
                for (int i = 0; i < clientStructs.Count; i++)
                {
                    if (clientStructs[i].client != _data.clientStruct.client) //if the client is not the sender of the data
                    {
                        //Writes to the specefic client
                        StreamWriter sWriter = new StreamWriter(clientStructs[i].client.GetStream(), Encoding.ASCII);


                        //sends data
                        sWriter.WriteLine(_data.information);

                        //Clears buffer
                        sWriter.Flush();

                    }

                }
                System.Diagnostics.Debug.WriteLine("Forwarded Client Message From " + _data.clientStruct.Team.ToString() + ": " + _data.information);
            }

        }
        public void WriteServerMessage(string message)
        {
            lock (clientsListKey)
            {
                for (int i = 0; i < clientStructs.Count; i++)
                {

                    //Writes to the specefic client
                    StreamWriter sWriter = new StreamWriter(clientStructs[i].client.GetStream(), Encoding.ASCII);


                    //sends data
                    sWriter.WriteLine(message);

                    //Clears buffer
                    sWriter.Flush();

                }
                System.Diagnostics.Debug.WriteLine("ServerMessage Sent: " + message);

            }
        }
        /// <summary>
        /// Turns off server
        /// </summary>
        public void ShutDownServer()
        {
            foreach (Thread thread in serverThreads)
            {
                thread.Abort();
            }

            instance = null;

            System.Diagnostics.Debug.WriteLine("Server has been shut down");
        }


    }
}


