using System;
using System.Data;
using System.Data.SqlClient;
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
        private DBTools m_dbTools;

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

        internal bool CreateTableCriteria()
        {
            DataTable myTable = new DataTable();

            return true;
        }

        internal bool AddRowToTableCriteria(string s_contractNumner, string s_tankName)
        {
            DataSet newCriteria = new DataSet();
            DataTable criteriaTable = newCriteria.Tables.Add("CriteriaTable");

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


        
    }
}


