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
using System.Diagnostics;

namespace PaymentProcess
{
    public class CreditTransactionInfo : TransactionInfo
    {
        private TraceSwitch ts = new TraceSwitch("PaymentProcess", "");

        //required
        private string _version, _card_num, _exp_date, _trans_id, __type, _auth_code;
        private decimal _amount = 0;

        //Optional
        private string _method, _recurring_billing, _card_code, _test_request;
        int _duplicate_window = 120;

        public CreditTransactionInfo(
            string version, decimal amount,
            string card_num, string exp_date,
            string trans_id, string _type,
            string auth_code):base(version, amount, "CC")
        {
            Trace.WriteLineIf(ts.TraceInfo, "CreditTransactionInfo CTor");
            _version = version;
            _amount = amount;
            _card_num = card_num;
            _exp_date = exp_date;
            _trans_id = trans_id;//conditional
            __type = _type;
            _auth_code = auth_code;//conditional

            _method = "CC";
            _recurring_billing = "FALSE";
            _card_code = "";
            _test_request = "TRUE";
        }

        #region Properties

        public string x_version
        {
            get { return _version; }
            set { _version = value; }
        }

        public decimal x_amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        public string x_type
        {
            get { return __type; }
            set { __type = value; }
        }

        public string x_method
        {
            get { return _method; }
            set { _method = value; }
        }

        public string x_recurring_billing
        {
            get { return _recurring_billing; }
            set { _recurring_billing = value; }
        }

        public string x_card_num
        {
            get { return _card_num; }
            set { _card_num = value; }
        }

        public string x_exp_date
        {
            get { return _exp_date; }
            set { _exp_date = value; }
        }

        public string x_card_code
        {
            get { return _card_code; }
            set { _card_code = value; }
        }

        public string x_trans_id
        {
            get { return _trans_id; }
            set { _trans_id = value; }
        }

        public string x_auth_code
        {
            get { return _auth_code; }
            set { _auth_code = value; }
        }

        #endregion

        public override string ToString()
        {
            Trace.WriteLineIf(ts.TraceInfo, "CreditTransactionInfo ToString");
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.Append("&x_type=" + __type);
            sb.Append("&x_card_num=" + _card_num);
            sb.Append("&x_exp_date=" + _exp_date);

            if (!String.IsNullOrEmpty(_card_code))
                sb.Append("&x_card_code=" + _card_code);
            if (!String.IsNullOrEmpty(_trans_id))
                sb.Append("&x_trans_id=" + _trans_id);
            if (!String.IsNullOrEmpty(_auth_code))
                sb.Append("&x_auth_code=" + _auth_code);

            return sb.ToString();
        }
    }
}
