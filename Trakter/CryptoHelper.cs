using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace Trakter
{
    public static class CryptoHelper
    {
        public static string GetSha1Hash(string value)
	    {
		    if (string.IsNullOrWhiteSpace(value))
			    throw new ArgumentException("String is empty and not hashable.");

		    Byte[] computedHash = new SHA1CryptoServiceProvider().ComputeHash(Encoding.ASCII.GetBytes(value));		
		    string result = String.Empty;
		
		    foreach(byte b in computedHash)
		    {
			    result += String.Format("{0:x2}", b);
		    }

		    return result;
	    }
    }
}