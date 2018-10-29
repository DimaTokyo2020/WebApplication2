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
    public class Mood
    {
        [StringLength(50)]
        //Now we can enter eny ID we want
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string MoodID { get; set; }
        public ICollection<Song> Songs { get; set; }
    }
}
