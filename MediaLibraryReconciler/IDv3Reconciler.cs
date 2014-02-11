using MediaLibraryReconciler.Models;
using MediaLibraryReconciler.Processors;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibraryReconciler
{
   public class IDv3Reconciler
   {
      private List<IDv3ReconcilableFile> m_files;
      private readonly string m_libraryPath;
      private readonly IDv3ReconcileProcessor r_processor;
      public IDv3Reconciler(string mediaLibraryPath, IEnumerable<IDv3MistmatchOption> options)
      {
         if (mediaLibraryPath == null)
         {
            throw new ArgumentNullException("mediaLibraryPath");
         }
         if (!File.Exists(mediaLibraryPath) && !Directory.Exists(mediaLibraryPath))
         {
            throw new ArgumentException(
                     string.Format("The path '{0}' does not refer to a file or directory",
                                    mediaLibraryPath));
         }
         if(options == null)
         {
            throw new ArgumentNullException("options");
         }

         m_libraryPath = mediaLibraryPath;
         r_processor = new IDv3ReconcileProcessor(options);
      }

      public void Reconcile()
      {
         m_files = EnumeralFilePaths(m_libraryPath);
         List<IDv3ReconcilePackage> reconciliations = r_processor.Process(m_files);
      }

      private static List<IDv3ReconcilableFile> EnumeralFilePaths(string path)
      {
         if (path == null)
         {
            throw new ArgumentNullException("path");
         }

         List<IDv3ReconcilableFile> ret = new List<IDv3ReconcilableFile>();
         if (File.Exists(path))
         {
            ret.Add(new IDv3ReconcilableFile(path));
         }
         else
         {
            DirectoryInfo dirInfo = new DirectoryInfo(path);
            foreach (FileInfo file in dirInfo.EnumerateFiles("*.mp3", SearchOption.AllDirectories))
            {
               ret.Add(new IDv3ReconcilableFile(file));
            }
         }
         return ret;
      }
   }
}
