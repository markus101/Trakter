using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Trakter.Models;

namespace Trakter.Providers
{
    public class HttpProvider
    {
        public virtual string DownloadString(string url)
        {
            var responseJson = new WebClient().DownloadString(url);
            var error = ErrorHelper.ErrorResponse(responseJson);

            if (error != null && error.Status == ResultStatusType.Failure)
                throw new TraktApiException(error.Message);

            return responseJson;
        }

        public virtual string DownloadString(string url, string requestJson)
        {
            var request = (HttpWebRequest) HttpWebRequest.Create(url);
            request.ContentType = "application/json; charset=utf-8";
            request.Accept = "application/json, text/javascript, */*";
            request.Method = "POST";

            using (var writer = new StreamWriter(request.GetRequestStream()))
            {
                writer.Write(requestJson);
            }

            var response = request.GetResponse();
            Stream stream = response.GetResponseStream();
            string responseJson = string.Empty;

            using (var reader = new StreamReader(stream))
            {
                while (!reader.EndOfStream)
                {
                    responseJson += reader.ReadLine();
                }
            }

            var error = ErrorHelper.ErrorResponse(responseJson);
            if (error != null && error.Status == ResultStatusType.Failure)
                throw new TraktApiException(error.Message);

            return responseJson;
        }
    }
}
