using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    [Serializable]
    class Leader : Enemy
    {
        Tile target;

        public Leader(int x,int y) : base(x, y, TileType.Enemy, 2, 20) { this.weapon = new MeleeWeapon(MeleeWeapon.Types.Longsword, 'l'); }

        public void setTarget(Tile target)
        {
            this.target = target;
        }

        public Tile getTarget()
        {
            return this.target;
        }

        public override Movement returnMove(Movement direction = 0)
        {
            int target_x = target.getX();
            int target_y = target.getY();

            //The first option should be moving on the axis (x or y) with the shortest distance to the target
            //The second option should therefore be moving on the other axis

            int x_difference = Math.Abs(target_x - this.getX());
            int y_difference = Math.Abs(target_y - this.getY());


            Movement second_option = Movement.None;

            if (x_difference <= y_difference)
            {
                if(target_x - this.getX() > 0)
                {
                    direction = Movement.Right;
                    second_option = (target_y > this.getY() ? Movement.Down : Movement.Up);
                    
                }
                else if(target_x - this.getX() < 0)
                {
                    direction = Movement.Left;
                    second_option = (target_y > this.getY() ? Movement.Down : Movement.Up);
                }
                else
                {
                    direction = (target_y > this.getY() ? Movement.Down : Movement.Up);
                }
            }
            else
            {
                if (target_y - this.getY() > 0)
                {
                    direction = Movement.Down;
                    second_option = (target_x > this.getX() ? Movement.Right : Movement.Left);
                }
                else if(target_y - this.getY() < 0)
                {
                    direction = Movement.Up;
                    second_option = (target_x > this.getX() ? Movement.Right : Movement.Left);
                }
                else
                {
                    direction = (target_x > this.getX() ? Movement.Right : Movement.Left);
                }
            }

            if (this.vision[(int)direction] is EmptyTile || this.vision[(int)direction] is Item)  //Updated to pick up items
            {
                return direction;
            }
            else if(this.vision[(int)direction].getX() == target_x && this.vision[(int)direction].getY() == target_y) // Standing right next to target already
            {
                return Movement.None;
            }
            else if(this.vision[(int)second_option] is EmptyTile || this.vision[(int)direction] is Item)  //Updated to pick up items
            {
                return second_option;
            }
            else if (this.vision[(int)second_option].getX() == target_x && this.vision[(int)second_option].getY() == target_y) // Standing right next to target already
            {
                return Movement.None;
            }
            else
            {



                Boolean move_found = false;
                int[] excluded_directions = { (int)direction, (int)second_option };
                Movement dir = Movement.None;

                while (!move_found)
                {
                    int[] available_moves = new int[4-excluded_directions.Length];
                    int index = 0;

                    for(int i = 0; i <= 3; ++i)
                    {
                        Boolean excluded = false;
                        for(int j = 0; j < excluded_directions.Length; ++j)
                        {
                            if (j == i)
                            {
                                excluded = true;
                            }
                        }
                        if (!excluded)
                        {
                            available_moves[index] = i;
                            ++index;
                        }

                    }


                    dir = (Character.Movement)available_moves[rnd.Next(0, available_moves.Length)];

                    if (this.vision[(int)dir] is EmptyTile || this.vision[(int)dir] is Item)  //Updated to pick up items
                    {
                        move_found = true;

                    }
                    else if (available_moves.Length > 1)
                    {

                        int[] new_excluded_directions = new int[excluded_directions.Length + 1];

                        for (int i = 0; i < excluded_directions.Length; ++i)
                        {
                            new_excluded_directions[i] = excluded_directions[i];
                        }
                        new_excluded_directions[new_excluded_directions.Length - 1] = (int)dir;
                        excluded_directions = new_excluded_directions;
                    }
                    else
                    {
                        move_found = true;
                        dir = Movement.None;
                    }


                }

                return dir;
            }
        }

        

    }
}
