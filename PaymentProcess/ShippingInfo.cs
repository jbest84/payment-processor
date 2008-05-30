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

namespace PaymentProcess
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Diagnostics;

    /// <summary>
    /// Shipping information
    /// </summary>
    public class ShippingInfo
    {
        /// <summary>
        /// Ship to first name
        /// </summary>
        private string firstName;

        /// <summary>
        /// Ship to last name
        /// </summary>
        private string lastName;

        /// <summary>
        /// Ship to company
        /// </summary>
        private string company;

        /// <summary>
        /// Ship to address
        /// </summary>
        private string address;

        /// <summary>
        /// Ship to city
        /// </summary>
        private string city;

        /// <summary>
        /// Ship to state
        /// </summary>
        private string state;

        /// <summary>
        /// Ship to zip code
        /// </summary>
        private string zip;

        /// <summary>
        /// Ship to country
        /// </summary>
        private string country;

        /// <summary>
        /// TraceSwitch PaymentProcess
        /// </summary>
        private TraceSwitch ts = new TraceSwitch("PaymentProcess", "");

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
        public ShippingInfo(string ship_to_first_name, string ship_to_last_name, string ship_to_company, string ship_to_address, string ship_to_city, string ship_to_state, string ship_to_zip, string ship_to_country)
        {
            Trace.WriteLineIf(this.ts.TraceInfo, "ShippingInfo - CTor (string * 8)");

            this.firstName = ship_to_first_name;
            this.lastName = ship_to_last_name;
            this.company = ship_to_company;
            this.address = ship_to_address;
            this.city = ship_to_city;
            this.state = ship_to_state;
            this.zip = ship_to_zip;
            this.country = ship_to_country;
        }

        /// <summary>
        /// Gets or sets ship to first name
        /// </summary>
        public string X_Ship_To_First_Name
        {
            get { return this.firstName; }
            set { this.firstName = value; }
        }

        /// <summary>
        /// Gets or sets ship to last name
        /// </summary>
        public string X_Ship_To_Last_Name
        {
            get { return this.lastName; }
            set { this.lastName = value; }
        }

        /// <summary>
        /// Gets or sets ship to compay
        /// </summary>
        public string X_Ship_To_Company
        {
            get { return this.company; }
            set { this.company = value; }
        }

        /// <summary>
        /// Gets or sets ship to address
        /// </summary>
        public string X_Ship_To_Address
        {
            get { return this.address; }
            set { this.address = value; }
        }

        /// <summary>
        /// Gets or sets ship to city
        /// </summary>
        public string X_Ship_To_City
        {
            get { return this.city; }
            set { this.city = value; }
        }

        /// <summary>
        /// Gets or sets ship to state
        /// </summary>
        public string X_Ship_To_State
        {
            get { return this.state; }
            set { this.state = value; }
        }

        /// <summary>
        /// Gets or sets ship to zip code
        /// </summary>
        public string X_Ship_To_Zip
        {
            get { return this.zip; }
            set { this.zip = value; }
        }

        /// <summary>
        /// Gets or sets ship to country
        /// </summary>
        public string X_Ship_To_Country
        {
            get { return this.country; }
            set { this.country = value; }
        }

        /// <summary>
        /// Builds the HTTP POST string for AuthorizeRequest
        /// </summary>
        /// <returns>see summary</returns>
        public override string ToString()
        {
            Trace.WriteLineIf(this.ts.TraceInfo, "ShippingInfo - ToString start");

            StringBuilder sb = new StringBuilder();

            sb.Append("&x_ship_to_first_name=" + this.firstName);
            sb.Append("&x_ship_to_last_name=" + this.lastName);
            sb.Append("&x_ship_to_company=" + this.company);
            sb.Append("&x_ship_to_address=" + this.address);
            sb.Append("&x_ship_to_city=" + this.city);
            sb.Append("&x_ship_to_state=" + this.state);
            sb.Append("&x_ship_to_zip=" + this.zip);
            sb.Append("&x_ship_to_country=" + this.country);

            Trace.WriteLineIf(this.ts.TraceInfo, "Stringbuilder value to return: " + sb.ToString());
            Trace.WriteLineIf(this.ts.TraceInfo, "ShippingInfo - ToString end");

            return sb.ToString();
        }
    }
}
