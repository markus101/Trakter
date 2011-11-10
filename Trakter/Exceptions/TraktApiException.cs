using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trakter
{
    [Serializable]
    public class TraktApiException : Exception
    {
        public string ErrorMessage
        {
            get
            {
                return base.Message;
            }
        }

        public TraktApiException()
        {
            
        }

        public TraktApiException(string errorMessage)
            : base(errorMessage) { }

        public TraktApiException(string errorMessage, Exception innerEx)
            : base(errorMessage, innerEx) { }
    }
}
