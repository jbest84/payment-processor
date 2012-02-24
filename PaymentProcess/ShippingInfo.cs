//-----------------------------------------------------------------------
// <copyright file="ShippingInfo.cs" company="Mission3, Inc.">
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
using System.Text;

namespace PaymentProcess
{
    /// <summary>
    /// Shipping information
    /// </summary>
    public class ShippingInfo : IInfo
    {
        /// <summary>
        /// TraceSwitch PaymentProcess
        /// </summary>
        private readonly TraceSwitch ts = new TraceSwitch("PaymentProcess", "");

        /// <summary>
        /// Ship to address
        /// </summary>
        private string address;

        /// <summary>
        /// Ship to city
        /// </summary>
        private string city;

        /// <summary>
        /// Ship to company
        /// </summary>
        private string company;

        /// <summary>
        /// Ship to country
        /// </summary>
        private string country;

        /// <summary>
        /// Ship to first name
        /// </summary>
        private string firstName;

        /// <summary>
        /// Ship to last name
        /// </summary>
        private string lastName;

        /// <summary>
        /// Ship to state
        /// </summary>
        private string state;

        /// <summary>
        /// Ship to zip code
        /// </summary>
        private string zip;

        /// <summary>
        /// ShippingInfo CTor
        /// </summary>
        /// <param name="ship_to_first_name">Ship to first name</param>
        /// <param name="ship_to_last_name">Ship to last name</param>
        /// <param name="ship_to_company">Ship to company</param>
        /// <param name="ship_to_address">Ship to address</param>
        /// <param name="ship_to_city">Ship to city</param>
        /// <param name="ship_to_state">Ship to state</param>
        /// <param name="ship_to_zip">Ship to zip code</param>
        /// <param name="ship_to_country">Ship to country</param>
        public ShippingInfo(string ship_to_first_name, string ship_to_last_name, string ship_to_company,
                            string ship_to_address, string ship_to_city, string ship_to_state, string ship_to_zip,
                            string ship_to_country)
        {
            Trace.WriteLineIf(ts.TraceInfo, "ShippingInfo - CTor (string * 8)");

            firstName = ship_to_first_name;
            lastName = ship_to_last_name;
            company = ship_to_company;
            address = ship_to_address;
            city = ship_to_city;
            state = ship_to_state;
            zip = ship_to_zip;
            country = ship_to_country;
        }

        /// <summary>
        /// Gets or sets ship to first name
        /// </summary>
        public string X_Ship_To_First_Name
        {
            get { return firstName; }
            set { firstName = value; }
        }

        /// <summary>
        /// Gets or sets ship to last name
        /// </summary>
        public string X_Ship_To_Last_Name
        {
            get { return lastName; }
            set { lastName = value; }
        }

        /// <summary>
        /// Gets or sets ship to compay
        /// </summary>
        public string X_Ship_To_Company
        {
            get { return company; }
            set { company = value; }
        }

        /// <summary>
        /// Gets or sets ship to address
        /// </summary>
        public string X_Ship_To_Address
        {
            get { return address; }
            set { address = value; }
        }

        /// <summary>
        /// Gets or sets ship to city
        /// </summary>
        public string X_Ship_To_City
        {
            get { return city; }
            set { city = value; }
        }

        /// <summary>
        /// Gets or sets ship to state
        /// </summary>
        public string X_Ship_To_State
        {
            get { return state; }
            set { state = value; }
        }

        /// <summary>
        /// Gets or sets ship to zip code
        /// </summary>
        public string X_Ship_To_Zip
        {
            get { return zip; }
            set { zip = value; }
        }

        /// <summary>
        /// Gets or sets ship to country
        /// </summary>
        public string X_Ship_To_Country
        {
            get { return country; }
            set { country = value; }
        }

        #region IInfo Members

        /// <summary>
        /// Builds the HTTP POST string for AuthorizeRequest
        /// </summary>
        /// <returns>see summary</returns>
        public override string ToString()
        {
            Trace.WriteLineIf(ts.TraceInfo, "ShippingInfo - ToString start");

            var sb = new StringBuilder();

            sb.Append("&x_ship_to_first_name=" + firstName);
            sb.Append("&x_ship_to_last_name=" + lastName);
            sb.Append("&x_ship_to_company=" + company);
            sb.Append("&x_ship_to_address=" + address);
            sb.Append("&x_ship_to_city=" + city);
            sb.Append("&x_ship_to_state=" + state);
            sb.Append("&x_ship_to_zip=" + zip);
            sb.Append("&x_ship_to_country=" + country);

            Trace.WriteLineIf(ts.TraceInfo, "Stringbuilder value to return: " + sb);
            Trace.WriteLineIf(ts.TraceInfo, "ShippingInfo - ToString end");

            return sb.ToString();
        }

        #endregion
    }
}