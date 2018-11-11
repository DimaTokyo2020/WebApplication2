using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoodTubeOriginal.Models
{
    public class SongTour
    {
        //Song
        public string ID { get; set; }
        public string SongName { get; set; }
        public string MoodID { get; set; }
        public string Genre { get; set; }
        //Tour
        public string Country { get; set; }
        public string City { get; set; }
        public DateTime When { get; set; }


    }
}
