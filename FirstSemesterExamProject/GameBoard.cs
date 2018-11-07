using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace FirstSemesterExamProject
{
    class GameBoard
    {
        //GameBoard map:
        private static GameObject[,] addObjects;
        private static GameObject[,] removeObjects;
        private static GameObject[,] unitMap;
        public static Tile[,] GroundMap;
        //private static List<GameObject> objects;
        Random rnd = new Random();
        private int mapNumber;
        private GameInstance board;
        private static float tileSize;
        public static float scaleFactor;

        /// <summary>
        /// Local
        /// </summary>
        /// <param name="playerNumber"></param>
        public GameBoard(int playerNumber)
        {
            CreateBoard(playerNumber);
            SetUnit();
        }

        /// <summary>
        /// Online
        /// </summary>
        /// <param name="playerNumber"></param>
        public GameBoard(int bord, int s)
        {
            CreateBoard(bord, s);
            SetUnit();
        }

        /// <summary>
        /// Chooses a random map and creates it depending on the number of players
        /// </summary>
        /// <param name="playerNumber"></param>
        /// <param name="tileSize"></param>
        private void CreateBoard(int playerNumber)
        {
            if (playerNumber == 2)
            {
                mapNumber = rnd.Next(1, Constant.numberPlayerMaps2 + 1);
                tileSize = Constant.tileSizeNormal;
            }
            else if (playerNumber <= 4)
            {
                mapNumber = rnd.Next(Constant.lessPlayerThan4 + 1, Constant.lessPlayerThan4 + Constant.numberPlayerMaps4 + 1);
                tileSize = Constant.tileSizeSmall;
            }
            scaleFactor = (TileSize / 64);
            //makes a new board from the map number choosen
            board = new GameInstance(mapNumber);
            //Makes the ground map of tiles via the generate map function from board
            GroundMap = board.GenerateMap();

            unitMap = new GameObject[GroundMap.GetLength(0), GroundMap.GetLength(1)];
            addObjects = new GameObject[GroundMap.GetLength(0), GroundMap.GetLength(1)];
            removeObjects = new GameObject[GroundMap.GetLength(0), GroundMap.GetLength(1)];

            // TODO: if Host Send mapnumber to all clients
        }

        /// <summary>
        /// the defined map players for online play
        /// </summary>
        /// <param name="playerNumber"></param>
        /// <param name="tileSize"></param>
        private void CreateBoard(int bord, int s)
        {
            mapNumber = bord;
            if (bord < Constant.numberPlayerMaps2 + 1)
            {
                tileSize = Constant.tileSizeNormal;
            }
            else if (bord < Constant.lessPlayerThan4 + Constant.numberPlayerMaps4 + 1)
            {
                tileSize = Constant.tileSizeSmall;
            }
            scaleFactor = (TileSize / 64);
            //makes a new board from the map number choosen
            board = new GameInstance(mapNumber);
            //Makes the ground map of tiles via the generate map function from board
            GroundMap = board.GenerateMap();

            unitMap = new GameObject[GroundMap.GetLength(0), GroundMap.GetLength(1)];
            addObjects = new GameObject[GroundMap.GetLength(0), GroundMap.GetLength(1)];
            removeObjects = new GameObject[GroundMap.GetLength(0), GroundMap.GetLength(1)];
        }

        /// <summary>
        /// Adds Objects
        /// </summary>
        public void AddObjects()
        {
            for (int X = 0; X < GroundMap.GetLength(0); X++)
            {
                for (int Y = 0; Y < GroundMap.GetLength(1); Y++)
                {
                    if (addObjects != null)
                    {
                        if (unitMap[X, Y] == null)
                        {
                            unitMap[X, Y] = addObjects[X, Y];
                        }
                    }
                    addObjects[X, Y] = null;
                }
            }
        }

        /// <summary>
        /// Removes Objects From The Game.
        /// </summary>
        public void RemoveObjects()
        {
            for (int X = 0; X < GroundMap.GetLength(0); X++)
            {
                for (int Y = 0; Y < GroundMap.GetLength(1); Y++)
                {
                    if (removeObjects != null)
                    {
                        if (unitMap[X, Y] == removeObjects[X, Y])
                        {
                            unitMap[X, Y] = null;
                        }
                    }
                    removeObjects[X, Y] = null;
                }
            }
        }

        /// <summary>
        /// Renders The board
        /// </summary>
        /// <param name="graphics"></param>
        public void BoardRender(Graphics graphics)
        {
            for (int X = 0; X < GroundMap.GetLength(0); X++)
            {
                for (int Y = 0; Y < GroundMap.GetLength(1); Y++)
                {
                    GroundMap[X, Y].RenderTile(graphics, tileSize, X, Y);
                }
            }
        }

        /// <summary>
        /// Property for objects with get and set
        /// </summary>
        public static GameObject[,] UnitMap
        {
            get { return unitMap; }
            set { unitMap = value; }
        }

        /// <summary>
        /// Property for objectsAdd with get and set
        /// </summary>
        public static GameObject[,] AddObject
        {
            get { return addObjects; }
            set { addObjects = value; }
        }

        /// <summary>
        /// Property for objectsRemove with get and set
        /// </summary>
        public static GameObject[,] RemoveObject
        {
            get { return removeObjects; }
            set { removeObjects = value; }
        }

        /// <summary>
        /// property for the size of tiles/sprites
        /// </summary>
        public static float TileSize
        {
            get { return tileSize; }
            set { tileSize = value; }
        }

        /// <summary>
        /// places the units on the board
        /// </summary>
        public void SetUnit()
        {
            //Places RedTeam Units
            if (Window.RedTeamStack != null)
            {
                if (Window.RedTeamStack.Count > 0)
                {
                    for (int x = 0; x < 3; x++)
                    {
                        for (int y = 0; y < 3; y++)
                        {
                            if (Window.RedTeamStack.Count > 0)
                            {
                                Enum unit = Window.RedTeamStack.Pop();
                                PlaceUnit(unit, PlayerTeam.RedTeam, x, y);
                            }
                        }
                    }
                }
            }
            //Places BlueTeam Units
            if (Window.BlueTeamStack != null)
            {
                if (Window.BlueTeamStack.Count > 0)
                {
                    for (int x = UnitMap.GetLength(0) - 1; x > UnitMap.GetLength(0) - 4; x--)
                    {
                        for (int y = UnitMap.GetLength(1) - 1; y > UnitMap.GetLength(1) - 4; y--)
                        {
                            if (Window.BlueTeamStack.Count > 0)
                            {
                                Enum unit = Window.BlueTeamStack.Pop();
                                PlaceUnit(unit, PlayerTeam.BlueTeam, x, y);
                            }
                        }
                    }
                }
            }
            //Places GreenTeam Units
            if (Window.GreenTeamStack != null)
            {
                if (Window.GreenTeamStack.Count > 0)
                {
                    for (int x = UnitMap.GetLength(0) - 1; x > UnitMap.GetLength(0) - 4; x--)
                    {
                        for (int y = 0; y < 3; y++)
                        {
                            if (Window.GreenTeamStack.Count > 0)
                            {
                                Enum unit = Window.GreenTeamStack.Pop();
                                PlaceUnit(unit, PlayerTeam.GreenTeam, x, y);
                            }
                        }
                    }
                }
            }
            //Places YellowTeam Units
            if (Window.YellowTeamStack != null)
            {
                if (Window.YellowTeamStack.Count > 0)
                {
                    for (int x = 0; x < 3; x++)
                    {
                        for (int y = UnitMap.GetLength(1) - 1; y > UnitMap.GetLength(1) - 4; y--)
                        {
                            if (Window.YellowTeamStack.Count > 0)
                            {
                                Enum unit = Window.YellowTeamStack.Pop();
                                PlaceUnit(unit, PlayerTeam.YellowTeam, x, y);
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Places a unit at coordinates
        /// </summary>
        /// <param name="unit"></param>
        /// <param name="team"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        private void PlaceUnit(Enum unit, PlayerTeam team, int x, int y)
        {
            switch (unit)
            {
                case Units.Archer:
                    addObjects[x, y] = new Archer(team, new PointF(x, y));
                    break;

                case Units.Knight:
                    addObjects[x, y] = new Knight(team, new PointF(x, y));
                    break;

                case Units.Mage:
                    addObjects[x, y] = new Mage(team, new PointF(x, y));
                    break;

                case Units.Cleric:
                    addObjects[x, y] = new Cleric(team, new PointF(x, y));
                    break;

                case Units.Scout:
                    addObjects[x, y] = new Scout(team, new PointF(x, y));
                    break;

                case Units.Artifact:
                    addObjects[x, y] = new Artifact(team, new PointF(x, y));
                    break;

                default:
                    break;
            }
        }
    }
}
