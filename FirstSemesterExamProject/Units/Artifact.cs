using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace FirstSemesterExamProject
{
    class Artifact : Unit, IRanged, IHeal
    {
        protected int range;

        /// <summary>
        /// Constructor for custom Artifact
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
        public Artifact(int range, string name, int health, int armor, int move, int damage, PlayerTeam team, PointF coordinates, string ImagePath) : base(name, health, armor, move, damage, team, coordinates, ImagePath)
        {
            this.range = range;
        }

        /// <summary>
        /// standeart artifact constructor, need only team and coordinates.
        /// </summary>
        /// <param name="team"></param>
        /// <param name="coordinates"></param>
        public Artifact(PlayerTeam team, PointF coordinates) : base(Constant.artifactName, Constant.artifactHealth, Constant.artifactArmor, Constant.artifactMove, Constant.artifactDamage, team, coordinates, Constant.artifactImagePath)
        {
            this.animationSpeed = Constant.animationSpeed - 5;
            this.range = Constant.artifactRange;
            this.description = "A powerful, heavily amored \nlong-ranged Unit with ranged attack and healing\nabilities. Ignores enemy armor completely.";

        }

        public int Range
        {
            get { return range; }
        }

        public override void Die()
        {
            base.Die();
        }

        /// <summary>
        /// Attack funktion for artifact uniten
        /// artifact ignores enemy armor! armor is not included in calculation
        /// </summary>
        /// <param name="enemy"></param>
        public override void Attack(Unit enemy)
        {
            //damage to enemy
            if (enemy.Team != team)
            {

                int damageDealt = this.damage;
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
                SoundEngine.PlaySound(Constant.artifactAttackSound);
                //removes all further moves the unit might have, for this turn.
                base.Attack(enemy);

            }
            else if (enemy.Team == team && enemy.Health < enemy.MaxHealth)
            {
                //healing to ally
                int damageHealed = (this.damage / 2);

                //can't heal more than maxs health
                if ((damageHealed + enemy.Health) > enemy.MaxHealth)
                {
                    enemy.Health = enemy.MaxHealth;
                }
                else
                {
                    enemy.Health += damageHealed;
                }
                SoundEngine.PlaySound(Constant.artifactHealSound);
                base.Attack(enemy);
            }
        }
        public override string ToString()
        {
            return "Artifact" + base.ToString();
        }
    }
}
