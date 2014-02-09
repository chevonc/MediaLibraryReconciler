using Mp3Lib;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibraryReconciler.ConsoleTestApp
{
   class Program
   {
      static void Main(string[] args)
      {
         string testSong = Path.Combine(string.Format("{0}\\TestFiles\\SkyJames.mp3", Directory.GetCurrentDirectory()));
         Stopwatch sw = new Stopwatch();
         sw.Restart();
         Mp3File song = new Mp3File(testSong);
         song.TagHandler.Album = "MyAlbum" + DateTime.Now.ToLongTimeString(); ;
         song.Update();
         sw.Stop();
         Console.WriteLine(sw.Elapsed.TotalSeconds);
         Mp3File song1 = new Mp3File(testSong);
         Console.WriteLine(song1.TagHandler.Album);
         Console.ReadKey();
      }
   }
}
