//-----------------------------------------------------------------------
// <copyright file="XTypes.cs" company="Mission3, Inc.">
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
    /// Transaction types
    /// </summary>
    public class XTypes
    {
        /// <summary>
        /// Auth capture type - Default
        /// </summary>
        private static string authCapture = "AUTH_CAPTURE";

        /// <summary>
        /// Auth only type
        /// </summary>
        private static string authOnly = "AUTH_ONLY";

        /// <summary>
        /// Capture only type
        /// </summary>
        private static string captureOnly = "CAPTURE_ONLY";

        /// <summary>
        /// Credit type
        /// </summary>
        private static string credit = "CREDIT";

        /// <summary>
        /// Prior type
        /// </summary>
        private static string prior = "PRIOR_";

        /// <summary>
        /// Void transaction type
        /// </summary>
        private static string vvoid = "VOID";

        /// <summary>
        /// Gets the auth capture type
        /// </summary>
        public static string AUTH_CAPTURE
        {
            get { return authCapture; }
        }

        /// <summary>
        /// Gets the auth only type
        /// </summary>
        public static string AUTH_ONLY
        {
            get { return authOnly; }
        }

        /// <summary>
        /// Gets the capture only type
        /// </summary>
        public static string CAPTURE_ONLY
        {
            get { return captureOnly; }
        }

        /// <summary>
        /// Gets the credit type
        /// </summary>
        public static string CREDIT
        {
            get { return credit; }
        }

        /// <summary>
        /// Gets the prior type
        /// </summary>
        public static string PRIOR
        {
            get { return prior; }
        }
    }
}