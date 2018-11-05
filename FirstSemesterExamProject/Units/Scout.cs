using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstSemesterExamProject
{
    class Scout : Unit
    {
        protected int range;
        protected bool canAttack = true;

        /// <summary>
        /// propety for can attack
        /// </summary>
        public bool CanAttack
        {
            get { return canAttack; }
            set { canAttack = value; }
        }

        public Scout(string name, int health, int armor, int move, int damage, PlayerTeam team, PointF coordinates, string ImagePath) : base(name, health, armor, move, damage, team, coordinates, ImagePath)
        {

            this.range = Constant.scoutRange;

        }
        public Scout(PlayerTeam team, PointF coordinates) : base(Constant.scoutName, Constant.scoutHealth, Constant.scoutArmor, Constant.scoutMove, Constant.scoutDamage, team, coordinates, Constant.scoutImagePath)
        {
            this.animationSpeed = Constant.animationSpeed - 5;
            this.range = Constant.scoutRange;
            this.description = "A melee unit with high mobility\nand low damage. Moves do not cost player\n moves. Deals increased damage to Artifacts.";

        }
        public override void Die()
        {
            base.Die();
        }
        public override void Attack(Unit enemy)
        {
            if (canAttack)
            {
                int damageDealt;
                if (enemy is Artifact)
                {
                    damageDealt = this.damage + Constant.scoutBonusDamage;
                }
                else
                {
                    damageDealt = this.damage - enemy.Armor;
                }
                //if armor is 1 and you hot more than 1 the damage will only hit for 1
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
                    SoundEngine.PlaySound(Constant.scoutSoundArmor);
                }
                SoundEngine.PlaySound(Constant.scoutSound);
                this.move--;
                if (this.move < 0)
                {
                    this.move = 0;
                }
                canAttack = false;

            }
        }
    }
}
