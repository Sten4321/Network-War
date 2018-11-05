using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace FirstSemesterExamProject
{
    abstract class GameState
    {
        public GameState(Window window)
        {

        }

        public abstract void Render(Graphics graphics);

        public abstract void Tick(float deltaTime);
    }
}