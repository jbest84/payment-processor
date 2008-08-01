//-----------------------------------------------------------------------
// <copyright file="LineItem.cs" company="Mission3, Inc.">
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
    /// Line item information
    /// </summary>
    public class LineItem : IInfo
    {
        /// <summary>
        /// Line item ID
        /// </summary>
        private string itemId;

        /// <summary>
        /// Line item name
        /// </summary>
        private string itemName;

        /// <summary>
        /// Line item description
        /// </summary>
        private string itemDesc;

        /// <summary>
        /// Line item quantity
        /// </summary>
        private decimal quantity;

        /// <summary>
        /// Line item price
        /// </summary>
        private decimal itemPrice;

        /// <summary>
        /// Line item taxable
        /// </summary>
        private string taxable;

        /// <summary>
        /// TraceSwitch PaymentProcess
        /// </summary>
        private TraceSwitch ts = new TraceSwitch("PaymentProcess", "");

        /// <summary>
        /// LineItem CTor
        /// </summary>
        /// <param name="itemId">line item ID</param>
        /// <param name="itemName">line item name</param>
        /// <param name="itemDesc">line item description</param>
        /// <param name="quantity">line item quantity</param>
        /// <param name="itemPrice">line item price</param>
        /// <param name="taxable">line item taxable</param>
        public LineItem(string itemId, string itemName, string itemDesc, decimal quantity, decimal itemPrice, bool taxable)
        {
            Trace.WriteLineIf(this.ts.TraceInfo, "LineItem - CTor (string, string, string, decimal, decimal, bool)");
            this.itemId = itemId;
            this.itemName = itemName;
            this.itemDesc = itemDesc;
            this.quantity = quantity;
            this.itemPrice = itemPrice;
            this.taxable = (taxable == true ? "T" : "F");
        }

        /// <summary>
        /// Gets or sets the line item ID
        /// </summary>
        public string ItemId
        {
            get { return this.itemId; }
            set { this.itemId = value; }
        }

        /// <summary>
        /// Gets or sets the line item name
        /// </summary>
        public string ItemName
        {
            get { return this.itemName; }
            set { this.itemName = value; }
        }

        /// <summary>
        /// Gets or sets the line item description
        /// </summary>
        public string ItemDesc
        {
            get { return this.itemDesc; }
            set { this.itemDesc = value; }
        }

        /// <summary>
        /// Gets or sets the line item quantity
        /// </summary>
        public decimal Quantity
        {
            get { return this.quantity; }
            set { this.quantity = value; }
        }

        /// <summary>
        /// Gets or sets the line item price
        /// </summary>
        public decimal ItemPrice
        {
            get { return this.itemPrice; }
            set { this.itemPrice = value; }
        }

        /// <summary>
        /// Gets or sets taxable for this line item
        /// </summary>
        public string Taxable
        {
            get { return this.taxable; }
            set { this.taxable = value; }
        }

        /// <summary>
        /// Builds the POST string for AuthorizeRequest
        /// </summary>
        /// <returns>Delimited string for HTTP POST</returns>
        public override string ToString()
        {
            Trace.WriteLineIf(this.ts.TraceInfo, "LineItem - ToString start");

            StringBuilder sb = new StringBuilder();
            sb.Append("&x_line_item=" + this.itemId);
            sb.Append("<|>" + this.itemName);
            sb.Append("<|>" + this.itemDesc);
            sb.Append("<|>" + this.quantity);
            sb.Append("<|>" + this.itemPrice);
            sb.Append("<|>" + this.taxable);

            Trace.WriteLineIf(this.ts.TraceInfo, "Stringbuilder value to return: " + sb.ToString());
            Trace.WriteLineIf(this.ts.TraceInfo, "LineItem - ToString end");

            return sb.ToString();
        }
    }
}