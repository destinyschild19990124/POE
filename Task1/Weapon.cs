using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    [Serializable]
    abstract class Weapon : Item
    {

        public enum WeaponType
        {
            MeleeWeapon
        }

        public Weapon(int x,int y, char symbol) : base(x, y,TileType.Weapon)
        {
            this.symbol = symbol;
        }

        protected int damage;
        protected int range;
        protected int durability;
        protected int cost;
        protected WeaponType weapon_type;

        protected char symbol;

        /*public void setDamage(int damage)
        {
            this.damage = damage;
        }*/

        public int getDamage()
        {
            return this.damage;
        }

        /*public void setRange(int range)
        {
            this.range = range;
        }*/

        public virtual int getRange()
        {
            return this.range;
        }

        /*public void setDurability(int durability)
        {
            this.durability = durability;
        }*/

        public int getDurability()
        {
            return this.durability;
        }

        /*public void setCost(int cost)
        {
            this.cost = cost;
        }*/

        public int getCost()
        {
            return this.cost;
        }

        /*public void setWeaponType(WeaponType weapon_type)
        {
            this.weapon_type = weapon_type;
        }*/

        public WeaponType getWeaponType()
        {
            return this.weapon_type;
        }


        public char getSymbol()
        {
            return this.symbol;
        }

    }
}
