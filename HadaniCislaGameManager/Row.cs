using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HadaniCislaGameManager
{
    internal class Row
    {
        public List<Misto> misto = new List<Misto>();

        public Row()
        {
            for (int i = 0; i < 3; i++)
            {
                misto.Add(new Misto());
                Console.WriteLine(i + "Addesd");
            }
        }
    }
}
