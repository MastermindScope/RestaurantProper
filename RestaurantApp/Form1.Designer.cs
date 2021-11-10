
namespace RestaurantApp
{
    partial class Form1
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
            this.InitButton = new System.Windows.Forms.Button();
            this.Print = new System.Windows.Forms.Button();
            this.PommesButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // InitButton
            // 
            this.InitButton.Location = new System.Drawing.Point(45, 40);
            this.InitButton.Name = "InitButton";
            this.InitButton.Size = new System.Drawing.Size(197, 83);
            this.InitButton.TabIndex = 0;
            this.InitButton.Text = "Init";
            this.InitButton.UseVisualStyleBackColor = true;
            this.InitButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // Print
            // 
            this.Print.Location = new System.Drawing.Point(304, 43);
            this.Print.Name = "Print";
            this.Print.Size = new System.Drawing.Size(167, 79);
            this.Print.TabIndex = 1;
            this.Print.Text = "Print";
            this.Print.UseVisualStyleBackColor = true;
            this.Print.Click += new System.EventHandler(this.Print_Click);
            // 
            // PommesButton
            // 
            this.PommesButton.Location = new System.Drawing.Point(542, 48);
            this.PommesButton.Name = "PommesButton";
            this.PommesButton.Size = new System.Drawing.Size(186, 89);
            this.PommesButton.TabIndex = 2;
            this.PommesButton.Text = "PommesToBuchung";
            this.PommesButton.UseVisualStyleBackColor = true;
            this.PommesButton.Click += new System.EventHandler(this.PommesButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1026, 558);
            this.Controls.Add(this.PommesButton);
            this.Controls.Add(this.Print);
            this.Controls.Add(this.InitButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button InitButton;
        private System.Windows.Forms.Button Print;
        private System.Windows.Forms.Button PommesButton;
    }
}

