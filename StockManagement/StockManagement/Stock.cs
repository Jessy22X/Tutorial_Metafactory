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
    public partial class Stock : Form
    {
        DBTools m_dbTools = null;
        private DataTable m_dtLocation = null;

        // on initialise la variable m_Mode;
        internal Mode m_Mode;

        // on initialise une DataRow pour récupérer ce qui sera envoyé à partir de la fenêtre StockManagement
        DataRow m_drStock = null;

        public Stock(DataRow drStock, DBTools dbTools, Mode mode)
        {
            InitializeComponent();
            m_dbTools = dbTools;
            m_dtLocation = m_dbTools.Location;
            m_drStock = drStock;
            m_Mode = mode;
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

        private void SwitchModeStock(Mode mode)
        {
            if (mode == Mode.View)
            {
                m_tbStockNumber.Enabled = false;
                m_tbStockCapacity.Enabled = false;
                m_cbStockLocation.Enabled = false;
                m_btOkStock.Enabled = false;
            }
            else if (mode == Mode.Update)
            {
                m_tbStockNumber.Enabled = true;
                m_tbStockCapacity.Enabled = true;
                m_cbStockLocation.Enabled = true;
                m_btOkStock.Enabled = true;
            }
        }

        private void LoadData()
        {
            if(m_drStock != null)
            {
                string sStockNumber = m_drStock.Field<string>(SearchDefines.column_stock_number);
                m_tbStockNumber.Text = sStockNumber;
                decimal dCapacity = m_drStock.Field<decimal>(SearchDefines.column_stock_capacity);
                m_tbStockCapacity.Text = dCapacity.ToString("#,##0.00");
                int iIdLocation = m_drStock.Field<int>(SearchDefines.column_location);
                m_cbStockLocation.SelectedValue = iIdLocation;
            }
        }
        #endregion

        #region Events

        // Au chargement de la fenêtre Stock
        private void Stock_Load(object sender, EventArgs e)
        {
            InitComboLocation();
            LoadData();
            SwitchModeStock(m_Mode);
        }

        private void m_btOkStock_Click(object sender, EventArgs e)
        {
            string sStockNumber = m_tbStockNumber.Text;
            decimal dCapacity = !string.IsNullOrEmpty(m_tbStockCapacity.Text) ? Convert.ToDecimal(m_tbStockCapacity.Text) : 0;
            int iIdLocation = m_cbStockLocation.SelectedValue == null ? 0 : Convert.ToInt32(m_cbStockLocation.SelectedValue);

            // La fenêtre a été ouverte à partir de "Update Stock" dans le menu contextuel de StockManagement.cs
            if (m_Mode == Mode.Update)
            {
                // on récupère l'id location de la row sélectionnée dans StockManagement.cs
                

                if (!string.IsNullOrEmpty(sStockNumber) && dCapacity > 0 && iIdLocation != 0)
                {
                    if (m_drStock != null)
                    {
                        int iIdStock = m_drStock.Field<int>(StockDefines.stock_id_stock);
                        string sStatus = m_drStock.Field<string>(StockDefines.stock_status);
                        if (m_dbTools.UpdateStock(iIdStock, sStockNumber, dCapacity, iIdLocation, sStatus))
                        {
                            MessageBox.Show("This stock has been updated successfully");
                        }
                    }
                }
                else
                    Console.WriteLine("error");
            }

            // La fenêtre a été ouverte à partir de Stock > New
            else if(m_Mode == Mode.Add)
            {               

                if (!string.IsNullOrEmpty(sStockNumber) && dCapacity > 0 && iIdLocation != 0)
                {
                    if (m_dbTools.AddNewStock(sStockNumber, dCapacity, iIdLocation))
                    {
                        MessageBox.Show("New stock added");
                    }
                }
                else
                    Console.WriteLine("error");
            }
        }
 
        private void m_bCancelStock_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }

}
