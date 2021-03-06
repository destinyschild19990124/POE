﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    [Serializable]
    class Map
    {
        private Random rnd = new Random();

        private Tile[,] map;
        private Hero hero;
        private Enemy[] enemies;
        private Item[] items;
        private int num_gold = 0;
        private int num_weapons = 0;
        private int width;
        private int height;


        public Map(int min_width,int max_width,int min_height,int max_height,int num_enemies,int num_gold,int num_weapons)
        {

            //max width = 13
            //max height = 13
            this.width = rnd.Next(min_width, max_width + 1);
            this.width = (this.width > 15 ? 15 : this.width);
            this.height = rnd.Next(min_height, max_height + 1);
            this.height = (this.height > 13 ? 13 : this.height);

            this.map = new Tile[height, width];

            //Check that the number of enemies spawned does not exceed the limit
            int max_num_enemies = ((width - 2) * (height - 2)) - 1;
            if (num_enemies > max_num_enemies)
            {
                num_enemies = max_num_enemies;
            }
            this.enemies = new Enemy[num_enemies];

            //Check that the number of gold spawned does not exceed the limit
            int max_num_gold = ((width - 2) * (height - 2)) - 1 - this.enemies.Length;
            if (num_gold > max_num_gold)
            {
                num_gold = max_num_gold;
            }
            this.num_gold = num_gold;

            //Check that the number of weapons spawned does not exceed the limit
            int max_num_weapons = ((width - 2) * (height - 2)) - 1 - this.enemies.Length - num_gold;
            if (num_weapons > max_num_weapons)
            {
                num_weapons = max_num_weapons;
            }
            this.num_weapons = num_weapons;


            this.items = new Item[num_gold+num_weapons];

            generateEmptyMap();
            populateEmptyMap();
            
        }

        private void generateEmptyMap()
        {
            for(int i= 0; i < height;++i)
            {
                for(int j = 0; j < width; ++j)
                {
                    if (i == 0 || i == (height - 1))
                    {
                        map[i, j] = new Obstacle(i, j);
                    }
                    else if (j == 0 || j == (width - 1))
                    {
                        map[i, j] = new Obstacle(i, j);
                    }
                    else
                    {
                        map[i, j] = new EmptyTile(i, j);
                    }
                }
            }
        }

        private void populateEmptyMap()
        {
            this.hero = (Hero)create(Tile.TileType.Hero, 0);
            map[hero.getY(), hero.getX()] = hero;

            for (int i = 0; i < enemies.Length; ++i)
            {
                //0 = Goblin, 1 = Mage
                int enemy_specification = rnd.Next(0, 3);

                if (enemy_specification == 0)
                {
                    enemies[i] = (Goblin)create(Tile.TileType.Enemy, enemy_specification);
                }
                else if(enemy_specification == 1)
                {
                    enemies[i] = (Mage)create(Tile.TileType.Enemy, enemy_specification);
                }
                else
                {
                    enemies[i] = (Leader)create(Tile.TileType.Enemy, enemy_specification);
                }
                map[enemies[i].getY(), enemies[i].getX()] = enemies[i];
            }

            for (int i = 0; i < this.num_gold; ++i)
            {
                items[i] = (Gold)create(Tile.TileType.Gold, 0);
                map[items[i].getY(), items[i].getX()] = items[i];
            }

            for (int i = this.num_gold; i < this.items.Length; ++i)
            {
                items[i] = (Weapon)create(Tile.TileType.Weapon, 0);
                map[items[i].getY(), items[i].getX()] = items[i];
            }

            updateVision();
        }

        private Tile create(Tile.TileType type,int specification)
        {
            int[] spawn_location = getSpawnPosition();

            if(type == Tile.TileType.Hero)
            {
                return new Hero(spawn_location[1], spawn_location[0], 10);
            }
            else if(type == Tile.TileType.Enemy)
            {
                
                if (specification == 0)
                {
                    return new Goblin(spawn_location[1], spawn_location[0]);
                }
                else if(specification == 1)
                {
                    return new Mage(spawn_location[1], spawn_location[0]);
                }
                else
                {
                    Leader l = new Leader(spawn_location[1], spawn_location[0]);
                    l.setTarget(this.getHero());
                    return l;
                }
            }
            else if(type == Tile.TileType.Gold)
            {
                return new Gold(spawn_location[1], spawn_location[0]);
            }
            else if(type == Tile.TileType.Weapon)
            {
                //0 = melee weapon 1 = ranged weapon
                int super_type = rnd.Next(0, 2);
                if (super_type == 0)
                {
                    //2 = dagger 3 = longsword
                    int sub_type = rnd.Next(2, 4);
                    if (sub_type == 2)
                    {
                        return new MeleeWeapon(MeleeWeapon.Types.Dagger, 'd', spawn_location[1], spawn_location[0]);
                    }
                    else
                    {
                        return new MeleeWeapon(MeleeWeapon.Types.Longsword, 'l', spawn_location[1], spawn_location[0]);
                    }
                }
                else
                {
                    //2 = longbow 3 = rifle
                    int sub_type = rnd.Next(2, 4);
                    if (sub_type == 2)
                    {
                        return new RangedWeapon(RangedWeapon.Types.Longbow, 'b', spawn_location[1], spawn_location[0]);
                    }
                    else
                    {
                        return new RangedWeapon(RangedWeapon.Types.Rifle, 'r', spawn_location[1], spawn_location[0]);
                    }
                }
            }
            else
            {
                return new EmptyTile(spawn_location[1], spawn_location[0]);
            }
        }


        private void updateVision()
        {
            if (!hero.isVisionLocked())
            {
                hero.setVision(returnVision(hero.getX(), hero.getY()));
                int range = (hero.getWeapon()==null?1:hero.getWeapon().getRange());
                hero.setAttackingVision(returnAttackingVision(hero.getX(), hero.getY(),range));
            }

            for (int i = 0; i < enemies.Length; ++i)
            {
                if (!enemies[i].isVisionLocked())
                {
                    enemies[i].setVision(returnVision(enemies[i].getX(), enemies[i].getY()));
                    int range = (enemies[i].getWeapon() == null ? 1 : enemies[i].getWeapon().getRange());
                    enemies[i].setAttackingVision(returnAttackingVision(enemies[i].getX(), enemies[i].getY(),range));
                }
            }
        }

        public void removeFromMap(Tile type)
        {
            
            if(type.getTileType() == Tile.TileType.Enemy)
            {
                Enemy[] new_list = new Enemy[enemies.Length-1];
                int index = 0;

                for(int i = 0; i < enemies.Length; ++i)
                {
                    if (enemies[i].isDead())
                    {
                        map[enemies[i].getY(), enemies[i].getX()] = new EmptyTile(enemies[i].getY(), enemies[i].getX());
                    }
                    else
                    {
                        new_list[index] = enemies[i];
                        ++index;
                    }
                }

                enemies = new_list;
                updateVision();
            }
            else if(type.getTileType() == Tile.TileType.Gold || type.getTileType() == Tile.TileType.Weapon)
            {
                Item[] new_list = new Item[items.Length - 1];
                int index = 0;

                for (int i = 0; i < items.Length; ++i)
                {
                    if (items[i].isPickedUp())
                    {
                        map[items[i].getY(), items[i].getX()] = new EmptyTile(items[i].getY(), items[i].getX());
                    }
                    else
                    {
                        new_list[index] = items[i];
                        ++index;
                    }
                }

                items = new_list;
                updateVision();
            }
            else if(type.getTileType() == Tile.TileType.Hero)
            {
                map[hero.getY(), hero.getX()] = new EmptyTile(hero.getY(),hero.getX());
                updateVision();
            }
        }

        public void updateCharaterPosition(Tile character,Character.Movement direction)
        {
            Character c = (Character)map[character.getY(), character.getX()];
            EmptyTile emp;
            Tile at_position = null;

            switch (direction)
            {
                case Character.Movement.Up:
                    at_position = this.getItemAtPosition(character.getY() - 1, character.getX());
                    if ((c is Hero || c is Goblin || c is Leader) && at_position != null )
                    {  
                        c.pickUp((Item)at_position);
                    }

                    emp = (EmptyTile)map[character.getY() - 1, character.getX()];
                    map[character.getY() - 1, character.getX()] = c;
                    map[character.getY(), character.getX()] = emp;
                    c.move(Character.Movement.Up);
                    emp.setY(emp.getY() + 1);
                    break;
                case Character.Movement.Down:
                    at_position = this.getItemAtPosition(character.getY() + 1, character.getX());
                    if ((c is Hero || c is Goblin || c is Leader) && at_position != null)
                    {
                        c.pickUp((Item)at_position);
                    }

                    emp = (EmptyTile)map[character.getY() + 1, character.getX()];
                    map[character.getY() + 1, character.getX()] = c;
                    map[character.getY(), character.getX()] = emp;
                    c.move(Character.Movement.Down);
                    emp.setY(emp.getY() - 1);
                    break;
                case Character.Movement.Left:
                    at_position = this.getItemAtPosition(character.getY(), character.getX() - 1);
                    if ((c is Hero || c is Goblin || c is Leader) && at_position != null)
                    {
                        c.pickUp((Item)at_position);
                    }

                    emp = (EmptyTile)map[character.getY(), character.getX()-1];
                    map[character.getY(), character.getX()-1] = c;
                    map[character.getY(), character.getX()] = emp;
                    c.move(Character.Movement.Left);
                    emp.setX(emp.getX() + 1);
                    break;
                case Character.Movement.Right:
                    at_position = this.getItemAtPosition(character.getY(), character.getX() + 1);
                    if ((c is Hero || c is Goblin || c is Leader) && at_position != null)
                    {
                        c.pickUp((Item)at_position);
                    }

                    emp = (EmptyTile)map[character.getY(), character.getX()+1];
                    map[character.getY(), character.getX()+1] = c;
                    map[character.getY(), character.getX()] = emp;
                    c.move(Character.Movement.Right);
                    emp.setX(emp.getX() - 1);
                    break;
            }

            this.updateVision();

        }

        private Tile[] returnVision(int x,int y)
        {
            Tile[] vision = new Tile[8];

            vision[0] = map[y - 1, x];  //North
            vision[1] = map[y + 1, x];  //South
            vision[2] = map[y, x - 1];  //West
            vision[3] = map[y, x + 1];  //East

            //Mage vision update
            vision[4] = map[y - 1, x + 1];  //North East
            vision[5] = map[y + 1, x + 1];  //South East
            vision[6] = map[y + 1, x - 1];  //South West
            vision[7] = map[y - 1, x - 1];  //North West

            return vision;

        }

        private Tile[] returnAttackingVision(int x,int y,int range)
        {
            Tile[] attacking_vision = new Tile[4*range];
            Tile[] trimmed_attacking_vision;
            int index = 0;
            int out_of_bounds = 0;

            //North direction
            for(int i = 0; i < range; ++i)
            {
                try
                {
                    attacking_vision[index] = map[y - 1 - i, x];
                    ++index;
                }catch(Exception e )
                {
                    ++out_of_bounds;
                }
            }

            //South direction
            for (int i = 0; i < range; ++i)
            {
                try
                {
                    attacking_vision[index] = map[y + 1 + i, x];
                    ++index;
                }
                catch (Exception e)
                {
                    ++out_of_bounds;
                }
            }

            //West direction
            for (int i = 0; i < range; ++i)
            {
                try
                {
                    attacking_vision[index] = map[y, x - 1 - i];
                    ++index;
                }
                catch (Exception e)
                {
                    ++out_of_bounds;
                }
            }

            //East direction
            for (int i = 0; i < range; ++i)
            {

                try
                {
                    attacking_vision[index] = map[y, x + 1 + i];
                    ++index;
                }
                catch (Exception e)
                {
                    ++out_of_bounds;
                }
            }

            trimmed_attacking_vision = new Tile[(4 * range) - out_of_bounds];

            for(int i = 0; i < trimmed_attacking_vision.Length; ++i)
            {
                trimmed_attacking_vision[i] = attacking_vision[i];
            }
            attacking_vision = trimmed_attacking_vision;

            return attacking_vision;
        }

        private int[] getSpawnPosition()
        {
            //NOTE TO SELF - Maybe don't use recursion next time to avoid repetition ( use a list to store visited locations )

            int x_position = rnd.Next(1, width);
            int y_position = rnd.Next(1, height);

            if(map[y_position,x_position] is EmptyTile)
            {
                int[] s_point = new int[2];
                s_point[0] = y_position;
                s_point[1] = x_position;

                return s_point;
            }
            else
            {
                return getSpawnPosition();
            }
        }

        public Item getItemAtPosition(int y, int x)
        {
            Item drop = null;

            for(int i = 0; i < items.Length; ++i)
            {
                if(items[i].getX() == x && items[i].getY() == y)
                {
                    drop = items[i];
                    drop.setPickedUp(true);
                    this.removeFromMap(drop);
                    break;
                }
            }

            return drop;
        }

        public void setMap(Tile[,] map)
        {
            this.map = map;
        }

        public Tile[,] getMap()
        {
            return this.map;
        }

        public void setHero(Hero hero)
        {
            this.hero = hero;
        }

        public Hero getHero()
        {
            return this.hero;
        }

        public void setEnemies(Enemy[] enemies)
        {
            this.enemies = enemies;
        }

        public Enemy[] getEnemies()
        {
            return this.enemies;
        }

        public void setItems(Item[] items)
        {
            this.items = items;
        }

        public Item[] getItems()
        {
            return this.items;
        }


        public void setWidth(int width)
        {
            this.width = width;
        }

        public int getWidth()
        {
            return this.width;
        }

        public void setHeight(int height)
        {
            this.height = height;
        }

        public int getHeight()
        {
            return this.height;
        }
    }
}
