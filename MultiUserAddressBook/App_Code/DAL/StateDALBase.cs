using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for StateDALBase
/// </summary>
namespace AddressBook.DAL
{
    public abstract class StateDALBase
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
    }
}