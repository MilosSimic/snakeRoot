using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Test
{
    public class BLA
    {
        public bool test()
        {
            return XMLSerializer.ListValidator.validateXML("C:\\Users\\Milos\\Desktop\\list.xml");
        }
    }
}
