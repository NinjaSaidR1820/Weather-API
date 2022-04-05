using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main.WheatherInformation
{
    public class root
    {
        public Coord coord { get; set; }
        public List<Weather> weather { get; set; }
        public main main { get; set; }

        public wind wind { get; set; }
        public sys sys { get; set; }
    }
}
