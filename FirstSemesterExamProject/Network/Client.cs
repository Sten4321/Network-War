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
        Window windowRef;
        private static Client instance;
        TcpClient client;
        public static readonly object key = new object();
        int sleepDelay = 17;
        public int port = 13000;//The port to connect to
        StreamWriter sWriter;
        StreamReader sReader;
        private bool validIp = false;
        private IPAddress iP;
        public int PlayerNumber { get; set; }
        public PlayerTeam? Team { get; set; } //Nullable enum (if it's not assigned, returns null)
        public bool turn = false;//is it this clients turn

        public bool clientConnected = false;

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

        public int Port
        {
            get { return port; }
            set { port = value; }
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

        public void SetWindowRefrence(Window window) { windowRef = window; }

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
                windowRef.UpdateIpLabelText(); //UpdateIpLabelText();
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
            clientConnected = true;
            while (clientConnected)
            {
                if (Team != null) //Starts when it has been assigned to a team
                {
                    sData = ReceiveFromHost();
                    UseServerData(sData);

                    System.Diagnostics.Debug.WriteLine(sData);

                    Thread.Sleep(sleepDelay);
                }
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
            PlayerNumber = Convert.ToInt32(ReceiveFromHost());
            Team = (PlayerTeam)Convert.ToInt32(PlayerNumber);
            //Then host will be Red, 1st: Blue, 2nd: Green, 3rd: Yellow

            System.Diagnostics.Debug.WriteLine(Team.ToString());
        }

        /// <summary>
        /// Write to Host
        /// </summary>
        /// <param name="message"></param>
        public void SendToHost(string message)
        {
            sWriter.WriteLine(message);
            sWriter.Flush();

            System.Diagnostics.Debug.WriteLine("Message written to host: " + message);
        }

        /// <summary>
        /// Read from stream
        /// </summary>
        /// <returns></returns>
        private string ReceiveFromHost()
        {
            string sData;
            sData = sReader.ReadLine();
            System.Diagnostics.Debug.WriteLine("Message received from host: " + sData);

            return sData;


        }

        /// <summary>
        /// Method that handles the recieved Data
        /// </summary>
        /// <param name="Data"></param>
        private void UseServerData(string sData)
        {
            DataConverter.ApplyDataToself(sData);
        }

        /// <summary>
        /// Sets the clients map to be equal to the recived map number
        /// </summary>
        /// <param name="sData"></param>
        private void SetMap(string sData)
        {
            // TODO: sData to a GameBord...
            GameBoard gameBoard = new GameBoard(int.Parse(sData), int.Parse(sData));

            if (Window.GameState is BattleGameState)
            {
                ((BattleGameState)Window.GameState).SetGameBoard(gameBoard);
            }
        }

        /// <summary>
        /// Translates a move for the player
        /// </summary>
        /// <param name="sData"></param>
        private void MoveUnit(string sData)
        {
            //TODO: Insert Code/Hook for moving unit
        }

        /// <summary>
        /// Starts the game for the clients
        /// </summary>
        public void Start(string playerAmountString)
        {
            int amount = Convert.ToInt32(playerAmountString);

            //Starts the game
            Window.GameState = new BattleGameState(windowRef, amount, windowRef.Dc);
            SoundEngine.StopSound();
            SoundEngine.PlaySound(Constant.menuButtonSound);
            SoundEngine.PlayBackgroundMusic();
        }
    }
}