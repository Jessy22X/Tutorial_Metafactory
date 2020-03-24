using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Defines.LocationDefines;

namespace StockManagement
{
    public partial class Location : Form
    {
        DBTools m_dbTools = null;
        private Mode m_Mode;

        public Location(DBTools dbTools)
        {
            InitializeComponent();
            m_dbTools = dbTools;
        }

        #region Methodes
        private void Location_Load(object sender, EventArgs e)
        {
            if (m_dbTools.location != null)
            {
                BindingSource SBind = new BindingSource();
                SBind.DataSource = m_dbTools.location;
                m_dgvLocation.DataSource = SBind;
                m_Mode = Mode.View;
            }
        }

        private void SwitchMode(Mode mode)

        {

            if (mode == Mode.View)

            {

                m_tbLocation.Text = string.Empty;

                m_tbLocation.Enabled = false;

                m_btOkLocation.Enabled = false;

                m_Mode = Mode.View;

            }

            else if (mode == Mode.Add)

            {

                m_tbLocation.Enabled = true;

                m_btOkLocation.Enabled = true;

                m_Mode = Mode.Add;

            }

            else if (mode == Mode.Update)

            {

                m_tbLocation.Enabled = true;

                m_btOkLocation.Enabled = true;

                m_Mode = Mode.Update;

            }

        }
        #endregion

        #region Events

        private void m_dgvLocation_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if(dgv != null && dgv.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgv.SelectedRows[0];
                if(row != null)
                {
                    m_tbLocation.Text = row.Cells[0].Value.ToString();
                }
            }
        }

        private void m_btAddLocation_Click(object sender, EventArgs e)

        {
            SwitchMode(Mode.Add);
            m_tbLocation.Enabled = true;
        }

        private void m_bOkLocation_Click(object sender, EventArgs e)
        {
            if(m_Mode == Mode.Add)
            {
                m_dbTools.AddLocation(m_tbLocation.Text);
            }
            else if(m_Mode == Mode.Update)
            {
                m_dbTools.UpdateLocation(m_tbLocation.Text);
            }
         
        }

        #endregion

    }
}

            