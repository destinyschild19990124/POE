using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    [Serializable]
    class Goblin : Enemy
    {

        public Goblin(int x,int y) : base(x, y, Tile.TileType.Enemy, 1, 10) { this.weapon = new MeleeWeapon(MeleeWeapon.Types.Dagger, 'd'); }

        public override Movement returnMove(Character.Movement direction)
        {
            int[] possible_moves = { 0, 1, 2, 3 };
            Boolean move_found = false;
            Character.Movement dir = Character.Movement.None;


            while (!move_found)
            {
                dir = (Character.Movement)possible_moves[rnd.Next(0,possible_moves.Length)];

                if (this.vision[(int)dir] is EmptyTile || this.vision[(int)dir] is Item)  // Updated to pick up items
                {
                    move_found = true;

                }else if (possible_moves.Length != 1)
                {
                    
                    int[] new_possible_moves = new int[possible_moves.Length - 1];
                    int index = 0;

                    for(int i = 0; i < possible_moves.Length; ++i)
                    {
                        if (possible_moves[i] != (int)dir)
                        {
                            new_possible_moves[index] = possible_moves[i];
                            ++index;
                        }
                    }

                    possible_moves = new_possible_moves;
                }
                else
                {
                    dir = Character.Movement.None;
                    move_found = true;
                }

            }


            return dir;

        }


    }
}
