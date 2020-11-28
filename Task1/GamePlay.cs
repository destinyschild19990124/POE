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
    public partial class GamePlay : Form
    {

        private Form1 caller;
        private GameEngine ge;
        private int width;
        private int height;

        public GamePlay(int min_width, int max_width, int min_height, int max_height, int num_enemies,int num_gold,int num_weapons)
        {
            InitializeComponent();
            ge = new GameEngine(min_width, max_width, min_height, max_height, num_enemies,num_gold,num_weapons);
            width = ge.getWidth();
            height = ge.getHeight();
            redraw();
        }

        public GamePlay()
        {
            InitializeComponent();
            ge = new GameEngine();
            width = ge.getWidth();
            height = ge.getHeight();
            redraw();
        }

        public void setCaller(Form1 caller)
        {
            this.caller = caller;
        }

       

        private void actionStatus(String action,Boolean success,String meta)
        {
            if (success)
            {
                actionstatusLabel.ForeColor = Color.Green;

                if (action.Substring(0, 6) == "attack")
                {
                    actionstatusLabel.Text = "Action successful!";
                    actionstatusLabel.Text += '\n' + meta + '\n';
                }

                if (ge.GetMap().getHero().getHp() <= 0)
                {
                    actionstatusLabel.Text += "You are now dead! PRESS \'L\' to load from last save.";
                }else if (ge.getDamageTaken() > 0)
                {
                    actionstatusLabel.Text += "You took a total of " + ge.getDamageTaken() + " DMG";
                }
                redraw();
            }
            else
            {
                actionstatusLabel.ForeColor = Color.Red;
                actionstatusLabel.Text = "You cannot " + action + (ge.GetMap().getHero().isDead()?" [DEAD]":"");
            }
        }

        private void redraw()
        {
            updateMap();
            updatePlayerStats(ge.getHeroStats());
            updateEnemiesRemaining(ge.getEnemiesRemaining());
            updateAttackingOptions(ge.getAttackingOptions());
        }

        private void updateMap()
        {
            Tile[,] view = ge.getMapView();
            string text_view = "";

            for(int i = 0; i < height; ++i)
            {
                for(int j = 0; j < width; ++j)
                {
                    text_view += this.getRepresentation(view[i, j]) + (j==(width-1)?"":" ");
                }
                text_view += '\n';
            }

            gameviewLabel.Text = text_view;
        }

        private void updatePlayerStats(String info)
        {
            herostatsLabel.Text = info;
        }

        private void updateEnemiesRemaining(String info)
        {
            enemiesremainingLabel.Text = info;
        }

        private void updateAttackingOptions(String info)
        {
            attackingOptionsLabel.Text = info;
        }

        private char getRepresentation(Tile type)
        {
            if(type is EmptyTile)
            {
                return '.';
            }
            else if(type is Hero)
            {
                return 'H';
            }
            else if (type is Goblin)
            {
                return 'G';
            }
            else if (type is Mage)
            {
                return 'M';
            }
            else if (type is Leader)
            {
                return 'L';
            }
            else if (type is Gold)
            {
                return 'c';
            }
            else if(type is Weapon)
            {
                return ((Weapon)type).getSymbol();
            }
            else
            {
                return 'X';
            }
        }

        private void GamePlay_FormClosed(object sender, FormClosedEventArgs e)
        {
            caller.Dispose();
        }

        private void GamePlay_KeyDown(object sender, KeyEventArgs e)
        {
            actionstatusLabel.Text = "";

            if (e.KeyCode == Keys.W)
            {
                actionStatus("move up", ge.movePlayer(Character.Movement.Up), "");
            }
            else if (e.KeyCode == Keys.S)
            {
                actionStatus("move down", ge.movePlayer(Character.Movement.Down), "");
            }
            else if (e.KeyCode == Keys.A)
            {
                actionStatus("move left", ge.movePlayer(Character.Movement.Left), "");
            }
            else if (e.KeyCode == Keys.D)
            {
                actionStatus("move right", ge.movePlayer(Character.Movement.Right), "");
            }
            else if (e.KeyCode == Keys.Space)
            {
                actionStatus("no move", ge.remainStill(), "");
            }
            else if (e.KeyCode == Keys.Up)
            {
                String response = ge.attackEnemy(ge.GetMap().getHero(), Character.Movement.Up,null);
                Boolean success = false;
                if (response[0] == '1')
                {
                    success = true;
                }
                actionStatus("attack up",success,response.Substring(1));
            }
            else if (e.KeyCode == Keys.Down)
            {
                String response = ge.attackEnemy(ge.GetMap().getHero(), Character.Movement.Down,null);
                Boolean success = false;
                if (response[0] == '1')
                {
                    success = true;
                }
                actionStatus("attack down", success, response.Substring(1));
            }
            else if (e.KeyCode == Keys.Left)
            {
                String response = ge.attackEnemy(ge.GetMap().getHero(), Character.Movement.Left,null);
                Boolean success = false;
                if (response[0] == '1')
                {
                    success = true;
                }
                actionStatus("attack left", success, response.Substring(1));
            }
            else if (e.KeyCode == Keys.Right)
            {
                String response = ge.attackEnemy(ge.GetMap().getHero(),Character.Movement.Right,null);
                Boolean success = false;
                if (response[0] == '1')
                {
                    success = true;
                }
                actionStatus("attack right", success, response.Substring(1));
            }
            else if(e.KeyCode == Keys.L)
            {
                if (ge.GetMap().getHero().isDead())
                {
                    caller.resetAfterDeath();
                    this.Dispose();
                }
            }
            else if(e.KeyCode == Keys.Escape)       // save and exit
            {
                ge.saveGame();

                caller.Show();
                this.Dispose();
            }
            else if (e.KeyCode == Keys.Enter)       // save only
            {
                if (ge.saveGame())
                {
                    actionstatusLabel.ForeColor = Color.Orange;
                    actionstatusLabel.Text = "Save successful!";
                }
                else
                {
                    actionstatusLabel.ForeColor = Color.Red;
                    actionstatusLabel.Text = "Unable to save.";
                }
                
            }
            
        }

        private void GamePlay_Load(object sender, EventArgs e)
        {

        }
    }

    
}
