using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GourmetCoffee
{
    public class CoffeeBrewer : Product
    {
        public string Model { set; get; }
        public string WaterSupply { set; get; }
        public int NumberOfCups { set; get; }

        public CoffeeBrewer()
        {
            Model = "";
            WaterSupply = "";
            NumberOfCups = 0;
        }

        public override string ToString()
        {
            return Code + "_" + Description + "_" + Price + "_" + Model + "_" + WaterSupply + "_" + NumberOfCups;
        }
    }
}
