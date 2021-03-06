﻿namespace StockManagement
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
            this.m_btAddLocation = new System.Windows.Forms.Button();
            this.m_btUpdateLocation = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.m_tbLocation = new System.Windows.Forms.TextBox();
            this.m_btOkLocation = new System.Windows.Forms.Button();
            this.m_btCancelLocation = new System.Windows.Forms.Button();
            this.m_btClose = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvLocation)).BeginInit();
            this.SuspendLayout();
            // 
            // m_dgvLocation
            // 
            this.m_dgvLocation.AllowUserToAddRows = false;
            this.m_dgvLocation.AllowUserToDeleteRows = false;
            this.m_dgvLocation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.m_dgvLocation.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.m_dgvLocation.Location = new System.Drawing.Point(12, 12);
            this.m_dgvLocation.Name = "m_dgvLocation";
            this.m_dgvLocation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.m_dgvLocation.Size = new System.Drawing.Size(351, 177);
            this.m_dgvLocation.TabIndex = 0;
            this.m_dgvLocation.SelectionChanged += new System.EventHandler(this.m_dgvLocation_SelectionChanged);
            // 
            // m_btAddLocation
            // 
            this.m_btAddLocation.Location = new System.Drawing.Point(207, 195);
            this.m_btAddLocation.Name = "m_btAddLocation";
            this.m_btAddLocation.Size = new System.Drawing.Size(75, 23);
            this.m_btAddLocation.TabIndex = 1;
            this.m_btAddLocation.Text = "Add";
            this.m_btAddLocation.UseVisualStyleBackColor = true;
            this.m_btAddLocation.Click += new System.EventHandler(this.m_btAddLocation_Click);
            // 
            // m_btUpdateLocation
            // 
            this.m_btUpdateLocation.Location = new System.Drawing.Point(288, 195);
            this.m_btUpdateLocation.Name = "m_btUpdateLocation";
            this.m_btUpdateLocation.Size = new System.Drawing.Size(75, 23);
            this.m_btUpdateLocation.TabIndex = 2;
            this.m_btUpdateLocation.Text = "Update";
            this.m_btUpdateLocation.UseVisualStyleBackColor = true;
            this.m_btUpdateLocation.Click += new System.EventHandler(this.m_btUpdateLocation_Click);
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
            this.m_btOkLocation.Enabled = false;
            this.m_btOkLocation.Location = new System.Drawing.Point(131, 303);
            this.m_btOkLocation.Name = "m_btOkLocation";
            this.m_btOkLocation.Size = new System.Drawing.Size(75, 23);
            this.m_btOkLocation.TabIndex = 5;
            this.m_btOkLocation.Text = "Ok";
            this.m_btOkLocation.UseVisualStyleBackColor = true;
            this.m_btOkLocation.Click += new System.EventHandler(this.m_btOkLocation_Click);
            // 
            // m_btCancelLocation
            // 
            this.m_btCancelLocation.Enabled = false;
            this.m_btCancelLocation.Location = new System.Drawing.Point(212, 303);
            this.m_btCancelLocation.Name = "m_btCancelLocation";
            this.m_btCancelLocation.Size = new System.Drawing.Size(75, 23);
            this.m_btCancelLocation.TabIndex = 6;
            this.m_btCancelLocation.Text = "Cancel";
            this.m_btCancelLocation.UseVisualStyleBackColor = true;
            this.m_btCancelLocation.Click += new System.EventHandler(this.m_btCancelLocation_Click);
            // 
            // m_btClose
            // 
            this.m_btClose.Location = new System.Drawing.Point(293, 303);
            this.m_btClose.Name = "m_btClose";
            this.m_btClose.Size = new System.Drawing.Size(75, 23);
            this.m_btClose.TabIndex = 7;
            this.m_btClose.Text = "Close";
            this.m_btClose.UseVisualStyleBackColor = true;
            this.m_btClose.Click += new System.EventHandler(this.m_btClose_Click);
            // 
            // Location
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 356);
            this.Controls.Add(this.m_btClose);
            this.Controls.Add(this.m_btCancelLocation);
            this.Controls.Add(this.m_btOkLocation);
            this.Controls.Add(this.m_tbLocation);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.m_btUpdateLocation);
            this.Controls.Add(this.m_btAddLocation);
            this.Controls.Add(this.m_dgvLocation);
            this.Name = "Location";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Location";
            this.Load += new System.EventHandler(this.Location_Load);
            ((System.ComponentModel.ISupportInitialize)(this.m_dgvLocation)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView m_dgvLocation;
        private System.Windows.Forms.Button m_btAddLocation;
        private System.Windows.Forms.Button m_btUpdateLocation;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox m_tbLocation;
        private System.Windows.Forms.Button m_btOkLocation;
        private System.Windows.Forms.Button m_btCancelLocation;
        private System.Windows.Forms.Button m_btClose;
    }
}