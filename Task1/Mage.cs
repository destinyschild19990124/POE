using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    [Serializable]
    class Mage : Enemy
    {

        public Mage(int x,int y) : base(x, y, Tile.TileType.Enemy, 5, 5)
        {

        }

        public override Movement returnMove(Movement dir = Character.Movement.None)
        {
            return Character.Movement.None;
        }

        public override bool checkRange(Character target)
        {
            Boolean enemies_nearby = false;

            for(int i = 0; i < this.vision.Length; ++i)
            {
                if(vision[i] is Character)
                {
                    enemies_nearby = true;
                    break;
                }
            }

            return enemies_nearby;
        }

    }
}
