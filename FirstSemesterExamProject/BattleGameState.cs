using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace FirstSemesterExamProject
{
    class BattleGameState : GameState
    {
        private GameBoard gameBoard;
        private int playerNumber;
        private static List<Player> players;
        private List<int> playersUnitCount;
        private static int playerTurn = 1;

        //online
        public static PlayerTeam yourTeamOnline;
        public static bool isAlive = true;
        public static bool gameOver = false;
        public static PlayerTeam winnerTeam;


        DateTime victoryNow;

        //for online ShowTeamTurn method
        public static string playerTurnString = "RedTeam";

        /// <summary>
        /// Property for players list
        /// </summary>
        public GameBoard GetGameBoard()
        { return gameBoard; }

        /// <summary>
        /// Property for players list
        /// </summary>
        public void SetGameBoard(GameBoard value)
        { gameBoard = value; }

        /// <summary>
        /// Property for players list
        /// </summary>
        public static List<Player> Players
        {
            get { return players; }
        }

        /// <summary>
        /// Property for playerturn
        /// </summary>
        public static int PlayerTurn
        {
            get { return playerTurn; }
            set { playerTurn = value; }
        }

        public BattleGameState(Window window, int playerNumber, Graphics graphics) : base(window)
        {
            this.playerNumber = playerNumber;
            players = new List<Player>();
            playersUnitCount = new List<int>();

            if (!Client.Instance.clientConnected)
            {
                gameBoard = new GameBoard(playerNumber);
            }

            CreatePlayers();

        }

        private void CreatePlayers()
        {
            if (Client.Instance.clientConnected)
            {
                players.Add(new Player((PlayerTeam)Client.Instance.Team, Window.playerAmount));
            }
            else
            {
                for (int i = 0; i < playerNumber; i++)
                {
                    players.Add(new Player((PlayerTeam)i, playerNumber));
                }
            }
        }
        /// <summary>
        /// Updates animation on each Unit in UnitMap.
        /// </summary>
        /// <param name="fps"></param>
        private void UpdateAnimation(float deltaTime)
        {
            if (GameBoard.UnitMap != null)
            {
                for (int X = 0; X < GameBoard.UnitMap.GetLength(0); X++)
                {
                    for (int Y = 0; Y < GameBoard.UnitMap.GetLength(1); Y++)
                    {
                        switch (GameBoard.UnitMap[X, Y])
                        {
                            case Unit unit:
                                unit.UpdateAnimation(deltaTime);
                                break;

                            default:
                                break;
                        }
                    }
                }
            }
            foreach (Player player in players)
            {
                player.UpdateAnimation(deltaTime);
            }
        }

        /// <summary>
        /// Renders The game
        /// </summary>
        /// <param name="graphics"></param>
        public override void Render(Graphics graphics)
        {
            gameBoard.BoardRender(graphics);
            //Userinterface til Unit stats
            graphics.DrawImage(Image.FromFile(Constant.statBackground), Constant.statBackgroundX, Constant.statBackgroundY);

            if (GameBoard.UnitMap != null)
            {
                for (int X = 0; X < GameBoard.UnitMap.GetLength(0); X++)
                {
                    for (int Y = 0; Y < GameBoard.UnitMap.GetLength(1); Y++)
                    {
                        if (GameBoard.UnitMap[X, Y] != null)
                        {
                            GameBoard.UnitMap[X, Y].ObjectRender(graphics);
                        }
                    }
                }
            }

            players[playerTurn - 1].ObjectRender(graphics);

            if (Window.OnlineGame() != true)//only if not online
            {
                if (playerNumber == 1)
                {
                    Victory(players[0].PlayerTeamColor, graphics);
                }
            }
            else
            {
                //Online
                //Clients are told by server who wins -> see DataConverter's case for "Winner"
                if (gameOver == true)
                {
                    if (Window.OnlineGame())
                    {
                        Victory(winnerTeam, graphics);
                    }

                }

            }
        }

        /// <summary>
        /// updates the game
        /// </summary>
        /// <param name="deltaTime"></param>
        public override void Tick(float deltaTime)
        {
            //Updates animations
            UpdateAnimation(deltaTime);
            //removes units
            gameBoard.RemoveObjects();
            //adds units
            gameBoard.AddObjects();
            if (!Window.OnlineGame())
            {
                //allows the player to move
                players[playerTurn - 1].Move();
            }
            else
            {
                foreach (Player pl in players)
                {

                    pl.Move();
                }
            }
            //allows a player to lose
            PlayerDies();
        }

        /// <summary>
        /// Changes player turn.
        /// </summary>
        public void ChangeTurn()
        {
            if (Window.OnlineGame())
            {
                OnlineChangeTurn();
            }
            else
            {
                //Fix for unitRevival Bug :)
                Players[PlayerTurn - 1].SelectedUnit = null;
                //changes to the next players turn
                playerTurn++;
                //makes sure that it is always a players turn and that the counter dosen't go off track
                if (playerTurn > playerNumber || playerTurn < 0)
                {
                    playerTurn = 1;
                }
                //resets the amount of moves a player have
                players[playerTurn - 1].PlayerMove = players[playerTurn - 1].PlayerMaxMove;
                //resets the moves of all units
                ResetUnitMoves();
            }
        }

        /// <summary>
        /// Handles Changing turns for online mode
        /// </summary>
        private void OnlineChangeTurn()
        {

            ServerChangeTurn();
            ClientChangeTurn();




        }

        private void ServerChangeTurn()
        {

            //if player is server
            if (Server.Instance.turn && Server.Instance.isOnline)
            {
                int nextPlayer = Server.Instance.NextAvailablePlayerNum(0);

                //Write the index of the next player
                Server.Instance.WriteServerMessage("EndTurn;" + nextPlayer);

                //for drawing teamturn
                DataConverter.ChangePlayerTurnText(nextPlayer);

                //Server cannot do any actions
                Server.Instance.turn = false;



                //resets the amount of moves a player have
                players[0].PlayerMove = players[0].PlayerMaxMove;
                //resets the moves of all units
                ResetUnitMoves();
            }
        }
        private void ClientChangeTurn()
        {
            //if client
            if (Client.Instance.turn)
            {
                //Index of the next player
                int thisPlayerNum = Client.Instance.PlayerNumber;
                                

                DataConverter.ChangePlayerTurnText(thisPlayerNum);

                //Writes the index of the next player
                Client.Instance.SendToHost("EndTurn;" + thisPlayerNum);

                //client cannot move
                Client.Instance.turn = false;

                //resets the amount of moves a player have
                players[0].PlayerMove = players[0].PlayerMaxMove;
                //resets the moves of all units
                ResetUnitMoves();
            }
        }

        /// <summary>
        /// Reset the max moves of all units
        /// </summary>
        public void ResetUnitMoves()
        {
            //goes through each unit and checks their type:
            for (int X = 0; X < GameBoard.UnitMap.GetLength(0); X++)
            {
                for (int Y = 0; Y < GameBoard.UnitMap.GetLength(1); Y++)
                {

                    switch (GameBoard.UnitMap[X, Y])
                    {
                        //Depending on the type it resets their moves
                        case Archer a:
                            ((Archer)GameBoard.UnitMap[X, Y]).Move = Constant.archerMove;
                            break;

                        case Knight k:
                            ((Knight)GameBoard.UnitMap[X, Y]).Move = Constant.knightMove;
                            break;

                        case Mage m:
                            ((Mage)GameBoard.UnitMap[X, Y]).Move = Constant.mageMove;
                            break;

                        case Cleric c:
                            ((Cleric)GameBoard.UnitMap[X, Y]).Move = Constant.clericMove;
                            break;

                        case Artifact A:
                            ((Artifact)GameBoard.UnitMap[X, Y]).Move = Constant.artifactMove;
                            break;

                        case Scout s:
                            ((Scout)GameBoard.UnitMap[X, Y]).Move = Constant.scoutMove;
                            ((Scout)GameBoard.UnitMap[X, Y]).CanAttack = true;
                            break;

                        default:
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// checks if a player has a gameover (no units) and removes the player if true
        /// </summary>
        public void PlayerDies()
        {
            if (GameBoard.UnitMap != null)
            {
                if (Window.OnlineGame())
                {
                    OnlinePlayerDie();
                }
                else
                {

                    foreach (Player pl in players)
                    {
                        playersUnitCount.Add(0);
                    }

                    for (int X = 0; X < GameBoard.UnitMap.GetLength(0); X++)
                    {
                        for (int Y = 0; Y < GameBoard.UnitMap.GetLength(1); Y++)
                        {
                            if (GameBoard.UnitMap[X, Y] != null)
                            {
                                switch (((Unit)GameBoard.UnitMap[X, Y]).Team)
                                {
                                    case PlayerTeam.RedTeam:
                                        foreach (Player player in players)
                                        {
                                            if (player.PlayerTeamColor == PlayerTeam.RedTeam)
                                            {
                                                playersUnitCount[players.IndexOf(player)]++;
                                            }
                                        }
                                        break;

                                    case PlayerTeam.BlueTeam:
                                        foreach (Player player in players)
                                        {
                                            if (player.PlayerTeamColor == PlayerTeam.BlueTeam)
                                            {
                                                playersUnitCount[players.IndexOf(player)]++;
                                            }
                                        }
                                        break;

                                    case PlayerTeam.GreenTeam:
                                        foreach (Player player in players)
                                        {
                                            if (player.PlayerTeamColor == PlayerTeam.GreenTeam)
                                            {
                                                playersUnitCount[players.IndexOf(player)]++;
                                            }
                                        }
                                        break;

                                    case PlayerTeam.YellowTeam:
                                        foreach (Player player in players)
                                        {
                                            if (player.PlayerTeamColor == PlayerTeam.YellowTeam)
                                            {
                                                playersUnitCount[players.IndexOf(player)]++;
                                            }
                                        }
                                        break;

                                    default:
                                        break;
                                }
                            }
                        }
                    }
                }



                for (int i = 0; i < playersUnitCount.Count; i++)
                {
                    if (playersUnitCount[i] == 0)
                    {
                        players.RemoveAt(i);
                        playerNumber--;
                        if (playerTurn > playerNumber)
                        {
                            playerTurn = playerNumber;
                        }
                    }
                }
                if (playerTurn <= 0)
                {
                    playerTurn = 1;
                }


                playersUnitCount.Clear();
            }
        }


        private void OnlinePlayerDie()
        {

            int yourUnitsCount = 0;


            for (int X = 0; X < GameBoard.UnitMap.GetLength(0); X++)
            {
                for (int Y = 0; Y < GameBoard.UnitMap.GetLength(1); Y++)
                {
                    if (GameBoard.UnitMap[X, Y] != null)
                    {
                        if ((((Unit)GameBoard.UnitMap[X, Y]).Team) == yourTeamOnline)
                        {
                            yourUnitsCount++;
                        }
                    }
                }
            }

            if (yourUnitsCount == 0 && isAlive)
            {

                isAlive = false;
                if (Client.Instance.clientConnected)
                {
                    Client.Instance.SendToHost("PlayerDead;" + Client.Instance.PlayerNumber);
                }

                else if (Server.Instance.isOnline)
                {
                    Server.Instance.CheckIfGameOver();
                }

            }

        }



        /// <summary>
        /// Handles what happens when a victory has happened
        /// </summary>
        public void Victory(PlayerTeam victoryTeam, Graphics graphics)
        {
            if (victoryNow == DateTime.MinValue) // if first running victory code
            {
                for (int X = 0; X < GameBoard.UnitMap.GetLength(0); X++)
                {
                    for (int Y = 0; Y < GameBoard.UnitMap.GetLength(1); Y++)
                    {
                        if (GameBoard.UnitMap[X, Y] is Unit unit)
                        {
                            unit.AnimationSpeed = 1;//Adds a slowmotion effect
                        }
                    }
                }
                //Tells highscoreConnection which team composition won
                try
                {
                    Server.Instance.WriteWinnerTeamCompositionToDatabase(winnerTeam);

                }
                catch (Exception e)
                {

                    Console.WriteLine(e.ToString());
                }
            }
            //draws the victory image depending on the team that won.
            switch (victoryTeam)
            {
                case PlayerTeam.RedTeam:
                    graphics.DrawImage(Image.FromFile(Constant.victoryRed), Constant.victoryX, Constant.victoryY);
                    break;
                case PlayerTeam.BlueTeam:
                    graphics.DrawImage(Image.FromFile(Constant.victoryBlue), Constant.victoryX, Constant.victoryY);
                    break;
                case PlayerTeam.GreenTeam:
                    graphics.DrawImage(Image.FromFile(Constant.victoryGreen), Constant.victoryX, Constant.victoryY);
                    break;
                case PlayerTeam.YellowTeam:
                    graphics.DrawImage(Image.FromFile(Constant.victoryYellow), Constant.victoryX, Constant.victoryY);
                    break;
                default:
                    break;
            }
            //takes time of the moment of victory
            if (victoryNow == DateTime.MinValue)
            {
                victoryNow = DateTime.Now;
            }
            System.Diagnostics.Debug.WriteLine(victoryNow);
            System.Diagnostics.Debug.WriteLine(DateTime.Now);

            //restarts the game after the victory wait time has elapsed.
            if (DateTime.Now > victoryNow.AddSeconds(Constant.victoryWait))
            {
                Application.Restart();
            }
        }

    }
}

