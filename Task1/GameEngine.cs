using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class GameEngine
    {

        private Map map;
        private Shop shop;
        private int damage_taken;

        public GameEngine(int min_width,int max_width,int min_height,int max_height,int num_enemies,int num_gold,int num_weapons)
        {
            map = new Map(min_width, max_width, min_height, max_height, num_enemies,num_gold,num_weapons);
            this.shop = new Shop(map.getHero());
            this.saveGame(); // Initial reset point
        }

        public GameEngine()
        {
            map = this.loadGame();
            this.shop = new Shop(map.getHero());
        }

        public Tile[,] getMapView()
        {
            return map.getMap();
        }

        public Shop getShop()
        {
            return this.shop;
        }

        public int getWidth()
        {
            return map.getWidth();
        }

        public int getHeight()
        {
            return map.getHeight();
        }

        public string getHeroStats()
        {
            return map.getHero().ToString();
        }

        public string getEnemiesRemaining()
        {
            string info = "";

            for(int i = 0; i < map.getEnemies().Length; ++i)
            {
                if (i <= 5)
                {
                    info += map.getEnemies()[i].ToString() + "\n\n";
                }
            }

            if (map.getEnemies().Length > 6)
            {
                info += "+" + (map.getEnemies().Length - 6) + " more enem" + ((map.getEnemies().Length - 6)>1?"ies":"y");
            }

            return info;
        }

        public string getAttackingOptions()
        {
            string info = "";

            if (!map.getHero().isDead())
            {

                for(int i = 0; i < map.getHero().getAttackingVision().Length; ++i)
                {
                    if(map.getHero().getAttackingVision()[i] is Enemy)
                    {
                        info += "["+getDirectionAndRange(map.getHero().getAttackingVision()[i]) +"]  " + map.getHero().getAttackingVision()[i].ToString() + "\n\n";
                    }
                }
            }

            return info;
        }

        public string getDirectionAndRange(Tile t)
        {
            int hero_x = map.getHero().getX();
            int hero_y = map.getHero().getY();
            int range = 0;
            String direction = "";

            if (hero_x == t.getX())
            {
                if (hero_y < t.getY())
                {
                    direction = "DOWN";
                }
                else
                {
                    direction = "UP";
                }

                range = Math.Abs(hero_y - t.getY());

            }
            else
            {
                if (hero_x < t.getX())
                {
                    direction = "RIGHT";
                }
                else
                {
                    direction = "LEFT";
                }

                range = Math.Abs(hero_x - t.getX());
            }

            switch (range)
            {
                case 2:direction += " + A";break;
                case 3:direction += " + D";break;
            }

            return direction;
        }

        public Boolean movePlayer(Character.Movement dir)
        {
            if (!map.getHero().isDead())
            {
                if (map.getHero().returnMove(dir) != Character.Movement.None)
                {
                    map.updateCharaterPosition(map.getHero(), dir);
                    moveEnemies();
                    damage_taken = enemyAttacks();                           //Enemies now attack after the player attacks
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        public bool remainStill()
        {
            moveEnemies();
            damage_taken = enemyAttacks();                           //Enemies now attack even if the player does not move
            return true;
        }

        private void moveEnemies()
        {
            Enemy[] enemies = map.getEnemies();

            for(int i = 0; i < enemies.Length; ++i)
            {
                Character.Movement direction = enemies[i].returnMove(Character.Movement.None);  //None is just a placeholder
                map.updateCharaterPosition(enemies[i], direction);
            }
        }

        public String attackEnemy(Character h,Character.Movement dir,int range,Tile t)
        {
            Tile target = new EmptyTile(0,0); // Set as an empty tile for placeholding

            if(h is Hero && h.getWeapon() != null)
            {
                if ((range + 1) > h.getWeapon().getRange())
                {
                    return "0";
                }
            }else if(h is Hero && h.getWeapon() == null)
            {
                if (range != 0)
                {
                    return "0";
                }
            }

            try
            {
                switch (dir)
                {
                    case Character.Movement.Up:
                        target = map.getMap()[h.getY() - 1 - range, h.getX()];
                        break;
                    case Character.Movement.Down:
                        target = map.getMap()[h.getY() + 1 + range, h.getX()];
                        break;
                    case Character.Movement.Left:
                        target = map.getMap()[h.getY(), h.getX() - 1 - range];
                        break;
                    case Character.Movement.Right:
                        target = map.getMap()[h.getY(), h.getX() + 1 + range];
                        break;
                    default:
                        target = t;
                        break;
                }
            }
            catch (Exception e)
            {
                return "0";
            }

            //Goblins only harm heroes
            //Mages harm the hero, goblins and other mages
            if ((h is Hero && target is Enemy && !h.isDead()) || (h is Goblin && target is Hero) || (h is Leader && target is Hero) || (h is Mage && target is Character))
            {

                h.attack((Character)target);
                Character c_target = (Character)target;
                string loot = "";

                if (c_target.isDead())
                {
                    loot = h.loot(c_target, h is Mage);
                    map.removeFromMap(c_target);
                }


                if (h is Hero) {

                    //moveEnemies();                        //Enemies no longer move after being attacked
                    damage_taken = enemyAttacks();                         //Enemies now attack after the player attacks
                    if (!c_target.isDead())
                    {
                        return "1" + c_target.ToString();   //Returning 1 infront of string indicates success
                    }
                    else
                    {
                        return "1The enemy is dead" + loot;
                    }
                }
                else if(c_target is Hero)
                {
                    return  "hero" + h.getDamage();
                }else if (!c_target.isDead())
                {
                    return "enemy";
                }
                else
                {
                    return "";
                }
                
            }
            else
            {
                return "0";                         //Returning 0 infront of string indicates failure
            }

            
        }


        
        public int enemyAttacks()
        {
            Enemy[] enemies_copy = new Enemy[map.getEnemies().Length];
            Array.Copy(map.getEnemies(),0,enemies_copy,0,map.getEnemies().Length);

            int hero_damage = 0;

            for(int i=0;i< enemies_copy.Length; ++i)
            {
                if (!enemies_copy[i].isDead())
                {
                    enemies_copy[i].lockVision();

                    int attacking_vision_length = (enemies_copy[i] is Mage ? 8 : enemies_copy[i].getAttackingVision().Length);

                    for (int j = 0; j < attacking_vision_length; ++j)
                    {
                        if (enemies_copy[i] is Goblin || enemies_copy[i] is Leader)
                        {
                            string attack_status = attackEnemy(enemies_copy[i], Character.Movement.None, 0, enemies_copy[i].getAttackingVision()[j]);
                            if (attack_status.Length >= 4 && attack_status.Substring(0, 4) == "hero")
                            {
                                hero_damage += Convert.ToInt32(attack_status.Substring(4));

                            }
                        }else if(enemies_copy[i] is Mage)
                        {
                            string attack_status = attackEnemy(enemies_copy[i], Character.Movement.None, 0, enemies_copy[i].getVision()[j]);
                            if (attack_status.Length >= 4 && attack_status.Substring(0, 4) == "hero")
                            {
                                hero_damage += Convert.ToInt32(attack_status.Substring(4));

                            }
                        }
                    }

                    enemies_copy[i].unlockVision();
                    map.updateCharaterPosition(enemies_copy[i], Character.Movement.None);    //Forces the characters vision to be updated at the end of the attack
                }
            }

            return hero_damage;
        }

        public int getDamageTaken()
        {
            return this.damage_taken;
        }

        public Map GetMap()
        {
            return this.map;
        }

        public Boolean saveGame()
        {
            try
            {
                FileStream output_file = new FileStream("gamesave.dat", FileMode.Create, FileAccess.ReadWrite);
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(output_file, map);

                output_file.Close();

                return true;
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            
        }

        public Map loadGame()
        {
            try
            {
                FileStream input_file = new FileStream("gamesave.dat", FileMode.Open, FileAccess.Read);
                BinaryFormatter bf = new BinaryFormatter();
                Map m = (Map)bf.Deserialize(input_file);

                input_file.Close();

                return m;
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

       

    }
}
