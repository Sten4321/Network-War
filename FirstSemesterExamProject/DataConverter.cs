﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

                splitStrings = information.Split(',');

                switch (command)
                {

                    case "UnitStack":

                        Enum.TryParse(splitStrings[0], out PlayerTeam _team); //Converts first information to a team (YELLOW,archer,knight,mage)                                                

                        AddUnitsToTeamStack(_team, splitStrings);

                        break;


                    default:
                        System.Diagnostics.Debug.WriteLine("Invalid Command!");
                        break;
                }

            }

        }
        public static void AddUnitsToTeamStack(PlayerTeam team, string[] unitStrings)
        {
            Stack<Enum> tmpStack = new Stack<Enum>();

            // i = 1 because the first string is Team colour
            for (int i = 1; i <= unitStrings.Length; i++)
            {
                Enum.TryParse(unitStrings[i], out Units unit); //tries to convert string to enum ("Knight" => Units.Knight)

                tmpStack.Push(unit);
            }

            //applies local stack to the designated team's stack
            switch (team)
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
        }
    }
}