using MediaLibraryReconciler.Models;
using MediaLibraryReconciler.Interop;
using Mp3Lib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MediaLibraryReconciler.Processors
{
   internal class IDv3ReconcilePredicateFactory
   {

      internal static Func<bool> CreateIsStringEmpty(IDv3ReconcilableFile song, IDv3MetaMismatchField targetField)
      {
         return () =>
         {
            string fieldValue = IDv3MistmatchHelper.GetIDv3MismatchFieldValueAs<string>(song, targetField);
            return string.IsNullOrEmpty(fieldValue);
         };
      }

      internal static Func<bool> CreateIsFileBlocked(IDv3ReconcilableFile song, IDv3MetaMismatchField targetField)
      {
         if (targetField != IDv3MetaMismatchField.FileName)
         {
            throw new InvalidOperationException(string.Format(
               "Cannot unblock field {0}. Only FileName field can be unblocked"
               , targetField));
         }
         return () =>
            {
               return true;
            };
      }

      internal static Func<bool> CreateDoesNotMatch(IDv3ReconcilableFile song, IDv3MetaMismatchField firstField, IDv3MetaMismatchField secondField)
      {
         return () =>
            {

               string firstString = IDv3MistmatchHelper.GetIDv3MismatchFieldValueAs<string>(song, firstField);
               string secondString = IDv3MistmatchHelper.GetIDv3MismatchFieldValueAs<string>(song, secondField);
               int result = string.Compare(firstString, secondString);
               return result == 0;
            };
      }

      internal static Func<bool> CreateIsUrl(IDv3ReconcilableFile song, IDv3MetaMismatchField field)
      {
         return () =>
            {
               string fieldValue = IDv3MistmatchHelper.GetIDv3MismatchFieldValueAs<string>(song, field);
               Regex r = new Regex(@"[((?<Protocol>\w+):\/\/)](?<Domain>[\w@][\w.:@]+)\/?[\w\.?=%&=\-@/$,]*");
               Match matches = r.Match(fieldValue);
               return matches.Success;
            };
      }

   }
}
