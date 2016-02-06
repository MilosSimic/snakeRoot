using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetTester
{
    public class InternetException : Exception
    {
        public InternetException(String message)
            : base(message)
        {

        }
    }
}
