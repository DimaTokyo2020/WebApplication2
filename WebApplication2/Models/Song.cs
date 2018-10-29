using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
//Control the input
using System.ComponentModel.DataAnnotations;


namespace MoodTubeOriginal.Models
{
    public class Song
    {

        [StringLength(50)]
        //Now we can enter eny ID we want
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        [Display(Name = "SongID")]
        public string SongID { get; set; }
        [StringLength(50)]
        [Required]
        [Display(Name = "SongName")]
        public string SongName { get; set; }
        [StringLength(50)]
        public string SingerID { get; set; }
        [StringLength(50)]

        public string MoodID { get; set; }
        [StringLength(50)]
        [Required]
        [Display(Name = "Genre")]
        public string Genre { get; set; }

        public virtual Singer Singer { get; set; }
        public virtual Mood Mood { get; set; }

    }
}
