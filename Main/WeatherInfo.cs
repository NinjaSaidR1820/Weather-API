using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Main
{
    public class WeatherInfo
    {
        public class coord
        {
           public double lon { get; set; }
            public double lat { get; set; }

        }

        public class weather
        {
            public string main { get; set; }
            public string description { get; set; }
            public string icon { get; set; }

        }
        public class main
        {
            public double temp { get; set; }
            //double feels_like { get; set; }
            //double temp_min { get; set; }
            //double temp_max { get; set; }
            public int preasure { get; set; }
            public int humidity { get; set; }

        }
        public class wind
        {
            public double speed { get; set; }

        }
        public class sys
        {
            public long sunrise { get; set; }
            public long sunset { get; set; }

        }
        public class root
        {
            public coord coord { get; set; }
            public List<weather> weather  { get; set; }
             public main main { get; set; }

            public wind wind { get; set; }  
            public sys sys { get; set; }   
        }


    }
}
