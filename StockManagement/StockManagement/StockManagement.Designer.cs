namespace StockManagement
{
    partial class StockManagement
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StockManagement));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.stockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newStockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tankToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newTankToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.locationToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.m_cbStock = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.m_bSearch = new System.Windows.Forms.Button();
            this.m_bClearCriteria = new System.Windows.Forms.Button();
            this.m_ckIncludingCancelledCnt = new System.Windows.Forms.CheckBox();
            this.m_dtValidTo = new System.Windows.Forms.DateTimePicker();
            this.m_dtValidFrom = new System.Windows.Forms.DateTimePicker();
            this.m_cbLocation = new System.Windows.Forms.ComboBox();
            this.m_tbTankName = new System.Windows.Forms.TextBox();
            this.m_grResults = new System.Windows.Forms.DataGridView();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.stockToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.viewStockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateStockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cancelStockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tankToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.viewTankToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateTankToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_grResults)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menuToolStripMenuItem
            // 
            this.menuToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stockToolStripMenuItem,
            this.tankToolStripMenuItem,
            this.locationToolStripMenuItem});
            this.menuToolStripMenuItem.Name = "menuToolStripMenuItem";
            this.menuToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menuToolStripMenuItem.Text = "Menu";
            // 
            // stockToolStripMenuItem
            // 
            this.stockToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newStockToolStripMenuItem});
            this.stockToolStripMenuItem.Name = "stockToolStripMenuItem";
            this.stockToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.stockToolStripMenuItem.Text = "Stock";
            // 
            // newStockToolStripMenuItem
            // 
            this.newStockToolStripMenuItem.Name = "newStockToolStripMenuItem";
            this.newStockToolStripMenuItem.Size = new System.Drawing.Size(98, 22);
            this.newStockToolStripMenuItem.Text = "New";
            this.newStockToolStripMenuItem.Click += new System.EventHandler(this.newStockToolStripMenuItem_Click);
            // 
            // tankToolStripMenuItem
            // 
            this.tankToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newTankToolStripMenuItem1});
            this.tankToolStripMenuItem.Name = "tankToolStripMenuItem";
            this.tankToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.tankToolStripMenuItem.Text = "Tank";
            // 
            // newTankToolStripMenuItem1
            // 
            this.newTankToolStripMenuItem1.Name = "newTankToolStripMenuItem1";
            this.newTankToolStripMenuItem1.Size = new System.Drawing.Size(98, 22);
            this.newTankToolStripMenuItem1.Text = "New";
            this.newTankToolStripMenuItem1.Click += new System.EventHandler(this.newTankToolStripMenuItem_Click);
            // 
            // locationToolStripMenuItem
            // 
            this.locationToolStripMenuItem.Name = "locationToolStripMenuItem";
            this.locationToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.locationToolStripMenuItem.Text = "Location";
            this.locationToolStripMenuItem.Click += new System.EventHandler(this.locationToolStripMenuItem_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.m_cbStock);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.m_bSearch);
            this.groupBox1.Controls.Add(this.m_bClearCriteria);
            this.groupBox1.Controls.Add(this.m_ckIncludingCancelledCnt);
            this.groupBox1.Controls.Add(this.m_dtValidTo);
            this.groupBox1.Controls.Add(this.m_dtValidFrom);
            this.groupBox1.Controls.Add(this.m_cbLocation);
            this.groupBox1.Controls.Add(this.m_tbTankName);
            this.groupBox1.Location = new System.Drawing.Point(12, 42);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 72);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            // 
            // m_cbStock
            // 
            this.m_cbStock.FormattingEnabled = true;
            this.m_cbStock.Location = new System.Drawing.Point(75, 13);
            this.m_cbStock.Name = "m_cbStock";
            this.m_cbStock.Size = new System.Drawing.Size(157, 21);
            this.m_cbStock.TabIndex = 18;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(413, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "to";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(250, 45);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 16;
            this.label4.Text = "Valid from";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(250, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Location";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 43);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "Tank name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Stock#";
            // 
            // m_bSearch
            // 
            this.m_bSearch.Location = new System.Drawing.Point(689, 40);
            this.m_bSearch.Name = "m_bSearch";
            this.m_bSearch.Size = new System.Drawing.Size(75, 23);
            this.m_bSearch.TabIndex = 12;
            this.m_bSearch.Text = "Search";
            this.m_bSearch.UseVisualStyleBackColor = true;
            this.m_bSearch.Click += new System.EventHandler(this.m_bSearch_Click);
            // 
            // m_bClearCriteria
            // 
            this.m_bClearCriteria.Location = new System.Drawing.Point(598, 41);
            this.m_bClearCriteria.Name = "m_bClearCriteria";
            this.m_bClearCriteria.Size = new System.Drawing.Size(75, 23);
            this.m_bClearCriteria.TabIndex = 11;
            this.m_bClearCriteria.Text = "Clear criteria";
            this.m_bClearCriteria.UseVisualStyleBackColor = true;
            this.m_bClearCriteria.Click += new System.EventHandler(this.m_bClearCriteria_Click);
            // 
            // m_ckIncludingCancelledCnt
            // 
            this.m_ckIncludingCancelledCnt.AutoSize = true;
            this.m_ckIncludingCancelledCnt.Location = new System.Drawing.Point(598, 15);
            this.m_ckIncludingCancelledCnt.Name = "m_ckIncludingCancelledCnt";
            this.m_ckIncludingCancelledCnt.Size = new System.Drawing.Size(163, 17);
            this.m_ckIncludingCancelledCnt.TabIndex = 10;
            this.m_ckIncludingCancelledCnt.Text = "Including canceled contracts";
            this.m_ckIncludingCancelledCnt.UseVisualStyleBackColor = true;
            // 
            // m_dtValidTo
            // 
            this.m_dtValidTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.m_dtValidTo.Location = new System.Drawing.Point(435, 40);
            this.m_dtValidTo.Name = "m_dtValidTo";
            this.m_dtValidTo.Size = new System.Drawing.Size(79, 20);
            this.m_dtValidTo.TabIndex = 9;
            this.m_dtValidTo.ValueChanged += new System.EventHandler(this.m_dtValidTo_ValueChanged);
            // 
            // m_dtValidFrom
            // 
            this.m_dtValidFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.m_dtValidFrom.Location = new System.Drawing.Point(312, 40);
            this.m_dtValidFrom.Name = "m_dtValidFrom";
            this.m_dtValidFrom.Size = new System.Drawing.Size(82, 20);
            this.m_dtValidFrom.TabIndex = 7;
            this.m_dtValidFrom.ValueChanged += new System.EventHandler(this.m_dtValidFrom_ValueChanged);
            // 
            // m_cbLocation
            // 
            this.m_cbLocation.FormattingEnabled = true;
            this.m_cbLocation.Location = new System.Drawing.Point(312, 13);
            this.m_cbLocation.Name = "m_cbLocation";
            this.m_cbLocation.Size = new System.Drawing.Size(202, 21);
            this.m_cbLocation.TabIndex = 6;
            // 
            // m_tbTankName
            // 
            this.m_tbTankName.Location = new System.Drawing.Point(75, 40);
            this.m_tbTankName.Name = "m_tbTankName";
            this.m_tbTankName.Size = new System.Drawing.Size(157, 20);
            this.m_tbTankName.TabIndex = 5;
            // 
            // m_grResults
            // 
            this.m_grResults.AllowUserToAddRows = false;
            this.m_grResults.AllowUserToDeleteRows = false;
            this.m_grResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_grResults.ContextMenuStrip = this.contextMenuStrip1;
            this.m_grResults.Location = new System.Drawing.Point(12, 120);
            this.m_grResults.Name = "m_grResults";
            this.m_grResults.Size = new System.Drawing.Size(776, 330);
            this.m_grResults.TabIndex = 6;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stockToolStripMenuItem1,
            this.tankToolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(104, 48);
            this.contextMenuStrip1.Text = "MyContextMenu";
            // 
            // stockToolStripMenuItem1
            // 
            this.stockToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewStockToolStripMenuItem,
            this.updateStockToolStripMenuItem,
            this.cancelStockToolStripMenuItem});
            this.stockToolStripMenuItem1.Name = "stockToolStripMenuItem1";
            this.stockToolStripMenuItem1.Size = new System.Drawing.Size(103, 22);
            this.stockToolStripMenuItem1.Text = "Stock";
            // 
            // viewStockToolStripMenuItem
            // 
            this.viewStockToolStripMenuItem.Name = "viewStockToolStripMenuItem";
            this.viewStockToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.viewStockToolStripMenuItem.Text = "View Stock";
            this.viewStockToolStripMenuItem.Click += new System.EventHandler(this.viewStockToolStripMenuItem_Click);
            // 
            // updateStockToolStripMenuItem
            // 
            this.updateStockToolStripMenuItem.Name = "updateStockToolStripMenuItem";
            this.updateStockToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.updateStockToolStripMenuItem.Text = "Update Stock";
            this.updateStockToolStripMenuItem.Click += new System.EventHandler(this.updateStockToolStripMenuItem_Click);
            // 
            // cancelStockToolStripMenuItem
            // 
            this.cancelStockToolStripMenuItem.Name = "cancelStockToolStripMenuItem";
            this.cancelStockToolStripMenuItem.Size = new System.Drawing.Size(144, 22);
            this.cancelStockToolStripMenuItem.Text = "Cancel Stock";
            this.cancelStockToolStripMenuItem.Click += new System.EventHandler(this.cancelStockToolStripMenuItem_Click);
            // 
            // tankToolStripMenuItem1
            // 
            this.tankToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewTankToolStripMenuItem,
            this.updateTankToolStripMenuItem1});
            this.tankToolStripMenuItem1.Name = "tankToolStripMenuItem1";
            this.tankToolStripMenuItem1.Size = new System.Drawing.Size(103, 22);
            this.tankToolStripMenuItem1.Text = "Tank";
            // 
            // viewTankToolStripMenuItem
            // 
            this.viewTankToolStripMenuItem.Name = "viewTankToolStripMenuItem";
            this.viewTankToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.viewTankToolStripMenuItem.Text = "View Tank";
            this.viewTankToolStripMenuItem.Click += new System.EventHandler(this.viewTankToolStripMenuItem_Click);
            // 
            // updateTankToolStripMenuItem1
            // 
            this.updateTankToolStripMenuItem1.Name = "updateTankToolStripMenuItem1";
            this.updateTankToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.updateTankToolStripMenuItem1.Text = "Update Tank";
            this.updateTankToolStripMenuItem1.Click += new System.EventHandler(this.updateTankToolStripMenuItem1_Click);
            // 
            // StockManagement
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 462);
            this.Controls.Add(this.m_grResults);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "StockManagement";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stock management";
            this.Load += new System.EventHandler(this.StockManagement_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.m_grResults)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuToolStripMenuItem;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker m_dtValidFrom;
        private System.Windows.Forms.TextBox m_tbTankName;
        private System.Windows.Forms.DateTimePicker m_dtValidTo;
        private System.Windows.Forms.Button m_bSearch;
        private System.Windows.Forms.Button m_bClearCriteria;
        private System.Windows.Forms.CheckBox m_ckIncludingCancelledCnt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView m_grResults;
        private System.Windows.Forms.ToolStripMenuItem stockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newStockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tankToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newTankToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem locationToolStripMenuItem;
        private System.Windows.Forms.ComboBox m_cbLocation;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem stockToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem viewStockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateStockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cancelStockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tankToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem viewTankToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateTankToolStripMenuItem1;
        private System.Windows.Forms.ComboBox m_cbStock;
    }
}

