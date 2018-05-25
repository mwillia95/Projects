namespace Software_Engineering_Project.Forms
{
    partial class HomepageAgent
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
            this.Logout_btn = new System.Windows.Forms.Button();
            this.Rental_btn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Logout_btn
            // 
            this.Logout_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Logout_btn.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Logout_btn.Location = new System.Drawing.Point(384, 308);
            this.Logout_btn.Name = "Logout_btn";
            this.Logout_btn.Size = new System.Drawing.Size(205, 76);
            this.Logout_btn.TabIndex = 12;
            this.Logout_btn.Text = "Logout";
            this.Logout_btn.UseVisualStyleBackColor = true;
            this.Logout_btn.Click += new System.EventHandler(this.button2_Click);
            // 
            // Rental_btn
            // 
            this.Rental_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Rental_btn.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Rental_btn.Location = new System.Drawing.Point(128, 308);
            this.Rental_btn.Name = "Rental_btn";
            this.Rental_btn.Size = new System.Drawing.Size(205, 76);
            this.Rental_btn.TabIndex = 11;
            this.Rental_btn.Text = "Rental";
            this.Rental_btn.UseVisualStyleBackColor = true;
            this.Rental_btn.Click += new System.EventHandler(this.button1_Click);
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(140, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(436, 56);
            this.label3.TabIndex = 10;
            this.label3.Text = "CSR Homepage Agent\r\n\r\n";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // Homepageagent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 468);
            this.Controls.Add(this.Logout_btn);
            this.Controls.Add(this.Rental_btn);
            this.Controls.Add(this.label3);
            this.Name = "Homepageagent";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Logout_btn;
        private System.Windows.Forms.Button Rental_btn;
        private System.Windows.Forms.Label label3;
    }
}