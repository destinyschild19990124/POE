using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void startgameButton_Click(object sender, EventArgs e)
        {
            try
            {

                int min_width = Convert.ToInt32(minwidthBox.Text);
                int max_width = Convert.ToInt32(minwidthBox.Text);
                int min_length = Convert.ToInt32(minlengthBox.Text);
                int max_length = Convert.ToInt32(maxlengthBox.Text);
                int enemies = Convert.ToInt32(enemiesBox.Text);
                int gold = Convert.ToInt32(goldBox.Text);
                int weapons = Convert.ToInt32(weaponsBox.Text);

                startGame(min_width, max_width, min_length, max_length, enemies,gold,weapons);

            }catch(FormatException exc)
            {
                errorLabel.Text = "Please input numbers";
            }


            }

        private void startGame(int min_width, int max_width, int min_height, int max_height, int num_enemies,int num_gold,int num_weapons)
        {
            errorLabel.Text = "";

            GamePlay gp = new GamePlay(min_width, max_width, min_height, max_height, num_enemies,num_gold,num_weapons);
            gp.setCaller(this);
            gp.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                FileStream save_file = new FileStream("gamesave.dat", FileMode.Open, FileAccess.Read);
                save_file.Close();

                GamePlay gp = new GamePlay();
                gp.setCaller(this);
                gp.Show();
                this.Hide();
            }
            catch(Exception exc)
            {
                errorLabel.Text = "No saved game found";
            }
    
        }

        public void resetAfterDeath()
        {
            try
            {
                FileStream save_file = new FileStream("gamesave.dat", FileMode.Open, FileAccess.Read);
                save_file.Close();

                GamePlay gp = new GamePlay();
                gp.setCaller(this);
                gp.Show();
                this.Hide();
            }
            catch (Exception exc)
            {
                errorLabel.Text = "No saved game found";
            }
        }

        
    }
}
