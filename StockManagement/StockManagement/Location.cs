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

namespace StockManagement
{
    public partial class Location : Form
    {
        DBTools m_dbTools = null;
        private Mode m_Mode;
        private DataTable m_dtLocation = null;

        public Location(DataTable dtLocation, DBTools dbTools)
        {
            InitializeComponent();
            m_dbTools = dbTools;
            m_dtLocation = dtLocation;
        }

        #region Methodes

        private void SwitchMode(Mode mode)
        {
            if (mode == Mode.View)
            {
                m_tbLocation.Text = string.Empty;
                m_tbLocation.Enabled = false;
                m_btOkLocation.Enabled = false;
                m_btUpdateLocation.Enabled = true;
                m_btAddLocation.Enabled = true;
                m_btCancelLocation.Enabled = false;
                m_Mode = Mode.View;
            }
            else if (mode == Mode.Add)
            {
                m_tbLocation.Enabled = true;
                m_btOkLocation.Enabled = true;
                m_btUpdateLocation.Enabled = false;
                m_btCancelLocation.Enabled = true;
                m_Mode = Mode.Add;
            }
            else if (mode == Mode.Update)
            {
                m_tbLocation.Enabled = true;
                m_btOkLocation.Enabled = true;
                m_btAddLocation.Enabled = false;
                m_btCancelLocation.Enabled = true;
                m_Mode = Mode.Update;
            }
        }

        private void SetHeaderColumns()
        {
            foreach (DataGridViewColumn dgc in m_dgvLocation.Columns)
            {
                if (dgc.DataPropertyName == LocationDefines.location_id_location || dgc.DataPropertyName == LocationDefines.location_id_location)
                {
                    dgc.Visible = false;
                }
               
                if (dgc.DataPropertyName == LocationDefines.location_name)
                {
                    dgc.HeaderText = "Location name";
                }
            }
        }

        private void LoadGridLocation()
        {
            if (m_dtLocation != null)
            {
                BindingSource SBind = new BindingSource();
                SBind.DataSource = m_dtLocation;
                m_dgvLocation.DataSource = SBind;
            }
        }
        #endregion

        #region Events

        private void Location_Load(object sender, EventArgs e)
        {
            LoadGridLocation();
            SetHeaderColumns();
            m_Mode = Mode.View;
        }

        private void m_dgvLocation_SelectionChanged(object sender, EventArgs e)
        {
            DataGridView dgv = sender as DataGridView;
            if (dgv != null && dgv.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgv.SelectedRows[0];
                DataRow dr = ((DataRowView)row.DataBoundItem).Row;
                if (dr != null)
                {
                    m_tbLocation.Text = dr.Field<string>(LocationDefines.location_name);
                }
            }
        }

        private void m_btAddLocation_Click(object sender, EventArgs e)

        {
            SwitchMode(Mode.Add);
            m_tbLocation.Text = null;
            m_tbLocation.Focus();
        }

        private void m_btUpdateLocation_Click(object sender, EventArgs e)
        {
            SwitchMode(Mode.Update);
            m_tbLocation.Focus();
            m_btAddLocation.Enabled = false;
            m_btCancelLocation.Enabled = true;
        }

        private void m_btOkLocation_Click(object sender, EventArgs e)
        {
            if (m_Mode == Mode.Add)
            {
                string sLocation = m_tbLocation.Text;

                if (!string.IsNullOrEmpty(sLocation))
                {
                    m_dbTools.AddLocation(sLocation);
                }
            }
            else if (m_Mode == Mode.Update)
            {
                DataRow dr = ((DataRowView)(m_dgvLocation.SelectedRows[0] as DataGridViewRow).DataBoundItem).Row;
                string sLocation = m_tbLocation.Text;
                string sOldLocation = dr.Field<string>(LocationDefines.location_name);
                int iIdLocation = dr.Field<int>(LocationDefines.location_id_location);

                // ajouter ce code pour AddRowStock et AddRowTank
                if (!string.IsNullOrEmpty(sLocation) && sLocation != sOldLocation)
                    m_dbTools.UpdateLocation(iIdLocation, sLocation);
            }
            m_dtLocation = m_dbTools.GetLocation();
            LoadGridLocation();
            SwitchMode(Mode.View);

            
        }

        private void m_btCancelLocation_Click(object sender, EventArgs e)
        {
            SwitchMode(Mode.View);
        }

        private void m_btClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion


    }
}

            