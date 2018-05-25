namespace Software_Engineering_Project.Forms
{
    partial class PickupVehicleSelection
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
            this.VehicleListBox = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.Rent_btn = new System.Windows.Forms.Button();
            this.Cancel_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // VehicleListBox
            // 
            this.VehicleListBox.FormattingEnabled = true;
            this.VehicleListBox.Location = new System.Drawing.Point(12, 68);
            this.VehicleListBox.Name = "VehicleListBox";
            this.VehicleListBox.Size = new System.Drawing.Size(292, 316);
            this.VehicleListBox.TabIndex = 0;
            this.VehicleListBox.SelectedIndexChanged += new System.EventHandler(this.VehicleListBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(12, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(292, 51);
            this.label3.TabIndex = 12;
            this.label3.Text = "CSR Rentals\n\r\n";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // Rent_btn
            // 
            this.Rent_btn.Location = new System.Drawing.Point(325, 352);
            this.Rent_btn.Name = "Rent_btn";
            this.Rent_btn.Size = new System.Drawing.Size(99, 32);
            this.Rent_btn.TabIndex = 13;
            this.Rent_btn.Text = "Rent";
            this.Rent_btn.UseVisualStyleBackColor = true;
            this.Rent_btn.Click += new System.EventHandler(this.Rent_btn_Click);
            // 
            // Cancel_btn
            // 
            this.Cancel_btn.Location = new System.Drawing.Point(430, 352);
            this.Cancel_btn.Name = "Cancel_btn";
            this.Cancel_btn.Size = new System.Drawing.Size(99, 32);
            this.Cancel_btn.TabIndex = 14;
            this.Cancel_btn.Text = "Cancel";
            this.Cancel_btn.UseVisualStyleBackColor = true;
            this.Cancel_btn.Click += new System.EventHandler(this.Cancel_btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(366, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 31);
            this.label1.TabIndex = 15;
            this.label1.Text = "Price/Day";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(385, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 31);
            this.label2.TabIndex = 16;
            this.label2.Text = "label2";
            this.label2.Visible = false;
            // 
            // PickupVehicleSelection
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 396);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Cancel_btn);
            this.Controls.Add(this.Rent_btn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.VehicleListBox);
            this.Name = "PickupVehicleSelection";
            this.Text = "Vehice Selection";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox VehicleListBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button Rent_btn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button Cancel_btn;
    }
}