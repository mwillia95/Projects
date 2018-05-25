namespace Software_Engineering_Project.Forms
{
    partial class HomepageTech
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
            this.label3 = new System.Windows.Forms.Label();
            this.Return_btn = new System.Windows.Forms.Button();
            this.Logout_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(142, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(436, 73);
            this.label3.TabIndex = 7;
            this.label3.Text = "CSR Homepage Technician\r\n";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // Return_btn
            // 
            this.Return_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Return_btn.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Return_btn.Location = new System.Drawing.Point(130, 288);
            this.Return_btn.Name = "Return_btn";
            this.Return_btn.Size = new System.Drawing.Size(205, 76);
            this.Return_btn.TabIndex = 8;
            this.Return_btn.Text = "Return";
            this.Return_btn.UseVisualStyleBackColor = true;
            this.Return_btn.Click += new System.EventHandler(this.Return_btn_Click);
            // 
            // Logout_btn
            // 
            this.Logout_btn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Logout_btn.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Logout_btn.Location = new System.Drawing.Point(386, 288);
            this.Logout_btn.Name = "Logout_btn";
            this.Logout_btn.Size = new System.Drawing.Size(205, 76);
            this.Logout_btn.TabIndex = 9;
            this.Logout_btn.Text = "Logout";
            this.Logout_btn.UseVisualStyleBackColor = true;
            this.Logout_btn.Click += new System.EventHandler(this.Logout_btn_Click);
            // 
            // HomepageTech
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(717, 468);
            this.Controls.Add(this.Logout_btn);
            this.Controls.Add(this.Return_btn);
            this.Controls.Add(this.label3);
            this.Name = "HomepageTech";
            this.Text = "Homepage";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Return_btn;
        private System.Windows.Forms.Button Logout_btn;
    }
}