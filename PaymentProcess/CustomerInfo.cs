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

namespace PaymentProcess
{
    public class CustomerInfo
    {
        private string _first_name;

        public string x_first_name
        {
            get { return _first_name; }
            set { _first_name = value; }
        }

        private string _last_name;

        public string x_last_name
        {
            get { return _last_name; }
            set { _last_name = value; }
        }

        private string _company;

        public string x_company
        {
            get { return _company; }
            set { _company = value; }
        }

        private string _address;

        public string x_address
        {
            get { return _address; }
            set { _address = value; }
        }

        private string _city;

        public string x_city
        {
            get { return _city; }
            set { _city = value; }
        }

        private string _state;

        public string x_state
        {
            get { return _state; }
            set { _state = value; }
        }

        private string _zip;

        public string x_zip
        {
            get { return _zip; }
            set { _zip = value; }
        }

        private string _country;

        public string x_country
        {
            get { return _country; }
            set { _country = value; }
        }

        private string _phone;

        public string x_phone
        {
            get { return _phone; }
            set { _phone = value; }
        }

        private string _fax;

        public string x_fax
        {
            get { return _fax; }
            set { _fax = value; }
        }

        private string _email;

        public string x_email
        {
            get { return _email; }
            set { _email = value; }
        }

        private string _customer_id;

        public string x_cust_id
        {
            get { return _customer_id; }
            set { _customer_id = value; }
        }

        private string _customer_ip;

        public string x_customer_ip
        {
            get { return _customer_ip; }
            set { _customer_ip = value; }
        }

        public CustomerInfo(string first_name, string last_name, string company, string address,
            string city, string state, string zip, string country, string phone, string fax,
            string email, string customer_id, string customer_ip)
        {
            _first_name = first_name;
            _last_name = last_name;
            _company = company;
            _address = address;
            _city = city;
            _state = state;
            _zip = zip;
            _country = country;
            _phone = phone;
            _fax = fax;
            _email = email;
            _customer_id = customer_id;
            _customer_ip = customer_ip;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("&x_first_name=" + _first_name);
            sb.Append("&x_last_name=" + _last_name);
            sb.Append("&x_company=" + _company);
            sb.Append("&x_address=" + _address);
            sb.Append("&x_city=" + _city);
            sb.Append("&x_state=" + _state);
            sb.Append("&x_zip=" + _zip);
            sb.Append("&x_country=" + _country);
            sb.Append("&x_phone=" + _phone);
            sb.Append("&x_fax=" + _fax);
            sb.Append("&x_email=" + _email);
            sb.Append("&x_cust_id=" + _customer_id);
            sb.Append("&x_customer_ip=" + _customer_ip);

            return sb.ToString();
        }
    }
}
