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
        /// Required merchant information
        /// </summary>
        private MerchantInfo merchantInfo = null;

        /// <summary>
        /// Required transaction information
        /// </summary>
        private TransactionInfo transactionInfo = null;

        /// <summary>
        /// Optional additional shipping information
        /// </summary>
        private AdditionalShippingInfo additionalShippingInfo = null;

        /// <summary>
        /// Optional customer informaiton
        /// </summary>
        private CustomerInfo customerInfo = null;

        /// <summary>
        /// Optional itemized order information
        /// </summary>
        private ItemizedOrderInfo itemizedOrderInfo = null;

        /// <summary>
        /// Optional order information
        /// </summary>
        private OrderInfo orderInfo = null;

        /// <summary>
        /// Optional shipping information
        /// </summary>
        private ShippingInfo shippingInfo = null;

        /// <summary>
        /// Default URL to send HTTP POST to (TEST)
        /// </summary>
        private string url = "https://test.authorize.net/gateway/transact.dll";

        /// <summary>
        /// TraceSwitch PaymentProcess
        /// </summary>
        private TraceSwitch ts = new TraceSwitch("PaymentProcess", "");

        /// <summary>
        /// AuthorizeRequest CTor
        /// </summary>
        /// <param name="mi">Merchant information class</param>
        /// <param name="ti">Transaction information class</param>
        /// <param name="url">URL to send HTTP POST</param>
        public AuthorizeRequest(MerchantInfo mi, TransactionInfo ti, string url)
        {
            this.merchantInfo = mi;
            this.transactionInfo = ti;
            this.url = url;
            Trace.WriteLineIf(this.ts.TraceInfo, "AuthorizeRequest - CTor");
        }

        /// <summary>
        /// AuthorizeRequest CTor
        /// </summary>
        /// <param name="mi">Merchant information class</param>
        /// <param name="ti">Transaction information class</param>
        /// <param name="url">URL to send the HTTP POST</param>
        /// <param name="oi">Order information class</param>
        /// <param name="si">Shipping information class</param>
        /// <param name="ioi">Itemized order information class</param>
        /// <param name="ci">Customer information class</param>
        /// <param name="asi">Additional shipping info class</param>
        public AuthorizeRequest(MerchantInfo mi, TransactionInfo ti, string url, OrderInfo oi, ShippingInfo si, ItemizedOrderInfo ioi, CustomerInfo ci, AdditionalShippingInfo asi)
            : this(mi, ti, url)
        {
            Trace.WriteLineIf(this.ts.TraceInfo, "AuthorizeRequest - CTor additional");
            this.additionalShippingInfo = asi;
            this.customerInfo = ci;
            this.itemizedOrderInfo = ioi;
            this.orderInfo = oi;
            this.shippingInfo = si;
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
            StringBuilder sb = new StringBuilder();

            // Merchant information
            if (this.merchantInfo != null)
            {
                sb.Append(this.merchantInfo.ToString());
            }

            // Transaction information
            if (this.transactionInfo != null)
            {
                sb.Append(this.transactionInfo.ToString());
            }

            // Order information
            if (this.orderInfo != null)
            {
                sb.Append(this.orderInfo.ToString());
            }

            // Shipping information
            if (this.shippingInfo != null)
            {
                sb.Append(this.shippingInfo.ToString());
            }

            // ItemizedOrder information
            if (this.itemizedOrderInfo != null)
            {
                sb.Append(this.itemizedOrderInfo.ToString());
            }

            // Customer information
            if (this.customerInfo != null)
            {
                sb.Append(this.customerInfo.ToString());
            }

            // Additional shipping info
            if (this.additionalShippingInfo != null)
            {
                sb.Append(this.additionalShippingInfo.ToString());
            }

            // Delimited configuration
            sb.Append("&x_delim_data=TRUE");
            sb.Append("&x_delim_char=|");
            sb.Append("&x_relay_response=FALSE");
            return sb.ToString();
        }
    }
}
