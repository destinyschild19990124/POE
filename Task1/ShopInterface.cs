using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task1
{
    partial class ShopInterface : Form
    {

        private Shop shop;
        private GamePlay caller;

        public ShopInterface(Shop shop)
        {
            InitializeComponent();
            this.shop = shop;
            Console.WriteLine(shop.displayWeapon(0));
            updateInterface();
        }

        public void setCaller(GamePlay caller)
        {
            this.caller = caller;
        }

        public void updateInterface()
        {
            for(int i = 0; i < shop.getInventory().Length; ++i)
            {
                switch (i)
                {
                    case 0:item1.Text = shop.displayWeapon(i);
                        if (shop.canBuy(i))
                        {
                            buyItem1.Enabled = true;
                            buyItem1.BackColor = Color.LimeGreen;
                        }
                        else
                        {
                            buyItem1.Enabled = false;
                            buyItem1.BackColor = Color.Gray;
                        }
                        break;
                    case 1:
                        item2.Text = shop.displayWeapon(i);
                        if (shop.canBuy(i))
                        {
                            buyItem2.Enabled = true;
                            buyItem2.BackColor = Color.Maroon;
                        }
                        else
                        {
                            buyItem2.Enabled = false;
                            buyItem2.BackColor = Color.Gray;
                        }
                        break;
                    case 2:
                        item3.Text = shop.displayWeapon(i);
                        if (shop.canBuy(i))
                        {
                            buyItem3.Enabled = true;
                            buyItem3.BackColor = Color.MidnightBlue;
                        }
                        else
                        {
                            buyItem3.Enabled = false;
                            buyItem3.BackColor = Color.Gray;
                        }
                        break;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            shop.buy(0);
            caller.updatePlayerStats(shop.getPlayerStats());
            this.updateInterface();
        }

        private void buyItem2_Click(object sender, EventArgs e)
        {
            shop.buy(1);
            caller.updatePlayerStats(shop.getPlayerStats());
            this.updateInterface();
        }

        private void buyItem3_Click(object sender, EventArgs e)
        {
            shop.buy(2);
            caller.updatePlayerStats(shop.getPlayerStats());
            this.updateInterface();
        }

        private void ShopInterface_FormClosed(object sender, FormClosedEventArgs e)
        {
            caller.nullifyShop();
        }
    }
}
