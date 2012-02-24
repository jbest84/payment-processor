//-----------------------------------------------------------------------
// <copyright file="AuthorizeURL.cs" company="Mission3, Inc.">
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
    /// Holds URL information
    /// </summary>
    public class AuthorizeURL
    {
        /// <summary>
        /// Test URL to send HTTP POST requests
        /// </summary>
        private static string testUrl = "https://test.authorize.net/gateway/transact.dll";

        /// <summary>
        /// Production URL to send HTTP POST requests
        /// </summary>
        private static string productionUrl = "https://secure.authorize.net/gateway/transact.dll";

        /// <summary>
        /// Gets the TEST URL
        /// </summary>
        public static string TEST_URL
        {
            get { return testUrl; }
        }

        /// <summary>
        /// Gets the PRODUCTION URL
        /// </summary>
        public static string PRODUCTION_URL
        {
            get { return productionUrl; }
        }
    }
}