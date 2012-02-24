//-----------------------------------------------------------------------
// <copyright file="AuthorizeRequest.cs" company="Mission3, Inc.">
//      Copyright (c) Mission3, Inc. All rights reserved.
//
//      Permission is hereby granted, free of charge, to any person
//      obtaining a copy of this software and associated documentation
//      files (the "Software"), to deal in the Software without
//      restriction, including without limitation the rights to use,
//      copy, modify, merge, publish, distribute, sublicense, and/or sell
//      copies of the Software, and to permit persons to whom the
//      Software is furnished to do so, subject to the following
//      conditions:
//
//      The above copyright notice and this permission notice shall be
//      included in all copies or substantial portions of the Software.
//
//      THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
//      EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
//      OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
//      NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
//      HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
//      WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
//      FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
//      OTHER DEALINGS IN THE SOFTWARE.
// </copyright>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text;

namespace PaymentProcess
{
    /// <summary>
    /// Communicates with Authorize.NET by sending HTTP POST strings
    /// </summary>
    public class AuthorizeRequest
    {
        /// <summary>
        /// Info class container
        /// </summary>
        private readonly List<IInfo> info;

        /// <summary>
        /// TraceSwitch PaymentProcess
        /// </summary>
        private readonly TraceSwitch ts = new TraceSwitch("PaymentProcess", "");

        /// <summary>
        /// Default URL to send HTTP POST to (TEST)
        /// </summary>
        private readonly string url = "https://test.authorize.net/gateway/transact.dll";

        public AuthorizeRequest(string url, params IInfo[] args)
        {
            Trace.WriteLineIf(ts.TraceInfo, "AuthorizeRequest - CTor");
            this.url = url;
            info = new List<IInfo>();
            foreach (IInfo i in args)
            {
                info.Add(i);
            }
        }

        /// <summary>
        /// Sends the request through HTTP POST to Authorize.NET
        /// </summary>
        /// <returns>Returns an AuthorizeResponse class instance</returns>
        public AuthorizeResponse SendRequest()
        {
            Trace.WriteLineIf(ts.TraceInfo, "AuthorizeRequest - SendRequest start");
            try
            {
                var request = (HttpWebRequest) WebRequest.Create(url);
                request.Method = "POST";
                string post = BuildPostString();
                request.ContentLength = post.Length;
                request.ContentType = "application/x-www-form-urlencoded";

                Trace.WriteLineIf(ts.TraceInfo, "\tAuthorizeRequest - post string: " + post);
                var writer = new StreamWriter(request.GetRequestStream());
                writer.Write(post);
                writer.Close();

                var response = (HttpWebResponse) request.GetResponse();
                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    string results = reader.ReadToEnd();
                    reader.Close();

                    Trace.WriteLineIf(ts.TraceInfo, "\tAuthorizeRequest - raw results: " + results);
                    return new AuthorizeResponse(results);
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLineIf(ts.TraceError, "\tException was thrown.");
                Trace.WriteLineIf(ts.TraceError, "\t" + ex.Message);
                Trace.WriteLineIf(ts.TraceError, "\t" + ex.StackTrace);
                throw ex;
            }
            finally
            {
                Trace.WriteLineIf(ts.TraceInfo, "AuthorizeRequest - SendRequest end");
            }
        }

        /// <summary>
        /// Builts the POST string for sending to Authorize.NET
        /// </summary>
        /// <returns>Returns the full POST string as requird by Authorize.NET</returns>
        private string BuildPostString()
        {
            Trace.WriteLineIf(ts.TraceInfo, "AuthorizeRequest - BuildPostString start");
            var sb = new StringBuilder();

            foreach (IInfo i in info)
            {
                Trace.WriteLineIf(ts.TraceInfo, "\tBuildPostString - IInfo");
                sb.Append(i.ToString());
            }

            // Delimited configuration
            sb.Append("&x_delim_data=TRUE");
            sb.Append("&x_delim_char=|");
            sb.Append("&x_relay_response=FALSE");

            Trace.WriteLineIf(ts.TraceInfo, "AuthorizeRequest - BuildPostString end");

            return sb.ToString();
        }
    }
}