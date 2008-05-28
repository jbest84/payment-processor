//-----------------------------------------------------------------------
// <copyright file="BankTransactionInfo.cs" company="Mission3, Inc.">
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
    /// Bank transaction info for ECHECK transactions.
    /// </summary>
    public class BankTransactionInfo : TransactionInfo
    {
        /// <summary>
        /// TraceSwitch PaymentProcess
        /// </summary>
        private TraceSwitch ts = new TraceSwitch("PaymentProcess", "");

        /// <summary>
        /// ABA code for this bank transactions
        /// </summary>
        private int abaCode = 0;

        /// <summary>
        /// Account number
        /// </summary>
        private int acctNum = 0;
        
        /// <summary>
        /// Account type
        /// </summary>
        private string acctType;

        /// <summary>
        /// Bank name for this transaction
        /// </summary>
        private string bankName;

        /// <summary>
        /// Account name
        /// </summary>
        private string acctName;

        /// <summary>
        /// ECHECK type
        /// </summary>
        private string echeckType;

        // Not used
        ////private string _check_number;

        /// <summary>
        /// BankTransactionInfo CTor
        /// </summary>
        /// <param name="version">API version</param>
        /// <param name="amount">Amount for this transaction</param>
        /// <param name="aba_code">ABA code for this transaction</param>
        /// <param name="acct_num">Account number</param>
        /// <param name="acct_type">Account type</param>
        /// <param name="bank_name">Bank name for this transaction</param>
        /// <param name="acct_name">Account name</param>
        public BankTransactionInfo(string version, decimal amount, int aba_code, int acct_num, string acct_type, string bank_name, string acct_name)
            : base(version, amount, "ECHECK")
        {
            Trace.WriteLineIf(this.ts.TraceInfo, "BankTransactionInfo CTor");
            this.x_recurring_billing = "FALSE";
            this.abaCode = aba_code;
            this.acctNum = acct_num;
            this.echeckType = x_echeck_types.WEB;
            this.acctType = acct_type;
            this.bankName = bank_name;
            this.acctName = acct_name;
        }

        /// <summary>
        /// Gets or sets the aba code
        /// </summary>
        public int X_Bank_Aba_Code
        {
            get { return this.abaCode; }
            set { this.abaCode = value; }
        }

        /// <summary>
        /// Gets or sets the bank account number
        /// </summary>
        public int X_Bank_Acct_Num
        {
            get { return this.acctNum; }
            set { this.acctNum = value; }
        }

        /// <summary>
        /// Gets or sets the echeck type
        /// </summary>
        public string X_Echeck_Type
        {
            get { return this.echeckType; }
            set { this.echeckType = value; }
        }

        /// <summary>
        /// Gets or sets the bank account name
        /// </summary>
        public string X_Bank_Acct_Name
        {
            get { return this.acctName; }
            set { this.acctName = value; }
        }

        /// <summary>
        /// Gets or sets the bank name
        /// </summary>
        public string X_Bank_Name
        {
            get { return this.bankName; }
            set { this.bankName = value; }
        }

        /// <summary>
        /// Gets or sets the bank account type
        /// </summary>
        public string X_Bank_Acct_Type
        {
            get { return this.acctType; }
            set { this.acctType = value; }
        }

        /// <summary>
        /// Returns the POST string for this bank transaction.
        /// </summary>
        /// <returns>See summary</returns>
        public override string ToString()
        {
            Trace.WriteLineIf(this.ts.TraceInfo, "BankTransactionInfo ToString");
            StringBuilder sb = new StringBuilder();
            sb.Append(base.ToString());

            if (this.abaCode > 0)
            {
                sb.Append("&x_bank_aba_code=" + this.abaCode.ToString("000000000"));
            }

            if (this.acctNum > 0)
            {
                sb.Append("&x_bank_acct_num=" + this.acctNum);
            }

            if (!string.IsNullOrEmpty(this.acctType))
            {
                sb.Append("&x_bank_acct_type=" + this.acctType);
            }

            if (!string.IsNullOrEmpty(this.bankName))
            {
                sb.Append("&x_bank_name=" + this.bankName);
            }

            if (!string.IsNullOrEmpty(this.acctName))
            {
                sb.Append("&x_bank_acct_name=" + this.acctName);
            }

            sb.Append("&x_echeck_type=" + x_echeck_types.WEB);

            return sb.ToString();
        }
    }
}
