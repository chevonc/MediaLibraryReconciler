using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibraryReconciler.Models
{
   public class IDv3MismatchOptionHelper
   {
      public static IDv3MistmatchOption ArtistIsEmpty
      {
         get
         {
            return new IDv3MistmatchOption(IDv3MetaMismatchField.Artist, IDv3MetaMismatchCriteria.Empty);
         }
      }
      public static IDv3MistmatchOption AlbumIsEmpty
      {
         get
         {
            return new IDv3MistmatchOption(IDv3MetaMismatchField.Album, IDv3MetaMismatchCriteria.Empty);
         }
      }
      public static IDv3MistmatchOption GenreIsEmpty
      {
         get
         {
            return new IDv3MistmatchOption(IDv3MetaMismatchField.Genre, IDv3MetaMismatchCriteria.Empty);
         }
      }
      public static IDv3MistmatchOption TitleIsEmpty
      {
         get
         {
            return new IDv3MistmatchOption(IDv3MetaMismatchField.Title, IDv3MetaMismatchCriteria.Empty);
         }
      }
      public static IDv3MistmatchOption TitleDoesNotMatchFileName
      {
         get
         {
            return new IDv3MistmatchOption(IDv3MetaMismatchField.Title, IDv3MetaMismatchCriteria.DoesNotMatch, IDv3MetaMismatchField.FileName);
         }
      }
      public static IDv3MistmatchOption AlbumDoesNotMatchFolder
      {
         get
         {
            return new IDv3MistmatchOption(IDv3MetaMismatchField.Album, IDv3MetaMismatchCriteria.DoesNotMatch, IDv3MetaMismatchField.Folder);
         }
      }
      public static IDv3MistmatchOption ArtistDoesNotMatchGrandparentFolder
      {
         get
         {
            return new IDv3MistmatchOption(IDv3MetaMismatchField.Artist, IDv3MetaMismatchCriteria.DoesNotMatch, IDv3MetaMismatchField.GrandparentFolder);
         }
      }
      public static IDv3MistmatchOption TitleContainsLink
      {
         get
         {
            return new IDv3MistmatchOption(IDv3MetaMismatchField.Title, IDv3MetaMismatchCriteria.UrlFormatted);
         }
      }
      public static IDv3MistmatchOption AlbumContainsLink
      {
         get
         {
            return new IDv3MistmatchOption(IDv3MetaMismatchField.Album, IDv3MetaMismatchCriteria.UrlFormatted);
         }
      }
      public static IDv3MistmatchOption ArtistContainsLink
      {
         get
         {
            return new IDv3MistmatchOption(IDv3MetaMismatchField.Artist, IDv3MetaMismatchCriteria.UrlFormatted);
         }
      }
      public static IDv3MistmatchOption ComposerContainsLink
      {
         get
         {
            return new IDv3MistmatchOption(IDv3MetaMismatchField.Composer, IDv3MetaMismatchCriteria.UrlFormatted);
         }
      }
      public static IDv3MistmatchOption GenreContainsLink
      {
         get
         {
            return new IDv3MistmatchOption(IDv3MetaMismatchField.Genre, IDv3MetaMismatchCriteria.UrlFormatted);
         }
      }
      public static IDv3MistmatchOption CommentContainsLink
      {
         get
         {
            return new IDv3MistmatchOption(IDv3MetaMismatchField.Comment, IDv3MetaMismatchCriteria.UrlFormatted);
         }
      }
      public static IDv3MistmatchOption FileIsBlocked
      {
         get
         {
            return new IDv3MistmatchOption(IDv3MetaMismatchField.FileName, IDv3MetaMismatchCriteria.Blocked);
         }
      }
   }
}
