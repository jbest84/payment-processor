/*
Copyright (c) 2008 Mission3, INC (jbest@mission3.com)

Permission is hereby granted, free of charge, to any person
obtaining a copy of this software and associated documentation
files (the "Software"), to deal in the Software without
restriction, including without limitation the rights to use,
copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the
Software is furnished to do so, subject to the following
conditions:

The above copyright notice and this permission notice shall be
included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
OTHER DEALINGS IN THE SOFTWARE.
*/

using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentProcess
{
    public class AdditionalShippingInfo
    {
        private StringBuilder sb;

        TaxItem _tax;

        public TaxItem x_tax
        {
            get { return _tax; }
        }

        decimal _tax_amount;

        public decimal x_tax_amount
        {
            get { return _tax_amount; }
        }

        FreightItem _freight;

        public FreightItem x_freight
        {
            get { return _freight; }
        }

        decimal _freight_amount;

        public decimal x_freight_amount
        {
            get { return _freight_amount; }
        }

        DutyItem _duty;

        public DutyItem x_duty
        {
            get { return _duty; }
        }

        decimal _duty_amount;

        public decimal x_duty_amount
        {
            get { return _duty_amount; }
        }

        string _tax_exempt;

        public string x_tax_exempt
        {
            get { return _tax_exempt; }
        }

        string _po_num;

        public string x_po_num
        {
            get { return _po_num; }
        }

        public AdditionalShippingInfo(TaxItem tax, FreightItem freight, DutyItem duty, bool tax_exempt, string po_number)
        {
            _tax = tax;
            _freight = freight;
            _duty = duty;
            _tax_exempt = (tax_exempt == true ? "T" : "F");
            _po_num = po_number;

            //Build return string
            sb = new StringBuilder();
            if(_tax != null)
                sb.Append("&x_tax=" + _tax.ToString());
            if (_freight != null)
                sb.Append("&x_freight=" + _freight.ToString());
            if (_duty != null)
                sb.Append("&x_duty=" + _duty.ToString());
        }

        public AdditionalShippingInfo(decimal tax_amount, decimal freight_amount, decimal duty_amount, bool tax_exempt, string po_number)
        {
            _tax_amount = tax_amount;
            _freight_amount = freight_amount;
            _duty_amount = duty_amount;
            _tax_exempt = (tax_exempt == true ? "T" : "F");
            _po_num = po_number;

            //Build return string
            sb = new StringBuilder();
            if (tax_amount > 0)
                sb.Append("&x_tax=" + _tax_amount);
            if(freight_amount > 0)
                sb.Append("&x_freight=" + _freight_amount);
            if(duty_amount > 0)
                sb.Append("&x_duty=" + _duty_amount);
        }

        public override string ToString()
        {
            //CTor's build the first part of this string
            //finish the remaining two optional fields.
            if(!String.IsNullOrEmpty(_tax_exempt))
                sb.Append("&x_tax_exempt=" + _tax_exempt);
            if(!String.IsNullOrEmpty(_po_num))
                sb.Append("&x_po_num=" + _po_num);

            return sb.ToString();
        }
    }
}
