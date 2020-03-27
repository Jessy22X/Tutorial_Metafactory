using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Defines;
using static Defines.LocationDefines;
using static Defines.SearchDefines;

namespace StockManagement
{
    public partial class StockManagement : Form
    {
        DBTools m_dbTools = null;
        DateTimePickerFormat m_defaultDateTimePickerFormat = DateTimePickerFormat.Short;
        private DataTable m_dtLocation = null;
        private DataTable m_dtStock = null;

        public StockManagement()
        {
            InitializeComponent();
            m_dbTools = new DBTools();
            m_dtLocation = m_dbTools.Location;
            m_dtStock = m_dbTools.Stock;
        }

        #region Methodes

        private void ClearCriteria()
        {
            m_tbStockNumber.Text = string.Empty;
            m_tbTankName.Text = string.Empty;
            m_cbLocation.SelectedItem = null;
            m_dtValidFrom.Format = DateTimePickerFormat.Short;
            m_dtValidTo.Format = DateTimePickerFormat.Short;
            m_ckIncludingCancelledCnt.Checked = false;
        }

        private void InitDatePickerFormat()
        {
            m_dtValidFrom.Format = m_defaultDateTimePickerFormat;
            m_dtValidFrom.CustomFormat = " ";
            m_dtValidTo.Format = m_defaultDateTimePickerFormat;
            m_dtValidTo.CustomFormat = " ";
        }
        private void InitComboLocation()
        {
            if(m_dtLocation != null && m_dtLocation.Rows.Count > 0)
            {
                m_cbLocation.DataSource = m_dtLocation;
                m_cbLocation.ValueMember = "id_location";
                m_cbLocation.DisplayMember = "location_name";
            }
        }
        private void OnSearch()
        {
            DateTime? validDateFrom = string.IsNullOrWhiteSpace(m_dtValidFrom.Text) ? new DateTime(2001,1,1) : (DateTime?)m_dtValidFrom.Value;
            DateTime? validDateTo = string.IsNullOrWhiteSpace(m_dtValidTo.Text) ? new DateTime(2001, 1, 1) : (DateTime?)m_dtValidTo.Value;
            int? iIdLocation = m_cbLocation.SelectedValue == null ? 0 : Convert.ToInt32(m_cbLocation.SelectedValue);

            
            m_dbTools.AddRowToTableCriteria(m_tbStockNumber.Text, m_tbTankName.Text, validDateFrom, validDateTo, iIdLocation, m_ckIncludingCancelledCnt.Checked ? "Y" : "N");

            m_dbTools.Search();

            if (m_dbTools.SearchResult != null)
            {
                BindingSource SBind = new BindingSource();
                SBind.DataSource = m_dbTools.SearchResult;
                m_grResults.DataSource = SBind;
                SetHeaderColumns();
                SetLineColor();
            }
        }

        private void SetHeaderColumns()
        {
            foreach (DataGridViewColumn dgc in m_grResults.Columns)
            {
                if (dgc.DataPropertyName == SearchDefines.column_id_stock || dgc.DataPropertyName == SearchDefines.column_id_stock)
                {
                    dgc.Visible = false;
                }
                if (dgc.DataPropertyName == SearchDefines.column_id_tank || dgc.DataPropertyName == SearchDefines.column_id_tank)
                {
                    dgc.Visible = false;
                }
                if (dgc.DataPropertyName == SearchDefines.column_tank_name)
                {
                    dgc.HeaderText = "Tank name";
                }
                if (dgc.DataPropertyName == SearchDefines.column_stock_number)
                {
                    dgc.HeaderText = "Stock number";
                }
                if (dgc.DataPropertyName == SearchDefines.column_location)
                {
                    dgc.HeaderText = "Location";
                }
                if (dgc.DataPropertyName == SearchDefines.column_valid_from)
                {
                    dgc.HeaderText = "Valid from";
                }
                if (dgc.DataPropertyName == SearchDefines.column_valid_to)
                {
                    dgc.HeaderText = "Valid to";
                }
               
            }
        }
        private void SetLineColor()
        {
            foreach (DataGridViewRow dgr in m_grResults.Rows)
            {
                DataRowView dgv = dgr.DataBoundItem as DataRowView;
                if(dgv != null)
                {
                    DataRow dr = dgv.Row;
                    string sStatus = dr.Field<string>(SearchDefines.column_status);
                    if (!string.IsNullOrEmpty(sStatus) && sStatus == "C")
                        dgr.DefaultCellStyle.BackColor = Color.Red;
                }                
            }
        }

        #endregion

        #region Events
        private void StockManagement_Load(object sender, EventArgs e)
        {
            InitComboLocation();
            InitDatePickerFormat();
        }

        private void m_dtValidFrom_ValueChanged(object sender, EventArgs e)
        {
            m_dtValidFrom.Format = m_defaultDateTimePickerFormat;
        }

        private void m_dtValidTo_ValueChanged(object sender, EventArgs e)
        {
            m_dtValidTo.Format = m_defaultDateTimePickerFormat;
        }
        
        private void m_bClearCriteria_Click(object sender, EventArgs e)
        {
            ClearCriteria();
        }

        private void m_bSearch_Click(object sender, EventArgs e)
        {
            OnSearch();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stock myStock = new Stock(m_dtStock, m_dbTools);
            myStock.Show();
        }

        private void locationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Location myLocation = new Location(m_dtLocation, m_dbTools);
            myLocation.Show();
        }

        #endregion

        private void newToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Tank myTank = new Tank(m_dbTools);
            myTank.Show();
        }
    }
}
