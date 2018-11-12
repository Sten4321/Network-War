using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace FirstSemesterExamProject
{
    class Cleric : Unit, IHeal
    {
        protected int range;

        /// <summary>
        /// Constructor for custom Cleric
        /// </summary>
        /// <param name="name"></param>
        /// <param name="health"></param>
        /// <param name="armor"></param>
        /// <param name="move"></param>
        /// <param name="damage"></param>
        /// <param name="team"></param>
        /// <param name="coordinates"></param>
        /// <param name="ImagePath"></param>
        public Cleric(string name, int health, int armor, int move, int damage, PlayerTeam team, PointF coordinates, string ImagePath) : base(name, health, armor, move, damage, team, coordinates, ImagePath)
        {
            this.range = Constant.clericRange;
        }

        /// <summary>
        /// standeart cleric constructor, need only team and coordinates.
        /// </summary>
        /// <param name="team"></param>
        /// <param name="coordinates"></param>
        public Cleric(PlayerTeam team, PointF coordinates) : base(Constant.clericName, Constant.clericHealth, Constant.clericArmor, Constant.clericMove, Constant.clericDamage, team, coordinates, Constant.clericImagePath)
        {
            this.animationSpeed = Constant.animationSpeed - 6;
            this.range = Constant.clericRange;
            this.description = "A close ranged healer, with \nmedium-low health and medium suvivability.";

        }

        public override void Die()
        {
            base.Die();
        }

        public override void Attack(Unit teamMember)
        {
            if (teamMember.Team == team && teamMember.Health < teamMember.MaxHealth)
            {
                int damageHealed = this.damage;

                //can't heal more than maxs health
                if ((damageHealed + teamMember.Health) > teamMember.MaxHealth)
                {
                    teamMember.Health = teamMember.MaxHealth;
                }
                else
                {
                    teamMember.Health += damageHealed;
                }

                System.Diagnostics.Debug.WriteLine("TMHealth:" + teamMember.Health + " DH:" + damageHealed);
                //removes all further moves the unit might have, for this turn.
                base.Attack(teamMember);

                SoundEngine.PlaySound(Constant.clericSound);
            }
        }
        public override string ToString()
        {
            return "Cleric" + base.ToString();
        }
    }
}
