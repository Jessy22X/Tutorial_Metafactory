using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StockManagement
{
    public partial class Tank : Form
    {
        DBTools m_dbTools = null;
        private DataTable m_dtStock = null;

        public Tank(DBTools dbTools)
        {
            InitializeComponent();
            m_dbTools = dbTools;
            m_dtStock = m_dbTools.Stock;
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
        #endregion

        #region Events

        #endregion

        private void Tank_Load(object sender, EventArgs e)
        {
            InitComboStock();
        }

        private void m_bAddTank_Click(object sender, EventArgs e)
        {
            int iIdStock = m_cbStockTank.SelectedValue != null ? Convert.ToInt32(m_cbStockTank.SelectedValue) : 0;
            string sTankName = m_tTankName.Text;
            decimal? dQuantity = !string.IsNullOrEmpty(m_tTankQuantity.Text) ? Convert.ToDecimal(m_tTankQuantity.Text) : 0;
            DateTime? dtValidFrom = m_dtTankValidFrom.Value;
            DateTime? dtValidto = m_dtTankValidTo.Value;

            if (iIdStock != 0 && !string.IsNullOrEmpty(sTankName) && dQuantity > 0)
            {
                if (m_dbTools.AddNewTank(iIdStock, sTankName, dQuantity, dtValidFrom, dtValidto))
                {
                    MessageBox.Show("New tank added");
                }
                //this.Close();
            }
            else
                Console.WriteLine("error");
        }

        private void m_bCancelTank_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void m_tTankQuantity_TextChanged(object sender, EventArgs e)
        {
            m_dtTankValidFrom.Enabled = true;
            m_dtTankValidTo.Enabled = true;
        }
    }
}
