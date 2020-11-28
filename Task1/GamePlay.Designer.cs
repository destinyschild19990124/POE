namespace Task1
{
    partial class GamePlay
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.actionstatusLabel = new System.Windows.Forms.Label();
            this.gameviewLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.enemiesremainingLabel = new System.Windows.Forms.Label();
            this.attackingOptionsLabel = new System.Windows.Forms.Label();
            this.herostatsLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // actionstatusLabel
            // 
            this.actionstatusLabel.AutoSize = true;
            this.actionstatusLabel.ForeColor = System.Drawing.Color.Red;
            this.actionstatusLabel.Location = new System.Drawing.Point(17, 369);
            this.actionstatusLabel.Name = "actionstatusLabel";
            this.actionstatusLabel.Size = new System.Drawing.Size(0, 17);
            this.actionstatusLabel.TabIndex = 0;
            // 
            // gameviewLabel
            // 
            this.gameviewLabel.AutoSize = true;
            this.gameviewLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.gameviewLabel.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gameviewLabel.Location = new System.Drawing.Point(15, 40);
            this.gameviewLabel.Name = "gameviewLabel";
            this.gameviewLabel.Size = new System.Drawing.Size(2, 24);
            this.gameviewLabel.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 418);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Controls";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 448);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(189, 68);
            this.label2.TabIndex = 3;
            this.label2.Text = "W - move up  S - move down\r\nA - move left  D - move right\r\n\r\nSPACE - not move";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(16, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "Display";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.enemiesremainingLabel);
            this.panel1.Controls.Add(this.attackingOptionsLabel);
            this.panel1.Controls.Add(this.herostatsLabel);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Location = new System.Drawing.Point(386, 13);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(447, 609);
            this.panel1.TabIndex = 5;
            // 
            // enemiesremainingLabel
            // 
            this.enemiesremainingLabel.AutoSize = true;
            this.enemiesremainingLabel.BackColor = System.Drawing.SystemColors.Control;
            this.enemiesremainingLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.enemiesremainingLabel.Location = new System.Drawing.Point(12, 229);
            this.enemiesremainingLabel.Name = "enemiesremainingLabel";
            this.enemiesremainingLabel.Size = new System.Drawing.Size(0, 17);
            this.enemiesremainingLabel.TabIndex = 12;
            // 
            // attackingOptionsLabel
            // 
            this.attackingOptionsLabel.AutoSize = true;
            this.attackingOptionsLabel.BackColor = System.Drawing.SystemColors.Control;
            this.attackingOptionsLabel.ForeColor = System.Drawing.Color.Blue;
            this.attackingOptionsLabel.Location = new System.Drawing.Point(12, 481);
            this.attackingOptionsLabel.Name = "attackingOptionsLabel";
            this.attackingOptionsLabel.Size = new System.Drawing.Size(0, 17);
            this.attackingOptionsLabel.TabIndex = 11;
            // 
            // herostatsLabel
            // 
            this.herostatsLabel.AutoSize = true;
            this.herostatsLabel.Location = new System.Drawing.Point(12, 43);
            this.herostatsLabel.Name = "herostatsLabel";
            this.herostatsLabel.Size = new System.Drawing.Size(0, 17);
            this.herostatsLabel.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 195);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(150, 17);
            this.label6.TabIndex = 8;
            this.label6.Text = "Enemies Remaining";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(12, 451);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(136, 17);
            this.label5.TabIndex = 7;
            this.label5.Text = "Attacking Options";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(12, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 17);
            this.label4.TabIndex = 6;
            this.label4.Text = "Hero Stats";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label7.Location = new System.Drawing.Point(9, 520);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(185, 102);
            this.label7.TabIndex = 6;
            this.label7.Text = "ESCAPE  - save and exit\r\nENTER    - save\r\n\r\n\r\n\r\n\r\n";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(9, 588);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(320, 34);
            this.label8.TabIndex = 7;
            this.label8.Text = "Up Arrow - attack up     Down Arrow - attack down\r\nLeft Arrow - attack left   Rig" +
    "ht Arrow - attack right\r\n";
            // 
            // GamePlay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(845, 639);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.gameviewLabel);
            this.Controls.Add(this.actionstatusLabel);
            this.Name = "GamePlay";
            this.Text = "Fight!";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.GamePlay_FormClosed);
            this.Load += new System.EventHandler(this.GamePlay_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.GamePlay_KeyDown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label actionstatusLabel;
        private System.Windows.Forms.Label gameviewLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label attackingOptionsLabel;
        private System.Windows.Forms.Label herostatsLabel;
        private System.Windows.Forms.Label enemiesremainingLabel;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}