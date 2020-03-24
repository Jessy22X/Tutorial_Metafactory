namespace StockManagement
{
    partial class Stock
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
            this.m_bAddStock = new System.Windows.Forms.Button();
            this.m_bCancelStock = new System.Windows.Forms.Button();
            this.l_Stock = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.m_tStockStock = new System.Windows.Forms.TextBox();
            this.m_tStockCapacity = new System.Windows.Forms.TextBox();
            this.m_cbStockLocation = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // m_bAddStock
            // 
            this.m_bAddStock.Location = new System.Drawing.Point(151, 120);
            this.m_bAddStock.Name = "m_bAddStock";
            this.m_bAddStock.Size = new System.Drawing.Size(75, 23);
            this.m_bAddStock.TabIndex = 0;
            this.m_bAddStock.Text = "Add";
            this.m_bAddStock.UseVisualStyleBackColor = true;
            //this.m_bAddStock.Click += new System.EventHandler(this.m_bAddStock_Click);
            // 
            // m_bCancelStock
            // 
            this.m_bCancelStock.Location = new System.Drawing.Point(232, 120);
            this.m_bCancelStock.Name = "m_bCancelStock";
            this.m_bCancelStock.Size = new System.Drawing.Size(75, 23);
            this.m_bCancelStock.TabIndex = 1;
            this.m_bCancelStock.Text = "Cancel";
            this.m_bCancelStock.UseVisualStyleBackColor = true;
            this.m_bCancelStock.Click += new System.EventHandler(this.m_bCancelStock_Click);
            // 
            // l_Stock
            // 
            this.l_Stock.AutoSize = true;
            this.l_Stock.Location = new System.Drawing.Point(21, 27);
            this.l_Stock.Name = "l_Stock";
            this.l_Stock.Size = new System.Drawing.Size(45, 13);
            this.l_Stock.TabIndex = 2;
            this.l_Stock.Text = "Stock #";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Capacity";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Location";
            // 
            // m_tStockStock
            // 
            this.m_tStockStock.Location = new System.Drawing.Point(76, 24);
            this.m_tStockStock.Name = "m_tStockStock";
            this.m_tStockStock.Size = new System.Drawing.Size(220, 20);
            this.m_tStockStock.TabIndex = 5;
            // 
            // m_tStockCapacity
            // 
            this.m_tStockCapacity.Location = new System.Drawing.Point(76, 53);
            this.m_tStockCapacity.Name = "m_tStockCapacity";
            this.m_tStockCapacity.Size = new System.Drawing.Size(220, 20);
            this.m_tStockCapacity.TabIndex = 6;
            // 
            // m_cbStockLocation
            // 
            this.m_cbStockLocation.FormattingEnabled = true;
            this.m_cbStockLocation.Location = new System.Drawing.Point(76, 80);
            this.m_cbStockLocation.Name = "m_cbStockLocation";
            this.m_cbStockLocation.Size = new System.Drawing.Size(220, 21);
            this.m_cbStockLocation.TabIndex = 7;
            // 
            // Stock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(319, 155);
            this.Controls.Add(this.m_cbStockLocation);
            this.Controls.Add(this.m_tStockCapacity);
            this.Controls.Add(this.m_tStockStock);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.l_Stock);
            this.Controls.Add(this.m_bCancelStock);
            this.Controls.Add(this.m_bAddStock);
            this.Name = "Stock";
            this.Text = "Stock";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button m_bAddStock;
        private System.Windows.Forms.Button m_bCancelStock;
        private System.Windows.Forms.Label l_Stock;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox m_tStockStock;
        private System.Windows.Forms.TextBox m_tStockCapacity;
        private System.Windows.Forms.ComboBox m_cbStockLocation;
    }
}