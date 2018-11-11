using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoodTubeOriginal.Models
{
    public class Tour
    {
        public string TourID { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string SingerID { get; set; }
        public int Latitude { get; set; }
        public int Longitude { get; set; }

        public DateTime When { get; set; }
        public virtual Singer Singer { get; set; }



    }
}
