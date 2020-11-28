using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    [Serializable]
    class RangedWeapon : Weapon
    {

        public enum Types
        {
            Rifle,
            Longbow
        }

        protected string type_string;

        public RangedWeapon(Types ranged_type, char symbol, int x = 0, int y = 0) : base(x, y, symbol)
        {
            if (ranged_type == Types.Rifle)
            {
                this.type_string = "Rifle";
                this.durability = 3;
                this.range = 3;
                this.damage = 5;
                this.cost = 7;

            }
            else if (ranged_type == Types.Longbow)
            {
                this.type_string = "Longbow";
                this.durability = 4;
                this.range = 2;
                this.damage = 4;
                this.cost = 6;
            }
        }

        public RangedWeapon(Types ranged_type,int durability, char symbol, int x = 0, int y = 0) : base(x, y, symbol)
        {
            if (ranged_type == Types.Rifle)
            {
                this.type_string = "Rifle";
                this.durability = durability;
                this.range = 3;
                this.damage = 5;
                this.cost = 7;

            }
            else if (ranged_type == Types.Longbow)
            {
                this.type_string = "Longbow";
                this.durability = durability;
                this.range = 2;
                this.damage = 4;
                this.cost = 6;
            }
        }

        public override int getRange()
        {
            return base.getRange();
        }


        public override string ToString()
        {
            return this.type_string;
        }

    }
}
