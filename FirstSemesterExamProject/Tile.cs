using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstSemesterExamProject
{
    class Tile
    {
        public Image tileSprite;
        public bool hasCollision;
        public PointF coordinates;

        public Tile(PointF coordinates, string ImagePath, bool hasCollision)
        {
            this.coordinates = coordinates;
            this.tileSprite = Image.FromFile(ImagePath);
            this.hasCollision = hasCollision;
        }

        public void RenderTile(Graphics graphics, float tileSize, int X, int Y)
        {
            graphics.DrawImage(tileSprite, X * tileSize, (Y * tileSize), tileSize, tileSize);
        }
    }
}
