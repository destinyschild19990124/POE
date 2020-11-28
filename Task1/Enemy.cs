using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    [Serializable]
    abstract class Enemy : Character
    {
        protected Random rnd = new Random();

        public Enemy(int x, int y, Tile.TileType type,int damage,int hp) : base(x, y, type) 
        {
            setDamage(damage);
            setHp(hp);
            setMaxHp(hp);
        }

        public override string ToString()
        {
            string current_weapon = (weapon == null ? "Bare hands" : weapon.getTypeString());
            string weapon_damage = (current_weapon == "Bare hands" ? "2" : weapon.getDamage().ToString());
            string weapon_durability = (current_weapon == "Bare hands" ? "" : weapon.getDurability().ToString());

            string name = (current_weapon=="Bare hands"?"Barehanded: ":"Equipped: ") + this.GetType().Name +"("+this.getHp()+"/"+this.getMaxHp()+"HP) at ["+this.getX()+","+this.getY()+"] ";

            if(current_weapon!="Bare hands")
            {
                name += "with " + current_weapon + " (" + weapon_durability + " x " + weapon_damage + " DMG)";
            }

            return name;
        }

    }
}
