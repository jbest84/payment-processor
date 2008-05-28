//-----------------------------------------------------------------------
// <copyright file="TransactionInfo.cs" company="Mission3, Inc.">
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
    /// Base class for transactions
    /// </summary>
    public abstract class TransactionInfo
    {
        /// <summary>
        /// TraceSwitch PaymentProcess
        /// </summary>
        private TraceSwitch ts = new TraceSwitch("PaymentProcess", "");

        /// <summary>
        /// Required API version number
        /// </summary>
        private string version;

        /// <summary>
        /// Required transaction amount
        /// </summary>
        private decimal amount = 0;

        /// <summary>
        /// Transaction method
        /// </summary>
        private string method;

        /// <summary>
        /// Recurring billing
        /// </summary>
        private string recurringBilling;

        /// <summary>
        /// Test request indicator
        /// </summary>
        private string testRequest;

        /// <summary>
        /// Delay time to prevent duplicate transactions
        /// </summary>
        private int duplicateWindow = 120;

        /// <summary>
        /// TransactionInfo CTor
        /// </summary>
        /// <param name="version">API version number</param>
        /// <param name="amount">Transaction amount</param>
        /// <param name="method">Transaction method</param>
        public TransactionInfo(string version, decimal amount, string method)
        {
            Trace.WriteLineIf(this.ts.TraceInfo, "TransactionInfo CTor");
            this.version = version;
            this.amount = amount;

            if (!String.IsNullOrEmpty(method))
            {
                this.method = method;
            }
            else
            {
                this.method = "CC"; // Default
            }
            
            // Default values
            this.recurringBilling = "FALSE";
            this.testRequest = "TRUE";
        }

        /// <summary>
        /// Gets or sets the API version number
        /// </summary>
        public string X_Version
        {
            get { return this.version; }
            set { this.version = value; }
        }

        /// <summary>
        /// Gets or sets the transaction amount
        /// </summary>
        public decimal X_Amount
        {
            get { return this.amount; }
            set { this.amount = value; }
        }

        /// <summary>
        /// Gets or sets the transaction method
        /// </summary>
        public string X_Method
        {
            get { return this.method; }
            set { this.method = value; }
        }

        /// <summary>
        /// Gets or sets recurring billing
        /// </summary>
        public string X_Recurring_Billing
        {
            get { return this.recurringBilling; }
            set { this.recurringBilling = value; }
        }

        /// <summary>
        /// Gets or sets the test request indicator
        /// </summary>
        public string X_Test_Request
        {
            get { return this.testRequest; }
            set { this.testRequest = value; }
        }

        /// <summary>
        /// Gets or sets the duplicate window time
        /// </summary>
        public int X_Duplicate_Window
        {
            get { return this.duplicateWindow; }
            set { this.duplicateWindow = value; }
        }

        /// <summary>
        /// Builds the HTTP POST string for AuthorizeRequest
        /// </summary>
        /// <returns>see summary</returns>
        public override string ToString()
        {
            Trace.WriteLineIf(this.ts.TraceInfo, "TransactionInfo ToString");
            StringBuilder sb = new StringBuilder();
            sb.Append("&x_version=" + this.version);
            sb.Append("&x_method=" + this.method);
            sb.Append("&x_recurring_billing=" + this.recurringBilling);
            sb.Append("&x_amount=" + this.amount);

            if (!String.IsNullOrEmpty(this.testRequest))
            {
                sb.Append("&x_test_request=" + this.testRequest);
            }

            if (this.duplicateWindow > 0)
            {
                sb.Append("&x_duplicate_window=" + this.duplicateWindow);
            }

            return sb.ToString();
        }
    }
}
