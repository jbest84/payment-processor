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
    public abstract class TransactionInfo
    {
        private TraceSwitch ts = new TraceSwitch("PaymentProcess", "");

        //required
        private string _version;
        private decimal _amount = 0;

        //Optional
        private string _method, _recurring_billing, _test_request;
        int _duplicate_window = 120;

        public TransactionInfo(
            string version, decimal amount, string method)
        {
            Trace.WriteLineIf(ts.TraceInfo, "TransactionInfo CTor");
            _version = version;
            _amount = amount;
            if(!String.IsNullOrEmpty(method))
                _method = method;
            else
                _method = "CC";//Default
            _recurring_billing = "FALSE";
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

        public string x_test_request
        {
            get { return _test_request; }
            set { _test_request = value; }
        }

        public int x_duplicate_window
        {
            get { return _duplicate_window; }
            set { _duplicate_window = value; }
        }

        #endregion

        public override string ToString()
        {
            Trace.WriteLineIf(ts.TraceInfo, "TransactionInfo ToString");
            StringBuilder sb = new StringBuilder();
            sb.Append("&x_version=" + _version);
            sb.Append("&x_method=" + _method);
            sb.Append("&x_recurring_billing=" + _recurring_billing);
            sb.Append("&x_amount=" + _amount);

            if (!String.IsNullOrEmpty(_test_request))
                sb.Append("&x_test_request=" + _test_request);
            if (_duplicate_window > 0)
                sb.Append("&x_duplicate_window=" + _duplicate_window);

            return sb.ToString();
        }
    }
}
