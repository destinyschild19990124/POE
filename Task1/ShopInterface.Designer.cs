namespace Task1
{
    partial class ShopInterface
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
            this.buyItem1 = new System.Windows.Forms.Button();
            this.item1 = new System.Windows.Forms.Label();
            this.item2 = new System.Windows.Forms.Label();
            this.buyItem2 = new System.Windows.Forms.Button();
            this.item3 = new System.Windows.Forms.Label();
            this.buyItem3 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buyItem1
            // 
            this.buyItem1.BackColor = System.Drawing.Color.LimeGreen;
            this.buyItem1.ForeColor = System.Drawing.Color.White;
            this.buyItem1.Location = new System.Drawing.Point(287, 54);
            this.buyItem1.Name = "buyItem1";
            this.buyItem1.Size = new System.Drawing.Size(95, 58);
            this.buyItem1.TabIndex = 0;
            this.buyItem1.Text = "Buy";
            this.buyItem1.UseVisualStyleBackColor = false;
            this.buyItem1.Click += new System.EventHandler(this.button1_Click);
            // 
            // item1
            // 
            this.item1.AutoSize = true;
            this.item1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.item1.Location = new System.Drawing.Point(13, 78);
            this.item1.Name = "item1";
            this.item1.Size = new System.Drawing.Size(46, 17);
            this.item1.TabIndex = 1;
            this.item1.Text = "label1";
            // 
            // item2
            // 
            this.item2.AutoSize = true;
            this.item2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.item2.Location = new System.Drawing.Point(13, 198);
            this.item2.Name = "item2";
            this.item2.Size = new System.Drawing.Size(46, 17);
            this.item2.TabIndex = 3;
            this.item2.Text = "label2";
            // 
            // buyItem2
            // 
            this.buyItem2.BackColor = System.Drawing.Color.Maroon;
            this.buyItem2.ForeColor = System.Drawing.Color.White;
            this.buyItem2.Location = new System.Drawing.Point(287, 174);
            this.buyItem2.Name = "buyItem2";
            this.buyItem2.Size = new System.Drawing.Size(95, 58);
            this.buyItem2.TabIndex = 2;
            this.buyItem2.Text = "Buy";
            this.buyItem2.UseVisualStyleBackColor = false;
            this.buyItem2.Click += new System.EventHandler(this.buyItem2_Click);
            // 
            // item3
            // 
            this.item3.AutoSize = true;
            this.item3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.item3.Location = new System.Drawing.Point(13, 322);
            this.item3.Name = "item3";
            this.item3.Size = new System.Drawing.Size(46, 17);
            this.item3.TabIndex = 5;
            this.item3.Text = "label3";
            // 
            // buyItem3
            // 
            this.buyItem3.BackColor = System.Drawing.Color.MidnightBlue;
            this.buyItem3.ForeColor = System.Drawing.Color.White;
            this.buyItem3.Location = new System.Drawing.Point(287, 298);
            this.buyItem3.Name = "buyItem3";
            this.buyItem3.Size = new System.Drawing.Size(95, 58);
            this.buyItem3.TabIndex = 4;
            this.buyItem3.Text = "Buy";
            this.buyItem3.UseVisualStyleBackColor = false;
            this.buyItem3.Click += new System.EventHandler(this.buyItem3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.Silver;
            this.label1.Location = new System.Drawing.Point(61, 384);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(249, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Click gameplay window to regain focus";
            // 
            // ShopInterface
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(394, 410);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.item3);
            this.Controls.Add(this.buyItem3);
            this.Controls.Add(this.item2);
            this.Controls.Add(this.buyItem2);
            this.Controls.Add(this.item1);
            this.Controls.Add(this.buyItem1);
            this.Name = "ShopInterface";
            this.Text = "Shop";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.ShopInterface_FormClosed);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buyItem1;
        private System.Windows.Forms.Label item1;
        private System.Windows.Forms.Label item2;
        private System.Windows.Forms.Button buyItem2;
        private System.Windows.Forms.Label item3;
        private System.Windows.Forms.Button buyItem3;
        private System.Windows.Forms.Label label1;
    }
}