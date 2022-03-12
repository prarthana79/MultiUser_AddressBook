using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CityDALBase
/// </summary>
namespace AddressBook.DAL
{
    public abstract class CityDALBase : DatabaseConfig
    {
        #region Local Variables Message
        protected string _Message;
        public string Message
        {
            get
            {
                return _Message;
            }
            set
            {
                _Message = value;
            }
        }
        #endregion Local Variables Message

        #region Insert City Operation
        //Insert
        #endregion Insert City Operation

        #region Update City Operation
        //Update
        #endregion Update City Operation

        #region Delete City Operation
        //Delete
        #endregion Delete City Operation

        #region Select Operations
        //SelectAll
        DataTable SelectAll()
        {
            try
            {
                using (SqlConnection objConn = new SqlConnection(ConnectionString))
                {
                    objConn.Open();
                    using(SqlCommand objCMD = objConn.CreateCommand())
                    {
                        objCMD.CommandType = CommandType.StoredProcedure;
                        objCMD.CommandText = "PR_City_SelectByUserID";
                        DataTable dt = new DataTable();
                        using(SqlDataReader objSDR = objCMD.ExecuteReader())
                        {
                            dt.Load(objSDR);
                        }
                        return dt;
                    }
                }
            }
            catch(SqlException sqlex)
            {
                Message = sqlex.InnerException.Message.ToString();
                return null;
            }
            catch (Exception ex)
            {
                Message = ex.InnerException.Message.ToString();
                return null;
            }
            finally
            {

            }
        }
        //SelectByPK
        //SelectForDropDownList
        #endregion Select Operations
    }
}