using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CityENT
/// </summary>
namespace AddressBook.ENT
{
    public class CityENT
    {
        #region Constructor
        public CityENT()
        {

        }
        #endregion Constructor

        #region declare CityID
        protected SqlInt32 _CityID;
        public SqlInt32 CityID
        {
            get
            {
                return _CityID;
            }
            set
            {
                _CityID = value;
            }
        }
        #endregion declare CityID

        #region declare StateID
        protected SqlInt32 _StateID;
        public SqlInt32 StateID
        {
            get
            {
                return _StateID;
            }
            set
            {
                _StateID = value;
            }
        }
        #endregion declare StateID

        #region declare CountryID
        protected SqlInt32 _CountryID;
        public SqlInt32 CountryID
        {
            get
            {
                return _CountryID;
            }
            set
            {
                _CountryID = value;
            }
        }
        #endregion declare CountryID

        #region declare CityName
        protected SqlString _CityName;
        public SqlString CityName
        {
            get
            {
                return _CityName;
            }
            set
            {
                _CityName = value;
            }
        }
        #endregion declare CityName

        #region declare STDCode
        protected SqlString _STDCode;
        public SqlString STDCode
        {
            get
            {
                return _STDCode;
            }
            set
            {
                _STDCode = value;
            }
        }
        #endregion declare STDCode

        #region declare PinCode
        protected SqlString _PinCode;
        public SqlString PinCode
        {
            get
            {
                return _PinCode;
            }
            set
            {
                _PinCode = value;
            }
        }
        #endregion declare PinCode

        #region declare UserID
        protected SqlInt32 _UserID;
        public SqlInt32 UserID
        {
            get
            {
                return _UserID;
            }
            set
            {
                _UserID = value;
            }
        }
        #endregion declare UserID

        #region declare CreationDate
        protected SqlDateTime _CreationDate;
        public SqlDateTime CreationDate
        {
            get
            {
                return _CreationDate;
            }
            set
            {
                _CreationDate = value;
            }
        }
        #endregion declare CreationDate

        #region declare ModificationDate
        protected SqlDateTime _ModificationDate;
        public SqlDateTime ModificationDate
        {
            get
            {
                return _ModificationDate;
            }
            set
            {
                _ModificationDate = value;
            }
        }
        #endregion declare ModificationDate
    }
}