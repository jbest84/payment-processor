//-----------------------------------------------------------------------
// <copyright file="CustomerInfo.cs" company="Mission3, Inc.">
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

    /// <summary>
    /// Holds customer information for AuthorizeRequest
    /// </summary>
    public class CustomerInfo
    {
        /// <summary>
        /// Customer first name
        /// </summary>
        private string firstName;

        /// <summary>
        /// Customer last name
        /// </summary>
        private string lastName;

        /// <summary>
        /// Customer company
        /// </summary>
        private string company;

        /// <summary>
        /// Customer address
        /// </summary>
        private string address;

        /// <summary>
        /// Customer city
        /// </summary>
        private string city;

        /// <summary>
        /// Customer state
        /// </summary>
        private string state;

        /// <summary>
        /// Customer zip code
        /// </summary>
        private string zip;

        /// <summary>
        /// Customer country
        /// </summary>
        private string country;

        /// <summary>
        /// Customer phone number
        /// </summary>
        private string phone;

        /// <summary>
        /// Customer fax number
        /// </summary>
        private string fax;

        /// <summary>
        /// Customer email address
        /// </summary>
        private string email;

        /// <summary>
        /// Customer ID
        /// </summary>
        private string customerId;

        /// <summary>
        /// Customer IP address
        /// </summary>
        private string customerIp;

        /// <summary>
        /// CustomerInfo CTor
        /// </summary>
        /// <param name="first_name">Customer first name</param>
        /// <param name="last_name">Customer last name</param>
        /// <param name="company">Customer company</param>
        /// <param name="address">Customer address</param>
        /// <param name="city">Customer city</param>
        /// <param name="state">Customer state</param>
        /// <param name="zip">Customer zipcode</param>
        /// <param name="country">Customer country</param>
        /// <param name="phone">Customer phone</param>
        /// <param name="fax">Customer fax</param>
        /// <param name="email">Customer email</param>
        /// <param name="customer_id">Customer ID</param>
        /// <param name="customer_ip">Customer IP address</param>
        public CustomerInfo(string first_name, string last_name, string company, string address, string city, string state, string zip, string country, string phone, string fax, string email, string customer_id, string customer_ip)
        {
            this.firstName = first_name;
            this.lastName = last_name;
            this.company = company;
            this.address = address;
            this.city = city;
            this.state = state;
            this.zip = zip;
            this.country = country;
            this.phone = phone;
            this.fax = fax;
            this.email = email;
            this.customerId = customer_id;
            this.customerIp = customer_ip;
        }

        /// <summary>
        /// Gets or sets the customer first name
        /// </summary>
        public string X_First_Name
        {
            get { return this.firstName; }
            set { this.firstName = value; }
        }

        /// <summary>
        /// Gets or sets the customer last name
        /// </summary>
        public string X_Last_Name
        {
            get { return this.lastName; }
            set { this.lastName = value; }
        }

        /// <summary>
        /// Gets or sets the company name
        /// </summary>
        public string X_Company
        {
            get { return this.company; }
            set { this.company = value; }
        }

        /// <summary>
        /// Gets or sets the customer address
        /// </summary>
        public string X_Address
        {
            get { return this.address; }
            set { this.address = value; }
        }

        /// <summary>
        /// Gets or sets the customer city
        /// </summary>
        public string X_City
        {
            get { return this.city; }
            set { this.city = value; }
        }

        /// <summary>
        /// Gets or sets the customer state
        /// </summary>
        public string X_State
        {
            get { return this.state; }
            set { this.state = value; }
        }

        /// <summary>
        /// Gets or sets the customer zip code
        /// </summary>
        public string X_Zip
        {
            get { return this.zip; }
            set { this.zip = value; }
        }

        /// <summary>
        /// Gets or sets the customer country
        /// </summary>
        public string X_Country
        {
            get { return this.country; }
            set { this.country = value; }
        }

        /// <summary>
        /// Gets or sets the customer phone number
        /// </summary>
        public string X_Phone
        {
            get { return this.phone; }
            set { this.phone = value; }
        }

        /// <summary>
        /// Gets or sets the customer fax number
        /// </summary>
        public string X_Fax
        {
            get { return this.fax; }
            set { this.fax = value; }
        }

        /// <summary>
        /// Gets or sets the customer email address
        /// </summary>
        public string X_Email
        {
            get { return this.email; }
            set { this.email = value; }
        }

        /// <summary>
        /// Gets or sets the customer ID
        /// </summary>
        public string X_Cust_Id
        {
            get { return this.customerId; }
            set { this.customerId = value; }
        }

        /// <summary>
        /// Gets or sets the customer IP address
        /// </summary>
        public string X_Customer_Ip
        {
            get { return this.customerIp; }
            set { this.customerIp = value; }
        }

        /// <summary>
        /// Builds the POST string for the AuthorizeRequest
        /// </summary>
        /// <returns>see summary</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("&x_first_name=" + this.firstName);
            sb.Append("&x_last_name=" + this.lastName);
            sb.Append("&x_company=" + this.company);
            sb.Append("&x_address=" + this.address);
            sb.Append("&x_city=" + this.city);
            sb.Append("&x_state=" + this.state);
            sb.Append("&x_zip=" + this.zip);
            sb.Append("&x_country=" + this.country);
            sb.Append("&x_phone=" + this.phone);
            sb.Append("&x_fax=" + this.fax);
            sb.Append("&x_email=" + this.email);
            sb.Append("&x_cust_id=" + this.customerId);
            sb.Append("&x_customer_ip=" + this.customerIp);

            return sb.ToString();
        }
    }
}
