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
    public partial class Tank : Form
    {
        DBTools m_dbTools = null;
        private DataTable m_dtStock = null;

        // on initialise la variable m_Mode;
        internal Mode m_Mode;

        // on initialise une DataRow pour récupérer ce qui sera envoyé à partir de la fenêtre StockManagement
        DataRow m_drTank = null;

        public Tank(DataRow drTank, DBTools dbTools, Mode mode)
        {
            InitializeComponent();
            m_dbTools = dbTools;
            m_dtStock = m_dbTools.GetStock();
            m_drTank = drTank;
            m_Mode = mode;
        }

        #region Methodes
        private void InitComboStock()
        {
            if (m_dtStock != null && m_dtStock.Rows.Count > 0)
            {
                m_cbStockTank.DataSource = m_dtStock;
                m_cbStockTank.ValueMember = "id_stock";
                m_cbStockTank.DisplayMember = "stock_number";
            }
        }

        private void SwitchModeTank(Mode mode)
        {
            if (mode == Mode.View)
            {
                m_tTankName.Enabled = false;
                m_tTankQuantity.Enabled = false;
                m_dtTankValidFrom.Enabled = false;
                m_dtTankValidTo.Enabled = false;
                m_cbStockTank.Enabled = false;
                m_bOkTank.Enabled = false;
            }
            else if (mode == Mode.Update)
            {
                m_tTankName.Enabled = true;
                m_tTankQuantity.Enabled = true;
                m_dtTankValidFrom.Enabled = true;
                m_dtTankValidTo.Enabled = true;
                m_cbStockTank.Enabled = true;
                m_bOkTank.Enabled = true;
            }
        }

        private void LoadData()
        {
            if (m_drTank != null)
            {
                int iIdStock = m_drTank.Field<int>(SearchDefines.column_id_stock);
                m_cbStockTank.SelectedValue = iIdStock;
                string sTankName = m_drTank.Field<string>(SearchDefines.column_tank_name);
                m_tTankName.Text = sTankName;
                decimal dQuantity = m_drTank.Field<decimal>(SearchDefines.column_tank_quantity);
                m_tTankQuantity.Text = dQuantity.ToString("#,##0.00");
                string dtValidFrom = m_drTank.Field<string>(SearchDefines.column_valid_from);
                m_dtTankValidFrom.Text = dtValidFrom == null ? " " : dtValidFrom.ToString();
                string dtValidTo = m_drTank.Field<string>(SearchDefines.column_valid_to);
                m_dtTankValidTo.Text = dtValidTo == null ? " " : dtValidTo.ToString();
            }
        }
        #endregion

        #region Events

        private void Tank_Load(object sender, EventArgs e)
        {
            InitComboStock();
            LoadData();
            SwitchModeTank(m_Mode);
        }

        private void m_bOkTank_Click(object sender, EventArgs e)
        {
            int iIdStock = m_cbStockTank.SelectedValue != null ? Convert.ToInt32(m_cbStockTank.SelectedValue) : 0;
            string sTankName = m_tTankName.Text;
            decimal? dQuantity = !string.IsNullOrEmpty(m_tTankQuantity.Text) ? Convert.ToDecimal(m_tTankQuantity.Text) : 0;
            DateTime? dtValidFrom = m_dtTankValidFrom.Value;
            DateTime? dtValidto = m_dtTankValidTo.Value;

            // La fenêtre a été ouverte à partir de "Update Stock" dans le menu contextuel de StockManagement.cs
            if (m_Mode == Mode.Update)
            {
                if (iIdStock != 0 && !string.IsNullOrEmpty(sTankName) && dQuantity > 0)
                {
                    if (m_drTank != null)
                    {
                        int iIdTank = m_drTank.Field<int>(TankDefines.tank_id_tank);
                        if (m_dbTools.UpdateTank(iIdStock, iIdTank, sTankName, dQuantity, dtValidFrom, dtValidto))
                        {
                            MessageBox.Show("This stock has been updated successfully");
                            this.DialogResult = DialogResult.OK;
                            this.Close();
                        }
                    }
                }
                else
                    Console.WriteLine("error");
            }

            // La fenêtre a été ouverte à partir de Tank > New
            else if (m_Mode == Mode.Add)
            {

                if (!string.IsNullOrEmpty(sTankName) && dQuantity > 0 && iIdStock != 0)
                {
                    if (m_dbTools.AddNewTank(iIdStock, sTankName, dQuantity, dtValidFrom, dtValidto))
                    {
                        MessageBox.Show("New stock added");
                        this.DialogResult = DialogResult.OK;
                        this.Close();
                    }
                }
                else
                    Console.WriteLine("error");
            }
        }

        private void m_bCancelTank_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void m_tTankQuantity_TextChanged(object sender, EventArgs e)
        {
            m_dtTankValidFrom.Enabled = true;
            m_dtTankValidTo.Enabled = true;
        }

        #endregion

        
    }
}
