using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Shop
    {

        private Random rn;
        private Weapon[] weapons;
        private Character buyer;

        public Shop(Character buyer)
        {
            rn = new Random();
            this.weapons = new Weapon[3];
            this.buyer = buyer;

            for(int i = 0; i < 3; ++i)
            {
                weapons[i] = randomWeapon();
            }
        }

        private Weapon randomWeapon()
        {

            // 0 = dagger 1 = longsword 2 = longbow 3 = rifle
            int wpn_num = rn.Next(0, 4); 

            if (wpn_num == 0) { return new MeleeWeapon(MeleeWeapon.Types.Dagger, 'd'); }
            else if(wpn_num == 1) { return new MeleeWeapon(MeleeWeapon.Types.Longsword, 'l'); }
            else if(wpn_num == 2) { return new RangedWeapon(RangedWeapon.Types.Longbow, 'b'); }
            else{ return new RangedWeapon(RangedWeapon.Types.Rifle, 'r'); }
        }

        public Boolean canBuy(int num)
        {
            
            int cost = weapons[num-1].getCost();

            return buyer.getGoldPurse() >= cost;
        }

        public void buy(int num)
        {
            buyer.setGoldPurse(buyer.getGoldPurse() - weapons[num - 1].getCost());
            buyer.pickUp(weapons[num - 1]);
            weapons[num - 1] = randomWeapon();
        }

        public string displayWeapon(int num)
        {
            return "Buy " + (weapons[num - 1] is MeleeWeapon ? ((MeleeWeapon)weapons[num - 1]).getTypeString() : ((RangedWeapon)weapons[num - 1]).getTypeString()) + " ( " + weapons[num - 1] + " GOLD )";
        }

    }
}
