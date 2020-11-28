using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    [Serializable]
    class Hero : Character
    {

        public Hero(int x, int y,int hp) : base(x, y, Tile.TileType.Hero) {
            this.setHp(hp);
            this.setMaxHp(hp);
            this.setDamage(2);
        }

        public override Movement returnMove(Movement dir)
        {

            //Editted to accomodate for picking up items
            if(this.vision[(int)dir] is EmptyTile || this.vision[(int)dir] is Item)
            {
                return dir;
            }
            else
            {
                return Movement.None;
            }

        }

        public override string ToString()
        {
            string current_weapon = (weapon == null ? "Bare hands" : weapon.getTypeString());
            string weapon_range = (current_weapon == "Bare hands" ? "1" : weapon.getRange().ToString());
            string weapon_damage = (current_weapon == "Bare hands" ? "2" : weapon.getDamage().ToString());
            string weapon_durability = (current_weapon == "Bare hands" ? "" : weapon.getDurability().ToString());

            return "Player Stats:" + "\nHP: " + this.getHp() + "\nCurrent Weapon : " + current_weapon + "\nWeapon Range : " + weapon_range + "\nWeapon Damage : " + weapon_damage + (weapon_durability==""?"":("\nWeapon Durability : " + weapon_durability)) + "\nGold: " + gold_purse + "\n[" + this.x + "," + this.y + "]";
        }
    }
}
