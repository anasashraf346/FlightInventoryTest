using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightInventoryTest
{
    class Menu
    {
        public string Header { get; set; }
        public IList<string> Items { get; set; }
        public int ExitValue { get; set; }

        public Menu()
        {
            Items = new List<string>();
        }
    }
}
