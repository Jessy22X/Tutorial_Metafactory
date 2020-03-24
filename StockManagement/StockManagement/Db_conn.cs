using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static Defines;

namespace StockManagement
{
    public class DBTools
    {
        private string m_sConnection = "Data Source=.\\SQLServer;" +
                                       "User Instance=true;" +
                                       "AttachDbFilename=|DataDirectory|StockDB.mdf;";
        private DataTable m_dtSearchResult = null;
        private DataTable m_dtCriteria = null;
        private DataTable m_dtLocation = null;
        internal object location;

        public DBTools()
        {
            Criteria = CreateTableCriteria();
            GetLocation();
        }

        public DataTable SearchResult
        {
            get
            {
                return m_dtSearchResult;
            }
            set
            {
                m_dtSearchResult = value;
            }
        }

        public DataTable Criteria
        {
            get
            {
                return m_dtCriteria;
            }

            set
            {
                m_dtCriteria = value;
            }
        }

        public DataTable Location
        {
            get
            {
                return m_dtLocation;
            }

            set
            {
                m_dtLocation = value;
            }
        }

        internal DataTable CreateTableCriteria()
        {
            if(Criteria != null)
            {
                return Criteria;
            }
            else
            {
                DataTable myTable = new DataTable();
                myTable.Columns.Add(CriteriaDefines.criterium_stock_number, typeof(string));

                Criteria = myTable;
                return Criteria;
            }
        }

        internal bool AddRowToTableCriteria(string sContractNumber, string sTankName, DateTime? dt_validFrom, DateTime? dt_validTo, int i_idLocation, string s_includeCancelled)
        {
            Criteria.Rows.Add(sContractNumber, sTankName, dt_validFrom, dt_validTo, i_idLocation, s_includeCancelled);
            return true;
        }

        internal bool Search()
        {
            try
            {
                if (m_dtCriteria == null || m_dtCriteria.Rows.Count == 0)
                    return false;

                using (SqlConnection conn = new SqlConnection(m_sConnection))
                {
                    conn.Open();

                    //get criteria from table
                    DataRow drCriteria = m_dtCriteria.Rows[0];
                    string sStockNumber = drCriteria.Field<string>(CriteriaDefines.criterium_stock_number);
                    string sTankName = drCriteria.Field<string>(CriteriaDefines.criterium_tank_name);
                    DateTime? dValidFrom = drCriteria.Field<DateTime?>(CriteriaDefines.criterium_valid_from);
                    DateTime? dValidTo = drCriteria.Field<DateTime?>(CriteriaDefines.criterium_valid_to);
                    int? iIdLocation = drCriteria.Field<int?>(CriteriaDefines.criterium_location);
                    string sIncludeCancelled = drCriteria.Field<string>(CriteriaDefines.criterium_include_cancelled);
                    //set stored procedure name
                    string spName = @"dbo.[STOCK_MANAGEMENT_SEARCH]";

                    //define the SqlCommand object
                    SqlCommand cmd = new SqlCommand(spName, conn);

                    //Set SqlParameter - the employee id parameter value will be set from the command line
                    SqlParameter paramStockNumber = new SqlParameter("@stock_number", SqlDbType.NVarChar);
                    paramStockNumber.Value = sStockNumber;

                    SqlParameter paramTankName = new SqlParameter("@tank_name", SqlDbType.NVarChar);
                    paramTankName.Value = sTankName;

                    SqlParameter paramValidFrom = new SqlParameter("@valid_from", SqlDbType.DateTime);
                    paramValidFrom.Value = dValidFrom;

                    SqlParameter paramValidTo = new SqlParameter("@valid_to", SqlDbType.DateTime);
                    paramValidTo.Value = dValidTo;

                    SqlParameter paramLocation = new SqlParameter("@id_location", SqlDbType.Int);
                    paramLocation.Value = iIdLocation;

                    SqlParameter paramIncludeCancelled = new SqlParameter("@include_cancelled", SqlDbType.Char);
                    paramIncludeCancelled.Value = sIncludeCancelled;

                    //add the parameter to the SqlCommand object
                    cmd.Parameters.Add(paramStockNumber);
                    cmd.Parameters.Add(paramTankName);
                    cmd.Parameters.Add(paramValidFrom);
                    cmd.Parameters.Add(paramValidTo);
                    cmd.Parameters.Add(paramLocation);
                    cmd.Parameters.Add(paramIncludeCancelled);

                    //set the SqlCommand type to stored procedure and execute
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader dr = cmd.ExecuteReader();

                    Console.WriteLine(Environment.NewLine + "Retrieving data from database..." + Environment.NewLine);

                    //check if there are records
                    if (dr.HasRows)
                    {
                        SearchResult.Load(dr);
                    }
                    else
                    {
                        Console.WriteLine("No data found.");
                    }

                    //close data reader
                    dr.Close();

                    //close connection
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                //display error message
                Console.WriteLine("Exception: " + ex.Message);
                return false;
            }


            return true;
        }

        // Méthode pour l'ajout d'une ligne dans la table Stock
        internal bool AddRowToStock(int i_stock_number, decimal? d_stock_capacity, int i_id_location)
        {
            bool bIsOK = false;
            try
            {
               
                using (SqlConnection conn = new SqlConnection(m_sConnection))
                {
                    conn.Open();

                    
                    //set stored procedure name
                    string spName = @"dbo.[STOCK_MANAGEMENT_ADD_STOCK]";

                    //define the SqlCommand object
                    SqlCommand cmd = new SqlCommand(spName, conn);

                    //Set SqlParameter - the employee id parameter value will be set from the command line
                    SqlParameter paramStockNumber = new SqlParameter("@stock_number", SqlDbType.NVarChar);
                    paramStockNumber.Value = i_stock_number;

                    SqlParameter paramTankName = new SqlParameter("@capacity", SqlDbType.Decimal);
                    paramTankName.Value = d_stock_capacity;

                    SqlParameter paramLocation = new SqlParameter("@id_location", SqlDbType.Int);
                    paramLocation.Value = i_id_location;
                    

                    //add the parameter to the SqlCommand object
                    cmd.Parameters.Add(paramStockNumber);
                    cmd.Parameters.Add(paramTankName);
                    cmd.Parameters.Add(paramLocation);

                    //set the SqlCommand type to stored procedure and execute
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader dr = cmd.ExecuteReader();

                    Console.WriteLine(Environment.NewLine + "Retrieving data from database..." + Environment.NewLine);

                    //check if there are records
                    if (dr.HasRows)
                    {
                        string sError = dr.GetValue(0).ToString();
                        MessageBox.Show(sError, "Error");
                    }
                    else
                    {
                        bIsOK = true;
                    }

                    //close datik a reader
                    dr.Close();

                    //close connection
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                //display error message
                Console.WriteLine("Exception: " + ex.Message);
            }


            return bIsOK;
        }

        internal bool AddRowToTank(int i_id_stock, string s_tank_name, decimal? d_quantity, DateTime? dt_valid_from, DateTime? dt_valid_to)
        {
            DataSet newTank = new DataSet();
            DataTable tankTable = newTank.Tables.Add("tank");

            return true;
        }

        internal bool AddRowToLocation(string s_location_name)
        {
            DataSet newLocation = new DataSet();
            DataTable tankTable = newLocation.Tables.Add("location");

            return true;
        }

        internal bool GetLocation()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(m_sConnection))
                {
                    conn.Open();
                    
                    //set stored procedure name
                    string spName = @"dbo.[STOCK_MANAGEMENT_GET_LOCATION]";

                    //define the SqlCommand object
                    SqlCommand cmd = new SqlCommand(spName, conn);
                    
                    //set the SqlCommand type to stored procedure and execute
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader dr = cmd.ExecuteReader();

                    Console.WriteLine(Environment.NewLine + "Retrieving data from database..." + Environment.NewLine);

                    //check if there are records
                    if (dr.HasRows)
                    {
                        Location.Load(dr);
                    }
                    else
                    {
                        Console.WriteLine("No data found.");
                    }

                    //close data reader
                    dr.Close();

                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: " + ex.Message);
                return false;
            }

            return true;
        }

