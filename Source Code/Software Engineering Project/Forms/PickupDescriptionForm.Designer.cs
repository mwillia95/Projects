namespace Software_Engineering_Project.Forms
{
    partial class PickupDescriptionForm
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
            this.Make_label = new System.Windows.Forms.Label();
            this.License_label = new System.Windows.Forms.Label();
            this.Year_label = new System.Windows.Forms.Label();
            this.Model_label = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.DescriptionBox = new System.Windows.Forms.TextBox();
            this.Approve_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(526, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(228, 51);
            this.label3.TabIndex = 12;
            this.label3.Text = "CSR Rentals\n\r\n";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // Make_label
            // 
            this.Make_label.AutoSize = true;
            this.Make_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Make_label.Location = new System.Drawing.Point(12, 9);
            this.Make_label.Name = "Make_label";
            this.Make_label.Size = new System.Drawing.Size(71, 25);
            this.Make_label.TabIndex = 13;
            this.Make_label.Text = "Make:";
            // 
            // License_label
            // 
            this.License_label.AutoSize = true;
            this.License_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.License_label.Location = new System.Drawing.Point(160, 63);
            this.License_label.Name = "License_label";
            this.License_label.Size = new System.Drawing.Size(148, 25);
            this.License_label.TabIndex = 14;
            this.License_label.Text = "License Plate:";
            // 
            // Year_label
            // 
            this.Year_label.AutoSize = true;
            this.Year_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Year_label.Location = new System.Drawing.Point(12, 63);
            this.Year_label.Name = "Year_label";
            this.Year_label.Size = new System.Drawing.Size(64, 25);
            this.Year_label.TabIndex = 15;
            this.Year_label.Text = "Year:";
            // 
            // Model_label
            // 
            this.Model_label.AutoSize = true;
            this.Model_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Model_label.Location = new System.Drawing.Point(231, 9);
            this.Model_label.Name = "Model_label";
            this.Model_label.Size = new System.Drawing.Size(77, 25);
            this.Model_label.TabIndex = 16;
            this.Model_label.Text = "Model:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(271, 128);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(197, 25);
            this.label6.TabIndex = 17;
            this.label6.Text = "Vehicle Description";
            // 
            // DescriptionBox
            // 
            this.DescriptionBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.DescriptionBox.Enabled = false;
            this.DescriptionBox.Location = new System.Drawing.Point(125, 156);
            this.DescriptionBox.Multiline = true;
            this.DescriptionBox.Name = "DescriptionBox";
            this.DescriptionBox.ReadOnly = true;
            this.DescriptionBox.Size = new System.Drawing.Size(489, 125);
            this.DescriptionBox.TabIndex = 18;
            // 
            // Approve_btn
            // 
            this.Approve_btn.Location = new System.Drawing.Point(631, 247);
            this.Approve_btn.Name = "Approve_btn";
            this.Approve_btn.Size = new System.Drawing.Size(123, 34);
            this.Approve_btn.TabIndex = 19;
            this.Approve_btn.Text = "Approve";
            this.Approve_btn.UseVisualStyleBackColor = true;
            this.Approve_btn.Click += new System.EventHandler(this.Approve_btn_Click);
            // 
            // PickupDescriptionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 322);
            this.Controls.Add(this.Approve_btn);
            this.Controls.Add(this.DescriptionBox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.Model_label);
            this.Controls.Add(this.Year_label);
            this.Controls.Add(this.License_label);
            this.Controls.Add(this.Make_label);
            this.Controls.Add(this.label3);
            this.Name = "PickupDescriptionForm";
            this.Text = "DescriptionForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label Make_label;
        private System.Windows.Forms.Label License_label;
        private System.Windows.Forms.Label Year_label;
        private System.Windows.Forms.Label Model_label;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox DescriptionBox;
        private System.Windows.Forms.Button Approve_btn;
    }
}