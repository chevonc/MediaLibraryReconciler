using MediaLibraryReconciler.Models;
using Mp3Lib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibraryReconciler.Processors
{
   internal class IDv3MistmatchHelper
   {
      internal static T GetIDv3MismatchFieldValueAs<T>(IDv3ReconcilableFile song, IDv3MetaMismatchField field) where T : class
      {
         object ret = null;
         switch (field)
         {
            case IDv3MetaMismatchField.FileName:
               ret = song.Path;
               break;
            case IDv3MetaMismatchField.Folder:
               ret = Path.GetFileName(Path.GetDirectoryName(song.Path));
               break;
            case IDv3MetaMismatchField.GrandparentFolder:
               string dir = Path.GetDirectoryName(Path.GetDirectoryName(song.Path));
               if (!string.IsNullOrEmpty(dir))
               {
                  ret = Path.GetFileName(dir);
               }
               break;
            case IDv3MetaMismatchField.Title:
               ret = song.TagHandler.Title;
               break;
            case IDv3MetaMismatchField.Artist:
               ret = song.TagHandler.Artist;
               break;
            case IDv3MetaMismatchField.Album:
               ret = song.TagHandler.Album;
               break;
            case IDv3MetaMismatchField.Genre:
               ret = song.TagHandler.Genre;
               break;
            case IDv3MetaMismatchField.Picture:
               ret = song.TagHandler.Picture;
               break;
            default:
               throw new InvalidOperationException(string.Format(
                  "Could not find matching field value for {0}", field));
         }
         return (T)ret;
      }
      internal static void SetIDv3FieldValue(IDv3ReconcilableFile song, IDv3MetaMismatchField targetField, object value)
      {
         switch (targetField)
         {
            case IDv3MetaMismatchField.Title:
               song.TagHandler.Title = (string)value;
               break;
            case IDv3MetaMismatchField.Artist:
               song.TagHandler.Artist = (string)value;
               break;
            case IDv3MetaMismatchField.Album:
               song.TagHandler.Album = (string)value;
               break;
            case IDv3MetaMismatchField.Genre:
               song.TagHandler.Genre = (string)value;
               break;
            case IDv3MetaMismatchField.Composer:
               song.TagHandler.Composer = (string)value;
               break;
            case IDv3MetaMismatchField.Lyrics:
               song.TagHandler.Lyrics = (string)value;
               break;
            case IDv3MetaMismatchField.Comment:
               song.TagHandler.Comment = (string)value;
               break;
            case IDv3MetaMismatchField.Picture:
               break;
            default:
               break;
         }
      }
   }
}
