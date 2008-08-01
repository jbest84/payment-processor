//-----------------------------------------------------------------------
// <copyright file="AdditionalShippingInfo.cs" company="Mission3, Inc.">
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
    /// Additional shipping information for the request.
    /// </summary>
    public class AdditionalShippingInfo : IInfo
    {
        /// <summary>
        /// Stringbuilder for the POST string
        /// </summary>
        private StringBuilder sb;

        /// <summary>
        /// TaxItem information
        /// </summary>
        private TaxItem tax;

        /// <summary>
        /// tax amount
        /// </summary>
        private decimal taxAmount;

        /// <summary>
        /// freight information
        /// </summary>
        private FreightItem freight;

        /// <summary>
        /// freight amount
        /// </summary>
        private decimal freightAmount;

        /// <summary>
        /// duty information
        /// </summary>
        private DutyItem duty;

        /// <summary>
        /// duty amount
        /// </summary>
        private decimal dutyAmount;

        /// <summary>
        /// tax exempt
        /// </summary>
        private string taxExempt;

        /// <summary>
        /// purchase order number
        /// </summary>
        private string purchaseNum;

        /// <summary>
        /// TraceSwitch PaymentProcess
        /// </summary>
        private TraceSwitch ts = new TraceSwitch("PaymentProcess", "");

        /// <summary>
        /// AdditionalShippingInfo Ctor
        /// </summary>
        /// <param name="tax">tax information</param>
        /// <param name="freight">freight information</param>
        /// <param name="duty">duty information</param>
        /// <param name="tax_exempt">tax exempt</param>
        /// <param name="ponumber">purchase order number</param>
        public AdditionalShippingInfo(TaxItem tax, FreightItem freight, DutyItem duty, bool tax_exempt, string ponumber)
        {
            Trace.WriteLineIf(this.ts.TraceInfo, "AdditionalShippingInfo CTor - (TaxItem, FreightItem, DutyItem, bool, string)");
            this.tax = tax;
            this.freight = freight;
            this.duty = duty;
            this.taxExempt = (tax_exempt == true ? "T" : "F");
            this.purchaseNum = ponumber;

            // Build return string
            this.sb = new StringBuilder();
            if (tax != null)
            {
                this.sb.Append("&x_tax=" + tax.ToString());
            }

            if (freight != null)
            {
                this.sb.Append("&x_freight=" + freight.ToString());
            }

            if (duty != null)
            {
                this.sb.Append("&x_duty=" + duty.ToString());
            }
        }

        /// <summary>
        /// AdditionalShippingInfo CTor
        /// </summary>
        /// <param name="tax_amount">tax amount</param>
        /// <param name="freight_amount">freight amount</param>
        /// <param name="duty_amount">duty amount</param>
        /// <param name="tax_exempt">tax exempt</param>
        /// <param name="ponumber">purchase order number</param>
        public AdditionalShippingInfo(decimal tax_amount, decimal freight_amount, decimal duty_amount, bool tax_exempt, string ponumber)
        {
            Trace.WriteLineIf(this.ts.TraceInfo, "AdditionalShippingInfo CTor - (decimal, decimal, decimal, bool, string)");
            this.taxAmount = tax_amount;
            this.freightAmount = freight_amount;
            this.dutyAmount = duty_amount;
            this.taxExempt = (tax_exempt == true ? "T" : "F");
            this.purchaseNum = ponumber;

            // Build return string
            this.sb = new StringBuilder();
            if (tax_amount > 0)
            {
                this.sb.Append("&x_tax=" + tax_amount);
            }

            if (freight_amount > 0)
            {
                this.sb.Append("&x_freight=" + freight_amount);
            }

            if (duty_amount > 0)
            {
                this.sb.Append("&x_duty=" + duty_amount);
            }
        }

        /// <summary>
        /// Gets the tax information held in TaxItem
        /// </summary>
        public TaxItem X_Tax
        {
            get { return this.tax; }
        }

        /// <summary>
        /// Gets the tax amount
        /// </summary>
        public decimal X_Tax_Amount
        {
            get { return this.taxAmount; }
        }

        /// <summary>
        /// Gets the freight information
        /// </summary>
        public FreightItem X_Freight
        {
            get { return this.freight; }
        }

        /// <summary>
        /// Gets the freight amount
        /// </summary>
        public decimal X_Freight_Amount
        {
            get { return this.freightAmount; }
        }

        /// <summary>
        /// Gets the duty information
        /// </summary>
        public DutyItem X_Duty
        {
            get { return this.duty; }
        }

        /// <summary>
        /// Gets the duty amount
        /// </summary>
        public decimal X_Duty_Amount
        {
            get { return this.dutyAmount; }
        }

        /// <summary>
        /// Gets the tax exempt string (T or F)
        /// </summary>
        public string X_Tax_Exempt
        {
            get { return this.taxExempt; }
        }

        /// <summary>
        /// Gets the purchase order number
        /// </summary>
        public string X_PO_Num
        {
            get { return this.purchaseNum; }
        }

        /// <summary>
        /// Returns the POST string for this Info class.
        /// </summary>
        /// <returns>See summary</returns>
        public override string ToString()
        {
            Trace.WriteLineIf(this.ts.TraceInfo, "AdditionalShippingInfo - ToString start");

            // CTor's build the first part of this string
            // finish the remaining two optional fields.
            if (!String.IsNullOrEmpty(this.taxExempt))
            {
                this.sb.Append("&x_tax_exempt=" + this.taxExempt);
            }

            if (!String.IsNullOrEmpty(this.purchaseNum))
            {
                this.sb.Append("&x_po_num=" + this.purchaseNum);
            }

            Trace.WriteLineIf(this.ts.TraceInfo, "\tStringbuilder value to return: " + this.sb.ToString());
            Trace.WriteLineIf(this.ts.TraceInfo, "AdditionalShippingInfo - ToString end");
            return this.sb.ToString();
        }
    }
}
