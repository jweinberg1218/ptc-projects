using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GourmetCoffee
{
    public class Coffee : Product
    {
        public string Origin { set; get; }
        public string Roast { set; get; }
        public string Flavor { set; get; }
        public string Aroma { set; get; }
        public string Acidity { set; get; }
        public string Body { set; get; }

        public Coffee()
        {
            Origin = "";
            Roast = "";
            Flavor = "";
            Aroma = "";
            Acidity = "";
            Body = "";
        }

        public override string ToString()
        {
            return Code + "_" + Description + "_" + Price + "_" + Origin + "_" + Roast + "_" + Flavor + "_" + Aroma + "_" + Acidity + "_" + Body;
        }
    }
}
