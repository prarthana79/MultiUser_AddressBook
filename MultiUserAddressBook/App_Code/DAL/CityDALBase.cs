using AddressBook.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for CityDALBase
/// </summary>
namespace AddressBook.DAL
{
    public class CityDALBase : DatabaseConfig
    {
        #region Constructor
        public CityDALBase()
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

        #region SelectAll cities
        public DataTable SelectAll(SqlInt32 UserID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                #region Set Connection
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();
                #endregion Set Connection
                try
                {
                    using (SqlCommand objCMD = objConn.CreateCommand())
                    {
                        #region Command Object
                        objCMD.CommandType = CommandType.StoredProcedure;
                        objCMD.CommandText = "PR_City_SelectByUserID";
                        DataTable dt = new DataTable();
                        objCMD.Parameters.AddWithValue("@UserID", UserID);
                        #endregion Command Object
                        #region Read the value and set the controls
                        using (SqlDataReader objSDR = objCMD.ExecuteReader())
                        {
                            dt.Load(objSDR);
                        }
                        return dt;
                        #endregion Read the value and set the controls
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
                    if (objConn.State == ConnectionState.Open)
                        objConn.Close();
                }
            }
        }
        #endregion SelectAll cities

        #region SelectByPK
        public CityENT SelectByPK(SqlInt32 UserID, SqlInt32 CityID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                #region Set Connection
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();
                #endregion Set Connection
                try
                {
                    using (SqlCommand objCMD = objConn.CreateCommand())
                    {
                        #region Command Object
                        objCMD.CommandType = CommandType.StoredProcedure;
                        objCMD.CommandText = "PR_City_SelectByPKUserID";
                        DataTable dt = new DataTable();
                        objCMD.Parameters.AddWithValue("@StateID", CityID);
                        objCMD.Parameters.AddWithValue("@UserID", UserID);
                        #endregion Command Object
                        #region Read the value and set the controls
                        CityENT entCity = new CityENT();

                        using (SqlDataReader objSDR = objCMD.ExecuteReader())
                        {
                            if (objSDR.HasRows)
                            {
                                while (objSDR.Read())
                                {
                                    if (!objSDR["CountryID"].Equals(DBNull.Value))
                                    {
                                        entCity.CountryID = Convert.ToInt32(objSDR["CountryID"].ToString().Trim());
                                        //CommonDropDownFillMethods.FillDropDownListState(ddlStateID, ddlCountryID);
                                    }
                                    if (!objSDR["CityID"].Equals(DBNull.Value))
                                    {
                                        entCity.CityID = Convert.ToInt32(objSDR["CityID"].ToString().Trim());
                                    }
                                    if (!objSDR["StateID"].Equals(DBNull.Value))
                                    {
                                        entCity.StateID = Convert.ToInt32(objSDR["StateID"].ToString().Trim());
                                    }
                                    if (!objSDR["CityName"].Equals(DBNull.Value))
                                    {
                                        entCity.CityName = objSDR["CityName"].ToString().Trim();
                                    }
                                    if (!objSDR["STDCode"].Equals(DBNull.Value))
                                    {
                                        entCity.STDCode = objSDR["STDCode"].ToString().Trim();
                                    }
                                    if (!objSDR["PinCode"].Equals(DBNull.Value))
                                    {
                                        entCity.PinCode = objSDR["PinCode"].ToString().Trim();
                                    }
                                    if (!objSDR["CreationDate"].Equals(DBNull.Value))
                                    {
                                        entCity.CreationDate = Convert.ToDateTime(objSDR["CreationDate"].ToString().Trim());
                                    }
                                    if (!objSDR["ModificationDate"].Equals(DBNull.Value))
                                    {
                                        entCity.ModificationDate = Convert.ToDateTime(objSDR["ModificationDate"].ToString().Trim());
                                    }

                                    break;
                                }
                            }
                            #endregion Read the value and set the controls
                        }
                        return entCity;
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
                    if (objConn.State == ConnectionState.Open)
                        objConn.Close();
                }
            }
        }
        #endregion SelectByPK

        #region SelectForDropDownList
        public DataTable SelectForDropDownList(SqlInt32 UserID, SqlInt32 StateID)
        {
            using (SqlConnection objConn = new SqlConnection(ConnectionString))
            {
                #region Set Connection
                if (objConn.State != ConnectionState.Open)
                    objConn.Open();
                #endregion Set Connection
                try
                {
                    using (SqlCommand objCMD = objConn.CreateCommand())
                    {
                        #region Command Object
                        objCMD.CommandType = CommandType.StoredProcedure;
                        objCMD.CommandText = "PR_City_SelectForDropDownListByUserIDStateID";
                        DataTable dt = new DataTable();
                        objCMD.Parameters.AddWithValue("@StateID", StateID);
                        objCMD.Parameters.AddWithValue("@UserID", UserID);
                        #endregion Command Object
                        #region Read the value and set the controls
                        using (SqlDataReader objSDR = objCMD.ExecuteReader())
                        {
                            dt.Load(objSDR);
                        }
                        return dt;
                        #endregion Read the value and set the controls
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
                    if (objConn.State == ConnectionState.Open)
                        objConn.Close();
                }
            }
        }
        #endregion SelectForDropDownList

        #endregion Select Operations
    }
}