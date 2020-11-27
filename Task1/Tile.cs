using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    [Serializable]
    abstract class Tile
    {

        public enum TileType
        {
            Hero,Enemy,Gold,Weapon
        }

        protected int x { get; set; }
        
        protected int y;
        protected TileType type;

        public Tile(int x,int y,TileType type)
        {
            setX(x);
            setY(y);
            setTileType(type);
        }

        public Tile(int x, int y)
        {
            setX(x);
            setY(y);
        }

        public int getX()
        {
            return x;
        }

        public void setX(int x)
        {
            this.x = x;
        }

        public int getY()
        {
            return y;
        }

        public void setY(int y)
        {
            this.y = y;
        }

        public TileType getTileType()
        {
            return type;
        }

        public void setTileType(TileType type)
        {
            this.type = type;
        }
    }
}
