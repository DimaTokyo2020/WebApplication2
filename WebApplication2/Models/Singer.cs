using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//Now we can enter eny ID we want
using System.ComponentModel.DataAnnotations.Schema;
//Control the input
using System.ComponentModel.DataAnnotations;


namespace MoodTubeOriginal.Models
{
    public class Singer
    {
        [StringLength(50)]
        //Now we can enter eny ID we want
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string SingerID { get; set; }
        [StringLength(50)]
        public string SingerName { get; set; }
        public ICollection<Song> Songs { get; set; }
    }
}
