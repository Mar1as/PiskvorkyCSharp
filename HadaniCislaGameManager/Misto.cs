using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace HadaniCislaGameManager
{
    internal class Misto
    {
        public string symbol = " ";
        public string Symbol
        {
            get
            {
                return symbol;
            }
            set
            {
                if (obsazeno == false)
                {
                    symbol = value;
                    obsazeno = true;
                }
            }
        }

        public bool obsazeno = false;

    }
}
