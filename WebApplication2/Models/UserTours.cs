using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MoodTubeOriginal.Models
{
    public class UserTours
    {

        public string ID { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string UserName { get; set; }
        public virtual Singer Singer { get; set; }
        public DateTime When { get; set; }
        //  public ApplicationUser ApplicationUserv { get; set; }
        // public Tour Tourv { get; set; }

    }
}
