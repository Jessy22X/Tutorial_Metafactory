namespace StockManagement
{
    partial class Tank
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.m_cbStockTank = new System.Windows.Forms.ComboBox();
            this.m_tTankName = new System.Windows.Forms.TextBox();
            this.m_tTankQuantity = new System.Windows.Forms.TextBox();
            this.m_dtTankValidFrom = new System.Windows.Forms.DateTimePicker();
            this.m_dtTankValidTo = new System.Windows.Forms.DateTimePicker();
            this.m_bAddTank = new System.Windows.Forms.Button();
            this.m_bCancelTank = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Stock#";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tank name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Quantity";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Valid from";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(33, 127);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Valid to";
            // 
            // m_cbStockTank
            // 
            this.m_cbStockTank.FormattingEnabled = true;
            this.m_cbStockTank.Location = new System.Drawing.Point(110, 18);
            this.m_cbStockTank.Name = "m_cbStockTank";
            this.m_cbStockTank.Size = new System.Drawing.Size(173, 21);
            this.m_cbStockTank.TabIndex = 5;
            // 
            // m_tTankName
            // 
            this.m_tTankName.Location = new System.Drawing.Point(110, 46);
            this.m_tTankName.Name = "m_tTankName";
            this.m_tTankName.Size = new System.Drawing.Size(173, 20);
            this.m_tTankName.TabIndex = 6;
            // 
            // m_tTankQuantity
            // 
            this.m_tTankQuantity.Location = new System.Drawing.Point(110, 72);
            this.m_tTankQuantity.Name = "m_tTankQuantity";
            this.m_tTankQuantity.Size = new System.Drawing.Size(173, 20);
            this.m_tTankQuantity.TabIndex = 7;
            this.m_tTankQuantity.TextChanged += new System.EventHandler(this.m_tTankQuantity_TextChanged);
            // 
            // m_dtTankValidFrom
            // 
            this.m_dtTankValidFrom.Enabled = false;
            this.m_dtTankValidFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.m_dtTankValidFrom.Location = new System.Drawing.Point(189, 101);
            this.m_dtTankValidFrom.Name = "m_dtTankValidFrom";
            this.m_dtTankValidFrom.Size = new System.Drawing.Size(94, 20);
            this.m_dtTankValidFrom.TabIndex = 10;
            this.m_dtTankValidFrom.UseWaitCursor = true;
            // 
            // m_dtTankValidTo
            // 
            this.m_dtTankValidTo.Enabled = false;
            this.m_dtTankValidTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.m_dtTankValidTo.Location = new System.Drawing.Point(189, 127);
            this.m_dtTankValidTo.Name = "m_dtTankValidTo";
            this.m_dtTankValidTo.Size = new System.Drawing.Size(94, 20);
            this.m_dtTankValidTo.TabIndex = 11;
            // 
            // m_bAddTank
            // 
            this.m_bAddTank.Location = new System.Drawing.Point(127, 165);
            this.m_bAddTank.Name = "m_bAddTank";
            this.m_bAddTank.Size = new System.Drawing.Size(75, 23);
            this.m_bAddTank.TabIndex = 12;
            this.m_bAddTank.Text = "Add";
            this.m_bAddTank.UseVisualStyleBackColor = true;
            this.m_bAddTank.Click += new System.EventHandler(this.m_bAddTank_Click);
            // 
            // m_bCancelTank
            // 
            this.m_bCancelTank.Location = new System.Drawing.Point(208, 165);
            this.m_bCancelTank.Name = "m_bCancelTank";
            this.m_bCancelTank.Size = new System.Drawing.Size(75, 23);
            this.m_bCancelTank.TabIndex = 13;
            this.m_bCancelTank.Text = "Cancel";
            this.m_bCancelTank.UseVisualStyleBackColor = true;
            this.m_bCancelTank.Click += new System.EventHandler(this.m_bCancelTank_Click);
            // 
            // Tank
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 207);
            this.Controls.Add(this.m_bCancelTank);
            this.Controls.Add(this.m_bAddTank);
            this.Controls.Add(this.m_dtTankValidTo);
            this.Controls.Add(this.m_dtTankValidFrom);
            this.Controls.Add(this.m_tTankQuantity);
            this.Controls.Add(this.m_tTankName);
            this.Controls.Add(this.m_cbStockTank);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Tank";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tank";
            this.Load += new System.EventHandler(this.Tank_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox m_cbStockTank;
        private System.Windows.Forms.TextBox m_tTankName;
        private System.Windows.Forms.TextBox m_tTankQuantity;
        private System.Windows.Forms.DateTimePicker m_dtTankValidFrom;
        private System.Windows.Forms.DateTimePicker m_dtTankValidTo;
        private System.Windows.Forms.Button m_bAddTank;
        private System.Windows.Forms.Button m_bCancelTank;
    }
}