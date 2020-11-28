using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    [Serializable]
    class MeleeWeapon : Weapon
    {

        public enum Types
        {
            Dagger,
            Longsword
        }


        public MeleeWeapon(Types melee_type,char symbol,int x = 0,int y = 0) : base(x, y, symbol)
        {
            if(melee_type == Types.Dagger)
            {
                this.type_string = "Dagger";
                this.durability = 10;
                this.damage = 3;
                this.cost = 3;

            }else if(melee_type == Types.Longsword)
            {
                this.type_string = "Longsword";
                this.durability = 6;
                this.damage = 4;
                this.cost = 5;
            }
        }

        public MeleeWeapon(Types melee_type,int durability, char symbol, int x = 0, int y = 0) : base(x, y, symbol)
        {
            if (melee_type == Types.Dagger)
            {
                this.type_string = "Dagger";
                this.durability = durability;
                this.damage = 3;
                this.cost = 3;

            }
            else if (melee_type == Types.Longsword)
            {
                this.type_string = "Longsword";
                this.durability = durability;
                this.damage = 4;
                this.cost = 5;
            }
        }

        public override int getRange()
        {
            return 1;
        }


        public override string ToString()
        {
            return this.type_string;
        }
    }
}
