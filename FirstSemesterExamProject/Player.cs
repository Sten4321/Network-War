﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace FirstSemesterExamProject
{
    class Player : GameObject
    {
        private int playerMove; //The amount of moves a Player has.
        private int playerMaxMove;
        private PlayerTeam playerTeam;
        private Unit selectedUnit;
        private int selectedUnitX;
        private int selectedUnitY;
        private bool canMove;
        private Tile selectedTile;
        private Brush brushColor;
        private string imagePath;
        private bool mouseClick = false;

        /// <summary>
        /// Property for selected Unit.
        /// </summary>
        public Unit SelectedUnit
        {
            get { return selectedUnit; }
            set { selectedUnit = value; }
        }

        /// <summary>
        /// Property for playerMove
        /// </summary>
        public int PlayerMove
        {
            get { return playerMove; }
            set { playerMove = value; }
        }

        /// <summary>
        /// Property for playerMaxMove
        /// </summary>
        public int PlayerMaxMove
        {
            get { return playerMaxMove; }
            set { playerMaxMove = value; }
        }

        public PlayerTeam PlayerTeamColor
        {
            get { return playerTeam; }
        }

        /// <summary>
        /// The Constructor, required by GameObject. Constructs the "Player Marker". 
        /// </summary>
        /// <param name="playerTeam"></param>
        public Player(PlayerTeam playerTeam, int playerNumber)
        {
            this.hasCollision = false;
            this.playerTeam = playerTeam;
            this.coordinates = StartCoordinates(playerTeam);
            playerMove = Constant.playerMove + playerNumber;
            playerMaxMove = Constant.playerMove + playerNumber;
            canMove = true; //Makes it possible to move

            PlayerTeamSelect(playerTeam);
        }

        /// <summary>
        /// returns coordinates depending on the team
        /// </summary>
        /// <param name="playerTeam"></param>
        /// <returns></returns>
        private PointF StartCoordinates(PlayerTeam playerTeam)
        {
            switch (playerTeam)
            {
                case PlayerTeam.RedTeam:
                    return new PointF(1, 1);
                case PlayerTeam.BlueTeam:
                    return new PointF(GameBoard.UnitMap.GetLength(0) - 2, GameBoard.UnitMap.GetLength(1) - 2);
                case PlayerTeam.GreenTeam:
                    return new PointF(GameBoard.UnitMap.GetLength(0) - 2, 1);
                case PlayerTeam.YellowTeam:
                    return new PointF(1, GameBoard.UnitMap.GetLength(1) - 2);
                default:
                    return new PointF(1, 1);
            }
        }

        /// <summary>
        /// sets color depending on the team
        /// </summary>
        /// <param name="playerTeam"></param>
        private void PlayerTeamSelect(PlayerTeam playerTeam)
        {
            switch (playerTeam) //Changes the player sprite, depending on the player's team
            {
                case PlayerTeam.RedTeam:
                    imagePath = Constant.playerRedImagePath;
                    brushColor = new SolidBrush(Color.FromArgb(180, 0, 0));
                    break;
                case PlayerTeam.BlueTeam:
                    imagePath = Constant.playerBlueImagePath;
                    brushColor = Brushes.Blue;
                    break;
                case PlayerTeam.GreenTeam:
                    imagePath = Constant.playerGreenImagePath;
                    brushColor = Brushes.LawnGreen;
                    break;
                case PlayerTeam.YellowTeam:
                    imagePath = Constant.playerYellowImagePath;
                    brushColor = Brushes.Yellow;
                    break;
            }
            base.images = imagePath.Split(';');//splits all imagepaths, whenever a ';' is typed. Fx: img1;img2;img3 
            base.frames = new List<Image>();

            foreach (string image in images)
            {
                base.frames.Add(Image.FromFile(image));
            }
            base.sprite = this.frames[0];
        }

        /// <summary>
        /// Moves the Player Marker, using the keyboard.
        /// </summary>
        public void Move()
        {
            //Moves curser up
            Up();
            //Moves curser down
            Down();
            //Moves curser left
            Left();
            //Moves curser right
            Right();
            //Select and move unit
            Select();
            //makes it posible to move
            CanMove();

        }

        /// <summary>
        /// Moves curser up
        /// </summary>
        private void Up()
        {
            if (coordinates.Y > 0)
            {
                if (Keyboard.IsKeyDown(Keys.W))
                {
                    if (canMove)
                    {
                        coordinates.Y -= 1;
                        canMove = false;
                    }
                }


                if (Keyboard.IsKeyDown(Keys.Up))
                {
                    if (canMove)
                    {
                        coordinates.Y -= 1;
                        canMove = false;
                    }
                }
            }
        }

        /// <summary>
        /// Moves curser Down
        /// </summary>
        private void Down()
        {
            if (coordinates.Y < GameBoard.UnitMap.GetLength(0) - 1)
            {
                if (Keyboard.IsKeyDown(Keys.S))
                {
                    if (canMove)
                    {
                        coordinates.Y += 1;
                        canMove = false;
                    }
                }


                if (Keyboard.IsKeyDown(Keys.Down))
                {
                    if (canMove)
                    {
                        coordinates.Y += 1;
                        canMove = false;
                    }
                }
            }

        }

        /// <summary>
        /// Moves curser Left
        /// </summary>
        private void Left()
        {
            if (coordinates.X > 0)
            {
                if (Keyboard.IsKeyDown(Keys.A))
                {
                    if (canMove)
                    {
                        coordinates.X -= 1;
                        canMove = false;
                    }
                }

                if (Keyboard.IsKeyDown(Keys.Left))
                {
                    if (canMove)
                    {
                        coordinates.X -= 1;
                        canMove = false;
                    }
                }
            }
        }

        /// <summary>
        /// Moves curser Right
        /// </summary>
        private void Right()
        {
            if (coordinates.X < GameBoard.UnitMap.GetLength(1) - 1)
            {
                if (Keyboard.IsKeyDown(Keys.D))
                {
                    if (canMove)
                    {
                        coordinates.X += 1;
                        canMove = false;

                    }
                }

                if (Keyboard.IsKeyDown(Keys.Right))
                {
                    if (canMove)
                    {
                        coordinates.X += 1;
                        canMove = false;
                    }
                }
            }
        }


        /// <summary>
        /// Selects and moves the content of the tile highlighted by the Player Marker.
        /// </summary>
        public void Select()
        {
            if (Keyboard.IsKeyDown(Keys.Enter) || Keyboard.IsKeyDown(Keys.Space) || mouseClick == true)
            {
                if (canMove == true)
                {
                    if (selectedUnit == null)
                    {
                        NotSelected();
                    }
                    else if (selectedUnit != null)
                    {
                        Selected();
                    }

                    canMove = false;
                }

            }

        }

        /// <summary>
        /// Handles moving with the mouse
        /// </summary>
        public void MouseClickSelect(int x, int y)
        {
            coordinates = new Point(x, y);
            mouseClick = true;
            Select();
            mouseClick = false;
        }

        /// <summary>
        /// moves/attacks with sellected unit
        /// </summary>
        private void Selected()
        {
            if (selectedUnit.Move > 0 && playerMove > 0 || (selectedUnit is Scout && selectedUnit.Move > 0))
            {
                Healing();
                RangedAttack();
                //test if the tile is in range and a tile to which you can move
                if (InRange((int)coordinates.X, (int)coordinates.Y) && NotSolid((int)Coordinates.X, (int)Coordinates.Y))
                {
                    //tests if there is an enemy
                    if (GameBoard.UnitMap[(int)coordinates.X, (int)coordinates.Y] is Unit unit && !(selectedUnit is IRanged))
                    {
                        if (selectedUnit is Scout && playerMove > 0 || !(selectedUnit is Scout))
                        {
                            //moves to melee range and attacks if the unit on the tile is an enemy
                            if ((unit.Team != selectedUnit.Team)
                            && ((selectedUnitX < coordinates.X - 1) || (selectedUnitX > coordinates.X + 1)
                            || (selectedUnitY < coordinates.Y - 1) || (selectedUnitY > coordinates.Y + 1)))
                            {
                                AttackMove(unit);
                            }
                            //attacks from melee range if the unit on the tile is an enemy
                            else if ((unit.Team != selectedUnit.Team)
                                && ((selectedUnitX < coordinates.X)
                                || (selectedUnitX > coordinates.X)
                                || (selectedUnitY < coordinates.Y)
                                || (selectedUnitY > coordinates.Y)))
                            {

                                selectedUnit.Attack(unit);
                                playerMove--;
                            }
                        }
                    }
                    //moves to empty tile
                    else if (GameBoard.UnitMap[(int)coordinates.X, (int)coordinates.Y] == null)
                    {
                        MoveHere();
                    }
                }
            }
            //deselects unit
            selectedUnit = null;
            selectedUnitX = 0;
            selectedUnitY = 0;
        }

        /// <summary>
        /// Handles ranged attacks
        /// </summary>
        private void RangedAttack()
        {
            //tests if attacking an enemy unit with a ranged unit in ranged range
            if (selectedUnit is IRanged rangedUnit)
            {
                //tests if the coordinates is in range
                if (InRangeRanged(rangedUnit, (int)coordinates.X, (int)Coordinates.Y))
                {
                    //tests if there is a unit at the coordinates
                    if (GameBoard.UnitMap[(int)coordinates.X, (int)coordinates.Y] is Unit unit)
                    {
                        //tests if the unit is on your team
                        if (unit.Team != selectedUnit.Team)
                        {
                            selectedUnit.Attack(unit);
                            playerMove--;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Handles what happens when the unit is a healer
        /// </summary>
        private void Healing()
        {
            //test if the unit is a healer
            if (selectedUnit is IHeal healer)
            {
                if (selectedUnit is IRanged rangedHealer)
                {
                    if (InRangeRanged(rangedHealer, (int)coordinates.X, (int)Coordinates.Y))
                    {
                        if (GameBoard.UnitMap[(int)coordinates.X, (int)coordinates.Y] is Unit unit)
                        {
                            if (unit.Team == selectedUnit.Team && unit.Health < unit.MaxHealth)
                            {
                                selectedUnit.Attack(unit);
                                playerMove--;
                            }
                        }
                    }
                }
                else
                {
                    if (selectedUnit.Move > 0 && playerMove > 0)
                    {
                        if (InRange((int)coordinates.X, (int)coordinates.Y))
                        {
                            if (GameBoard.UnitMap[(int)coordinates.X, (int)coordinates.Y] is Unit unit)
                            {
                                if ((unit.Team == selectedUnit.Team) && ((selectedUnitX != coordinates.X) || (selectedUnitY != coordinates.Y)) && unit.Health < unit.MaxHealth)
                                {
                                    if ((unit.Team == selectedUnit.Team && ((selectedUnitX < coordinates.X - 1) || (selectedUnitX > coordinates.X + 1) || (selectedUnitY < coordinates.Y - 1) || (selectedUnitY > coordinates.Y + 1))))
                                    {
                                        AttackMove(unit);
                                    }
                                    //heals from melee range if the unit on the tile is a teammember
                                    else if ((unit.Team == selectedUnit.Team)
                                        && ((selectedUnitX < coordinates.X)
                                        || (selectedUnitX > coordinates.X)
                                        || (selectedUnitY < coordinates.Y)
                                        || (selectedUnitY > coordinates.Y))
                                        && unit.Health < unit.MaxHealth)
                                    {

                                        selectedUnit.Attack(unit);
                                        playerMove--;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// moves melle units next to the unit they are attacking
        /// </summary>
        /// <param name="unit"></param>
        private void AttackMove(Unit unit)
        {
            if ((unit.Coordinates.X - selectedUnitX > 1)
            && !(GameBoard.GroundMap[(int)unit.Coordinates.X - 1, (int)unit.Coordinates.Y].hasCollision)
            && !(GameBoard.UnitMap[(int)unit.Coordinates.X - 1, (int)unit.Coordinates.Y] != null))
            {
                //moves the unit to new coordinates
                selectedUnit.Coordinates = new PointF(coordinates.X - 1, coordinates.Y);
                //subtracts the amount of moves a unit can have
                selectedUnit.Move -= (Math.Abs((int)coordinates.X - selectedUnitX) + Math.Abs((int)coordinates.Y - selectedUnitY) - 1);
                //a units move must not be less than 0
                if (selectedUnit.Move < 0)
                {
                    selectedUnit.Move = 0;
                }
                //attacks with the unit
                selectedUnit.Attack(unit);
                //places the unit on the new coordinates
                GameBoard.UnitMap[(int)selectedUnit.Coordinates.X, (int)selectedUnit.Coordinates.Y] = selectedUnit;
                //empties the old coordinates
                GameBoard.UnitMap[selectedUnitX, selectedUnitY] = null;
            }
            else if ((selectedUnitX - unit.Coordinates.X > 1)
                && !(GameBoard.GroundMap[(int)unit.Coordinates.X + 1, (int)unit.Coordinates.Y].hasCollision)
                && !(GameBoard.UnitMap[(int)unit.Coordinates.X + 1, (int)unit.Coordinates.Y] != null))
            {
                //moves unit to new coordinates
                selectedUnit.Coordinates = new PointF(coordinates.X + 1, coordinates.Y);
                selectedUnit.Move -= (Math.Abs((int)coordinates.X - selectedUnitX) + Math.Abs((int)coordinates.Y - selectedUnitY) - 1);
                //a units move must not be less than 0
                if (selectedUnit.Move < 0)
                {
                    selectedUnit.Move = 0;
                }
                //attacks with the unit
                selectedUnit.Attack(unit);
                //moves the unit virsually
                GameBoard.UnitMap[(int)selectedUnit.Coordinates.X, (int)selectedUnit.Coordinates.Y] = selectedUnit;
                GameBoard.UnitMap[selectedUnitX, selectedUnitY] = null;
            }
            else if ((unit.Coordinates.Y - selectedUnitY > 1)
                && !(GameBoard.GroundMap[(int)unit.Coordinates.X, (int)unit.Coordinates.Y - 1].hasCollision)
                && !(GameBoard.UnitMap[(int)unit.Coordinates.X, (int)unit.Coordinates.Y - 1] != null))
            {
                selectedUnit.Coordinates = new PointF(coordinates.X, coordinates.Y - 1);
                selectedUnit.Move -= (Math.Abs((int)coordinates.X - selectedUnitX) + Math.Abs((int)coordinates.Y - selectedUnitY) - 1);
                //a units move must not be less than 0
                if (selectedUnit.Move < 0)
                {
                    selectedUnit.Move = 0;
                }
                //attacks with the unit
                selectedUnit.Attack(unit);
                //moves the unit virsually
                GameBoard.UnitMap[(int)selectedUnit.Coordinates.X, (int)selectedUnit.Coordinates.Y] = selectedUnit;
                GameBoard.UnitMap[selectedUnitX, selectedUnitY] = null;
            }
            else if ((selectedUnitY - unit.Coordinates.Y > 1)
                && !(GameBoard.GroundMap[(int)unit.Coordinates.X, (int)unit.Coordinates.Y + 1].hasCollision)
                && !(GameBoard.UnitMap[(int)unit.Coordinates.X, (int)unit.Coordinates.Y + 1] != null))
            {
                selectedUnit.Coordinates = new PointF(coordinates.X, coordinates.Y + 1);
                selectedUnit.Move -= (Math.Abs((int)coordinates.X - selectedUnitX) + Math.Abs((int)coordinates.Y - selectedUnitY) - 1);
                //a units move must not be less than 0
                if (selectedUnit.Move < 0)
                {
                    selectedUnit.Move = 0;
                }
                //attacks with the unit
                selectedUnit.Attack(unit);
                //moves the unit virsually
                GameBoard.UnitMap[(int)selectedUnit.Coordinates.X, (int)selectedUnit.Coordinates.Y] = selectedUnit;
                GameBoard.UnitMap[selectedUnitX, selectedUnitY] = null;
            }
            if (selectedUnitX != selectedUnit.Coordinates.X || selectedUnitY != selectedUnit.Coordinates.Y)
            {
                if (!(selectedUnit is Scout))
                {
                    //subtracts the number of moves done from the player moves
                    playerMove -= Math.Abs((int)coordinates.X - selectedUnitX) + Math.Abs((int)coordinates.Y - selectedUnitY);
                }
                else
                {
                    playerMove--;
                }
            }
        }

        /// <summary>
        /// selects unit if not selected
        /// </summary>
        private void NotSelected()
        {
            SoundEngine.PlaySound(Constant.playerMoveUnit);
            if (GameBoard.UnitMap[(int)coordinates.X, (int)coordinates.Y] is Unit unit)
            {
                //if unit is on your team :)
                if (unit.Team == playerTeam)
                {
                    selectedUnit = unit;
                    selectedUnitX = (int)coordinates.X;
                    selectedUnitY = (int)coordinates.Y;

                    switch (playerTeam) //Changes the Selected tile sprite, depending on the player's team 
                    {
                        case PlayerTeam.RedTeam:
                            selectedTile = new Tile(new PointF(selectedUnitX, selectedUnitY), Constant.selectedMarkerRed, false);
                            break;
                        case PlayerTeam.BlueTeam:
                            selectedTile = new Tile(new PointF(selectedUnitX, selectedUnitY), Constant.selectedMarkerBlue, false);
                            break;
                        case PlayerTeam.GreenTeam:
                            selectedTile = new Tile(new PointF(selectedUnitX, selectedUnitY), Constant.selectedMarkerGreen, false);
                            break;
                        case PlayerTeam.YellowTeam:
                            selectedTile = new Tile(new PointF(selectedUnitX, selectedUnitY), Constant.selectedMarkerYellow, false);
                            break;
                    }

                }
            }
        }

        /// <summary>
        /// Moves The unit to selected Coordinates
        /// </summary>
        private void MoveHere()
        {
            //gives unit the new coordinates
            selectedUnit.Coordinates = new PointF(coordinates.X, coordinates.Y);
            //calculates how far of a move was done
            selectedUnit.Move -= Math.Abs((int)coordinates.X - selectedUnitX) + Math.Abs((int)coordinates.Y - selectedUnitY);
            if (selectedUnit.Move < 0)
            {
                selectedUnit.Move = 0;
            }
            //limits how many times you can move a unit a turn
            if (!(selectedUnit is Scout))
            {
                playerMove -= Math.Abs((int)coordinates.X - selectedUnitX) + Math.Abs((int)coordinates.Y - selectedUnitY);
                if (PlayerMove < 0)
                {
                    PlayerMove = 0;
                }
            }
            System.Diagnostics.Debug.WriteLine(selectedUnit.Move);
            //actually moves the unit
            GameBoard.UnitMap[(int)selectedUnit.Coordinates.X, (int)selectedUnit.Coordinates.Y] = selectedUnit;
            GameBoard.UnitMap[selectedUnitX, selectedUnitY] = null;
        }

        /// <summary>
        /// Returns true if the selected squere is a tile to wich you can move
        /// </summary>
        /// <returns></returns>
        private bool NotSolid(int X, int Y)
        {
            if (GameBoard.GroundMap[X, Y].hasCollision)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Returns true if in range
        /// </summary>
        /// <returns></returns>
        private bool InRange(int X, int Y)
        {
            //using Taxicab Geometry
            if (//checking diagonally in all 4 directions comparing to both the units moves and the players moves
                ((((X - selectedUnitX) + (Y - selectedUnitY))
                <= (selectedUnit.Move) &&
                (X > selectedUnitX && Y > selectedUnitY))

                || (((selectedUnitX - X) + (Y - selectedUnitY))
                <= (selectedUnit.Move) &&
                (X < selectedUnitX && Y > selectedUnitY))

                || (((X - selectedUnitX) + (selectedUnitY - Y))
                <= (selectedUnit.Move) &&
                (X > selectedUnitX && Y < selectedUnitY))

                || (((selectedUnitX - X) + (selectedUnitY - Y))
                <= (selectedUnit.Move) &&
                (X < selectedUnitX && Y < selectedUnitY)))

                && ((((X - selectedUnitX) + (Y - selectedUnitY))
                <= (playerMove) &&
                (X > selectedUnitX && Y > selectedUnitY))

                || (((selectedUnitX - X) + (Y - selectedUnitY))
                <= (playerMove) &&
                (X < selectedUnitX && Y > selectedUnitY))

                || (((X - selectedUnitX) + (selectedUnitY - Y))
                <= (playerMove) &&
                (X > selectedUnitX && Y < selectedUnitY))

                || (((selectedUnitX - X) + (selectedUnitY - Y))
                <= (playerMove) &&
                (X < selectedUnitX && Y < selectedUnitY))

                || (selectedUnit is Scout))
               )
            {
                return true;
            }
            else if (//As above but Checking the linier paths...
                     ((((selectedUnitX - X))
                     <= (selectedUnit.Move) &&
                     (X < selectedUnitX && selectedUnitY == Y))

                     || (((X - selectedUnitX))
                     <= (selectedUnit.Move) &&
                     (X > selectedUnitX && selectedUnitY == Y))

                     || (((selectedUnitY - Y))
                     <= (selectedUnit.Move) &&
                     (Y < selectedUnitY && selectedUnitX == X))

                     || (((Y - selectedUnitY))
                     <= (selectedUnit.Move) &&
                     (Y > selectedUnitY && selectedUnitX == X)))

                     && ((((selectedUnitX - X))
                     <= (playerMove) &&
                     (X < selectedUnitX && selectedUnitY == Y))

                     || (((X - selectedUnitX))
                     <= (playerMove) &&
                     (X > selectedUnitX && selectedUnitY == Y))

                     || (((selectedUnitY - Y))
                     <= (playerMove) &&
                     (Y < selectedUnitY && selectedUnitX == X))

                     || (((Y - selectedUnitY))
                     <= (playerMove) &&
                     (Y > selectedUnitY && selectedUnitX == X))

                     || (selectedUnit is Scout))
                    )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Returns true if in range of ranged attack
        /// </summary>
        /// <returns></returns>
        private bool InRangeRanged(IRanged rangedUnit, int X, int Y)
        {
            //using Taxicab Geometry
            if (//checking diagonally in all 4 directions
                (((X - selectedUnitX) + (Y - selectedUnitY))
                <= (rangedUnit.Range) &&
                (X > selectedUnitX && Y > selectedUnitY))

                || (((selectedUnitX - X) + (Y - selectedUnitY))
                <= (rangedUnit.Range) &&
                (X < selectedUnitX && Y > selectedUnitY))

                || (((X - selectedUnitX) + (selectedUnitY - Y))
                <= (rangedUnit.Range) &&
                (X > selectedUnitX && Y < selectedUnitY))

                || (((selectedUnitX - X) + (selectedUnitY - Y))
                <= (rangedUnit.Range) &&
                (X < selectedUnitX && Y < selectedUnitY))
               )
            {
                return true;
            }
            else if (//Checking the linier paths...
                     ((((selectedUnitX - X))
                     <= (rangedUnit.Range) &&
                     (X < selectedUnitX && selectedUnitY == Y))

                     || (((X - selectedUnitX))
                     <= (rangedUnit.Range) &&
                     (X > selectedUnitX && selectedUnitY == Y))

                     || (((selectedUnitY - Y))
                     <= (rangedUnit.Range) &&
                     (Y < selectedUnitY && selectedUnitX == X))

                     || (((Y - selectedUnitY))
                     <= (rangedUnit.Range) &&
                     (Y > selectedUnitY && selectedUnitX == X)))
                    )
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// makes it posible to move the curser.
        /// </summary>
        private void CanMove()
        {
            if (!Keyboard.IsKeyDown(Keys.Right) && !Keyboard.IsKeyDown(Keys.D)
                && !Keyboard.IsKeyDown(Keys.Left) && !Keyboard.IsKeyDown(Keys.A)
                && !Keyboard.IsKeyDown(Keys.Down) && !Keyboard.IsKeyDown(Keys.S)
                && !Keyboard.IsKeyDown(Keys.Up) && !Keyboard.IsKeyDown(Keys.W)
                && !Keyboard.IsKeyDown(Keys.Enter) && !Keyboard.IsKeyDown(Keys.Space))
            {
                canMove = true;
            }
            if (!Keyboard.IsKeyDown(Keys.Back))
            {
                Window.canEndTurn = true;
            }
            if (!Keyboard.IsKeyDown(Keys.F5))
            {
                Window.canRestart = true;
            }
            if (!Keyboard.IsKeyDown(Keys.M))
            {
                Window.canMute = true;
            }
        }


        /// <summary>
        /// Renders the "Player Marker". 
        /// </summary>
        /// <param name="graphics"></param>
        public override void ObjectRender(Graphics graphics)
        {
            ChangeMarker();

            if (selectedUnit != null)
            {
                selectedTile.RenderTile(graphics, GameBoard.TileSize, selectedUnitX, selectedUnitY);
                selectedUnit.RenderSelectedUnitStats(graphics);
                DrawRange(graphics);
            }

            graphics.DrawImage(sprite, coordinates.X * GameBoard.TileSize, coordinates.Y * GameBoard.TileSize,
                GameBoard.TileSize, GameBoard.TileSize);

            if (GameBoard.UnitMap[(int)coordinates.X, (int)coordinates.Y] is Unit)
            {
                ((Unit)GameBoard.UnitMap[(int)coordinates.X, (int)coordinates.Y]).RenderUnitStats(graphics);
            }

            RenderPlayerMoveCount(graphics);
        }

        /// <summary>
        /// Draws Where the selected unit can move to and shoot if ranged
        /// </summary>
        private void DrawRange(Graphics graphics)
        {
            //goes through each tile
            for (int X = 0; X < GameBoard.GroundMap.GetLength(0); X++)
            {
                for (int Y = 0; Y < GameBoard.GroundMap.GetLength(1); Y++)
                {
                    //checks if the tile is in range of the selected charecter and that the tile is one where the unit can stand
                    if (InRange(X, Y) && NotSolid(X, Y) && GameBoard.UnitMap[X, Y] is null && selectedUnit.Move > 0)
                    {
                        //Draws a balck shade on the tile
                        graphics.FillRectangle(new SolidBrush(Color.FromArgb(100, Color.Black)), new RectangleF(X * GameBoard.TileSize, (Y * GameBoard.TileSize), GameBoard.TileSize, GameBoard.TileSize));
                    }
                    //if the chosen charecter is melee and is in range of an enemy draws a red shade over the enemy
                    else if (InRange(X, Y) && NotSolid(X, Y) && GameBoard.UnitMap[X, Y] is Unit unit && !(selectedUnit is IRanged) && selectedUnit.Move > 0)
                    {
                        if (unit.Team != selectedUnit.Team && !(selectedUnit is IHeal))
                        {
                            graphics.FillRectangle(new SolidBrush(Color.FromArgb(100, Color.Red)), new RectangleF(X * GameBoard.TileSize, (Y * GameBoard.TileSize), GameBoard.TileSize, GameBoard.TileSize));
                        }
                        //if the chosen charecter is a melee Healer and is in range of a damaged teammember draws a blue shade over the teammember
                        if (unit.Team == selectedUnit.Team && selectedUnit is IHeal && unit.Health < unit.MaxHealth)
                        {
                            graphics.FillRectangle(new SolidBrush(Color.FromArgb(100, Color.Blue)), new RectangleF(X * GameBoard.TileSize, (Y * GameBoard.TileSize), GameBoard.TileSize, GameBoard.TileSize));
                        }
                    }
                    //if the chosen charecter is Ranged and is in range of an enemy draws a red shade over the enemy
                    if (selectedUnit is IRanged rangedUnit && selectedUnit.Move > 0)
                    {
                        if (InRangeRanged(rangedUnit, X, Y) && GameBoard.UnitMap[X, Y] is Unit unit)
                        {
                            if (unit.Team != selectedUnit.Team)
                            {
                                //graphics.DrawEllipse(new Pen(brushColor), X * GameBoard.TileSize, (Y * GameBoard.TileSize), GameBoard.TileSize, GameBoard.TileSize);
                                graphics.FillRectangle(new SolidBrush(Color.FromArgb(100, Color.Red)), new RectangleF(X * GameBoard.TileSize, (Y * GameBoard.TileSize), GameBoard.TileSize, GameBoard.TileSize));
                            }
                            //if the chosen charecter is a ranged Healer and is in range of a damaged teammember draws a blue shade over the teammember
                            if (unit.Team == selectedUnit.Team && selectedUnit is IHeal && unit.Health < unit.MaxHealth)
                            {
                                graphics.FillRectangle(new SolidBrush(Color.FromArgb(100, Color.Blue)), new RectangleF(X * GameBoard.TileSize, (Y * GameBoard.TileSize), GameBoard.TileSize, GameBoard.TileSize));
                            }
                        }
                    }
                }
            }

        }

        /// <summary>
        /// Changes the look of the marker in an attack position
        /// </summary>
        private void ChangeMarker()
        {
            if (GameBoard.UnitMap[(int)coordinates.X, (int)coordinates.Y] is Unit unit)
            {
                if (unit.Team != playerTeam)
                {
                    if (selectedUnit != null)
                    {
                        switch (playerTeam)
                        {
                            case PlayerTeam.RedTeam:
                                imagePath = Constant.attackedMarkerRed;
                                break;

                            case PlayerTeam.BlueTeam:
                                imagePath = Constant.attackedMarkerBlue;
                                break;

                            case PlayerTeam.GreenTeam:
                                imagePath = Constant.attackedMarkerGreen;
                                break;

                            case PlayerTeam.YellowTeam:
                                imagePath = Constant.attackedMarkerYellow;
                                break;
                        }
                    }
                    else
                    {
                        switch (playerTeam)
                        {
                            case PlayerTeam.RedTeam:
                                imagePath = Constant.playerRedImagePath;
                                break;

                            case PlayerTeam.BlueTeam:
                                imagePath = Constant.playerBlueImagePath;
                                break;

                            case PlayerTeam.GreenTeam:
                                imagePath = Constant.playerGreenImagePath;
                                break;

                            case PlayerTeam.YellowTeam:
                                imagePath = Constant.playerYellowImagePath;
                                break;
                        }
                    }
                }
                else
                {
                    switch (playerTeam)
                    {
                        case PlayerTeam.RedTeam:
                            imagePath = Constant.playerRedImagePath;
                            break;

                        case PlayerTeam.BlueTeam:
                            imagePath = Constant.playerBlueImagePath;
                            break;

                        case PlayerTeam.GreenTeam:
                            imagePath = Constant.playerGreenImagePath;
                            break;

                        case PlayerTeam.YellowTeam:
                            imagePath = Constant.playerYellowImagePath;
                            break;
                    }
                }
            }
            else
            {
                switch (playerTeam)
                {
                    case PlayerTeam.RedTeam:
                        imagePath = Constant.playerRedImagePath;
                        break;

                    case PlayerTeam.BlueTeam:
                        imagePath = Constant.playerBlueImagePath;
                        break;

                    case PlayerTeam.GreenTeam:
                        imagePath = Constant.playerGreenImagePath;
                        break;

                    case PlayerTeam.YellowTeam:
                        imagePath = Constant.playerYellowImagePath;
                        break;
                }
            }
            base.images = imagePath.Split(';');
            base.frames = new List<Image>();

            foreach (string image in images)
            {
                base.frames.Add(Image.FromFile(image));
            }

        }

        /// <summary>
        /// renders hov many moves the player have left
        /// </summary>
        /// <param name="graphics"></param>
        private void RenderPlayerMoveCount(Graphics graphics)
        {
            graphics.DrawString("Moves Left: " + playerMove, new Font("Arial", Constant.playerMovesFontSize), brushColor, new PointF(Constant.playerMovesLeftX, Constant.playerMovesLeftY));
        }
    }
}
