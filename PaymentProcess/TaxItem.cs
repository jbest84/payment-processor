//-----------------------------------------------------------------------
// <copyright file="TaxItem.cs" company="Mission3, Inc.">
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

namespace PaymentProcess
{
    /// <summary>
    /// Tax item information
    /// </summary>
    public class TaxItem : Item
    {
        /// <summary>
        /// TraceSwitch PaymentProcess
        /// </summary>
        private readonly TraceSwitch ts = new TraceSwitch("PaymentProcess", "");

        /// <summary>
        /// TaxItem CTor
        /// </summary>
        /// <param name="name">Tax item name</param>
        /// <param name="description">Tax item description</param>
        /// <param name="amount">Tax item amount</param>
        public TaxItem(string name, string description, decimal amount) : base(name, description, amount)
        {
            Trace.WriteLineIf(ts.TraceInfo, "TaxeItem - CTor (string, string, decimal)");
        }
    }
}