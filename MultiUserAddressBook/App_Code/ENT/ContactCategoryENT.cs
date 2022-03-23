using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ContactCategoryENT
/// </summary>
namespace AddressBook.ENT
{
    public abstract class ContactCategoryENT
    {
        #region Constructor
        public ContactCategoryENT()
        {

        }
        #endregion Constructor

        #region declare ContactCategoryID
        protected SqlInt32 _ContactCategoryID;
        public SqlInt32 ContactCategoryID
        {
            get
            {
                return _ContactCategoryID;
            }
            set
            {
                _ContactCategoryID = value;
            }
        }
        #endregion declare ContactCategoryID

        #region declare ContactCategoryName
        protected SqlString _ContactCategoryName;
        public SqlString ContactCategoryName
        {
            get
            {
                return _ContactCategoryName;
            }
            set
            {
                _ContactCategoryName = value;
            }
        }
        #endregion declare ContactCategoryName

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