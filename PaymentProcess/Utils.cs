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
    public class x_types
    {
        public static string AUTH_CAPTURE = "AUTH_CAPTURE";//default
        public static string AUTH_ONLY = "AUTH_ONLY";
        public static string CAPTURE_ONLY = "CAPTURE_ONLY";
        public static string CREDIT = "CREDIT";
        public static string PRIOR_ = "PRIOR_";
        public static string VOID = "VOID";
    }

    public class x_echeck_types
    {
        /*public static string ARC = "ARC";
        public static string BOC = "BOC";
        public static string CCD = "CCD";
        public static string PPD = "PPD";
        public static string TEL = "TEL";*/
        public static string WEB = "WEB";//We are only going to support this one for now
    }

    public class x_bank_account_types
    {
        public static string CHECKING = "CHECKING";//default
        public static string BUSINESSCHECKING = "BUSINESSCHECKING";
        public static string SAVINGS = "SAVINGS";
    }

    public enum ResponseCode
    {
        Approved = 1,
        Declined = 2,
        Error = 3,
        HeldForReview = 4,
    }

    public struct ResponseReason
	{
        public int responseCode;
        public int responseReasonCode;
        public string responseReasonText;
        public string notes;
        public bool IsEmpty;

        public ResponseReason(int response_code, int reasonCode, string reasonText, string notes_)
        {
            responseCode = response_code;
            responseReasonCode = reasonCode;
            responseReasonText = reasonText;
            notes = notes_;
            IsEmpty = false;
        }

        public ResponseReason(bool empty)
        {
            responseCode = 0;
            responseReasonCode = 0;
            responseReasonText = null;
            notes = null;
            IsEmpty = empty;
        }
	}
}