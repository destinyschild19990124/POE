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
            return "Player Stats:" + "\nHP: " + this.getHp() + "\nDamage: " + damage + "\nGold: " + gold_purse + "\n[" + this.x + "," + this.y + "]";
        }
    }
}
