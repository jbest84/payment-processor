//-----------------------------------------------------------------------
// <copyright file="AdditionalShippingInfo.cs" company="Mission3, Inc.">
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

namespace PaymentProcessQuickStart
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using PaymentProcess;

    class Program
    {
        static void Main(string[] args)
        {
            List<IInfo> reqInfo = new List<IInfo>();

            // CC
            string version = "3.1";
            decimal amount = 1; // one dollar
            string CCNumber = "4111111111111111";
            string CCExp = "0115";
            string TAC_ID = "123456";
            string TAC_AuthCode = "";
            //bool TEST = false;

	        // new constructor param - TEST - remove if not needed
            CreditTransactionInfo infCCTrans = new CreditTransactionInfo(version, amount, CCNumber, CCExp, TAC_ID, XTypes.AUTH_CAPTURE, TAC_AuthCode);
            reqInfo.Add(infCCTrans);

            // Merchant
            string login = "your test or prod API Login ID";
            string tranKey = "your test or prod Transaction Key";

            MerchantInfo infMerchant = new MerchantInfo(login, tranKey);
            reqInfo.Add(infMerchant);

            // Order
            string invoice = "666";
            string description = "Gummi Baerchen";
            OrderInfo infOrder = new OrderInfo(invoice, description);
            reqInfo.Add(infOrder);

            // Customer
            CustomerInfo infCustomer = new CustomerInfo("John", "Doe", "Pretty Good Company", "Address", "City", "State", "ZIP", "US", "410150620", "fax", "doe@goodcompany.com", "CustomerID", "CustomerIP");
            reqInfo.Add(infCustomer);

            // send request
            AuthorizeRequest request;
            AuthorizeResponse response;

            try
            {
                request = new AuthorizeRequest(AuthorizeURL.PRODUCTION_URL, reqInfo.ToArray());
                response = request.SendRequest();

                Console.WriteLine(string.Format("RespCode '{0}'\nRespSubCode '{1}'\nReasonCode '{2}'\nReasonText '{3}'", response.ResponseCode, response.ResponseSubcode, response.ResponseReasonCode, response.ResponseReasonText));

                Console.ReadKey();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
