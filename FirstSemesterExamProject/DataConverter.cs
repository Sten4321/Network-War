using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace FirstSemesterExamProject
{
    /// <summary>
    /// A class with the tools to translate data and apply it to the game
    /// </summary>
    public static class DataConverter
    {


        /// <summary>
        /// Applies data information to the clients / servers gameInstance
        /// </summary>
        /// <param name="dataInformation">data.Information</param>
        public static void ApplyDataToself(string dataInformation)
        {
            if (dataInformation.Contains(';'))
            {
                string[] splitStrings = dataInformation.Split(';');

                // "Move", "Map", "EndTurn" ect.
                string command = string.Empty;

                // "x1,y1,x2,y2"... "yellow,archer,knight,mage" ect
                string information = string.Empty;

                //fx "Move"
                command = splitStrings[0];

                //fx "0,1,3,3"  -coordinates
                information = splitStrings[1];

                System.Diagnostics.Debug.WriteLine(command + ": " + information);

                //fx "0","1","3","3" - coordinates split into individual strings and put into array
                splitStrings = information.Split(',');

                switch (command)
                {
                    //For adding other player's teams to your own game
                    case "UnitStack":
                        AddUnitsToTeamStack(splitStrings);

                        break;

                    //For determining what map clients are going to pick - also how many players
                    case "Map":
                        SetMap(splitStrings);
                        break;

                    //For moving Units based on the coordinates received
                    case "Move":
                        MoveUnit(splitStrings);
                        break;

                    //Tells clients they should start their game
                    case "Start":
                        Client.Instance.Start();
                        break;

                    //A message sent from the server, calculating who the next player to move will be
                    case "EndTurn":
                        ChangePlayerTurn(Convert.ToInt32(information));
                        break;

                    case "Winner": //Winner;RedTeam
                        PlayTeamVictoryScreen(information);
                        break;
                    case "RemoveAll": //"RemoveAll;RedTeam"
                        Enum.TryParse(information, out PlayerTeam _team);
                        Client.Instance.RemoveAllFromTeam(_team);
                        break;

                    case "Ready":
                        Enum.TryParse(information, out PlayerTeam rdyTeam);
                        UpdateLobbyListSetTeamReady(rdyTeam);
                        break;

                    case "NewPlayer":
                        UpdateLobbyList(Convert.ToInt32(information));
                        break;

                    case "PlayerLeft":
                        PlayerLeftHandler(Convert.ToInt32(splitStrings[0]),Convert.ToInt32(splitStrings[1]));
                        break;

                    default:
                        System.Diagnostics.Debug.WriteLine("Invalid Command!");
                        break;
                }
            }
        }

        private static void PlayerLeftHandler(int playerWhoLeft, int newAmount)
        {
            if (Client.Instance.clientConnected)
            {
                if (Window.GameState is UnitChoiceGameState) //if it's in the lobby (shouldn't change teams during game :))
                {
                    if (Client.Instance.PlayerNumber > playerWhoLeft)
                    {
                        Client.Instance.Team = (PlayerTeam)(int)Client.Instance.Team - 1;

                        DataConverter.UpdateLobbyList(newAmount);
                        Window.lobbyChangeHasHappened = true;
                    }
                }
            }
        }

        private static void PlayTeamVictoryScreen(string information)
        {
            Enum.TryParse(information, out PlayerTeam _team);

            if (Window.GameState is BattleGameState)
            {
                BattleGameState.winnerTeam = _team;
                BattleGameState.gameOver = true;
            }
        }

        /// <summary>
        /// Tells the local client / server if it's their turn
        /// </summary>
        /// <param name="information"></param>
        private static void ChangePlayerTurn(int? _playerTurn)
        {
            if (_playerTurn != null)
            {
                if (Client.Instance.clientConnected && _playerTurn == Client.Instance.PlayerNumber)
                {
                    if (BattleGameState.isAlive)
                    {
                        if (Window.GameState is BattleGameState bs)
                        {
                            bs.ResetUnitMoves();
                        }
                        Client.Instance.turn = true;
                        System.Diagnostics.Debug.WriteLine("It's your turn!");

                    }
                    else
                    {
                        Client.Instance.SendToHost("EndTurn;" + _playerTurn);
                    }
                }
            }
            //Resets player's moves
            Player.playerMove = Player.playerMaxMove;
            //Changes the text displaying whose turn it is
            ChangePlayerTurnText(_playerTurn);

        }

        /// <summary>
        /// Adds units to the stacks
        /// </summary>
        /// <param name="team"></param>
        /// <param name="unitStrings"></param>
        public static void AddUnitsToTeamStack(string[] unitStrings)
        {


            Stack<Enum> tmpStack = new Stack<Enum>();

            // i = 1 because the first string is Team colour
            for (int i = 1; i < unitStrings.Length; i++)
            {
                Enum.TryParse(unitStrings[i], out Units unit); //tries to convert string to enum ("Knight" => Units.Knight)

                tmpStack.Push(unit);
            }

            // tmpStack = ReverseStack(tmpStack);

            //applies local stack to the designated team's stack
            Enum.TryParse(unitStrings[0], out PlayerTeam _team); //Converts first information to a team (YELLOW,archer,knight,mage)                                                

            switch (_team)
            {

                case PlayerTeam.RedTeam:
                    Window.RedTeamStack = tmpStack;
                    break;

                case PlayerTeam.BlueTeam:
                    Window.BlueTeamStack = tmpStack;
                    break;

                case PlayerTeam.GreenTeam:
                    Window.GreenTeamStack = tmpStack;
                    break;

                case PlayerTeam.YellowTeam:
                    Window.YellowTeamStack = tmpStack;
                    break;

                default:
                    System.Diagnostics.Debug.WriteLine("DataConverter could not add units to stack.. AddUnitsToTeamStack() ");
                    break;
            }

            System.Diagnostics.Debug.WriteLine(_team.ToString() + " Amount of Units:" + tmpStack.Count);

        }

        /// <summary>
        /// Sets the clients map to be equal to the recived map number
        /// </summary>
        /// <param name="sData"></param>
        public static void SetMap(string[] sData)
        {
            //Total player amount
            Window.playerAmount = Convert.ToInt32(sData[1]);

            //makes a new gameboard, based on map type sData[0]
            GameBoard gameBoard = new GameBoard(int.Parse(sData[0]), 1);

            //Enters new game
            Client.Instance.SetBattleGameState();

            if (Window.GameState is BattleGameState)
            {
                ((BattleGameState)Window.GameState).SetGameBoard(gameBoard);
            }
        }

        /// <summary>
        /// Moves a unit
        /// </summary>
        /// <param name="sData"></param>
        public static void MoveUnit(string[] sData)
        {
            //From
            int x = Int32.Parse(sData[0]);
            int y = Int32.Parse(sData[1]);

            //To
            int dx = Int32.Parse(sData[2]);
            int dy = Int32.Parse(sData[3]);
         
            if (Window.GameState is BattleGameState)
            {
                if (BattleGameState.Players.Count != 0)
                {
                    BattleGameState.Players[0].Select(x, y, dx, dy);
                }
            }
        }


        public static Stack<Enum> ReverseStack(Stack<Enum> stack)
        {
            //Declare another stack to store the values from the passed stack
            Stack<Enum> reversedStack = new Stack<Enum>();

            //While the passed stack isn't empty, pop elements from the passed stack onto the temp stack
            while (stack.Count != 0)
                reversedStack.Push(stack.Pop());

            return reversedStack;
        }

        /// <summary>
        /// Changes the text and color of whose turn it is in multiplayer mode
        /// </summary>
        /// <param name="playerTurnIndex"></param>
        public static void ChangePlayerTurnText(int? playerTurnIndex)
        {
            if (playerTurnIndex == null)
            {
                return;
            }
            //for drawing teamturn
            PlayerTeam team = (PlayerTeam)playerTurnIndex;
            BattleGameState.playerTurnString = team.ToString();

            switch (team)
            {
                case PlayerTeam.RedTeam:
                    Player.OnlineTeambrushColor = new SolidBrush(Color.FromArgb(180, 0, 0));
                    break;
                case PlayerTeam.BlueTeam:
                    Player.OnlineTeambrushColor = Brushes.Blue;

                    break;
                case PlayerTeam.GreenTeam:
                    Player.OnlineTeambrushColor = Brushes.LawnGreen;

                    break;
                case PlayerTeam.YellowTeam:
                    Player.OnlineTeambrushColor = Brushes.Yellow;

                    break;


                default:
                    Player.OnlineTeambrushColor = Brushes.Black;
                    System.Diagnostics.Debug.WriteLine("Error in ChangePlayerTurn");
                    break;

            }
        }

        public static void UpdateLobbyList(int playerIndex)
        {
            PlayerTeam team = (PlayerTeam)playerIndex;


            switch (team)
            {
                case PlayerTeam.RedTeam:
                    Window.blueTeamInLobby = false;
                    Window.greenTeamInLobby = false;
                    Window.yellowTeamInLobby = false;
                    break;
                case PlayerTeam.BlueTeam:
                    Window.blueTeamInLobby = true;
                    Window.greenTeamInLobby = false;
                    Window.yellowTeamInLobby = false;

                    break;
                case PlayerTeam.GreenTeam:
                    Window.blueTeamInLobby = true;
                    Window.greenTeamInLobby = true;
                    Window.yellowTeamInLobby = false;

                    break;
                case PlayerTeam.YellowTeam:
                    Window.blueTeamInLobby = true;
                    Window.greenTeamInLobby = true;
                    Window.yellowTeamInLobby = true;
                    break;

                default:
                    System.Diagnostics.Debug.WriteLine("Error ");

                    break;
            }
            Window.lobbyChangeHasHappened = true;
        }

        public static void UpdateLobbyListSetTeamReady(PlayerTeam team)
        {

            switch (team)
            {
                case PlayerTeam.RedTeam:
                    Window.redTeamReady = true;
                    break;
                case PlayerTeam.BlueTeam:
                    Window.blueTeamReady = true;

                    break;
                case PlayerTeam.GreenTeam:
                    Window.greenTeamReady = true;

                    break;
                case PlayerTeam.YellowTeam:
                    Window.yelloTeamReady = true;
                    break;

                default:
                    System.Diagnostics.Debug.WriteLine("Error");

                    break;
            }
            Window.lobbyChangeHasHappened = true;
        }

        
    }


}

