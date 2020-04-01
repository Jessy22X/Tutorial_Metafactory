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
            m_cbStock.Text = string.Empty;
            m_tbTankName.Text = string.Empty;
            m_cbLocation.SelectedItem = null;
            m_dtValidFrom.Format = DateTimePickerFormat.Custom;
            m_dtValidTo.Format = DateTimePickerFormat.Custom;
            m_ckIncludingCancelledCnt.Checked = false;
        }
        #region Initialisation StockManagement
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

        private void InitComboStock()
        {
            if (m_dtStock != null && m_dtStock.Rows.Count > 0)
            {
                m_cbStock.DataSource = m_dtStock;
                m_cbStock.ValueMember = "id_stock";
                m_cbStock.DisplayMember = "stock_number";
            }
        }

        #endregion

        private void OnSearch()
        {
            DateTime? validDateFrom = string.IsNullOrWhiteSpace(m_dtValidFrom.Text) ? new DateTime(2001,1,1) : (DateTime?)m_dtValidFrom.Value;
            DateTime? validDateTo = string.IsNullOrWhiteSpace(m_dtValidTo.Text) ? new DateTime(2001, 1, 1) : (DateTime?)m_dtValidTo.Value;
            int? iIdLocation = m_cbLocation.SelectedValue == null ? 0 : Convert.ToInt32(m_cbLocation.SelectedValue);
            int? iIdStock = m_cbStock.SelectedValue == null ? 0 : Convert.ToInt32(m_cbStock.SelectedValue);


            m_dbTools.AddRowToTableCriteria(iIdStock, m_tbTankName.Text, validDateFrom, validDateTo, iIdLocation, m_ckIncludingCancelledCnt.Checked ? "Y" : "N");

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

        #region StockManagement Events
        private void StockManagement_Load(object sender, EventArgs e)
        {
            InitComboLocation();
            InitComboStock();
            InitDatePickerFormat();
            m_cbStock.SelectedIndex = -1;
            m_cbLocation.SelectedIndex = -1;
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

        #endregion

        #region Location Event
        private void locationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Location myLocation = new Location(m_dtLocation, m_dbTools);
            myLocation.Show();
        }
        #endregion

        #region Stock Event

        private void newStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stock myStock = new Stock(null, m_dbTools, Mode.Add);
            myStock.Show();
        }

        private void viewStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // on récupère la ligne sélectionnée
            DataGridViewRow dRow = m_grResults.CurrentRow as DataGridViewRow;
            if (dRow != null)
            {
                // on récupère toutes les données (même cachées) de la ligne sélectionnée
                DataRow drRow = ((DataRowView)dRow.DataBoundItem).Row;

                // on initialise une nouvelle fenêtre Stock avec en argument les données de la ligne sélectionnée (ou pas), paramètre de connexion et le mode de Vue
                Stock viewStock = new Stock(drRow, m_dbTools, Mode.View);
                viewStock.Show();
            }
        }

        private void updateStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // on récupère la ligne sélectionnée
            DataGridViewRow dRow = m_grResults.CurrentRow as DataGridViewRow;
            if (dRow != null)
            {
                // on récupère toutes les données (même cachées) de la ligne sélectionnée
                DataRow drRow = ((DataRowView)dRow.DataBoundItem).Row;

                // on initialise une nouvelle fenêtre Stock avec en argument les données de la ligne sélectionnée (ou pas), paramètre de connexion et le mode de Vue
                Stock updateStock = new Stock(drRow, m_dbTools, Mode.Update);
                updateStock.Show();
            }
        }

        private void cancelStockToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataGridViewRow dRow = m_grResults.CurrentRow as DataGridViewRow;
            if (dRow != null)
            {
                // on récupère toutes les données (même cachées) de la ligne sélectionnée
                DataRow drRow = ((DataRowView)dRow.DataBoundItem).Row;

                string sStatusActuel = drRow.Field<string>(SearchDefines.column_status);
                if (!string.IsNullOrEmpty(sStatusActuel) && sStatusActuel == "A")
                {
                    int iIdStock = drRow.Field<int>(SearchDefines.column_id_stock);
                    string sStockNumber = drRow.Field<string>(SearchDefines.column_stock_number);
                    decimal dCapacity = drRow.Field<decimal>(SearchDefines.column_stock_capacity);
                    int iIdLocation = drRow.Field<int>(SearchDefines.column_location);
                    string sStatus = "C";

                    // on initialise une nouvelle fenêtre Stock avec en argument les données de la ligne sélectionnée (ou pas), paramètre de connexion et le mode de Vue
                    if (m_dbTools.UpdateStock(iIdStock, sStockNumber, dCapacity, iIdLocation, sStatus))
                    {
                        drRow.SetField(SearchDefines.column_status, "C");
                        m_dbTools.SearchResult.AcceptChanges();

                        MessageBox.Show(sStockNumber + " was cancelled", "Information");
                    }
                }
                else
                {
                    //todo message
                }

            }
        }

        #endregion

        #region Tank Events

        private void newTankToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Tank myTank = new Tank(null, m_dbTools, Mode.Add);
            myTank.Show();
        }

        private void viewTankToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // on récupère la ligne sélectionnée
            DataGridViewRow dRow = m_grResults.CurrentRow as DataGridViewRow;
            if (dRow != null)
            {
                // on récupère toutes les données (même cachées) de la ligne sélectionnée
                DataRow drRow = ((DataRowView)dRow.DataBoundItem).Row;

                // on initialise une nouvelle fenêtre Tank avec en argument les données de la ligne sélectionnée (ou pas), paramètre de connexion et le mode de Vue
                Tank viewTank = new Tank(drRow, m_dbTools, Mode.View);
                viewTank.Show();
            }
        }

        private void updateTankToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // on récupère la ligne sélectionnée
            DataGridViewRow dRow = m_grResults.CurrentRow as DataGridViewRow;
            if (dRow != null)
            {
                // on récupère toutes les données (même cachées) de la ligne sélectionnée
                DataRow drRow = ((DataRowView)dRow.DataBoundItem).Row;

                // on initialise une nouvelle fenêtre Tank avec en argument les données de la ligne sélectionnée (ou pas), paramètre de connexion et le mode de Vue
                Tank updateTank = new Tank(drRow, m_dbTools, Mode.Update);
                updateTank.Show();
            }
        }


        #endregion

        #endregion


    }
}
