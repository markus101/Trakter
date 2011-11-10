using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Trakter
{
    [Serializable]
    public class InvalidApiKeyException : Exception
    {
        public string ErrorMessage
        {
            get
            {
                return base.Message;
            }
        }

        public InvalidApiKeyException()
        {
            
        }

        public InvalidApiKeyException(string errorMessage)
            : base(errorMessage) { }

        public InvalidApiKeyException(string errorMessage, Exception innerEx)
            : base(errorMessage, innerEx) { }
    }
}
