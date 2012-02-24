//-----------------------------------------------------------------------
// <copyright file="AuthorizeResponse.cs" company="Mission3, Inc.">
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

using System.Diagnostics;

namespace PaymentProcess
{
    /// <summary>
    /// Captures the response from the Authorize.NET request.
    /// </summary>
    public class AuthorizeResponse
    {
        /// <summary>
        /// Delimited text from the request (needs to be parsed). Seperated by '|'.
        /// </summary>
        private readonly string results;

        /// <summary>
        /// TraceSwitch PaymentProcess
        /// </summary>
        private readonly TraceSwitch ts = new TraceSwitch("PaymentProcess", "");

        #region Split Fields

        /// <summary>
        /// Company address
        /// </summary>
        private string address = "";

        /// <summary>
        /// Transaction amount
        /// </summary>
        private string amount = "";

        /// <summary>
        /// Authorization code
        /// </summary>
        private string authorizationCode = "";

        /// <summary>
        /// AVS response
        /// </summary>
        private string avsResponse = "";

        /// <summary>
        /// Card code response
        /// </summary>
        private string cardCodeResponse = "";

        /// <summary>
        /// Cardholder authentication verification response
        /// </summary>
        private string cardholderAuthenticationVerificationResponse = "";

        /// <summary>
        /// Company city
        /// </summary>
        private string city = "";

        /// <summary>
        /// Company name
        /// </summary>
        private string company = "";

        /// <summary>
        /// Company country
        /// </summary>
        private string country = "";

        /// <summary>
        /// Customer ID
        /// </summary>
        private string customerId = "";

        /// <summary>
        /// Transaction description
        /// </summary>
        private string description = "";

        /// <summary>
        /// Duty amount
        /// </summary>
        private string duty = "";

        /// <summary>
        /// Company email
        /// </summary>
        private string email = "";

        /// <summary>
        /// Company fax
        /// </summary>
        private string fax = "";

        /// <summary>
        /// First name
        /// </summary>
        private string firstName = "";

        /// <summary>
        /// Freight amount
        /// </summary>
        private string freight = "";

        /// <summary>
        /// MD5 hash for this transaction
        /// </summary>
        private string hash = "";

        /// <summary>
        /// Invoice number
        /// </summary>
        private string invoiceNumber = "";

        /// <summary>
        /// Last name information
        /// </summary>
        private string lastName = "";

        /// <summary>
        /// Transaction method
        /// </summary>
        private string method = "";

        /// <summary>
        /// Company phone
        /// </summary>
        private string phone = "";

        /// <summary>
        /// Purchase order number
        /// </summary>
        private string purchaseOrderNumber = "";

        /// <summary>
        /// Response code
        /// </summary>
        private string responseCode = "";

        /// <summary>
        /// Response reason code
        /// </summary>
        private string responseReasonCode = "";

        /// <summary>
        /// Response reason text
        /// </summary>
        private string responseReasonText = "";

        /// <summary>
        /// Response subcode
        /// </summary>
        private string responseSubCode = "";

        /// <summary>
        /// Ship to address
        /// </summary>
        private string shipToAddress = "";

        /// <summary>
        /// Ship to city
        /// </summary>
        private string shipToCity = "";

        /// <summary>
        /// Ship to company
        /// </summary>
        private string shipToCompany = "";

        /// <summary>
        /// Ship to country
        /// </summary>
        private string shipToCountry = "";

        /// <summary>
        /// Ship to first name
        /// </summary>
        private string shipToFirstName = "";

        /// <summary>
        /// Ship to last name
        /// </summary>
        private string shipToLastName = "";

        /// <summary>
        /// Ship to state
        /// </summary>
        private string shipToState = "";

        /// <summary>
        /// Ship to zipcode
        /// </summary>
        private string shipToZip = "";

        /// <summary>
        /// Company state
        /// </summary>
        private string state = "";

        /// <summary>
        /// Tax amount
        /// </summary>
        private string tax = "";

