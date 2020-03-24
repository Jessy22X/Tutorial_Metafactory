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

        public Stock(DBTools dbTools)
        {
            InitializeComponent();
            m_dbTools = dbTools;
        }
        
        private void m_bAddStock_Click(object sender, EventArgs e)
        {

            if(m_dbTools.AddRowToStock())
            {
                MessageBox.Show("New stock added");
                this.Close();
            }            
        }
        
        private void m_bCancelStock_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
