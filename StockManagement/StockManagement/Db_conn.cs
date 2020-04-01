using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using static Defines;

namespace StockManagement
{
    public class DBTools
    {
        private string m_sConnection = "Data Source=(localdb)\\MSSQLLocalDB;" +
                                       "Integrated Security=true;" +
                                       "AttachDBFilename=C:\\users\\jessx\\source\\repos\\Tutorial_Metafactory\\StockManagement\\StockManagement\\Database1.mdf;";
        private DataTable m_dtSearchResult = null;
        private DataTable m_dtCriteria = null;
        private DataTable m_dtLocation = null;
        private DataTable m_dtStock = null;

        public DBTools()
        {
            Criteria = CreateTableCriteria();
            GetLocation();
            Stock = GetStock();
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
                if(m_dtLocation != null)
                {
                    return m_dtLocation;
                }
                else
                {
                    m_dtLocation = new DataTable();
                    m_dtLocation.Columns.Add("id_location", typeof(int));
                    m_dtLocation.Columns.Add("location_name", typeof(string));

                    return m_dtLocation;
                }
            }

            private set
            {
                m_dtLocation = value;
            }
        }

        public DataTable Stock
        {
            get
            {
                if (m_dtStock != null)
                {
                    return m_dtStock;
                }
                else
                {
                    m_dtStock = new DataTable();
                    m_dtStock.Columns.Add("id_stock", typeof(int));
                    m_dtStock.Columns.Add("stock_number", typeof(string));

                    return m_dtStock;
                }
            }

            private set
            {
                m_dtStock = value;
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
                myTable.Columns.Add(CriteriaDefines.criterium_id_stock, typeof(int));
                myTable.Columns.Add(CriteriaDefines.criterium_tank_name, typeof(string));
                myTable.Columns.Add(CriteriaDefines.criterium_valid_from, typeof(DateTime));
                myTable.Columns.Add(CriteriaDefines.criterium_valid_to, typeof(DateTime));
                myTable.Columns.Add(CriteriaDefines.criterium_location, typeof(int));
                myTable.Columns.Add(CriteriaDefines.criterium_include_cancelled, typeof(string));
                
                Criteria = myTable;
                return Criteria;
            }
        }

        internal bool AddRowToTableCriteria(int? iIdStock, string sTankName, DateTime? dtValidFrom, DateTime? dtValidTo, int? iIdLocation, string sIncludeCancelled)
        {
            Criteria.Rows.Add(iIdStock, sTankName, dtValidFrom, dtValidTo, iIdLocation, sIncludeCancelled);
            return true;
        }

