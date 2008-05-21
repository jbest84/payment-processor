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
    public class BankTransactionInfo : TransactionInfo
    {
        private TraceSwitch ts = new TraceSwitch("PaymentProcess", "");

        int _aba_code = 0;

        public int x_bank_aba_code
        {
            get { return _aba_code; }
            set { _aba_code = value; }
        }

        int _acct_num = 0;

        public int x_bank_acct_num
        {
            get { return _acct_num; }
            set { _acct_num = value; }
        }

        private string _acct_type, _name, _acct_name, _echeck_type, _check_number;//check number will not be used

        public string x_echeck_type
        {
            get { return _echeck_type; }
            set { _echeck_type = value; }
        }

        public string x_bank_acct_name
        {
            get { return _acct_name; }
            set { _acct_name = value; }
        }

        public string x_bank_name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string x_bank_acct_type
        {
            get { return _acct_type; }
            set { _acct_type = value; }
        }

        public BankTransactionInfo(string version, decimal amount, int aba_code, int acct_num, string acct_type, string bank_name, string acct_name)
            : base(version, amount, "ECHECK")
        {
            Trace.WriteLineIf(ts.TraceInfo, "BankTransactionInfo CTor");
            base.x_recurring_billing = "FALSE";
            _aba_code = aba_code;
            _acct_num = acct_num;
            _echeck_type = x_echeck_types.WEB;
            _acct_type = acct_type;
            _name = bank_name;
            _acct_name = acct_name;
        }

        public override string ToString()
        {
            Trace.WriteLineIf(ts.TraceInfo, "BankTransactionInfo ToString");
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());

            if (_aba_code > 0)
                sb.Append("&x_bank_aba_code=" + _aba_code.ToString("000000000"));

            if (_acct_num > 0)
                sb.Append("&x_bank_acct_num=" + _acct_num);

            if (!string.IsNullOrEmpty(_acct_type))
                sb.Append("&x_bank_acct_type=" + _acct_type);

            if (!string.IsNullOrEmpty(_name))
                sb.Append("&x_bank_name=" + _name);

            if (!string.IsNullOrEmpty(_acct_name))
                sb.Append("&x_bank_acct_name=" + _acct_name);

            sb.Append("&x_echeck_type=" + x_echeck_types.WEB);

            
            return sb.ToString();
        }
    }
}
