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
using static Defines.SearchDefines;

namespace StockManagement
{
    public partial class StockManagement : Form
    {

        DBTools m_dbTools = null;

        public StockManagement()
        {
            InitializeComponent();
            m_dbTools = new DBTools();
        }

        DateTimePickerFormat m_defaultDateTimePickerFormat = DateTimePickerFormat.Short;

        private void ClearCriteria()
        {
            m_tbStockNumber.Text = string.Empty;
            m_tbTankName.Text = string.Empty;
            m_cbLocation.SelectedValue = null;
            m_dtValidFrom.Format = DateTimePickerFormat.Custom;
            m_dtValidTo.Format = DateTimePickerFormat.Custom;
            m_ckIncludingCancelledCnt.Checked = false;
        }

        private void InitDatePickerFormat()
        {
            m_dtValidFrom.Format = m_defaultDateTimePickerFormat;
            m_dtValidFrom.CustomFormat = " ";
            m_dtValidTo.Format = m_defaultDateTimePickerFormat;
            m_dtValidTo.CustomFormat = " ";
        }

        private void m_dtValidFrom_ValueChanged(object sender, EventArgs e)
        {
            m_dtValidFrom.Format = m_defaultDateTimePickerFormat;
        }

        private void StockManagement_Load(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void m_bClearCriteria_Click(object sender, EventArgs e)
        {
            ClearCriteria();
        }

        private void OnSearch()
        {
            DateTime? validDateFrom = string.IsNullOrWhiteSpace(m_dtValidFrom.Text)
            ? null
            : (DateTime?)m_dtValidFrom.Value;
            DateTime? validDateTo = string.IsNullOrWhiteSpace(m_dtValidTo.Text)
            ? null
            : (DateTime?)m_dtValidTo.Value;
            m_dbTools.AddRowToTableCriteria(m_tbStockNumber.Text, m_tbTankName.Text,
            validDateFrom, validDateTo, m_cbLocation.SelectedIndex,
            m_ckIncludingCancelledCnt.Checked ? "A" : "C");

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
                if(dgc.DataPropertyName == SearchDefines.column_id_location ||dgc.DataPropertyName == SearchDefines.column_id_tank)
                {
                    dgc.Visible = false;
                }
                // pareil mais il faut remplacer dgc.DataPropertyName par SearchDefines.column.Name
            }
        }
        private void SetLineColor()
        {
            foreach (DataGridViewRow dgr in m_grResults.Rows)
            {
                DataRow dr = ((DataRowView)dgr.DataBoundItem).Row;
                string sStatus = dr.Field<string>(SearchDefines.column_status);
                if (!string.IsNullOrEmpty(sStatus) && sStatus == "C")
                    dgr.DefaultCellStyle.BackColor = Color.Red;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
