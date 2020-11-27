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
            return this.GetType().Name +" at ["+ this.x + ", " + this.y + "]  (" + damage + " DMG)  (" + this.hp + " HP)";
        }

    }
}
