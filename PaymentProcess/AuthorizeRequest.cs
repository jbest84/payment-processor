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

namespace PaymentProcess
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Net;
    using System.IO;
    using System.Diagnostics;

    /// <summary>
    /// Communicates with Authorize.NET by sending HTTP POST strings
    /// </summary>
    public class AuthorizeRequest
    {
        /// <summary>
        /// Default URL to send HTTP POST to (TEST)
        /// </summary>
        private string url = "https://test.authorize.net/gateway/transact.dll";

        /// <summary>
        /// TraceSwitch PaymentProcess
        /// </summary>
        private TraceSwitch ts = new TraceSwitch("PaymentProcess", "");

        /// <summary>
        /// Info class container
        /// </summary>
        private List<IInfo> info = null;

        public AuthorizeRequest(string url, params IInfo[] args)
        {
            Trace.WriteLineIf(this.ts.TraceInfo, "AuthorizeRequest - CTor");
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
            Trace.WriteLineIf(this.ts.TraceInfo, "AuthorizeRequest - SendRequest start");
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(this.url);
                request.Method = "POST";
                string post = this.BuildPostString();
                request.ContentLength = post.Length;
                request.ContentType = "application/x-www-form-urlencoded";

                Trace.WriteLineIf(this.ts.TraceInfo, "\tAuthorizeRequest - post string: " + post);
                StreamWriter writer = new StreamWriter(request.GetRequestStream());
                writer.Write(post);
                writer.Close();

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    string results = reader.ReadToEnd();
                    reader.Close();

                    Trace.WriteLineIf(this.ts.TraceInfo, "\tAuthorizeRequest - raw results: " + results);
                    return new AuthorizeResponse(results);
                }
            }
            catch (Exception ex)
            {
                Trace.WriteLineIf(this.ts.TraceError, "\tException was thrown.");
                Trace.WriteLineIf(this.ts.TraceError, "\t" + ex.Message);
                Trace.WriteLineIf(this.ts.TraceError, "\t" + ex.StackTrace);
                throw ex;
            }
            finally
            {
                Trace.WriteLineIf(this.ts.TraceInfo, "AuthorizeRequest - SendRequest end");
            }
        }

        /// <summary>
        /// Builts the POST string for sending to Authorize.NET
        /// </summary>
        /// <returns>Returns the full POST string as requird by Authorize.NET</returns>
        private string BuildPostString()
        {
            Trace.WriteLineIf(this.ts.TraceInfo, "AuthorizeRequest - BuildPostString start");
            StringBuilder sb = new StringBuilder();

            foreach (IInfo i in this.info)
            {
                Trace.WriteLineIf(this.ts.TraceInfo, "\tBuildPostString - IInfo");
                sb.Append(i.ToString());
            }

            // Delimited configuration
            sb.Append("&x_delim_data=TRUE");
            sb.Append("&x_delim_char=|");
            sb.Append("&x_relay_response=FALSE");

            Trace.WriteLineIf(this.ts.TraceInfo, "AuthorizeRequest - BuildPostString end");

            return sb.ToString();
        }
    }
}
