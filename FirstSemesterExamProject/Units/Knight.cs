using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstSemesterExamProject
{
    class Knight : Unit
    {
        protected int range;

        /// <summary>
        /// Constructor for custom Knight
        /// </summary>
        /// <param name="name"></param>
        /// <param name="health"></param>
        /// <param name="armor"></param>
        /// <param name="move"></param>
        /// <param name="damage"></param>
        /// <param name="team"></param>
        /// <param name="coordinates"></param>
        /// <param name="ImagePath"></param>
        public Knight(string name, int health, int armor, int move, int damage, PlayerTeam team, PointF coordinates, string ImagePath) : base(name, health, armor, move, damage, team, coordinates, ImagePath)
        {
            this.range = Constant.knightRange;
        }

        /// <summary>
        /// standeart knight constructor, need only team and coordinates.
        /// </summary>
        /// <param name="team"></param>
        /// <param name="coordinates"></param>
        public Knight(PlayerTeam team, PointF coordinates) : base(Constant.knightName, Constant.knightHealth, Constant.knightArmor, Constant.knightMove, Constant.knightDamage, team, coordinates, Constant.knightImagePath)
        {
            this.animationSpeed= Constant.animationSpeed -6;
            this.range = Constant.knightRange;
            this.description = "A standard armored unit, with\nmedium-high damage and a large health pool";

        }

        public override void Die()
        {
            base.Die();
        }

        public override void Attack(Unit enemy)
        {
            //if armor is 1 and you hot more than 1 the damage will only hit for 1
            int damageDealt = this.damage - enemy.Armor;
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
            if (enemy.Armor>=10)
            {
                SoundEngine.PlaySound(Constant.knightSoundArmor);
            }
            SoundEngine.PlaySound(Constant.knightSound);

            //removes all further moves the unit might have, for this turn.
            base.Attack(enemy);

        }
    }
}
