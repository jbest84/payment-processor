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
using System.Diagnostics;

namespace PaymentProcess
{
    public class AuthorizeResponse
    {
        private string _results = null; //Delimited text from the request (needs to be parsed). Seperated by '|'.
        private TraceSwitch ts = new TraceSwitch("PaymentProcess", "");

        //These are all of the fields returned from the split, kept initially as string (caller can do the conversions if necessary).
        private string _response_code = "";

        public string ResponseCode
        {
            get { return _response_code; }
        }

        private string _response_subcode = "";

        public string ResponseSubcode
        {
            get { return _response_subcode; }
        }

        private string _response_reason_code = "";

        public string ResponseReasonCode
        {
            get { return _response_reason_code; }
        }

        private string _response_reason_text = "";

        public string ResponseReasonText
        {
            get { return _response_reason_text; }
        }

        private string _authorization_code = "";

        public string AuthorizationCode
        {
            get { return _authorization_code; }
        }

        private string _avs_response = "";

        public string AvsResponse
        {
            get { return _avs_response; }
        }

        private string _transaction_id = "";

        public string TransactionId
        {
            get { return _transaction_id; }
        }

        private string _invoice_number = "";

        public string InvoiceNumber
        {
            get { return _invoice_number; }
        }

        private string _description = "";

        public string Description
        {
            get { return _description; }
        }

        private string _amount = "";

        public string Amount
        {
            get { return _amount; }
        }

        private string _method = "";

        public string Method
        {
            get { return _method; }
        }

        private string _transaction_type = "";

        public string TransactionType
        {
            get { return _transaction_type; }
        }

        private string _customer_id = "";

        public string CustomerId
        {
            get { return _customer_id; }
        }

        private string _first_name = "";

        public string FirstName
        {
            get { return _first_name; }
        }

        private string _last_name = "";

        public string LastName
        {
            get { return _last_name; }
        }

        private string _company = "";

        public string Company
        {
            get { return _company; }
        }

        private string _address = "";

        public string Address
        {
            get { return _address; }
        }

        private string _city = "";

        public string City
        {
            get { return _city; }
        }

        private string _state = "";

        public string State
        {
            get { return _state; }
        }

        private string _zip = "";

        public string Zip
        {
            get { return _zip; }
        }

        private string _country = "";

        public string Country
        {
            get { return _country; }
        }

        private string _phone = "";

        public string Phone
        {
            get { return _phone; }
        }

        private string _fax = "";

        public string Fax
        {
            get { return _fax; }
        }

        private string _email = "";

        public string Email
        {
            get { return _email; }
        }

        private string _ship_to_first_name = "";

        public string ShipToFirstName
        {
            get { return _ship_to_first_name; }
        }

        private string _ship_to_last_name = "";

        public string ShipToLastName
        {
            get { return _ship_to_last_name; }
        }

        private string _ship_to_company = "";

        public string ShipToCompany
        {
            get { return _ship_to_company; }
        }

        private string _ship_to_address = "";

        public string ShipToAddress
        {
            get { return _ship_to_address; }
        }

        private string _ship_to_city = "";

        public string ShipToCity
        {
            get { return _ship_to_city; }
        }

        private string _ship_to_state = "";

        public string ShipToState
        {
            get { return _ship_to_state; }
        }

        private string _ship_to_zip = "";

        public string ShipToZip
        {
            get { return _ship_to_zip; }
        }

        private string _ship_to_country = "";

        public string ShipToCountry
        {
            get { return _ship_to_country; }
        }

        private string _tax = "";

        public string Tax
        {
            get { return _tax; }
        }

        private string _duty = "";

        public string Duty
        {
            get { return _duty; }
        }

        private string _freight = "";

        public string Freight
        {
            get { return _freight; }
        }

        private string _tax_exempt = "";

        public string TaxExempt
        {
            get { return _tax_exempt; }
        }

        private string _purchase_order_number = "";

        public string PurchaseOrderNumber
        {
            get { return _purchase_order_number; }
        }

        private string _md5_hash = "";

        public string Md5Hash
        {
            get { return _md5_hash; }
        }

        private string _card_code_response = "";

        public string CardCodeResponse
        {
            get { return _card_code_response; }
        }

        private string _cardholder_authentication_verification_response = "";

        public string CardholderAuthenticationVerificationResponse
        {
            get { return _cardholder_authentication_verification_response; }
        }

        private AuthorizeResponse() { }

        public AuthorizeResponse(string results)
        {
            Trace.WriteLineIf(ts.TraceInfo, "AuthorizeResponse CTor");
            _results = results;
            Parse();
        }

        private void Parse()
        {
            Trace.WriteLineIf(ts.TraceInfo, "AuthorizeResponse - Parse start");
            string[] p = _results.Split('|');
            Trace.WriteLineIf(ts.TraceInfo, "\tAuthorizeResponse - Length of split: " + p.Length);
            if (p.Length >= 39)
            {
                this._response_code = p[0];
                this._response_subcode = p[1];
                this._response_reason_code = p[2];
                this._response_reason_text = p[3];
                this._authorization_code = p[4];
                this._avs_response = p[5];
                this._transaction_id = p[6];
                this._invoice_number = p[7];
                this._description = p[8];
                this._amount = p[9];
                this._method = p[10];
                this._transaction_type = p[11];
                this._customer_id = p[12];
                this._first_name = p[13];
                this._last_name = p[14];
                this._company = p[15];
                this._address = p[16];
                this._city = p[17];
                this._state = p[18];
                this._zip = p[19];
                this._country = p[20];
                this._phone = p[21];
                this._fax = p[22];
                this._email = p[23];
                this._ship_to_first_name = p[24];
                this._ship_to_last_name = p[25];
                this._ship_to_company = p[26];
                this._ship_to_address = p[27];
                this._ship_to_city = p[28];
                this._ship_to_state = p[29];
                this._ship_to_zip = p[30];
                this._ship_to_country = p[31];
                this._tax = p[32];
                this._duty = p[33];
                this._freight = p[34];
                this._tax_exempt = p[35];
                this._purchase_order_number = p[36];
                this._md5_hash = p[37];
                this._card_code_response = p[38];
                this._cardholder_authentication_verification_response = p[39];
            }
            Trace.WriteLineIf(ts.TraceInfo, "AuthorizeResponse - Parse end");
        }
    }
}