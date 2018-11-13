using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstSemesterExamProject
{
    class Archer : Unit, IRanged
    {
        protected int range;

        /// <summary>
        /// Constructor for custom Archer
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
        public Archer(int range, string name, int health, int armor, int move, int damage, PlayerTeam team, PointF coordinates, string ImagePath) : base(name, health, armor, move, damage, team, coordinates, ImagePath)
        {
            this.range = range;
        }

        /// <summary>
        /// standeart archer constructor, need only team and coordinates.
        /// </summary>
        /// <param name="team"></param>
        /// <param name="coordinates"></param>
        public Archer(PlayerTeam team, PointF coordinates) : base(Constant.archerName, Constant.archerHealth, Constant.archerArmor, Constant.archerMove, Constant.archerDamage, team, coordinates, Constant.archerImagePath)
        {
            this.animationSpeed = Constant.animationSpeed - 6;
            this.range = Constant.archerRange;
            this.description = "A ranged unit with medium range.\nDeals medium-high damage but deals reduced \ndamage against armored units.";

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
            int damageDealt = this.damage - (enemy.Armor * 2); 
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
            if (enemy.Armor >= 10)
            {
                SoundEngine.PlaySound(Constant.archerSoundArmor);
            }
            else
            {
                SoundEngine.PlaySound(Constant.archerSound);
            }
            base.Attack(enemy);

        }

        public override string ToString()
        {
            return "Archer" + base.ToString();
        }
    }
}
