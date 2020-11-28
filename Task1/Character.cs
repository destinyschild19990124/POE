using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    [Serializable]
    abstract class Character : Tile
    {

        public enum Movement
        {
            Up,Down,Left,Right,None
        }

        protected int hp;
        protected int max_hp;
        protected int damage;
        protected Tile[] vision;
        protected Tile[] attacking_vision;      //Some weapons extend range
        protected int gold_purse = 0;
        protected Boolean lock_vision = false;  //Disable vision from being changed for the purpose of looping through enemies
        protected Weapon weapon = null;

        public void setGoldPurse(int gold_purse)
        {
            this.gold_purse = gold_purse;
        }

        public int getGoldPurse()
        {
            return this.gold_purse;
        }

        public Weapon getWeapon()
        {
            return this.weapon;
        }

        public void lockVision()
        {
            this.lock_vision = true;
        }

        public void unlockVision()
        {
            this.lock_vision = false;
        }

        public Boolean isVisionLocked()
        {
            return this.lock_vision;
        }

        public Character(int x, int y,Tile.TileType type) : base(x, y, type) { }
      

        public virtual void attack(Character target) 
        {
            target.setHp(target.getHp() - this.getDamage());
            if (this.weapon != null)
            {
                this.weapon.setDurability(this.weapon.getDurability() - 1);
                if (this.weapon.getDurability() == 0)
                {
                    this.weapon = null;
                }
            }
        }

        public string loot(Character target,Boolean is_mage)
        {
            string looted = "\n[LOOT] Gold = " + target.getGoldPurse();
            this.gold_purse += target.getGoldPurse();

            if (this.weapon == null && !is_mage)
            {
                looted += "\n[LOOT] Weapon = " + target.getWeapon().getTypeString();
                this.weapon = target.getWeapon();
            }

            return looted;
        }
    

        public Boolean isDead()
        {
            return hp <= 0;
        }


        public virtual Boolean checkRange(Character target) 
        { 
            return false;
        }

        private int distanceTo(Character target)
        {
            int x_diff = Math.Abs(target.getX() - this.x);
            int y_diff = Math.Abs(target.getY() - this.y);

            return x_diff + y_diff;
        }

        public void move(Movement direction)
        {
            if(direction == Movement.Up) { --this.y; }
            else if(direction == Movement.Down) { ++this.y; }
            else if(direction == Movement.Left) { --this.x; }
            else if(direction == Movement.Right) { ++this.x; }

            //No movement edits required for characters that do not move
        }

        public void pickUp(Item i)
        {
            if(i is Gold)
            {
                this.gold_purse += ((Gold)i).getGold();
            }else if(i is Weapon)
            {
                equip((Weapon)i);
            }
        }

        private void equip(Weapon w)
        {
            this.weapon = w;
        }

        public abstract Movement returnMove(Movement direction = 0);

        public abstract override string ToString();

        public void setHp(int hp)
        {
            this.hp = hp;
            if (hp <= 0)
            {
                hp = 0;
            }
        }

        public int getHp()
        {
            return (this.hp>=0?this.hp:0);
        }

        public void setMaxHp(int max_hp)
        {
            this.max_hp = max_hp;
        }

        public int getMaxHp()
        {
            return this.max_hp;
        }

        public void setDamage(int damage)
        {
            this.damage = damage;
        }

        public int getDamage()
        {
            if (this.weapon == null)
            {
                return this.damage;
            }
            else
            {
                return this.weapon.getDamage();
            }
        }

        public void setVision(Tile[] vision)
        {
            this.vision = vision;
        }

        public Tile[] getVision()
        {
            return this.vision;
        }

        public void setAttackingVision(Tile[] attacking_vision)
        {
            this.attacking_vision = attacking_vision;
        }

        public Tile[] getAttackingVision()
        {
            return this.attacking_vision;
        }


    }
}
