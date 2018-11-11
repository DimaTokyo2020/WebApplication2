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


            var songs = new Song[]
       {
            new Song{SongID="kXYiU_JCYtU",SongName="Numb",SingerID="Linkin Park (UCZU9T1ceaOgwfLRq7OKFU4Q)",Genre="Rock",MoodID="Rage"},
            new Song{SongID="eVTXPUF4Oz4",SongName="In The End",SingerID="Linkin Park (UCZU9T1ceaOgwfLRq7OKFU4Q)",Genre="Rock",MoodID="Rage"},
            new Song{SongID="LYU-8IFcDPw",SongName="Faint",SingerID="Linkin Park (UCZU9T1ceaOgwfLRq7OKFU4Q)",Genre="Rock",MoodID="Rage"},
            new Song{SongID="GmHrjFIWl6U",SongName="Corazón",SingerID="Maluma (UClZuKq2m0Qu-HkopkSBLpEw)",Genre="p",MoodID="Party"},
            new Song{SongID="kJQP7kiw5Fk",SongName="Despacito",SingerID="Luis Fonsi (UCxoq-PAQeAdk_zyg8YS0JqA)",Genre="p",MoodID="Chile"},
       };
            foreach (Song c in songs)
            {
                context.Songs.Add(c);
            }
            context.SaveChanges();




            var singers = new Singer[]
   {
            new Singer{SingerID="Luis Fonsi (UCxoq-PAQeAdk_zyg8YS0JqA)",SingerName="Luis Fonsi"},
            new Singer{SingerID="Linkin Park (UCZU9T1ceaOgwfLRq7OKFU4Q)",SingerName="Linkin Park"},
            new Singer{SingerID="Maluma (UClZuKq2m0Qu-HkopkSBLpEw)",SingerName="Maluma"},
   };
            foreach (Singer e in singers)
            {
                context.Singers.Add(e);
            }
            context.SaveChanges();



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
            context.SaveChanges();



            context.Database.EnsureCreated();

         

          


           



           




            
           


           

           
        }
    }
}