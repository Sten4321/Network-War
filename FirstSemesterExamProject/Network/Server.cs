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
        public int port = 13001;
        public bool isOnline = false;
        private readonly byte clientsMaxAmount = 3;
        private static TcpListener tcpListener;

        //Collections
        public List<ClientObject> clientObjects = new List<ClientObject>(); //Client Structs contain the clients TcpClient and Team (could add ip ect.)
        private Queue<Data> receivedDataQueue = new Queue<Data>(); // Datas contains messages and the clients who sent them 
        public string teamComposition = string.Empty;

        //Threading
        private readonly object clientsListKey = new object(); //Two keys for threads to make sure only one can get in at a time
        private readonly object receivedDataKey = new object();
        List<Thread> serverThreads = new List<Thread>();



        //Singleton Instance 
        private static Server instance;

        //Host info
        public PlayerTeam serverTeam = PlayerTeam.RedTeam;
        public bool isReady = false;
        public bool turn = true;
        public byte mapNum;

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
        /// Server remembers initial team compositions
        /// </summary>
        /// <param name="data"></param>
        private void AddUnitStringToClient(Data data)
        {
            //UnitStack;Team,unit,unit,unit
            string[] splitUnitStackString = data.information.Split(';');

            //Team,unit,unit,unit
            splitUnitStackString = splitUnitStackString[1].Split(',');

            foreach (ClientObject client in clientObjects)
            {
                //if it's the sender of the unitStack message
                if (client == data.clientReference)
                {
                    string teamComposition = "";

                    //starts at 1, because we already know its team
                    for (int i = 1; i < splitUnitStackString.Length; i++)
                    {
                        //for all units except the last one
                        if (i < splitUnitStackString.Length - 1)
                        {
                            //unit,
                            teamComposition += splitUnitStackString[i] + ",";

                        }
                        else //if it's the last one, don't write ','
                        {
                            //unit
                            teamComposition += splitUnitStackString[i];

                        }
                    }

                    //the team composition of this client (and its team)
                    client.unitTeamComposition = teamComposition;



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

                System.Diagnostics.Debug.WriteLine("Clients found: " + clientObjects.Count);

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
            ClientObject _clientObject = new ClientObject(newClient);

            //add to collection
            _clientObject.Team = (PlayerTeam)clientObjects.Count + 1;
            clientObjects.Add(_clientObject);

            //Tells the client what team it's assigned to
            AssignNewClientToTeam(_clientObject);

            // If there are already existing teams, tell the new client
            SendExistingTeamsToLateClient(_clientObject);

            // create a thread to handle communication
            Thread clientThread = new Thread(new ParameterizedThreadStart(ClientUpdate));
            clientThread.Start(_clientObject);
        }

        /// <summary>
        /// Writes a team assignment message to the client
        /// </summary>
        /// <param name="_clientStruct">client to assign</param>
        private void AssignNewClientToTeam(ClientObject _clientStruct)
        {
            StreamWriter sWriter = new StreamWriter(_clientStruct.tcpClient.GetStream(), Encoding.ASCII);

            //sends data
            sWriter.WriteLine(clientObjects.Count);

            //Clears buffer
            sWriter.Flush();

            //for updating the clients lobbies
            WriteServerMessage("NewPlayer;" + clientObjects.Count);

            DataConverter.UpdateLobbyList(clientObjects.Count);

        }





        /// <summary>
        /// returns whether or not we have reached the maximum amount of clients
        /// </summary>
        /// <returns></returns>
        private bool LessThanMaxClients()
        {
            return clientObjects.Count < clientsMaxAmount;

        }

        public void ClientUpdate(object obj)
        {
            // retrieve client from parameter passed to thread
            ClientObject _clientObject = (ClientObject)obj;

            // sets two streams
            StreamReader sReader = new StreamReader(_clientObject.tcpClient.GetStream(), Encoding.ASCII);

            bool isConnected = true;
            string sData = null;

            IPEndPoint endPoint = (IPEndPoint)_clientObject.tcpClient.Client.RemoteEndPoint;
            IPEndPoint localPoint = (IPEndPoint)_clientObject.tcpClient.Client.LocalEndPoint;

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
                    int clientNum = (int)_clientObject.Team;

                    lock (clientsListKey)
                    {
                        _clientObject.tcpClient = null;

                        if (Window.GameState is UnitChoiceGameState)
                        {
                            clientObjects.Remove(_clientObject);
                        }

                        if (Window.GameState is BattleGameState)
                        {

                            //If it's the disconnected client's turn
                            if (_clientObject.clientsTurn)
                            {
                                int nextPlayerInt = NextAvailablePlayerNum(clientNum);
                                //change turn 
                                WriteServerMessage("EndTurn;" + nextPlayerInt);

                                DataConverter.ChangePlayerTurnText(nextPlayerInt);

                                if (Server.Instance.isOnline && nextPlayerInt == 0)
                                {
                                    if (BattleGameState.isAlive)
                                    {
                                        if (Window.GameState is BattleGameState bs)
                                        {
                                            bs.ResetUnitMoves();
                                        }

                                        Server.Instance.turn = true;
                                        System.Diagnostics.Debug.WriteLine("It's your turn!");
                                    }

                                }
                            }
                            //removes all his units                          

                            _clientObject.isAlive = false;

                            RemoveAllUnitsFromClient(_clientObject.Team);

                        }
                        else
                        {
                            WriteServerMessage("PlayerLeft;" + clientNum + "," + clientObjects.Count);

                            foreach (ClientObject client in clientObjects)
                            {
                                if ((int)client.Team > clientNum)
                                {//if client is on a higher team, than the one who quit, they all go one team down

                                    //yellow -> green -> blue
                                    //if green leaves, and there are 4 players, yellow becomes green
                                    client.Team = (PlayerTeam)(int)client.Team - 1;
                                }
                            }

                            DataConverter.UpdateLobbyList(clientObjects.Count);
                            Window.lobbyChangeHasHappened = true;

                        }



                    }
                    Thread.CurrentThread.Abort();
                }

                //when data has arrived or client has disconnected
                if (sData != null)
                {
                    //evaluate the Data and the client who sent it
                    EvaluateData(sData, _clientObject);
                }
            }
        }

        private void RemoveAllUnitsFromClient(PlayerTeam? team)
        {

            for (int X = 0; X < GameBoard.UnitMap.GetLength(0); X++)
            {
                for (int Y = 0; Y < GameBoard.UnitMap.GetLength(1); Y++)
                {
                    if (GameBoard.UnitMap[X, Y] is Unit unit && unit.Team == team)
                    {
                        GameBoard.RemoveObject[X, Y] = unit;
                    }
                }
            }

            CheckIfGameOver();
            WriteServerMessage("RemoveAll;" + team.ToString());
        }

        /// <summary>
        /// handles the received data and its client. 
        /// </summary>
        /// <param name="sData">the data received</param>
        /// <param name="client">the client who sent it</param>
        private void EvaluateData(string sData, ClientObject client)
        {
            Data data = new Data(sData, client);

            lock (receivedDataKey)
            {
                //If the data is not something only the server should know                
                if (MessageDirectlyToServer(data) == false)
                {
                    //The data is ready to be distributed to all other clients
                    receivedDataQueue.Enqueue(data);

                    //Applies data to own game 
                    DataConverter.ApplyDataToself(data.information);
                }
            }           

        }
        private bool MessageDirectlyToServer(Data data)
        {

            if (data.information.Contains("Ready;"))
            {
                ReadyMessageHandler(data);

            }
            if (data.information.Contains("PlayerDead;"))
            {
                DeathMessageHandler(data);
                return true;
            }
            if (data.information.Contains("UnitStack;"))
            {
                if (Server.Instance.isOnline)
                {
                    Server.Instance.AddUnitStringToClient(data);
                }
            }
            if (data.information.Contains("EndTurn;"))
            {

                ManageTurnChange(data);
                return true;

            }

            return false;
        }

        /// <summary>
        /// When a client dies, it sends a death message
        /// </summary>
        /// <param name="data"></param>
        private void DeathMessageHandler(Data data)
        {

            //PlayerDead;[PLAYER NUM]
            string playerNum = data.information.Split(';')[1]; // TODO: use for telling clients who's dead? if needed...

            //Finds the sender of the message
            foreach (ClientObject client in clientObjects)
            {
                if (data.clientReference == client)
                {
                    //he won't be walking for a long time >:~)
                    client.isAlive = false;
                }
            }

            //checks if there's only one player left
            CheckIfGameOver();
        }

        public void CheckIfGameOver()
        {

            //How many is alive?
            byte playersAlive = 0;
            if (BattleGameState.isAlive)
            {
                playersAlive++;
            }
            foreach (ClientObject client in clientObjects)
            {
                if (client.isAlive)
                {
                    playersAlive++;
                }
            }

            //if there's only one player left, the game is over
            if (playersAlive == 1)
            {

                PlayerTeam? winner = null;

                if (BattleGameState.isAlive)
                {
                    //host won
                    winner = PlayerTeam.RedTeam;

                }

                foreach (ClientObject client in clientObjects)
                {
                    if (client.isAlive)
                    {
                        //this client one
                        winner = client.Team;
                    }
                }

                AnnounceWinner(winner);

            }
        }

        /// <summary>
        /// Sends the winning team to clients and starts the end screen for host
        /// </summary>
        /// <param name="team"></param>
        private void AnnounceWinner(PlayerTeam? team)
        {
            if (team != null)
            {
                //Tells all clients Team name of the winner

                WriteServerMessage("Winner;" + team.ToString());


                //Clients does the same thing when receiving this message  through the data converter
                BattleGameState.winnerTeam = (PlayerTeam)team;
                BattleGameState.gameOver = true;
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Error in announcing winner");
            }

        }

        private void ReadyMessageHandler(Data data)
        {
            //This client is ready
            Enum.TryParse(data.information.Split(';')[1], out PlayerTeam _rdyTeam);
            DataConverter.UpdateLobbyListSetTeamReady(_rdyTeam);

            foreach (ClientObject _client in clientObjects)
            {
                if (_client.tcpClient == data.clientReference.tcpClient)
                {
                    _client.SetReady();
                    System.Diagnostics.Debug.WriteLine(_client.Team + " is ready!");
                }
            }
            CheckIfCanStart();

        }

        private bool AllIsReady()
        {
            int readyCount = 0;

            //Check if all clients are ready
            foreach (ClientObject client in clientObjects)
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
            if (readyCount == clientObjects.Count && /*host*/ isReady && readyCount > 1)
            {
                System.Diagnostics.Debug.WriteLine("All players are ready!");

                return true;
            }

            return false;
        }

        public void CheckIfCanStart()
        {
            if (AllIsReady())
            {
                Window.allPlayersReady = true;

            }
        }

        /// <summary>
        /// Tells all client what map to choose, and how many players there are going to be
        /// </summary>
        /// <param name="mapNum"></param>
        public void SendMapInfo(int mapNum)
        {
            WriteServerMessage("Map;" + mapNum + "," + (clientObjects.Count + 1)); //+1 for self

        }

        /// <summary>
        /// Tells clients to start their games
        /// </summary>
        public void StartGame()
        {
            BattleGameState.yourTeamOnline = PlayerTeam.RedTeam;

            WriteServerMessage("Start;");

        }


        /// <summary>
        /// Sends data to all other clients but the one who sent it
        /// </summary>
        /// <param name="message"></param>
        private void SendDataToAllOtherClients(Data _data)
        {
            lock (clientsListKey)
            {
                for (int i = 0; i < clientObjects.Count; i++)
                {
                    if (clientObjects[i].tcpClient != _data.clientReference.tcpClient) //if the client is not the sender of the data
                    {
                        if (clientObjects[i].tcpClient != null)
                        {

                            //Writes to the specefic client
                            StreamWriter sWriter = new StreamWriter(clientObjects[i].tcpClient.GetStream(), Encoding.ASCII);


                            //sends data
                            sWriter.WriteLine(_data.information);

                            //Clears buffer
                            sWriter.Flush();

                        }
                    }

                }
                System.Diagnostics.Debug.WriteLine("Forwarded Client Message From " +
                    _data.clientReference.Team.ToString() + ": " + _data.information);
            }

        }

        public void WriteServerMessage(string message)
        {
            lock (clientsListKey)
            {
                for (int i = 0; i < clientObjects.Count; i++)
                {
                    if (clientObjects[i].tcpClient != null && clientObjects[i].tcpClient.Connected)
                    {

                        //Writes to the specefic client
                        StreamWriter sWriter = new StreamWriter(clientObjects[i].tcpClient.GetStream(), Encoding.ASCII);


                        //sends data
                        sWriter.WriteLine(message);

                        //Clears buffer
                        sWriter.Flush();

                    }
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

        public void SaveTeamComposition(string message)
        {
            // see AddUnitStringToClient for an explenation of what's going on below :)

            string[] splitUnitStackString = message.Split(';');

            splitUnitStackString = splitUnitStackString[1].Split(',');

            string tmp = "";

            for (int i = 1; i < splitUnitStackString.Length; i++)
            {
                if (i < splitUnitStackString.Length - 1)
                {
                    tmp += splitUnitStackString[i] + ",";

                }
                else
                {
                    tmp += splitUnitStackString[i];

                }


            }
            teamComposition = tmp;
        }

        public void WriteWinnerTeamCompositionToDatabase(PlayerTeam team)
        {

            string message = "Morten McFart was here! Test!";

            if (team == PlayerTeam.RedTeam)
            {
                //Team comp = server's comp - server won.
                message = teamComposition;
            }
            else
            {
                foreach (ClientObject client in clientObjects)
                {
                    if (team == client.Team)
                    {
                        message = client.unitTeamComposition;
                        break;
                    }
                }

            }

            HighscoreConnection._Instance.SetAllEventData(message);

        }

        public void ManageTurnChange(Data data)
        {


            int playerTurn = Convert.ToInt32(data.information.Split(';')[1]);

            clientObjects[playerTurn - 1].clientsTurn = false;

            playerTurn = NextAvailablePlayerNum(playerTurn);


            if (Server.Instance.isOnline && playerTurn == 0)
            {
                if (BattleGameState.isAlive)
                {
                    if (Window.GameState is BattleGameState bs)
                    {
                        bs.ResetUnitMoves();
                    }

                    Server.Instance.turn = true;
                    System.Diagnostics.Debug.WriteLine("It's your turn!");
                    Server.Instance.WriteServerMessage("EndTurn;" + 0);
                    //    DataConverter.ChangePlayerTurnText(0);
                }
                else
                {
                    Server.Instance.WriteServerMessage("EndTurn;" + NextAvailablePlayerNum(0));
                    DataConverter.ChangePlayerTurnText(playerTurn);

                    return;
                }
            }
            Server.Instance.WriteServerMessage("EndTurn;" + playerTurn);


            Player.playerMove = Player.playerMaxMove;


            DataConverter.ChangePlayerTurnText(playerTurn);

        }

        public int NextAvailablePlayerNum(int currentNum)
        {

            //next player's id
            int nextPlayerNum = currentNum + 1;

            //If it exceeds the amount of players
            if (nextPlayerNum > clientObjects.Count + 1)
            {
                nextPlayerNum = 0;
            }

            //team enum based on the nextplayer id
            PlayerTeam _nextTeam = (PlayerTeam)nextPlayerNum;

            //Exit's when a new team is found            
            while (true)
            {
                if (_nextTeam == PlayerTeam.RedTeam)
                {
                    //is next team host?
                    if (BattleGameState.isAlive)
                    {
                        return (int)PlayerTeam.RedTeam;

                    }

                }
                else
                {
                    //is it a client?
                    foreach (ClientObject client in clientObjects)
                    {

                        if (client.Team == _nextTeam)
                        {
                            if (client.isAlive)
                            {
                                client.clientsTurn = true;
                                //it's this client
                                return (int)client.Team;
                            }
                        }

                    }
                }

                //if that team isn't alive, let's try the next team
                nextPlayerNum++;
                if (nextPlayerNum > clientObjects.Count + 1)
                {
                    //resets if the number exceeds 
                    nextPlayerNum = 0;
                }
                _nextTeam = (PlayerTeam)nextPlayerNum;

            }

        }
        private void SendExistingTeamsToLateClient(ClientObject client)
        {
            StreamWriter sWriter = new StreamWriter(client.tcpClient.GetStream(), Encoding.ASCII);

            if (teamComposition != string.Empty)
            {

                //sends data
                sWriter.WriteLine("UnitStack;" + PlayerTeam.RedTeam.ToString() + "," + teamComposition);

                //Clears buffer
                sWriter.Flush();
            }


            foreach (ClientObject _client in clientObjects)
            {
                if (_client.unitTeamComposition != string.Empty)
                {

                    //sends data
                    sWriter.WriteLine("UnitStack;" + _client.Team.ToString() + "," + _client.unitTeamComposition);

                    //Clears buffer
                    sWriter.Flush();
                }

                if (_client.ready)
                {
                    //sends data
                    sWriter.WriteLine("Ready;" + _client.Team.ToString());

                    //Clears buffer
                    sWriter.Flush();
                }
            }
        }
    }
}


