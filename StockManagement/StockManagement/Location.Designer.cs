namespace StockManagement
{
    partial class Location
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
            this.m_dgvLocation = new System.Windows.Forms.DataGridView();
            this.m_bAddLocation = new System.Windows.Forms.Button();
            this.m_bUpdateLocation = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.m_tbLocation = new System.Windows.Forms.TextBox();
            this.m_btOkLocation = new System.Windows.Forms.Button();
            this.m_bCancelLocation = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvLocation)).BeginInit();
            this.SuspendLayout();
            // 
            // m_dgvLocation
            // 
            this.m_dgvLocation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_dgvLocation.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.m_dgvLocation.Location = new System.Drawing.Point(12, 12);
            this.m_dgvLocation.Name = "m_dgvLocation";
            this.m_dgvLocation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_dgvLocation.Size = new System.Drawing.Size(351, 177);
            this.m_dgvLocation.TabIndex = 0;
            this.m_dgvLocation.SelectionChanged += new System.EventHandler(this.m_dgvLocation_SelectionChanged);
            // 
            // m_bAddLocation
            // 
            this.m_bAddLocation.Location = new System.Drawing.Point(207, 195);
            this.m_bAddLocation.Name = "m_bAddLocation";
            this.m_bAddLocation.Size = new System.Drawing.Size(75, 23);
            this.m_bAddLocation.TabIndex = 1;
            this.m_bAddLocation.Text = "Add";
            this.m_bAddLocation.UseVisualStyleBackColor = true;
            this.m_bAddLocation.Click += new System.EventHandler(this.m_btAddLocation_Click);
            // 
            // m_bUpdateLocation
            // 
            this.m_bUpdateLocation.Location = new System.Drawing.Point(288, 195);
            this.m_bUpdateLocation.Name = "m_bUpdateLocation";
            this.m_bUpdateLocation.Size = new System.Drawing.Size(75, 23);
            this.m_bUpdateLocation.TabIndex = 2;
            this.m_bUpdateLocation.Text = "Update";
            this.m_bUpdateLocation.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 251);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Location name";
            // 
            // m_tbLocation
            // 
            this.m_tbLocation.Enabled = false;
            this.m_tbLocation.Location = new System.Drawing.Point(95, 248);
            this.m_tbLocation.Name = "m_tbLocation";
            this.m_tbLocation.Size = new System.Drawing.Size(237, 20);
            this.m_tbLocation.TabIndex = 4;
            // 
            // m_btOkLocation
            // 
            this.m_btOkLocation.Location = new System.Drawing.Point(176, 303);
            this.m_btOkLocation.Name = "m_btOkLocation";
            this.m_btOkLocation.Size = new System.Drawing.Size(75, 23);
            this.m_btOkLocation.TabIndex = 5;
            this.m_btOkLocation.Text = "Ok";
            this.m_btOkLocation.UseVisualStyleBackColor = true;
            this.m_btOkLocation.Click += new System.EventHandler(this.m_bOkLocation_Click);
            // 
            // m_bCancelLocation
            // 
            this.m_bCancelLocation.Location = new System.Drawing.Point(257, 303);
            this.m_bCancelLocation.Name = "m_bCancelLocation";
            this.m_bCancelLocation.Size = new System.Drawing.Size(75, 23);
            this.m_bCancelLocation.TabIndex = 6;
            this.m_bCancelLocation.Text = "Cancel";
            this.m_bCancelLocation.UseVisualStyleBackColor = true;
            // 
            // Location
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 356);
            this.Controls.Add(this.m_bCancelLocation);
            this.Controls.Add(this.m_btOkLocation);
            this.Controls.Add(this.m_tbLocation);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_bUpdateLocation);
            this.Controls.Add(this.m_bAddLocation);
            this.Controls.Add(this.m_dgvLocation);
            this.Name = "Location";
            this.Text = "Location";
            this.Load += new System.EventHandler(this.Location_Load);
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvLocation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView m_dgvLocation;
        private System.Windows.Forms.Button m_bAddLocation;
        private System.Windows.Forms.Button m_bUpdateLocation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox m_tbLocation;
        private System.Windows.Forms.Button m_btOkLocation;
        private System.Windows.Forms.Button m_bCancelLocation;
    }
}