namespace Software_Engineering_Project.Forms
{
    partial class ReturnDescriptionForm
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
            this.Report_btn = new System.Windows.Forms.Button();
            this.Approve_btn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.Description_box = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // Report_btn
            // 
            this.Report_btn.Location = new System.Drawing.Point(372, 453);
            this.Report_btn.Name = "Report_btn";
            this.Report_btn.Size = new System.Drawing.Size(120, 48);
            this.Report_btn.TabIndex = 28;
            this.Report_btn.Text = "Report";
            this.Report_btn.UseVisualStyleBackColor = true;
            this.Report_btn.Click += new System.EventHandler(this.Report_btn_Click);
            // 
            // Approve_btn
            // 
            this.Approve_btn.Location = new System.Drawing.Point(62, 453);
            this.Approve_btn.Name = "Approve_btn";
            this.Approve_btn.Size = new System.Drawing.Size(120, 48);
            this.Approve_btn.TabIndex = 27;
            this.Approve_btn.Text = "Approve";
            this.Approve_btn.UseVisualStyleBackColor = true;
            this.Approve_btn.Click += new System.EventHandler(this.Approve_btn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(38, 274);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(275, 31);
            this.label1.TabIndex = 26;
            this.label1.Text = "Vehicle Description:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(141, 223);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(64, 25);
            this.label10.TabIndex = 25;
            this.label10.Text = "Year:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(128, 177);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(77, 25);
            this.label9.TabIndex = 24;
            this.label9.Text = "Model:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(134, 127);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 25);
            this.label8.TabIndex = 23;
            this.label8.Text = "Make:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(39, 78);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(166, 25);
            this.label5.TabIndex = 22;
            this.label5.Text = "License Plate #:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(175, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(196, 35);
            this.label4.TabIndex = 21;
            this.label4.Text = "CRS Rentals";
            // 
            // Description_box
            // 
            this.Description_box.CausesValidation = false;
            this.Description_box.Enabled = false;
            this.Description_box.Location = new System.Drawing.Point(62, 315);
            this.Description_box.Multiline = true;
            this.Description_box.Name = "Description_box";
            this.Description_box.ReadOnly = true;
            this.Description_box.Size = new System.Drawing.Size(429, 113);
            this.Description_box.TabIndex = 29;
            // 
            // ReturnDescriptionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 536);
            this.Controls.Add(this.Description_box);
            this.Controls.Add(this.Report_btn);
            this.Controls.Add(this.Approve_btn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Name = "ReturnDescriptionForm";
            this.Text = "Return: Information Lookup";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Report_btn;
        private System.Windows.Forms.Button Approve_btn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox Description_box;
    }
}