        internal bool AddLocation(string sLocation_name)
        {

            bool bIsOK = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(m_sConnection))
                {
                    conn.Open();


                    //set stored procedure name
                    string spName = @"dbo.[STOCK_MANAGEMENT_ADD_LOCATION]";

                    //define the SqlCommand object
                    SqlCommand cmd = new SqlCommand(spName, conn);

                    //Set SqlParameter - the employee id parameter value will be set from the command line
                    SqlParameter paramLocation = new SqlParameter("@location_name", SqlDbType.NVarChar);
                    paramLocation.Value = sLocation_name;

                    //add the parameter to the SqlCommand object
                    cmd.Parameters.Add(paramLocation);

                    //set the SqlCommand type to stored procedure and execute
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader dr = cmd.ExecuteReader();

                    Console.WriteLine(Environment.NewLine + "Retrieving data from database..." + Environment.NewLine);

                    //check if there are records
                    if (dr.HasRows)
                    {
                        string sError = dr.GetValue(0).ToString();
                        MessageBox.Show(sError, "Error");
                    }
                    else
                    {
                        bIsOK = true;
                    }

                    //close datik a reader
                    dr.Close();

                    //close connection
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                //display error message
                Console.WriteLine("Exception: " + ex.Message);
            }

            return bIsOK;
        }

        internal bool UpdateLocation(int iIdLocation, string sLocation_name)
        {

            bool bIsOK = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(m_sConnection))
                {
                    conn.Open();


                    //set stored procedure name
                    string spName = @"dbo.[STOCK_MANAGEMENT_UPDATE_LOCATION]";

                    //define the SqlCommand object
                    SqlCommand cmd = new SqlCommand(spName, conn);

                    //Set SqlParameter - the employee id parameter value will be set from the command line
                    SqlParameter paramIdLocation = new SqlParameter("@id_location", SqlDbType.NVarChar);
                    paramIdLocation.Value = iIdLocation;
                    SqlParameter paramLocationName = new SqlParameter("@location_name", SqlDbType.NVarChar);
                    paramLocationName.Value = sLocation_name;

                    //add the parameter to the SqlCommand object
                    cmd.Parameters.Add(paramIdLocation);
                    cmd.Parameters.Add(paramLocationName);

                    //set the SqlCommand type to stored procedure and execute
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader dr = cmd.ExecuteReader();

                    Console.WriteLine(Environment.NewLine + "Retrieving data from database..." + Environment.NewLine);

                    //check if there are records
                    if (dr.HasRows)
                    {
                        string sError = dr.GetValue(0).ToString();
                        MessageBox.Show(sError, "Error");
                    }
                    else
                    {
                        bIsOK = true;
                    }

                    //close datik a reader
                    dr.Close();

                    //close connection
                    conn.Close();
                }
            }
            catch (Exception ex)
            {
                //display error message
                Console.WriteLine("Exception: " + ex.Message);
            }

            return bIsOK;
        }

    }
}


