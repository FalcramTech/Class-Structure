using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace practic__4
{
    internal class Goods
    {
        public int price;
        public int count;
        public string name;
        public Goods(int priceUserInput, int countUserInput, string nameUserInput)
        {
            this.price = priceUserInput;
            this.count = countUserInput;
            this.name = nameUserInput;
        }
    }
}