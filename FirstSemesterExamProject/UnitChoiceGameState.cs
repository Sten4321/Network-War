using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstSemesterExamProject
{
    class UnitChoiceGameState : GameState
    {

        public UnitChoiceGameState(Window window) : base(window)
        {

        }

        public override void Render(Graphics graphics)
        {

            #region MainScreenGraphics;
            graphics.DrawImage(Image.FromFile(Constant.menuScreen), 0, 0, 1266, 640);
            //left sprites
            graphics.DrawImage(Image.FromFile(@"Sprites/Units/Cleric/cleric.png"),250,250, 128, 128);
            graphics.DrawImage(Image.FromFile(@"Sprites/Units/Knight/knight1.png"), 150, 250, 128, 128);
            graphics.DrawImage(Image.FromFile(@"Sprites/Units/Archer/archer1.png"), 50, 250, 128, 128);

            //right sprites
            graphics.DrawImage(Image.FromFile(@"Sprites/Units/Scout/scout.png"), 875, 250, 128, 128);
            graphics.DrawImage(Image.FromFile(@"Sprites/Units/Mage/mage6.png"), 975, 250, 128, 128);
            graphics.DrawImage(Image.FromFile(@"Sprites/Units/Artifact/artifact2.png"), 1075, 250, 128, 128);
#endregion

        }

        public override void Tick(float deltaTime)
        {

        }
        

    }
}
