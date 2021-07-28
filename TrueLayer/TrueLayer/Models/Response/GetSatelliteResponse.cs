using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrueLayer.Models.Response
{
    public class GetSatelliteResponse
    {
            public string name { get; set; }
            public int id { get; set; }
            public double latitude { get; set; }
            public double longitude { get; set; }
            public double altitude { get; set; }
            public double velocity { get; set; }
            public string visibility { get; set; }
            public double footprint { get; set; }
            public int timestamp { get; set; }
            public double daynum { get; set; }
            public double solar_lat { get; set; }
            public double solar_lon { get; set; }
            public string units { get; set; }
        

    }
}
