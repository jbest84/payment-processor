//-----------------------------------------------------------------------
// <copyright file="XEcheckTypes.cs" company="Mission3, Inc.">
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
    /// Holds ECHECK types
    /// </summary>
    public class XEcheckTypes
    {
        /*public static string ARC = "ARC";
        public static string BOC = "BOC";
        public static string CCD = "CCD";
        public static string PPD = "PPD";
        public static string TEL = "TEL";*/

        /// <summary>
        /// WEB ECHECK type
        /// </summary>
        private static string web = "WEB"; // We are only going to support this one for now

        /// <summary>
        /// Gets the WEB ECHECK type
        /// </summary>
        public static string WEB
        {
            get { return web; }
        }
    }
}