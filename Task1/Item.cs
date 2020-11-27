using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    [Serializable]
    abstract class Item : Tile
    {

        private Boolean picked_up = false;

        public Item(int x,int y,TileType type) : base(x, y,type)
        {

        }

        public abstract override string ToString();

        public void setPickedUp(Boolean picked_up)
        {
            this.picked_up = picked_up;
        }

        public Boolean isPickedUp()
        {
            return this.picked_up;
        }


    }
}
