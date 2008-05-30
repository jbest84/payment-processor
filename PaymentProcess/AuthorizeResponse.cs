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

namespace PaymentProcess
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Diagnostics;

    /// <summary>
    /// Captures the response from the Authorize.NET request.
    /// </summary>
    public class AuthorizeResponse
    {
        /// <summary>
        /// Delimited text from the request (needs to be parsed). Seperated by '|'.
        /// </summary>
        private string results = null;

        /// <summary>
        /// TraceSwitch PaymentProcess
        /// </summary>
        private TraceSwitch ts = new TraceSwitch("PaymentProcess", "");

        #region Split Fields

        /// <summary>
        /// Response code
        /// </summary>
        private string responseCode = "";

        /// <summary>
        /// Response subcode
        /// </summary>
        private string responseSubCode = "";

        /// <summary>
        /// Response reason code
        /// </summary>
        private string responseReasonCode = "";

        /// <summary>
        /// Response reason text
        /// </summary>
        private string responseReasonText = "";

        /// <summary>
        /// Authorization code
        /// </summary>
        private string authorizationCode = "";

        /// <summary>
        /// AVS response
        /// </summary>
        private string avsResponse = "";

        /// <summary>
        /// Transaction ID
        /// </summary>
        private string transactionId = "";

        /// <summary>
        /// Invoice number
        /// </summary>
        private string invoiceNumber = "";

        /// <summary>
        /// Transaction description
        /// </summary>
        private string description = "";

        /// <summary>
        /// Transaction amount
        /// </summary>
        private string amount = "";

        /// <summary>
        /// Transaction method
        /// </summary>
        private string method = "";

        /// <summary>
        /// Transaction type
        /// </summary>
        private string transactionType = "";

        /// <summary>
        /// Customer ID
        /// </summary>
        private string customerId = "";

        /// <summary>
        /// First name
        /// </summary>
        private string firstName = "";

        /// <summary>
        /// Last name information
        /// </summary>
        private string lastName = "";

        /// <summary>
        /// Company name
        /// </summary>
        private string company = "";

        /// <summary>
        /// Company address
        /// </summary>
        private string address = "";

        /// <summary>
        /// Company city
        /// </summary>
        private string city = "";

        /// <summary>
        /// Company state
        /// </summary>
        private string state = "";

        /// <summary>
        /// Company zipcode
        /// </summary>
        private string zip = "";

        /// <summary>
        /// Company country
        /// </summary>
        private string country = "";

        /// <summary>
        /// Company phone
        /// </summary>
        private string phone = "";

        /// <summary>
        /// Company fax
        /// </summary>
        private string fax = "";

        /// <summary>
        /// Company email
        /// </summary>
        private string email = "";

        /// <summary>
        /// Ship to first name
        /// </summary>
        private string shipToFirstName = "";

        /// <summary>
        /// Ship to last name
        /// </summary>
        private string shipToLastName = "";

        /// <summary>
        /// Ship to company
        /// </summary>
        private string shipToCompany = "";

        /// <summary>
        /// Ship to address
        /// </summary>
        private string shipToAddress = "";

        /// <summary>
        /// Ship to city
        /// </summary>
        private string shipToCity = "";

        /// <summary>
        /// Ship to state
        /// </summary>
        private string shipToState = "";

        /// <summary>
        /// Ship to zipcode
        /// </summary>
        private string shipToZip = "";

        /// <summary>
        /// Ship to country
        /// </summary>
        private string shipToCountry = "";

        /// <summary>
        /// Tax amount
        /// </summary>
        private string tax = "";

        /// <summary>
        /// Duty amount
        /// </summary>
        private string duty = "";

        /// <summary>
        /// Freight amount
        /// </summary>
        private string freight = "";

        /// <summary>
        /// Tax exempt
        /// </summary>
        private string taxExempt = "";

        /// <summary>
        /// Purchase order number
        /// </summary>
        private string purchaseOrderNumber = "";

        /// <summary>
        /// MD5 hash for this transaction
        /// </summary>
        private string hash = "";

        /// <summary>
        /// Card code response
        /// </summary>
        private string cardCodeResponse = "";

        /// <summary>
        /// Cardholder authentication verification response
        /// </summary>
        private string cardholderAuthenticationVerificationResponse = "";
        #endregion

        /// <summary>
        /// AuthorizeResponse CTor
        /// </summary>
        /// <param name="results">Raw result from the AuthorizeRequest</param>
        public AuthorizeResponse(string results)
        {
            Trace.WriteLineIf(this.ts.TraceInfo, "AuthorizeResponse CTor (string)");
            this.results = results;
            this.Parse();
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
            get { return this.responseCode; }
        }

        /// <summary>
        /// Gets the response sub code
        /// </summary>
        public string ResponseSubcode
        {
            get { return this.responseSubCode; }
        }

        /// <summary>
        /// Gets the response reason code
        /// </summary>
        public string ResponseReasonCode
        {
            get { return this.responseReasonCode; }
        }

        /// <summary>
        /// Gets the response reason text
        /// </summary>
        public string ResponseReasonText
        {
            get { return this.responseReasonText; }
        }

        /// <summary>
        /// Gets the authorization code
        /// </summary>
        public string AuthorizationCode
        {
            get { return this.authorizationCode; }
        }

        /// <summary>
        /// Gets the AVS response code
        /// </summary>
        public string AvsResponse
        {
            get { return this.avsResponse; }
        }

        /// <summary>
        /// Gets the transaction ID
        /// </summary>
        public string TransactionId
        {
            get { return this.transactionId; }
        }

        /// <summary>
        /// Gets the invoice number
        /// </summary>
        public string InvoiceNumber
        {
            get { return this.invoiceNumber; }
        }

        /// <summary>
        /// Gets the description
        /// </summary>
        public string Description
        {
            get { return this.description; }
        }

        /// <summary>
        /// Gets the amount
        /// </summary>
        public string Amount
        {
            get { return this.amount; }
        }

        /// <summary>
        /// Gets the method
        /// </summary>
        public string Method
        {
            get { return this.method; }
        }

        /// <summary>
        /// Gets the transaction type
        /// </summary>
        public string TransactionType
        {
            get { return this.transactionType; }
        }

        /// <summary>
        /// Gets the customer ID
        /// </summary>
        public string CustomerId
        {
            get { return this.customerId; }
        }

        /// <summary>
        /// Gets the first name
        /// </summary>
        public string FirstName
        {
            get { return this.firstName; }
        }

        /// <summary>
        /// Gets the last name
        /// </summary>
        public string LastName
        {
            get { return this.lastName; }
        }

        /// <summary>
        /// Gets the company
        /// </summary>
        public string Company
        {
            get { return this.company; }
        }

        /// <summary>
        /// Gets the address
        /// </summary>
        public string Address
        {
            get { return this.address; }
        }

        /// <summary>
        /// Gets the city
        /// </summary>
        public string City
        {
            get { return this.city; }
        }

        /// <summary>
        /// Gets the state
        /// </summary>
        public string State
        {
            get { return this.state; }
        }

        /// <summary>
        /// Gets the zip code
        /// </summary>
        public string Zip
        {
            get { return this.zip; }
        }

        /// <summary>
        /// Gets the country
        /// </summary>
        public string Country
        {
            get { return this.country; }
        }

        /// <summary>
        /// Gets the phone number
        /// </summary>
        public string Phone
        {
            get { return this.phone; }
        }

        /// <summary>
        /// Gets the fax number
        /// </summary>
        public string Fax
        {
            get { return this.fax; }
        }

        /// <summary>
        /// Gets the email address
        /// </summary>
        public string Email
        {
            get { return this.email; }
        }

        /// <summary>
        /// Gets ship to first name
        /// </summary>
        public string ShipToFirstName
        {
            get { return this.shipToFirstName; }
        }

        /// <summary>
        /// Gets ship to last name
        /// </summary>
        public string ShipToLastName
        {
            get { return this.shipToLastName; }
        }

        /// <summary>
        /// Gets ship to company
        /// </summary>
        public string ShipToCompany
        {
            get { return this.shipToCompany; }
        }

        /// <summary>
        /// Gets ship to address
        /// </summary>
        public string ShipToAddress
        {
            get { return this.shipToAddress; }
        }

        /// <summary>
        /// Gets ship to city
        /// </summary>
        public string ShipToCity
        {
            get { return this.shipToCity; }
        }

        /// <summary>
        /// Gets ship to state
        /// </summary>
        public string ShipToState
        {
            get { return this.shipToState; }
        }

        /// <summary>
        /// Gets ship to zip code
        /// </summary>
        public string ShipToZip
        {
            get { return this.shipToZip; }
        }

        /// <summary>
        /// Gets ship to country
        /// </summary>
        public string ShipToCountry
        {
            get { return this.shipToCountry; }
        }

        /// <summary>
        /// Gets tax amount
        /// </summary>
        public string Tax
        {
            get { return this.tax; }
        }

        /// <summary>
        /// Gets duty amount
        /// </summary>
        public string Duty
        {
            get { return this.duty; }
        }

        /// <summary>
        /// Gets freight amount
        /// </summary>
        public string Freight
        {
            get { return this.freight; }
        }

        /// <summary>
        /// Gets tax exempt
        /// </summary>
        public string TaxExempt
        {
            get { return this.taxExempt; }
        }

        /// <summary>
        /// Gets purchase order number
        /// </summary>
        public string PurchaseOrderNumber
        {
            get { return this.purchaseOrderNumber; }
        }

        /// <summary>
        /// Gets MD5 hash
        /// </summary>
        public string Md5Hash
        {
            get { return this.hash; }
        }

        /// <summary>
        /// Gets card code response
        /// </summary>
        public string CardCodeResponse
        {
            get { return this.cardCodeResponse; }
        }

        /// <summary>
        /// Gets cardholder authentication verification response
        /// </summary>
        public string CardholderAuthenticationVerificationResponse
        {
            get { return this.cardholderAuthenticationVerificationResponse; }
        }

        /// <summary>
        /// Parses the raw results and places the values in the class members.
        /// </summary>
        private void Parse()
        {
            Trace.WriteLineIf(this.ts.TraceInfo, "AuthorizeResponse - Parse start");
            string[] p = this.results.Split('|');
            Trace.WriteLineIf(this.ts.TraceInfo, "\tAuthorizeResponse - Length of split: " + p.Length);
            if (p.Length >= 39)
            {
                this.responseCode = p[0];
                this.responseSubCode = p[1];
                this.responseReasonCode = p[2];
                this.responseReasonText = p[3];
                this.authorizationCode = p[4];
                this.avsResponse = p[5];
                this.transactionId = p[6];
                this.invoiceNumber = p[7];
                this.description = p[8];
                this.amount = p[9];
                this.method = p[10];
                this.transactionType = p[11];
                this.customerId = p[12];
                this.firstName = p[13];
                this.lastName = p[14];
                this.company = p[15];
                this.address = p[16];
                this.city = p[17];
                this.state = p[18];
                this.zip = p[19];
                this.country = p[20];
                this.phone = p[21];
                this.fax = p[22];
                this.email = p[23];
                this.shipToFirstName = p[24];
                this.shipToLastName = p[25];
                this.shipToCompany = p[26];
                this.shipToAddress = p[27];
                this.shipToCity = p[28];
                this.shipToState = p[29];
                this.shipToZip = p[30];
                this.shipToCountry = p[31];
                this.tax = p[32];
                this.duty = p[33];
                this.freight = p[34];
                this.taxExempt = p[35];
                this.purchaseOrderNumber = p[36];
                this.hash = p[37];
                this.cardCodeResponse = p[38];
                this.cardholderAuthenticationVerificationResponse = p[39];
            }

            Trace.WriteLineIf(this.ts.TraceInfo, "AuthorizeResponse - Parse end");
        }
    }
}