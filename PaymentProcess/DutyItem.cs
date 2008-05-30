//-----------------------------------------------------------------------
// <copyright file="DutyItem.cs" company="Mission3, Inc.">
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
    /// Holds duty information
    /// </summary>
    public class DutyItem : Item
    {
        /// <summary>
        /// TraceSwitch PaymentProcess
        /// </summary>
        private TraceSwitch ts = new TraceSwitch("PaymentProcess", "");

        /// <summary>
        /// DutyItem CTor
        /// </summary>
        /// <param name="name">Duty item name</param>
        /// <param name="description">Duty item description</param>
        /// <param name="amount">Duty item amount</param>
        public DutyItem(string name, string description, decimal amount) : base(name, description, amount)
        {
            Trace.WriteLineIf(this.ts.TraceInfo, "DutyItem - CTor (string, string, decimal)");
        }
    }
}
