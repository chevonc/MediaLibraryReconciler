using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibraryReconciler.Models
{
   public enum IDv3MetaMismatchField
   {
      None,
      FileName,
      Folder,
      GrandparentFolder,
      FileZoneIdentifier,
      Title,
      Artist,
      Album,
      Genre,
      Composer,
      Lyrics,
      Comment,
      Picture
   }
}