        /// <summary>
        /// Tax exempt
        /// </summary>
        private string taxExempt = "";

        /// <summary>
        /// Transaction ID
        /// </summary>
        private string transactionId = "";

        /// <summary>
        /// Transaction type
        /// </summary>
        private string transactionType = "";

        /// <summary>
        /// Company zipcode
        /// </summary>
        private string zip = "";

        #endregion

        /// <summary>
        /// AuthorizeResponse CTor
        /// </summary>
        /// <param name="results">Raw result from the AuthorizeRequest</param>
        public AuthorizeResponse(string results)
        {
            Trace.WriteLineIf(ts.TraceInfo, "AuthorizeResponse CTor (string)");
            this.results = results;
            Parse();
        }

        /// <summary>
        /// AuthorizeResponse private CTor
        /// </summary>
        private AuthorizeResponse()
        {
        }

        /// <summary>
        /// Gets the response code
        /// </summary>
        public string ResponseCode
        {
            get { return responseCode; }
        }

        /// <summary>
        /// Gets the response sub code
        /// </summary>
        public string ResponseSubcode
        {
            get { return responseSubCode; }
        }

        /// <summary>
        /// Gets the response reason code
        /// </summary>
        public string ResponseReasonCode
        {
            get { return responseReasonCode; }
        }

        /// <summary>
        /// Gets the response reason text
        /// </summary>
        public string ResponseReasonText
        {
            get { return responseReasonText; }
        }

        /// <summary>
        /// Gets the authorization code
        /// </summary>
        public string AuthorizationCode
        {
            get { return authorizationCode; }
        }

        /// <summary>
        /// Gets the AVS response code
        /// </summary>
        public string AvsResponse
        {
            get { return avsResponse; }
        }

        /// <summary>
        /// Gets the transaction ID
        /// </summary>
        public string TransactionId
        {
            get { return transactionId; }
        }

        /// <summary>
        /// Gets the invoice number
        /// </summary>
        public string InvoiceNumber
        {
            get { return invoiceNumber; }
        }

        /// <summary>
        /// Gets the description
        /// </summary>
        public string Description
        {
            get { return description; }
        }

        /// <summary>
        /// Gets the amount
        /// </summary>
        public string Amount
        {
            get { return amount; }
        }

        /// <summary>
        /// Gets the method
        /// </summary>
        public string Method
        {
            get { return method; }
        }

        /// <summary>
        /// Gets the transaction type
        /// </summary>
        public string TransactionType
        {
            get { return transactionType; }
        }

        /// <summary>
        /// Gets the customer ID
        /// </summary>
        public string CustomerId
        {
            get { return customerId; }
        }

        /// <summary>
        /// Gets the first name
        /// </summary>
        public string FirstName
        {
            get { return firstName; }
        }

        /// <summary>
        /// Gets the last name
        /// </summary>
        public string LastName
        {
            get { return lastName; }
        }

        /// <summary>
        /// Gets the company
        /// </summary>
        public string Company
        {
            get { return company; }
        }

        /// <summary>
        /// Gets the address
        /// </summary>
        public string Address
        {
            get { return address; }
        }

        /// <summary>
        /// Gets the city
        /// </summary>
        public string City
        {
            get { return city; }
        }

        /// <summary>
        /// Gets the state
        /// </summary>
        public string State
        {
            get { return state; }
        }

        /// <summary>
        /// Gets the zip code
        /// </summary>
        public string Zip
        {
            get { return zip; }
        }

        /// <summary>
        /// Gets the country
        /// </summary>
        public string Country
        {
            get { return country; }
        }

        /// <summary>
        /// Gets the phone number
        /// </summary>
        public string Phone
        {
            get { return phone; }
        }

        /// <summary>
        /// Gets the fax number
        /// </summary>
        public string Fax
        {
            get { return fax; }
        }

        /// <summary>
        /// Gets the email address
        /// </summary>
        public string Email
        {
            get { return email; }
        }

