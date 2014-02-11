using MediaLibraryReconciler.Models;
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
      private static List<IDv3MistmatchOption> GetOptions()
      {
         return new List<IDv3MistmatchOption>()
         {
            IDv3MismatchOptionHelper.ArtistIsEmpty,
            IDv3MismatchOptionHelper.AlbumIsEmpty,
            IDv3MismatchOptionHelper.GenreIsEmpty,
            IDv3MismatchOptionHelper.TitleIsEmpty,
            IDv3MismatchOptionHelper.AlbumContainsLink,
            IDv3MismatchOptionHelper.ArtistContainsLink,
            IDv3MismatchOptionHelper.CommentContainsLink,
            IDv3MismatchOptionHelper.ComposerContainsLink,
            IDv3MismatchOptionHelper.AlbumDoesNotMatchFolder,
            IDv3MismatchOptionHelper.ArtistDoesNotMatchGrandparentFolder,
            IDv3MismatchOptionHelper.TitleDoesNotMatchFileName,
            IDv3MismatchOptionHelper.FileIsBlocked,
         };
      }
      static void Main(string[] args)
      {
         string testSong = Path.Combine(string.Format("{0}\\TestFiles\\", Directory.GetCurrentDirectory()));
         Stopwatch sw = new Stopwatch();
         IDv3Reconciler reconciler = new IDv3Reconciler(testSong, GetOptions());
         reconciler.Reconcile();
         Console.ReadKey();
      }
   }
}
