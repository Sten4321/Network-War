﻿using System;
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

                string command = string.Empty;// Move, Map, EndTurn ect.
                string information = string.Empty;// x1,y1,x2,y2... yellow,archer,knight,mage ect


                command = splitStrings[0];

                information = splitStrings[1];

                System.Diagnostics.Debug.WriteLine(command + ": " + information);

                splitStrings = information.Split(',');

                switch (command)
                {

                    case "UnitStack":
                        AddUnitsToTeamStack(splitStrings);
                        break;

                    case "Map":
                        SetMap(splitStrings);
                        break;

                    case "Move":
                        MoveUnit(splitStrings);
                        break;

                    case "Start":
                        Client.Instance.Start();
                        break;

                    case "EndTurn":
                        ChangePlayerTurn(information);
                        break;


                    default:
                        System.Diagnostics.Debug.WriteLine("Invalid Command!");
                        break;
                }
            }
        }

        /// <summary>
        /// Tells the local client / server if it's their turn
        /// </summary>
        /// <param name="information"></param>
        private static void ChangePlayerTurn(string information)
        {
            int playerTurn = Convert.ToInt32(information);// 1,2,3,4

            Player.playerMove = Player.playerMaxMove;

           

            if (Server.Instance.isOnline && playerTurn == 0)
            {
                Server.Instance.turn = true;
                System.Diagnostics.Debug.WriteLine("It's your turn!");

            }
            else if (Client.Instance.clientConnected && playerTurn == Client.Instance.PlayerNumber)
            {
                Client.Instance.turn = true;
                System.Diagnostics.Debug.WriteLine("It's your turn!");
            }

            ChangePlayerTurnText(playerTurn);
           
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
            Window.playerAmount = Convert.ToInt32(sData[1]);

            GameBoard gameBoard = new GameBoard(int.Parse(sData[0]), 1);

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
            int x = Int32.Parse(sData[0]);
            int y = Int32.Parse(sData[1]);
            int dx = Int32.Parse(sData[2]);
            int dy = Int32.Parse(sData[3]);
            //Player.Select(int x, int y, int dx, int dy) get player from 
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


        public static void ChangePlayerTurnText (int playerTurnIndex)
        {
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
    }
}
