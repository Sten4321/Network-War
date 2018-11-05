using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace FirstSemesterExamProject
{
    class GameInstance
    {
        private string mapPath;
        private int mapLength;
        private char[,] map;


        /// <summary>
        /// GameInstance Constructer To make The Map
        /// </summary>
        /// <param name="mapNumber"></param>
        public GameInstance(int mapNumber)
        {
            ChooseMap(mapNumber);

            map = LoadMap();
        }

        /// <summary>
        /// Chooses the map from the given number.
        /// </summary>
        /// <param name="mapNumber"></param>
        private void ChooseMap(int mapNumber)
        {//addMap
            switch (mapNumber)
            {
                case 1:
                    mapPath = Constant.map1;
                    break;

                case 2:
                    mapPath = Constant.map2;
                    break;

                case 3:
                    mapPath = Constant.map3;
                    break;

                case 4:
                    mapPath = Constant.p4Map1;
                    break;

                case 5:
                    mapPath = Constant.p4Map2;
                    break;

                case 6:
                    mapPath = Constant.p4Map3;
                    break;
                case 7:
                    mapPath = Constant.p4Map4;
                    break;
            }
        }

        /// <summary>
        /// Loads the map from the txt file, into a 2d char array for futher usage.
        /// </summary>
        /// <returns></returns>
        private char[,] LoadMap()
        {
            //Makes a string out of every line and stores it in a string array
            string[] fileLines = File.ReadAllLines(mapPath);
            foreach (char s in fileLines[2])//counts how long the map is in chars (counts chars in line 2 so, that line must NEVER be shorter that the others or loss of data will occur)
            {
                mapLength++;
            }
            //Makes a 2d array with the sizes that was calculated ealier (number of lines and line lenght)
            char[,] map = new char[fileLines.Length - 1, mapLength];
            //makes a string variable
            string line;
            //puts every char into the 2d array on a new position.
            for (int Y = 1; Y < fileLines.Length; Y++)
            {
                line = fileLines[Y];
                for (int X = 0; X < line.Length; X++)
                {
                    map[Y - 1, X] = (char)(line[X]);
                }
            }

            return map;
        }

        /// <summary>
        /// Makes a 2d Tile array filled with tiles and returns said array
        /// </summary>
        /// <returns></returns>
        public Tile[,] GenerateMap()
        {
            Tile[,] tileMap = new Tile[map.GetLength(1), map.GetLength(0)];
            //goes trought each char in the 2D array
            for (int Y = 0; Y < map.GetLength(0); Y++)
            {
                for (int X = 0; X < map.GetLength(1); X++)
                {
                    //makes at tile at the x y coordinates equal to the char at the same position in the other array
                    switch (map[Y, X])
                    {
                        case 'S'://Rock 1
                            tileMap[X, Y] = new Tile(new PointF(X, Y), Constant.rock1, Constant.rock1Solid);
                            break;
                        case 'W'://Rock 2
                            tileMap[X, Y] = new Tile(new PointF(X, Y), Constant.rock2, Constant.rock2Solid);
                            break;
                        case 'G'://Grass 1
                            tileMap[X, Y] = new Tile(new PointF(X, Y), Constant.grass1, Constant.grass1Solid);
                            break;
                        case 'F'://Grass 2
                            tileMap[X, Y] = new Tile(new PointF(X, Y), Constant.grass2, Constant.grass2Solid);
                            break;
                        case 'R'://Grass road
                            tileMap[X, Y] = new Tile(new PointF(X, Y), Constant.grassRoad1, Constant.grassRoad1Solid);
                            break;
                        case '2'://Water Side Bottom
                            tileMap[X, Y] = new Tile(new PointF(X, Y), Constant.waterEdge1, Constant.waterEdge1Solid);
                            break;
                        case '4'://Water Side Left
                            tileMap[X, Y] = new Tile(new PointF(X, Y), Constant.waterEdge1, Constant.waterEdge1Solid);
                            tileMap[X, Y].tileSprite.RotateFlip(RotateFlipType.Rotate90FlipNone);
                            break;
                        case '8'://Water Side Top
                            tileMap[X, Y] = new Tile(new PointF(X, Y), Constant.waterEdge1, Constant.waterEdge1Solid);
                            tileMap[X, Y].tileSprite.RotateFlip(RotateFlipType.Rotate180FlipNone);
                            break;
                        case '6'://Water Side Right
                            tileMap[X, Y] = new Tile(new PointF(X, Y), Constant.waterEdge1, Constant.waterEdge1Solid);
                            tileMap[X, Y].tileSprite.RotateFlip(RotateFlipType.Rotate270FlipNone);
                            break;
                        case '5'://Water Middle
                            tileMap[X, Y] = new Tile(new PointF(X, Y), Constant.water1, Constant.water1Solid);
                            break;
                        case '1'://Water corner Bottom Left
                            tileMap[X, Y] = new Tile(new PointF(X, Y), Constant.waterCorner1, Constant.waterCorner1Solid);
                            break;
                        case '7'://Water corner Top Left
                            tileMap[X, Y] = new Tile(new PointF(X, Y), Constant.waterCorner1, Constant.waterCorner1Solid);
                            tileMap[X, Y].tileSprite.RotateFlip(RotateFlipType.Rotate90FlipNone);
                            break;
                        case '9'://Water corner Top Right
                            tileMap[X, Y] = new Tile(new PointF(X, Y), Constant.waterCorner1, Constant.waterCorner1Solid);
                            tileMap[X, Y].tileSprite.RotateFlip(RotateFlipType.Rotate180FlipNone);
                            break;
                        case '3'://Water corner Bottom Right
                            tileMap[X, Y] = new Tile(new PointF(X, Y), Constant.waterCorner1, Constant.waterCorner1Solid);
                            tileMap[X, Y].tileSprite.RotateFlip(RotateFlipType.Rotate270FlipNone);
                            break;
                    }
                }
            }
            return tileMap;
        }
    }
}
