using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibraryReconciler.Flags
{
   enum MP3MetaMismatchOption
   {
      FileName,
      Folder,
      GrandparentFolder,
      FileZoneIdentifier,
      Title,
      Artist,
      Album,
      Genre,
      Picture
   }

   enum MP3MetaMismatchReason
   {
      Empty,
      DoesNotMatch,
      Blocked,
      UrlFormatted,
   }
}
