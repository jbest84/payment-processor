/*
Copyright (c) 2008 Mission3, INC (jbest@mission3.com)

Permission is hereby granted, free of charge, to any person
obtaining a copy of this software and associated documentation
files (the "Software"), to deal in the Software without
restriction, including without limitation the rights to use,
copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the
Software is furnished to do so, subject to the following
conditions:

The above copyright notice and this permission notice shall be
included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
OTHER DEALINGS IN THE SOFTWARE.
*/

using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using System.Diagnostics;

namespace PaymentProcess
{
    public class AuthorizeURL
    {
        public static string TEST_URL = "https://test.authorize.net/gateway/transact.dll";
        public static string PRODUCTION_URL = "https://secure.authorize.net/gateway/transact.dll";
    }

    public class AuthorizeRequest
    {
        private MerchantInfo _merchantInfo = null;
        private TransactionInfo _transactionInfo = null;

        //optional
        private AdditionalShippingInfo _additionalShippingInfo = null;
        private CustomerInfo _customerInfo = null;
        private ItemizedOrderInfo _itemizedOrderInfo = null;
        private OrderInfo _orderInfo = null;
        private ShippingInfo _shippingInfo = null;

        private string _url = "https://test.authorize.net/gateway/transact.dll";
        private TraceSwitch ts = new TraceSwitch("PaymentProcess", "");

        public AuthorizeRequest(MerchantInfo mi, TransactionInfo ti, string url)
        {
            _merchantInfo = mi;
            _transactionInfo = ti;
            _url = url;
            Trace.WriteLineIf(ts.TraceInfo, "AuthorizeRequest - CTor");
        }

        public AuthorizeRequest(MerchantInfo mi, TransactionInfo ti, string url, OrderInfo oi, ShippingInfo si, ItemizedOrderInfo ioi, CustomerInfo ci, AdditionalShippingInfo asi)
            : this(mi, ti, url)
        {
            Trace.WriteLineIf(ts.TraceInfo, "AuthorizeRequest - CTor additional");
            _additionalShippingInfo = asi;
            _customerInfo = ci;
            _itemizedOrderInfo = ioi;
            _orderInfo = oi;
            _shippingInfo = si;
        }

        public AuthorizeResponse SendRequest()
        {
            Trace.WriteLineIf(ts.TraceInfo, "AuthorizeRequest - SendRequest start");
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(_url);
                request.Method = "POST";
                string post = BuildPostString();
                request.ContentLength = post.Length;
                request.ContentType = "application/x-www-form-urlencoded";

                Trace.WriteLineIf(ts.TraceInfo, "\tAuthorizeRequest - post string: " + post);
                StreamWriter writer = new StreamWriter(request.GetRequestStream());
                writer.Write(post);
                writer.Close();

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
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

        private string BuildPostString()
        {
            StringBuilder sb = new StringBuilder();

            //Merchant information
            if(_merchantInfo != null)
                sb.Append(_merchantInfo.ToString());

            //Transaction information
            if(_transactionInfo != null)
                sb.Append(_transactionInfo.ToString());

            //Order information
            if(_orderInfo != null)
                sb.Append(_orderInfo.ToString());

            //Shipping information
            if(_shippingInfo != null)
                sb.Append(_shippingInfo.ToString());

            //ItemizedOrder information
            if(_itemizedOrderInfo != null)
                sb.Append(_itemizedOrderInfo.ToString());

            //Customer information
            if(_customerInfo != null)
                sb.Append(_customerInfo.ToString());

            //Additional shipping info
            if(_additionalShippingInfo != null)
                sb.Append(_additionalShippingInfo.ToString());

            //Delimited configuration
            sb.Append("&x_delim_data=TRUE");
            sb.Append("&x_delim_char=|");
            sb.Append("&x_relay_response=FALSE");
            return sb.ToString();
        }
    }
}
