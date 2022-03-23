using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for StateENT
/// </summary>
namespace AddressBook.ENT
{
    public abstract class StateENT
    {
        #region Constructor
        public StateENT()
        {

        }
        #endregion Constructor

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

        #region declare StateName
        protected SqlString _StateName;
        public SqlString StateName
        {
            get
            {
                return _StateName;
            }
            set
            {
                _StateName = value;
            }
        }
        #endregion declare StateName

        #region declare StateCode
        protected SqlString _StateCode;
        public SqlString StateCode
        {
            get
            {
                return _StateCode;
            }
            set
            {
                _StateCode = value;
            }
        }
        #endregion declare StateCode

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