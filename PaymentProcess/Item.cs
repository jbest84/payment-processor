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
    /// <summary>
    /// Base class for FreightItem, TaxItem, and DutyItem.
    /// </summary>
    public abstract class Item
    {
        private string _itemName;

        public string ItemName
        {
            get { return _itemName; }
            set { _itemName = value; }
        }

        private string _description;

        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }

        private decimal _amount;

        public decimal Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        public Item(string name, string description, decimal amount)
        {
            _itemName = name;
            _description = description;
            _amount = amount;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(_itemName);
            sb.Append("<|>" + _description);
            sb.Append("<|>" + _amount);
            return sb.ToString();
        }
    }
}
