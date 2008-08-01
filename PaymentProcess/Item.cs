//-----------------------------------------------------------------------
// <copyright file="Item.cs" company="Mission3, Inc.">
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
    /// Base class for FreightItem, TaxItem, and DutyItem.
    /// </summary>
    public abstract class Item : IInfo
    {
        /// <summary>
        /// Item name information
        /// </summary>
        private string itemName;

        /// <summary>
        /// Item description information
        /// </summary>
        private string description;

        /// <summary>
        /// Item amount information
        /// </summary>
        private decimal amount;

        /// <summary>
        /// TraceSwitch PaymentProcess
        /// </summary>
        private TraceSwitch ts = new TraceSwitch("PaymentProcess", "");

        /// <summary>
        /// Item constructor (CTor)
        /// </summary>
        /// <param name="name">Item name information</param>
        /// <param name="description">Item description information</param>
        /// <param name="amount">Item amount information</param>
        public Item(string name, string description, decimal amount)
        {
            Trace.WriteLineIf(this.ts.TraceInfo, "Item - CTor (string, string, decimal)");
            this.itemName = name;
            this.description = description;
            this.amount = amount;
        }

        /// <summary>
        /// Gets or sets the item name
        /// </summary>
        public string ItemName
        {
            get { return this.itemName; }
            set { this.itemName = value; }
        }

        /// <summary>
        /// Gets or sets the item description
        /// </summary>
        public string Description
        {
            get { return this.description; }
            set { this.description = value; }
        }

        /// <summary>
        /// Gets or sets the item amount
        /// </summary>
        public decimal Amount
        {
            get { return this.amount; }
            set { this.amount = value; }
        }

        /// <summary>
        /// Builds the Item POST string
        /// </summary>
        /// <returns>Delimited string for HTTP POST</returns>
        public override string ToString()
        {
            Trace.WriteLineIf(this.ts.TraceInfo, "Item - ToString start");

            StringBuilder sb = new StringBuilder();
            sb.Append(this.itemName);
            sb.Append("<|>" + this.description);
            sb.Append("<|>" + this.amount);

            Trace.WriteLineIf(this.ts.TraceInfo, "Stringbuilder value to return: " + sb.ToString());
            Trace.WriteLineIf(this.ts.TraceInfo, "Item - ToString end");

            return sb.ToString();
        }
    }
}
