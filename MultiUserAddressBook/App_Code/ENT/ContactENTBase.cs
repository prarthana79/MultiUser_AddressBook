using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ContactENTBase
/// </summary>
namespace AddressBook.ENT
{
    public abstract class ContactENTBase
    {
        #region declare ContactID
        protected SqlInt32 _ContactID;
        public SqlInt32 ContactID
        {
            get
            {
                return _ContactID;
            }
            set
            {
                _ContactID = value;
            }
        }
        #endregion declare ContactID

        #region declare ContactName
        protected SqlString _ContactName;
        public SqlString ContactName
        {
            get
            {
                return _ContactName;
            }
            set
            {
                _ContactName = value;
            }
        }
        #endregion declare ContactName

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

        #region declare BloodGroupID
        protected SqlInt32 _BloodGroupID;
        public SqlInt32 BloodGroupID
        {
            get
            {
                return _BloodGroupID;
            }
            set
            {
                _BloodGroupID = value;
            }
        }
        #endregion declare BloodGroupID

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

        #region declare Age
        protected SqlInt32 _Age;
        public SqlInt32 Age
        {
            get
            {
                return _Age;
            }
            set
            {
                _Age = value;
            }
        }
        #endregion declare Age

        #region declare Address
        protected SqlString _Address;
        public SqlString Address
        {
            get
            {
                return _Address;
            }
            set
            {
                _Address = value;
            }
        }
        #endregion declare Address

        #region declare EmailID
        protected SqlString _EmailID;
        public SqlString EmailID
        {
            get
            {
                return _EmailID;
            }
            set
            {
                _EmailID = value;
            }
        }
        #endregion declare EmailID

        #region declare FacebookID
        protected SqlString _FacebookID;
        public SqlString FacebookID
        {
            get
            {
                return _FacebookID;
            }
            set
            {
                _FacebookID = value;
            }
        }
        #endregion declare FacebookID

        #region declare LinkedInID
        protected SqlString _LinkedInID;
        public SqlString LinkedInID
        {
            get
            {
                return _LinkedInID;
            }
            set
            {
                _LinkedInID = value;
            }
        }
        #endregion declare LinkedInID

        #region declare ContactPhotoPath
        protected SqlString _ContactPhotoPath;
        public SqlString ContactPhotoPath
        {
            get
            {
                return _ContactPhotoPath;
            }
            set
            {
                _ContactPhotoPath = value;
            }
        }
        #endregion declare ContactPhotoPath

        #region declare ContactNo
        protected SqlString _ContactNo;
        public SqlString ContactNo
        {
            get
            {
                return _ContactNo;
            }
            set
            {
                _ContactNo = value;
            }
        }
        #endregion declare ContactNo

        #region declare WhatsAppNo
        protected SqlString _WhatsAppNo;
        public SqlString WhatsAppNo
        {
            get
            {
                return _WhatsAppNo;
            }
            set
            {
                _WhatsAppNo = value;
            }
        }
        #endregion declare WhatsAppNo

        #region declare BirthDate
        protected SqlDateTime _BirthDate;
        public SqlDateTime BirthDate
        {
            get
            {
                return _BirthDate;
            }
            set
            {
                _BirthDate = value;
            }
        }
        #endregion declare BirthDate

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