//-----------------------------------------------------------------------
// <copyright file="OrderInfo.cs" company="Mission3, Inc.">
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
    /// Order information
    /// </summary>
    public class OrderInfo
    {
        /// <summary>
        /// Order invoice number
        /// </summary>
        private string invoiceNum = "";

        /// <summary>
        /// Order description
        /// </summary>
        private string description = "";

        /// <summary>
        /// TraceSwitch PaymentProcess
        /// </summary>
        private TraceSwitch ts = new TraceSwitch("PaymentProcess", "");

        /// <summary>
        /// OrderInfo CTor
        /// </summary>
        /// <param name="invoice_number">Order invoice number</param>
        /// <param name="description">Order description</param>
        public OrderInfo(string invoice_number, string description)
        {
            Trace.WriteLineIf(this.ts.TraceInfo, "OrderInfo - CTor (string, string)");
            this.invoiceNum = invoice_number;
            this.description = description;
        }

        /// <summary>
        /// Gets or sets the order invoice number
        /// </summary>
        public string X_Invoice_Num
        {
            get { return this.invoiceNum; }
            set { this.invoiceNum = value; }
        }

        /// <summary>
        /// Gets or sets the order description
        /// </summary>
        public string X_Description
        {
            get { return this.description; }
            set { this.description = value; }
        }

        /// <summary>
        /// Builds the HTTP POST string for AuthorizeRequest
        /// </summary>
        /// <returns>see summary</returns>
        public override string ToString()
        {
            Trace.WriteLineIf(this.ts.TraceInfo, "OrderInfo - ToString start");

            StringBuilder sb = new StringBuilder();
            sb.Append("&x_invoice_num=" + this.invoiceNum);
            sb.Append("&x_description=" + this.description);

            Trace.WriteLineIf(this.ts.TraceInfo, "Stringbuilder value to return: " + sb.ToString());
            Trace.WriteLineIf(this.ts.TraceInfo, "OrderInfo - ToString end");

            return sb.ToString();
        }
    }
}