        internal bool Search()
        {
            DataTable dtSearch = new DataTable();
            try
            {
                if (m_dtCriteria == null || m_dtCriteria.Rows.Count == 0)
                    return false;

                using (SqlConnection conn = new SqlConnection(m_sConnection))
                {
                    conn.Open();

                    //get criteria from table
                    DataRow drCriteria = m_dtCriteria.Rows[0];
                    int? iIdStock = drCriteria.Field<int?>(CriteriaDefines.criterium_id_stock);
                    string sTankName = drCriteria.Field<string>(CriteriaDefines.criterium_tank_name);
                    DateTime? dValidFrom = drCriteria.Field<DateTime?>(CriteriaDefines.criterium_valid_from);
                    DateTime? dValidTo = drCriteria.Field<DateTime?>(CriteriaDefines.criterium_valid_to);
                    int? iIdLocation = drCriteria.Field<int?>(CriteriaDefines.criterium_location);
                    string sIncludeCancelled = drCriteria.Field<string>(CriteriaDefines.criterium_include_cancelled);
                    //set stored procedure name
                    string spName = @"dbo.[STOCK_MANAGEMENT_SEARCH]";

                    //define the SqlCommand object
                    SqlCommand cmd = new SqlCommand(spName, conn);

                    //Set SqlParameter - the stock id parameter value will be set from the command line
                    SqlParameter paramStockId = new SqlParameter("@id_stock", SqlDbType.Int);
                    if (iIdStock != 0)
                        paramStockId.Value = iIdStock;
                    else
                        paramStockId.Value = DBNull.Value ;

                    SqlParameter paramTankName = new SqlParameter("@tank_name", SqlDbType.NVarChar);
                    if (!string.IsNullOrEmpty(sTankName))
                        paramTankName.Value = sTankName;
                    else
                        paramTankName.Value = DBNull.Value;

                    SqlParameter paramValidFrom = new SqlParameter("@valid_from", SqlDbType.DateTime);
                    paramValidFrom.Value = dValidFrom;

                    SqlParameter paramValidTo = new SqlParameter("@valid_to", SqlDbType.DateTime);
                    paramValidTo.Value = dValidTo;

                    SqlParameter paramLocation = new SqlParameter("@id_location", SqlDbType.Int);
                    if (iIdLocation != 0)
                        paramLocation.Value = iIdLocation;
                    else
                        paramLocation.Value = DBNull.Value;

                    SqlParameter paramIncludeCancelled = new SqlParameter("@include_cancelled", SqlDbType.Char);
                    paramIncludeCancelled.Value = sIncludeCancelled;

                    //add the parameter to the SqlCommand object
                    cmd.Parameters.Add(paramStockId);
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
                        dtSearch.Load(dr);
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

            SearchResult = dtSearch;
            Criteria.Rows.Clear();
            return true;
        }

        #region Stock

        internal DataTable GetStock()
        {
            DataTable dtStock = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(m_sConnection))
                {
                    conn.Open();

                    //set stored procedure name
                    string spName = @"dbo.[STOCK_MANAGEMENT_GET_STOCK]";

                    //define the SqlCommand object
                    SqlCommand cmd = new SqlCommand(spName, conn);

                    //set the SqlCommand type to stored procedure and execute
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader dr = cmd.ExecuteReader();

                    Console.WriteLine(Environment.NewLine + "Retrieving data from database..." + Environment.NewLine);

                    //check if there are records
                    if (dr.HasRows)
                    {
                        dtStock.Load(dr);
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
                return dtStock;
            }

            return dtStock;
        }

        internal bool AddNewStock(string sStockNumber, decimal? dStockCapacity, int iIdLocation)
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
                    paramStockNumber.Value = sStockNumber;

                    SqlParameter paramCapacity = new SqlParameter("@capacity", SqlDbType.Decimal);
                    paramCapacity.Value = dStockCapacity;

                    SqlParameter paramLocation = new SqlParameter("@stock_id_location", SqlDbType.Int);
                    paramLocation.Value = iIdLocation;
                    

                    //add the parameter to the SqlCommand object
                    cmd.Parameters.Add(paramStockNumber);
                    cmd.Parameters.Add(paramCapacity);
                    cmd.Parameters.Add(paramLocation);

                    //set the SqlCommand type to stored procedure and execute
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader dr = cmd.ExecuteReader();

                    Console.WriteLine(Environment.NewLine + "Adding data to table stock" + Environment.NewLine);

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

        internal bool UpdateStock(int iIdStock, string sStockNumber, decimal dCapacity, int iIdLocation, string sStatus)
        {

            bool bIsOK = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(m_sConnection))
                {
                    conn.Open();


                    //set stored procedure name
                    string spName = @"dbo.[STOCK_MANAGEMENT_UPDATE_STOCK]";

                    //define the SqlCommand object
                    SqlCommand cmd = new SqlCommand(spName, conn);

                    //Set SqlParameter - the employee id parameter value will be set from the command line
                    SqlParameter paramIdStock = new SqlParameter("@stock_id_stock", SqlDbType.Int);
                    paramIdStock.Value = iIdStock;
                    SqlParameter paramStockNumber = new SqlParameter("@stock_number", SqlDbType.NVarChar);
                    paramStockNumber.Value = sStockNumber;
                    SqlParameter paramStockCapacity = new SqlParameter("@stock_capacity", SqlDbType.Decimal);
                    paramStockCapacity.Value = dCapacity;
                    SqlParameter paramIdLocation = new SqlParameter("@stock_id_location", SqlDbType.Int);
                    paramIdLocation.Value = iIdLocation;
                    SqlParameter paramStatus = new SqlParameter("@stock_status", SqlDbType.Char);
                    paramStatus.Value = sStatus;

                    //add the parameter to the SqlCommand object
                    cmd.Parameters.Add(paramIdStock);
                    cmd.Parameters.Add(paramStockNumber);
                    cmd.Parameters.Add(paramStockCapacity);
                    cmd.Parameters.Add(paramIdLocation);
                    cmd.Parameters.Add(paramStatus);

                    //set the SqlCommand type to stored procedure and execute
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader dr = cmd.ExecuteReader();

                    Console.WriteLine(Environment.NewLine + "Updating database..." + Environment.NewLine);

                    //check if there are records
                    if (dr.HasRows)
                    {
                        string sError = dr.GetValue(0).ToString();
                        MessageBox.Show(sError, "Error");
                    }
                    else
                    {
                        bIsOK = true;
                        Console.WriteLine("Update completed");
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

        #endregion

        #region Tank

        internal DataTable GetTank()
        {
            DataTable dtTank = new DataTable();
            try
            {
                using (SqlConnection conn = new SqlConnection(m_sConnection))
                {
                    conn.Open();

                    //set stored procedure name
                    string spName = @"dbo.[STOCK_MANAGEMENT_GET_TANK]";

                    //define the SqlCommand object
                    SqlCommand cmd = new SqlCommand(spName, conn);

                    //set the SqlCommand type to stored procedure and execute
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader dr = cmd.ExecuteReader();

                    Console.WriteLine(Environment.NewLine + "Retrieving data from database..." + Environment.NewLine);

                    //check if there are records
                    if (dr.HasRows)
                    {
                        dtTank.Load(dr);
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
                return dtTank;
            }

            return dtTank;
        }

        internal bool AddNewTank(int iIdStock, string sTankName, decimal? dQuantity, DateTime? dtValidFrom, DateTime? dtValidTo)
        {
            bool bIsOK = false;
            try
            {

                using (SqlConnection conn = new SqlConnection(m_sConnection))
                {
                    conn.Open();

                    //set stored procedure name
                    string spName = @"dbo.[STOCK_MANAGEMENT_ADD_TANK]";

                    //define the SqlCommand object
                    SqlCommand cmd = new SqlCommand(spName, conn);

                    //Set SqlParameter - the employee id parameter value will be set from the command line
                    SqlParameter paramIdStock = new SqlParameter("@tank_id_stock", SqlDbType.Int);
                    paramIdStock.Value = iIdStock;
                    SqlParameter paramTankName = new SqlParameter("@tank_name", SqlDbType.NVarChar);
                    paramTankName.Value = sTankName;
                    SqlParameter paramQuantity= new SqlParameter("@tank_quantity", SqlDbType.Decimal);
                    paramQuantity.Value = dQuantity;
                    SqlParameter paramValidFrom = new SqlParameter("@tank_valid_from", SqlDbType.DateTime);
                    paramValidFrom.Value = dtValidFrom;
                    SqlParameter paramValidTo = new SqlParameter("@tank_valid_to", SqlDbType.DateTime);
                    paramValidTo.Value = dtValidTo;


                    //add the parameter to the SqlCommand object
                    cmd.Parameters.Add(paramIdStock);
                    cmd.Parameters.Add(paramTankName);
                    cmd.Parameters.Add(paramQuantity);
                    cmd.Parameters.Add(paramValidFrom);
                    cmd.Parameters.Add(paramValidTo);

                    //set the SqlCommand type to stored procedure and execute
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader dr = cmd.ExecuteReader();

                    Console.WriteLine(Environment.NewLine + "Adding data to table tank" + Environment.NewLine);

                    //check if there are records
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            for (int i = 0; i < dr.FieldCount; i++)
                            {
                                string error = dr.GetValue(i).ToString();
                                MessageBox.Show(error, "Error");
                            }
                        }
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

        internal bool UpdateTank(int iIdStock, int iIdTank, string sTankName, decimal? dQuantity, DateTime? dtValidFrom, DateTime? dtValidTo)
        {

            bool bIsOK = false;
            try
            {
                using (SqlConnection conn = new SqlConnection(m_sConnection))
                {
                    conn.Open();


                    //set stored procedure name
                    string spName = @"dbo.[STOCK_MANAGEMENT_UPDATE_TANK]";

                    //define the SqlCommand object
                    SqlCommand cmd = new SqlCommand(spName, conn);

                    //Set SqlParameter - the employee id parameter value will be set from the command line
                    SqlParameter paramIdStock = new SqlParameter("@tank_id_stock", SqlDbType.Int);
                    paramIdStock.Value = iIdStock;
                    SqlParameter paramIdTank = new SqlParameter("@tank_id_tank", SqlDbType.Int);
                    paramIdTank.Value = iIdTank;
                    SqlParameter paramTankName = new SqlParameter("@tank_name", SqlDbType.NVarChar);
                    paramTankName.Value = sTankName;
                    SqlParameter paramQuantity = new SqlParameter("@quantity", SqlDbType.Decimal);
                    paramQuantity.Value = dQuantity;
                    SqlParameter paramValidFrom = new SqlParameter("@valid_from", SqlDbType.DateTime);
                    paramValidFrom.Value = dtValidFrom;
                    SqlParameter paramValidTo = new SqlParameter("@valid_to", SqlDbType.DateTime);
                    paramValidTo.Value = dtValidTo;

                    //add the parameter to the SqlCommand object
                    cmd.Parameters.Add(paramIdStock);
                    cmd.Parameters.Add(paramIdTank);
                    cmd.Parameters.Add(paramTankName);
                    cmd.Parameters.Add(paramQuantity);
                    cmd.Parameters.Add(paramValidFrom);
                    cmd.Parameters.Add(paramValidTo);

                    //set the SqlCommand type to stored procedure and execute
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader dr = cmd.ExecuteReader();

                    Console.WriteLine(Environment.NewLine + "Updating database..." + Environment.NewLine);

                    //check if there are records
                    if (dr.HasRows)
                    {
                        string sError = dr.GetValue(0).ToString();
                        MessageBox.Show(sError, "Error");
                    }
                    else
                    {
                        bIsOK = true;
                        Console.WriteLine("Update completed");
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

        #endregion

        #region Location

        internal DataTable GetLocation()
        {
            DataTable dtLocation = new DataTable();
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
                        dtLocation.Load(dr);
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
                return dtLocation;
            }
            Location = dtLocation;
            return dtLocation;
        }

        internal bool AddLocation(string sLocationName)
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
                    SqlParameter paramLocationName = new SqlParameter("@location_name", SqlDbType.NVarChar);
                    paramLocationName.Value = sLocationName;

                    //add the parameter to the SqlCommand object
                    cmd.Parameters.Add(paramLocationName);

                    //set the SqlCommand type to stored procedure and execute
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader dr = cmd.ExecuteReader();

                    Console.WriteLine(Environment.NewLine + "Adding data to database..." + Environment.NewLine);

                    //check if there are records
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            for (int i = 0; i < dr.FieldCount; i++)
                            {
                                string error = dr.GetValue(i).ToString();
                                MessageBox.Show(error, "Error");
                            }
                        }
                    }
                    else
                    {
                        bIsOK = true;
                        Console.WriteLine("New line added");
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

        internal bool UpdateLocation(int iIdLocation, string sLocationName)
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
                    SqlParameter paramIdLocation = new SqlParameter("@id_location", SqlDbType.Int);
                    paramIdLocation.Value = iIdLocation;
                    SqlParameter paramLocationName = new SqlParameter("@location_name", SqlDbType.NVarChar);
                    paramLocationName.Value = sLocationName;

                    //add the parameter to the SqlCommand object
                    cmd.Parameters.Add(paramIdLocation);
                    cmd.Parameters.Add(paramLocationName);

                    //set the SqlCommand type to stored procedure and execute
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataReader dr = cmd.ExecuteReader();

                    Console.WriteLine(Environment.NewLine + "Updating line from database..." + Environment.NewLine);

                    //check if there are records
                    if (dr.HasRows)
                    {
                        string sError = dr.GetValue(0).ToString();
                        MessageBox.Show(sError, "Error");
                    }
                    else
                    {
                        bIsOK = true;
                        Console.WriteLine("Update completed");
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

        #endregion
    }
}


