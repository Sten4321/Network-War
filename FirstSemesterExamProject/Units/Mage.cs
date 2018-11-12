using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstSemesterExamProject
{    
    class Mage : Unit, IRanged
    {
        protected int range;

        /// <summary>
        /// Constructor for custom Mage
        /// </summary>
        /// <param name="range"></param>
        /// <param name="name"></param>
        /// <param name="health"></param>
        /// <param name="armor"></param>
        /// <param name="move"></param>
        /// <param name="damage"></param>
        /// <param name="team"></param>
        /// <param name="coordinates"></param>
        /// <param name="ImagePath"></param>
        public Mage(int range, string name, int health, int armor, int move, int damage, PlayerTeam team, PointF coordinates, string ImagePath) : base(name, health, armor, move, damage, team, coordinates, ImagePath)
        {
            this.range = range;
        }

        /// <summary>
        /// standard Mage constructor, need only team and coordinates.
        /// </summary>
        /// <param name="team"></param>
        /// <param name="coordinates"></param>
        public Mage(PlayerTeam team, PointF coordinates) : base(Constant.mageName, Constant.mageHealth, Constant.mageArmor, Constant.mageMove, Constant.mageDamage, team, coordinates, Constant.mageImagePath)
        {
            this.animationSpeed = Constant.animationSpeed - 5;
            this.range = Constant.mageRange;
            this.description = "A ranged unit with medium range.\nDoes increased damage against armored units.\nHas low mobility and no armor.";
        }

        public int Range
        {
            get { return range; }
        }

        public override void Die()
        {
            base.Die();
        }

        public override void Attack(Unit enemy)
        {
            int damageDealt = this.damage + (enemy.Armor * 2);
            if (damageDealt <= 0)
            {
                damageDealt = 1;
            }
            enemy.Health -= damageDealt;
            System.Diagnostics.Debug.WriteLine("EnHealth:" + enemy.Health + " DD:" + damageDealt);
            if (enemy.Health <= 0)
            {
                enemy.Health = 0;
                enemy.Die();
            }

            //removes all further moves the unit might have, for this turn.
            base.Attack(enemy);
            SoundEngine.PlaySound(Constant.mageSound);

        }
        public override string ToString()
        {
            return "Mage" + base.ToString();
        }
    }
}

