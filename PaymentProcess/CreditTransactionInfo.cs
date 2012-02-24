//-----------------------------------------------------------------------
// <copyright file="CreditTransactionInfo.cs" company="Mission3, Inc.">
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

using System;
using System.Diagnostics;
using System.Text;

namespace PaymentProcess
{
    /// <summary>
    /// Holds credit card transaction information
    /// </summary>
    public class CreditTransactionInfo : TransactionInfo, IInfo
    {
        /// <summary>
        /// TraceSwitch PaymentProcess
        /// </summary>
        private readonly TraceSwitch ts = new TraceSwitch("PaymentProcess", "");

        #region Required

        /// <summary>
        /// Transaction amount
        /// </summary>
        private decimal amount;

        /// <summary>
        /// Authorization code
        /// </summary>
        private string authCode;

        /// <summary>
        /// Credit card number
        /// </summary>
        private string cardNum;

        /// <summary>
        /// Credit card expiration date
        /// </summary>
        private string expDate;

        /// <summary>
        /// Transaction ID
        /// </summary>
        private string transId;

        /// <summary>
        /// Transaction type
        /// </summary>
        private string ttype;

        /// <summary>
        /// API version
        /// </summary>
        private string version;

        #endregion

        #region Optional

        /// <summary>
        /// Credit card code
        /// </summary>
        private string cardCode;

        /// <summary>
        /// Dupiclate window
        /// </summary>
        private int duplicateWindow = 120;

        /// <summary>
        /// Transaction method
        /// </summary>
        private string method;

        /// <summary>
        /// Recurring billing
        /// </summary>
        private string recurringBilling;

        /// <summary>
        /// Test request
        /// </summary>
        private string testRequest;

        #endregion

        /// <summary>
        /// CreditTransactionInfo CTor
        /// </summary>
        /// <param name="version">API version</param>
        /// <param name="amount">amount for this transaction</param>
        /// <param name="card_num">credit card number</param>
        /// <param name="exp_date">credit card expiration date</param>
        /// <param name="trans_id">transaction id</param>
        /// <param name="ttype">transaction type</param>
        /// <param name="auth_code">authorization code</param>
        public CreditTransactionInfo(string version, decimal amount, string card_num, string exp_date, string trans_id,
                                     string ttype, string auth_code) : base(version, amount, "CC")
        {
            Trace.WriteLineIf(ts.TraceInfo,
                              "CreditTransactionInfo CTor (string, decimal, string, string, string, string)");
            this.version = version;
            this.amount = amount;
            cardNum = card_num;
            expDate = exp_date;

            // Conditional
            transId = trans_id;
            this.ttype = ttype;

            // Conditional
            authCode = auth_code;

            method = "CC";
            recurringBilling = "FALSE";
            cardCode = "";
            testRequest = "TRUE";
        }

        #region Properties

        /// <summary>
        /// Gets or sets the API version number
        /// </summary>
        public string X_Version
        {
            get { return version; }
            set { version = value; }
        }

        /// <summary>
        /// Gets or sets the transaction amount
        /// </summary>
        public decimal X_Amount
        {
            get { return amount; }
            set { amount = value; }
        }

        /// <summary>
        /// Gets or sets the transaction type
        /// </summary>
        public string X_Type
        {
            get { return ttype; }
            set { ttype = value; }
        }

        /// <summary>
        /// Gets or sets the method
        /// </summary>
        public string X_Method
        {
            get { return method; }
            set { method = value; }
        }

        /// <summary>
        /// Gets or sets recurring billing
        /// </summary>
        public string X_Recurring_Billing
        {
            get { return recurringBilling; }
            set { recurringBilling = value; }
        }

        /// <summary>
        /// Gets or sets credit card number
        /// </summary>
        public string X_Card_Num
        {
            get { return cardNum; }
            set { cardNum = value; }
        }

        /// <summary>
        /// Gets or sets expiration date
        /// </summary>
        public string X_Exp_Date
        {
            get { return expDate; }
            set { expDate = value; }
        }

        /// <summary>
        /// Gets or sets card code
        /// </summary>
        public string X_Card_Code
        {
            get { return cardCode; }
            set { cardCode = value; }
        }

        /// <summary>
        /// Gets or sets transaction ID
        /// </summary>
        public string X_Trans_Id
        {
            get { return transId; }
            set { transId = value; }
        }

        /// <summary>
        /// Gets or sets authorization code
        /// </summary>
        public string X_Auth_Code
        {
            get { return authCode; }
            set { authCode = value; }
        }

        #endregion

        #region IInfo Members

        /// <summary>
        /// Builds the POST string for the AuthorizeRequest
        /// </summary>
        /// <returns>see summary</returns>
        public override string ToString()
        {
            Trace.WriteLineIf(ts.TraceInfo, "CreditTransactionInfo - ToString start");

            var sb = new StringBuilder();
            sb.Append(base.ToString());
            sb.Append("&x_type=" + ttype);
            sb.Append("&x_card_num=" + cardNum);
            sb.Append("&x_exp_date=" + expDate);

            if (!String.IsNullOrEmpty(cardCode))
            {
                sb.Append("&x_card_code=" + cardCode);
            }

            if (!String.IsNullOrEmpty(transId))
            {
                sb.Append("&x_trans_id=" + transId);
            }

            if (!String.IsNullOrEmpty(authCode))
            {
                sb.Append("&x_auth_code=" + authCode);
            }

            Trace.WriteLineIf(ts.TraceInfo, "\tStringbuilder value to return: " + sb);
            Trace.WriteLineIf(ts.TraceInfo, "CreditTransactionInfo - ToString end");

            return sb.ToString();
        }

        #endregion
    }
}