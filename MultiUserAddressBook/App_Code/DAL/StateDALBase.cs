using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for StateDALBase
/// </summary>
namespace AddressBook.DAL
{
    public abstract class StateDALBase : DatabaseConfig
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

        #region Insert State Operation
        //Insert
        #endregion Insert State Operation

        #region Update State Operation
        //Update
        #endregion Update State Operation

        #region Delete State Operation
        //Delete
        #endregion Delete State Operation

        #region Select Operations

        #region SelectAll states
        DataTable SelectAll()
        {
            try
            {
                using (SqlConnection objConn = new SqlConnection(ConnectionString))
                {
                    objConn.Open();
                    using (SqlCommand objCMD = objConn.CreateCommand())
                    {
                        objCMD.CommandType = CommandType.StoredProcedure;
                        objCMD.CommandText = "PR_State_SelectByUserID";
                        DataTable dt = new DataTable();
                        using (SqlDataReader objSDR = objCMD.ExecuteReader())
                        {
                            dt.Load(objSDR);
                        }
                        return dt;
                    }
                }
            }
            catch (SqlException sqlex)
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
        #endregion SelectAll states

        #region SelectByPK
        #endregion SelectByPK

        #region SelectForDropDownList
        #endregion SelectForDropDownList

        #endregion Select Operations
    }
}