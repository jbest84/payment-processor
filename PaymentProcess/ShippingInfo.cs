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
    public class ShippingInfo
    {
        private string _first_name;

        public string x_ship_to_first_name
        {
            get { return _first_name; }
            set { _first_name = value; }
        }

        private string _last_name;

        public string x_ship_to_last_name
        {
            get { return _last_name; }
            set { _last_name = value; }
        }

        private string _company;

        public string x_ship_to_company
        {
            get { return _company; }
            set { _company = value; }
        }

        private string _address;

        public string x_ship_to_address
        {
            get { return _address; }
            set { _address = value; }
        }

        private string _city;

        public string x_ship_to_city
        {
            get { return _city; }
            set { _city = value; }
        }

        private string _state;

        public string x_ship_to_state
        {
            get { return _state; }
            set { _state = value; }
        }

        private string _zip;

        public string x_ship_to_zip
        {
            get { return _zip; }
            set { _zip = value; }
        }

        private string _country;

        public string x_ship_to_country
        {
            get { return _country; }
            set { _country = value; }
        }

        public ShippingInfo(string ship_to_first_name, string ship_to_last_name,
            string ship_to_company, string ship_to_address, string ship_to_city,
            string ship_to_state, string ship_to_zip, string ship_to_country)
        {
            _first_name = ship_to_first_name;
            _last_name = ship_to_last_name;
            _company = ship_to_company;
            _address = ship_to_address;
            _city = ship_to_city;
            _state = ship_to_state;
            _zip = ship_to_zip;
            _country = ship_to_country;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("&x_ship_to_first_name=" + _first_name);
            sb.Append("&x_ship_to_last_name=" + _last_name);
            sb.Append("&x_ship_to_company=" + _company);
            sb.Append("&x_ship_to_address=" + _address);
            sb.Append("&x_ship_to_city=" + _city);
            sb.Append("&x_ship_to_state=" + _state);
            sb.Append("&x_ship_to_zip=" + _zip);
            sb.Append("&x_ship_to_country=" + _country);

            return sb.ToString();

        }
    }
}
