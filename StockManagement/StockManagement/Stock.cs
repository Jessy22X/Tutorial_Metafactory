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
    public partial class Stock : Form
    {
        DBTools m_dbTools = null;
        private DataTable m_dtLocation = null;

        public Stock(DataTable dtStock, DBTools dbTools)
        {
            InitializeComponent();
            m_dbTools = dbTools;
            m_dtLocation = m_dbTools.Location;
            
        }
        #region Methodes
        private void InitComboLocation()
        {
            if (m_dtLocation != null && m_dtLocation.Rows.Count > 0)
            {
                m_cbStockLocation.DataSource = m_dtLocation;
                m_cbStockLocation.ValueMember = "id_location";
                m_cbStockLocation.DisplayMember = "location_name";
            }
        }
        #endregion

        #region Events

        // Au chargement de la fenêtre Stock
        private void Stock_Load(object sender, EventArgs e)
        {
            InitComboLocation();
        }

        private void m_bAddStock_Click(object sender, EventArgs e)
        {
            string sStockNumber = m_tbStockNumber.Text;
            decimal dCapacity = !string.IsNullOrEmpty(m_tbStockCapacity.Text) ? Convert.ToDecimal(m_tbStockCapacity.Text) : 0;
            int iIdLocation = !string.IsNullOrEmpty(m_cbStockLocation.Text) ? m_cbStockLocation.SelectedIndex : -1;

            if (!string.IsNullOrEmpty(sStockNumber) && dCapacity > 0 && iIdLocation != -1)
            {
                if (m_dbTools.AddNewStock(sStockNumber, dCapacity, iIdLocation))
                {
                    MessageBox.Show("New stock added");
                }
                //this.Close();
            }
            else
                Console.WriteLine("error");
        }
 
        private void m_bCancelStock_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }

}
