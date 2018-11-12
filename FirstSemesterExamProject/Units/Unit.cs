using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstSemesterExamProject
{
    abstract class Unit : GameObject
    {
        protected string name;
        protected int health;
        protected int maxHealth;
        protected int armor;
        protected int move;
        protected int damage;
        protected PlayerTeam team;
        protected string description;
        private Brush brushColor;

        /// <summary>
        /// Unit description property
        /// </summary>
        public string Description
        {
            get { return description; }
            set { value = description; }
        }

        /// <summary>
        /// Property for maks moves of the unit.
        /// </summary>
        public int Move
        {
            get { return move; }
            set { move = value; }
        }
        /// <summary>
        /// Property for Unit's Armor
        /// </summary>
        public int Armor
        {
            get { return armor; }
            set { armor = value; }
        }
        /// <summary>
        /// Property for Unit's health
        /// </summary>
        public int Health
        {
            get { return health; }
            set { health = value; }
        }
        /// <summary>
        /// Property for Unit's maxHealth
        /// </summary>
        public int MaxHealth
        {
            get { return maxHealth; }
            set { maxHealth = value; }
        }
        /// <summary>
        /// Property for unit team
        /// </summary>
        public PlayerTeam Team
        {
            get { return team; }
            set { team = value; }
        }

        public float AnimationSpeed
        {
            get { return animationSpeed; }
            set { animationSpeed = value; }
        }

        public Unit(string name, int health, int armor, int move, int damage, PlayerTeam team, PointF coordinates, string ImagePath) : base(coordinates, ImagePath, true)
        {
            this.name = name;
            this.health = health;
            this.maxHealth = health;
            this.armor = armor;
            this.move = move;
            this.damage = damage;
            this.team = team;
            TeamColor();
        }

        public Unit(PointF coordinates, string ImagePath, bool hasCollision)
        {
            this.coordinates = coordinates;
            this.hasCollision = hasCollision;

        }
        /// <summary>
        /// Removes Unit from the game
        /// </summary>
        public virtual void Die()
        {
            // TODO: Game Crashed in online when a unit died

            GameBoard.RemoveObject[(int)coordinates.X, (int)coordinates.Y] = this;

        }
        /// <summary>
        /// Sets Unit moves to 0
        /// </summary>
        /// <param name="enemy"></param>
        public virtual void Attack(Unit enemy)
        {
            move = 0;
        }


        /// <summary>
        /// chooses color for the units boarder dependend on its team
        /// </summary>
        private void TeamColor()
        {
            switch (team) //Changes unit's colour, depending on its Team
            {
                case PlayerTeam.BlueTeam:
                    brushColor = Brushes.Blue;
                    break;

                case PlayerTeam.RedTeam:
                    brushColor = new SolidBrush(Color.FromArgb(180, 0, 0));
                    break;

                case PlayerTeam.YellowTeam:
                    brushColor = Brushes.Yellow;
                    break;

                case PlayerTeam.GreenTeam:
                    brushColor = Brushes.LawnGreen;
                    break;
            }
        }

        public override void ObjectRender(Graphics graphics)
        {
            graphics.DrawRectangle(new Pen(brushColor), (coordinates.X * GameBoard.TileSize + (GameBoard.TileSize / 8)) - 1, (coordinates.Y * GameBoard.TileSize + (GameBoard.TileSize / 8)) - 1, (sprite.Width * GameBoard.scaleFactor) + 1, (sprite.Height * GameBoard.scaleFactor) + 1);

            graphics.DrawImage(sprite, coordinates.X * GameBoard.TileSize + (GameBoard.TileSize / 8), coordinates.Y * GameBoard.TileSize + (GameBoard.TileSize / 8), sprite.Width * GameBoard.scaleFactor, sprite.Height * GameBoard.scaleFactor);
        }

        /// <summary>
        /// renders some of the stats for the unit under the marker
        /// </summary>
        /// <param name="graphics"></param>
        public void RenderUnitStats(Graphics graphics)
        {
            graphics.DrawString("" + name, new Font(Constant.fontType, Constant.markerFontSize), brushColor, new PointF(Constant.markerStatsX, Constant.markerStatsY));
            graphics.DrawString("Health: " + Health, new Font(Constant.fontType, Constant.markerFontSize), brushColor, new PointF(Constant.markerStatsX, Constant.markerStatsY + (Constant.markerFontSize + (Constant.textGap - 5))));
            graphics.DrawString("Move: " + move, new Font(Constant.fontType, Constant.markerFontSize), brushColor, new PointF(Constant.markerStatsX, Constant.markerStatsY + (Constant.markerFontSize + (Constant.textGap - 5)) * 2));
            graphics.DrawString("Armor: " + armor, new Font(Constant.fontType, Constant.markerFontSize), brushColor, new PointF(Constant.markerStatsX, Constant.markerStatsY + (Constant.markerFontSize + (Constant.textGap - 5)) * 3));
            graphics.DrawImage(sprite, Constant.targetUnitUiX, Constant.targetUnitUiY, 128, 128);
        }

        /// <summary>
        /// renders the stats of the selected unit
        /// </summary>
        /// <param name="graphics"></param>
        public void RenderSelectedUnitStats(Graphics graphics)
        {
            graphics.DrawString("" + name, new Font(Constant.fontType, Constant.selectedFontSize), brushColor, new PointF(Constant.selectedStatsX, Constant.selectedStatsY));
            graphics.DrawString("Health: " + Health, new Font(Constant.fontType, Constant.selectedFontSize), brushColor, new PointF(Constant.selectedStatsX, Constant.selectedStatsY + (Constant.selectedFontSize + Constant.textGap)));
            graphics.DrawString("Armor: " + Armor, new Font(Constant.fontType, Constant.selectedFontSize), brushColor, new PointF(Constant.selectedStatsX, Constant.selectedStatsY + (Constant.selectedFontSize + Constant.textGap) * 2));
            graphics.DrawString("Power: " + damage, new Font(Constant.fontType, Constant.selectedFontSize), brushColor, new PointF(Constant.selectedStatsX, Constant.selectedStatsY + (Constant.selectedFontSize + Constant.textGap) * 3));
            graphics.DrawString("Description: " + Description, new Font(Constant.fontType, Constant.selectedFontSize - 3), brushColor, new PointF(Constant.selectedStatsX, Constant.selectedStatsY + (Constant.selectedFontSize + Constant.textGap) * 6.5f));
            graphics.DrawImage(sprite, Constant.unitUiX, Constant.unitUiY, 128, 128);

            if (this is IRanged)
            {
                graphics.DrawString("Range: " + ((IRanged)this).Range, new Font(Constant.fontType, Constant.selectedFontSize), brushColor, new PointF(Constant.selectedStatsX, Constant.selectedStatsY + (Constant.selectedFontSize + Constant.textGap) * 4));
                graphics.DrawString("Moves Left: " + move, new Font(Constant.fontType, Constant.selectedFontSize), brushColor, new PointF(Constant.selectedStatsX, Constant.selectedStatsY + (Constant.selectedFontSize + Constant.textGap) * 5));
            }
            else
            {
                graphics.DrawString("Moves Left: " + move, new Font(Constant.fontType, Constant.selectedFontSize), brushColor, new PointF(Constant.selectedStatsX, Constant.selectedStatsY + (Constant.selectedFontSize + Constant.textGap) * 4));
            }
        }
    }
}
