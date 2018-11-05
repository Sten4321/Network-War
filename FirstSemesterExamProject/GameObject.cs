using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace FirstSemesterExamProject
{
    abstract class GameObject
    {
        protected Image sprite;
        protected bool hasCollision;
        protected PointF coordinates;

        #region Animation;
        protected string[] images;
        protected List<Image> frames;
        protected float frameIndex;
        protected float animationSpeed = Constant.animationSpeed; 
                #endregion

        public PointF Coordinates
        {
            get { return coordinates; }
            set { coordinates = value; }
        }

        public GameObject()
        {

        }

        /// <summary>
        /// Gameobject constructor that takes multiple ImagePaths for animations
        /// </summary>
        /// <param name="coordinates"></param>
        /// <param name="ImagePath"></param>
        /// <param name="hasCollision"></param>
        public GameObject(PointF coordinates, string ImagePath, bool hasCollision)
        {
            this.coordinates = coordinates;
            this.hasCollision = hasCollision;

            images = ImagePath.Split(';');//splits all imagepaths, whenever a ';' is typed. Fx: img1;img2;img3 
            frames = new List<Image>();

            foreach (string image in images)
            {
                frames.Add(Image.FromFile(image));
            }
            this.sprite = this.frames[0];//default sprite

        }


        public abstract void ObjectRender(Graphics graphics);

        /// <summary>
        /// Updates the animation
        /// </summary>
        /// <param name="deltaTime"></param>
        public virtual void UpdateAnimation(float deltaTime)
        {

            frameIndex += deltaTime * animationSpeed;


            if (frameIndex >= frames.Count)
            {
                frameIndex = 0;
            }
            sprite = frames[(int)frameIndex];
        }

        //public abstract void ObjectTick(float deltaTime);


    }
}