        /// <summary>
        /// Gets ship to first name
        /// </summary>
        public string ShipToFirstName
        {
            get { return shipToFirstName; }
        }

        /// <summary>
        /// Gets ship to last name
        /// </summary>
        public string ShipToLastName
        {
            get { return shipToLastName; }
        }

        /// <summary>
        /// Gets ship to company
        /// </summary>
        public string ShipToCompany
        {
            get { return shipToCompany; }
        }

        /// <summary>
        /// Gets ship to address
        /// </summary>
        public string ShipToAddress
        {
            get { return shipToAddress; }
        }

        /// <summary>
        /// Gets ship to city
        /// </summary>
        public string ShipToCity
        {
            get { return shipToCity; }
        }

        /// <summary>
        /// Gets ship to state
        /// </summary>
        public string ShipToState
        {
            get { return shipToState; }
        }

        /// <summary>
        /// Gets ship to zip code
        /// </summary>
        public string ShipToZip
        {
            get { return shipToZip; }
        }

        /// <summary>
        /// Gets ship to country
        /// </summary>
        public string ShipToCountry
        {
            get { return shipToCountry; }
        }

        /// <summary>
        /// Gets tax amount
        /// </summary>
        public string Tax
        {
            get { return tax; }
        }

        /// <summary>
        /// Gets duty amount
        /// </summary>
        public string Duty
        {
            get { return duty; }
        }

        /// <summary>
        /// Gets freight amount
        /// </summary>
        public string Freight
        {
            get { return freight; }
        }

        /// <summary>
        /// Gets tax exempt
        /// </summary>
        public string TaxExempt
        {
            get { return taxExempt; }
        }

        /// <summary>
        /// Gets purchase order number
        /// </summary>
        public string PurchaseOrderNumber
        {
            get { return purchaseOrderNumber; }
        }

        /// <summary>
        /// Gets MD5 hash
        /// </summary>
        public string Md5Hash
        {
            get { return hash; }
        }

        /// <summary>
        /// Gets card code response
        /// </summary>
        public string CardCodeResponse
        {
            get { return cardCodeResponse; }
        }

        /// <summary>
        /// Gets cardholder authentication verification response
        /// </summary>
        public string CardholderAuthenticationVerificationResponse
        {
            get { return cardholderAuthenticationVerificationResponse; }
        }

        /// <summary>
        /// Parses the raw results and places the values in the class members.
        /// </summary>
        private void Parse()
        {
            Trace.WriteLineIf(ts.TraceInfo, "AuthorizeResponse - Parse start");
            string[] p = results.Split('|');
            Trace.WriteLineIf(ts.TraceInfo, "\tAuthorizeResponse - Length of split: " + p.Length);
            if (p.Length >= 39)
            {
                responseCode = p[0];
                responseSubCode = p[1];
                responseReasonCode = p[2];
                responseReasonText = p[3];
                authorizationCode = p[4];
                avsResponse = p[5];
                transactionId = p[6];
                invoiceNumber = p[7];
                description = p[8];
                amount = p[9];
                method = p[10];
                transactionType = p[11];
                customerId = p[12];
                firstName = p[13];
                lastName = p[14];
                company = p[15];
                address = p[16];
                city = p[17];
                state = p[18];
                zip = p[19];
                country = p[20];
                phone = p[21];
                fax = p[22];
                email = p[23];
                shipToFirstName = p[24];
                shipToLastName = p[25];
                shipToCompany = p[26];
                shipToAddress = p[27];
                shipToCity = p[28];
                shipToState = p[29];
                shipToZip = p[30];
                shipToCountry = p[31];
                tax = p[32];
                duty = p[33];
                freight = p[34];
                taxExempt = p[35];
                purchaseOrderNumber = p[36];
                hash = p[37];
                cardCodeResponse = p[38];
                cardholderAuthenticationVerificationResponse = p[39];
            }

            Trace.WriteLineIf(ts.TraceInfo, "AuthorizeResponse - Parse end");
        }
    }
}