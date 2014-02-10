using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibraryReconciler.Interop
{
   class DownloadedFileUnblocker
   {
      [DllImport("kernel32", CharSet=CharSet.Unicode, SetLastError=true)]
      [return: MarshalAs(UnmanagedType.Bool)]
      private static extern bool DeleteFile(string filePath);

      public static bool UnblockFile(string filePath)
      {
         if(!File.Exists(filePath))
         {
            return false;
         }
        return DeleteFile(string.Format("{0}:Zone.Identifier", filePath));

      }
   }
}
