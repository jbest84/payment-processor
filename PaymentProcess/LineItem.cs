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

namespace PaymentProcess
{
    public class LineItem
    {
        private string _itemId;

        public string ItemId
        {
            get { return _itemId; }
            set { _itemId = value; }
        }

        private string _itemName;

        public string ItemName
        {
            get { return _itemName; }
            set { _itemName = value; }
        }

        private string _itemDesc;

        public string ItemDesc
        {
            get { return _itemDesc; }
            set { _itemDesc = value; }
        }

        private decimal _quantity;

        public decimal Quantity
        {
            get { return _quantity; }
            set { _quantity = value; }
        }

        private decimal _itemPrice;

        public decimal ItemPrice
        {
            get { return _itemPrice; }
            set { _itemPrice = value; }
        }

        private string _taxable;

        public string Taxable
        {
            get { return _taxable; }
            set { _taxable = value; }
        }

        public LineItem(string itemId, string itemName, string itemDesc, decimal quantity, decimal itemPrice, bool taxable)
        {
            _itemId = itemId;
            _itemName = itemName;
            _itemDesc = itemDesc;
            _quantity = quantity;
            _itemPrice = itemPrice;
            _taxable = (taxable == true ? "T" : "F");
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("&x_line_item=" + _itemId);
            sb.Append("<|>" + _itemName);
            sb.Append("<|>" + _itemDesc);
            sb.Append("<|>" + _quantity);
            sb.Append("<|>" + _itemPrice);
            sb.Append("<|>" + _taxable);
            return sb.ToString();
        }
    }
}
