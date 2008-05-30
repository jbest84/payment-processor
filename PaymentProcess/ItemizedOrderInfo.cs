//-----------------------------------------------------------------------
// <copyright file="ItemizedOrderInfo.cs" company="Mission3, Inc.">
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
    /// Itemized order information
    /// </summary>
    public class ItemizedOrderInfo
    {
        /// <summary>
        /// List of line items
        /// </summary>
        private List<LineItem> lineItems;

        /// <summary>
        /// TraceSwitch PaymentProcess
        /// </summary>
        private TraceSwitch ts = new TraceSwitch("PaymentProcess", "");

        /// <summary>
        /// ItemizedOrderInfo CTor
        /// </summary>
        /// <param name="lineItems">List collection of LineItems</param>
        public ItemizedOrderInfo(List<LineItem> lineItems)
        {
            Trace.WriteLineIf(this.ts.TraceInfo, "ItemizedOrderInfo - CTor (List<LineItem>)");
            this.lineItems = lineItems;
        }

        /// <summary>
        /// Gets or sets a list of line items
        /// </summary>
        public List<LineItem> LineItems
        {
            get { return this.lineItems; }
            set { this.lineItems = value; }
        }

        /// <summary>
        /// Builds the POST string for AuthorizeRequest
        /// </summary>
        /// <returns>Delimited string for HTTP POST</returns>
        public override string ToString()
        {
            Trace.WriteLineIf(this.ts.TraceInfo, "ItemizedOrderInfo - ToString start");

            StringBuilder sb = new StringBuilder();
            foreach (LineItem li in this.lineItems)
            {
                sb.Append("&x_line_item=" + li.ToString());
            }

            Trace.WriteLineIf(this.ts.TraceInfo, "Stringbuilder value to return: " + sb.ToString());
            Trace.WriteLineIf(this.ts.TraceInfo, "ItemizedOrderInfo - ToString end");

            return sb.ToString();
        }
    }
}
