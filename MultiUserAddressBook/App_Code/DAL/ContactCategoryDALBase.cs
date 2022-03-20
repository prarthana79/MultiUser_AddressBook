using AddressBook;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ContactCategoryDALBase
/// </summary>
namespace AddressBook.DAL
{
    public class ContactCategoryDALBase : DatabaseConfig
    {
        #region Constructor
        public ContactCategoryDALBase()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

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

        #region Insert ContactCategory Operation
        //Insert
        #endregion Insert ContactCategory Operation

        #region Update ContactCategory Operation
        //Update
        #endregion Update ContactCategory Operation

        #region Delete ContactCategory Operation
        //Delete
        #endregion Delete ContactCategory Operation

        #region Select Operations

        #region SelectAll cities
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
                        objCMD.CommandText = "PR_ContactCategory_SelectByUserID";
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
        #endregion SelectAll cities

        #region SelectByPK
        #endregion SelectByPK

        #region SelectForDropDownList
        #endregion SelectForDropDownList

        #endregion Select Operations
    }
}