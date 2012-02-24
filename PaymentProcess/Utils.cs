//-----------------------------------------------------------------------
// <copyright file="Utils.cs" company="Mission3, Inc.">
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
    /// <summary>
    /// Response code
    /// </summary>
    public enum ResponseCode
    {
        /// <summary>
        /// Approved response
        /// </summary>
        Approved = 1,

        /// <summary>
        /// Declined response
        /// </summary>
        Declined = 2,

        /// <summary>
        /// Error response
        /// </summary>
        Error = 3,

        /// <summary>
        /// Held for review response
        /// </summary>
        HeldForReview = 4,
    }

    /// <summary>
    /// Response reason
    /// </summary>
    public struct ResponseReason
    {
        /// <summary>
        /// Empty indicator
        /// </summary>
        public bool IsEmpty;

        /// <summary>
        /// Response notes
        /// </summary>
        public string Notes;

        /// <summary>
        /// Response code
        /// </summary>
        public int ResponseCode;

        /// <summary>
        /// Response reason code
        /// </summary>
        public int ResponseReasonCode;

        /// <summary>
        /// Response reason text
        /// </summary>
        public string ResponseReasonText;

        /// <summary>
        /// ResponseReason struct CTor
        /// </summary>
        /// <param name="response_code">Response code</param>
        /// <param name="reasonCode">Response reason code</param>
        /// <param name="reasonText">Response reason text</param>
        /// <param name="notes_">Response notes</param>
        public ResponseReason(int response_code, int reasonCode, string reasonText, string notes_)
        {
            ResponseCode = response_code;
            ResponseReasonCode = reasonCode;
            ResponseReasonText = reasonText;
            Notes = notes_;
            IsEmpty = false;
        }

        /// <summary>
        /// ResponseReason struct CTor
        /// </summary>
        /// <param name="empty">Indicates that this response is empty</param>
        public ResponseReason(bool empty)
        {
            ResponseCode = 0;
            ResponseReasonCode = 0;
            ResponseReasonText = null;
            Notes = null;
            IsEmpty = empty;
        }
    }
}