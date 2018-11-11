using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MoodTubeOriginal.Models;

namespace MoodTubeOriginal.Data
{
    public static class DbInitializer
    {
        public static void Initialize(MusicContext context)
        {



            var moods = new Mood[]
       {
            new Mood{MoodID="Party"},
            new Mood{MoodID="Chile"},
            new Mood{MoodID="Rage"},
       };
            foreach (Mood s in moods)
            {
                context.Moods.Add(s);
            }


            var singers = new Singer[]
   {
            new Singer{SingerID="Linkin Park (UCZU9T1ceaOgwfLRq7OKFU4Q)",SingerName="Linkin Park"},
            new Singer{SingerID="Maluma (UClZuKq2m0Qu-HkopkSBLpEw)",SingerName="Maluma"},
            new Singer{SingerID="Luis Fonsi (UCxoq-PAQeAdk_zyg8YS0JqA)",SingerName="Luis Fonsi"},
            new Singer{SingerID="Bob Marley (UCd4zMyGp0chVzcmDTFEViIg)",SingerName="Bob Marley"},
            new Singer{SingerID="John Lennon (UCM8OS-PD-qkeX3cUD_XIN6Q)",SingerName="John Lennon"},
            new Singer{SingerID="The Beatles (UCAJjBvS4BvcbIqXKnXnRcYQ)",SingerName="The Beatles"},
            new Singer{SingerID="Norah Jones (UCBJtGODWGrM3fdQ0G5E9uAQ)",SingerName="Norah Jones"},
            new Singer{SingerID="Ed Sheeran (UC0C-w0YjGpqDXGB8IHb662A)",SingerName="Ed Sheeran"},
            new Singer{SingerID="Avicii (UCPHjpfnnGklkRBBTd0k6aHg)",SingerName="Avicii"},
            new Singer{SingerID="Nirvana (UCFMZHIQMgBXTSxsr86Caazw)",SingerName="Nirvana"},
            new Singer{SingerID="Rage Against The Machine(UCFcytuxeGAHyM67L)",SingerName="Rage Against The Machine"},
   };
            foreach (Singer e in singers)
            {
                context.Singers.Add(e);
            }


            var tours = new Tour[]
   {
            new Tour{TourID="hghh",Country="Russia",City="Moscow",SingerID="Linkin Park (UCZU9T1ceaOgwfLRq7OKFU4Q)",Latitude="yhy",Longitude="hyhy",When=new DateTime(2019, 5, 1, 22, 30, 00) },
            new Tour{TourID="hddddh",Country="Israel",City="Tel Aviv",SingerID="Linkin Park (UCZU9T1ceaOgwfLRq7OKFU4Q)",Latitude="hyh",Longitude="hyh",When=new DateTime(2019, 5, 1, 22, 30, 00) },
            new Tour{TourID="hgdvdv",Country="America",City="New York",SingerID="Linkin Park (UCZU9T1ceaOgwfLRq7OKFU4Q)",Latitude="hyh",Longitude="hyhy",When=new DateTime(2019, 5, 1, 22, 30, 00) },
   }; 
            foreach (Tour e in tours)
            {
                context.Tours.Add(e);
            }



            var songs = new Song[]
       {
            new Song{SongID="kXYiU_JCYtU",SongName="Numb",SingerID="Linkin Park (UCZU9T1ceaOgwfLRq7OKFU4Q)",Genre="Rock",MoodID="Rage"},
            new Song{SongID="eVTXPUF4Oz4",SongName="In The End",SingerID="Linkin Park (UCZU9T1ceaOgwfLRq7OKFU4Q)",Genre="Rock",MoodID="Rage"},
            new Song{SongID="LYU-8IFcDPw",SongName="Faint",SingerID="Linkin Park (UCZU9T1ceaOgwfLRq7OKFU4Q)",Genre="Rock",MoodID="Rage"},
            new Song{SongID="GmHrjFIWl6U",SongName="Corazón",SingerID="Maluma (UClZuKq2m0Qu-HkopkSBLpEw)",Genre="p",MoodID="Party"},
            new Song{SongID="kJQP7kiw5Fk",SongName="Despacito",SingerID="Luis Fonsi (UCxoq-PAQeAdk_zyg8YS0JqA)",Genre="p",MoodID="Chile"},
             new Song{SongID="LanCLS_hIo4",SongName="Three Little Birds",SingerID="Bob Marley (UCd4zMyGp0chVzcmDTFEViIg)",Genre="reggae",MoodID="Chill"},
            new Song{SongID="VOgFZfRVaww",SongName="Imagine",SingerID="John Lennon (UCM8OS-PD-qkeX3cUD_XIN6Q)",Genre="Rock",MoodID="Chill"},
            new Song{SongID="U_O1QKQCsGs",SongName="Here comes the Sun",SingerID="The Beatles (UCAJjBvS4BvcbIqXKnXnRcYQ)",Genre="Rock",MoodID="Chill"},
            new Song{SongID="tO4dxvguQDk",SongName="Don't Know Why",SingerID="Norah Jones (UCBJtGODWGrM3fdQ0G5E9uAQ)",Genre="Slow",MoodID="Chill"},
            new Song{SongID="JGwWNGJdvx8",SongName="Shape of You",SingerID="Ed Sheeran (UC0C-w0YjGpqDXGB8IHb662A)",Genre="Dance",MoodID="Party"},
            new Song{SongID="_ovdm2yX4MA",SongName="Levels",SingerID="Avicii (UCPHjpfnnGklkRBBTd0k6aHg)",Genre="Dance",MoodID="Party"},
            new Song{SongID="hTWKbfoikeg",SongName="Smells Like Teen Spirit",SingerID="Nirvana (UCFMZHIQMgBXTSxsr86Caazw)",Genre="Rock",MoodID="Rage"},
            new Song{SongID="bWXazVhlyxQ",SongName="Killing In the Name",SingerID="Rage Against The Machine (UCFcytuxeGAHyM67L_nHDTIA)",Genre="Rock",MoodID="Rage"},
       };
            foreach (Song c in songs)
            {
                context.Songs.Add(c);
            }
            context.SaveChanges();




         



         



            context.Database.EnsureCreated();

         

          


           



           




            
           


           

           
        }
    }
}