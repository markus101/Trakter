using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using Trakter.Models;

namespace Trakter
{
    internal static class ErrorHelper
    {
        //Used to check for errors
        internal static SimpleStatusResult ErrorResponse(string responseJson)
        {
            try
            {
                var result = JsonConvert.DeserializeObject<SimpleStatusResult>(responseJson);

                return result;
            }

            catch (JsonSerializationException ex)
            {
                return new SimpleStatusResult
                    {
                        Status = ResultStatusType.Success,
                        Message = "No error found."
                    };
            }
        }
    }
}
