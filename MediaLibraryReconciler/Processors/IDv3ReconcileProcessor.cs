using MediaLibraryReconciler.Interop;
using MediaLibraryReconciler.Models;
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
   class IDv3ReconcileProcessor
   {
      private readonly List<IDv3ReconilePackage> r_results = new List<IDv3ReconilePackage>();

      public IDv3ReconcileProcessor()
      { }
      public void Process(IDv3ReconcilableFile file)
      {

      }

      //Processors

      private static Func<bool> GetMismatchPredicate(IDv3ReconcilableFile song, IDv3MistmatchOptions option)
      {
         switch (option.Reason)
         {
            case IDv3MetaMismatchReason.Empty:
               return IDv3ReconcilePredicateFactory.CreateIsStringEmpty(song, option.TargetField);
            case IDv3MetaMismatchReason.Blocked:
               return IDv3ReconcilePredicateFactory.CreateIsFileBlocked(song, option.TargetField);
            case IDv3MetaMismatchReason.UrlFormatted:
               return IDv3ReconcilePredicateFactory.CreateIsUrl(song, option.TargetField);
            case IDv3MetaMismatchReason.DoesNotMatch:
               return IDv3ReconcilePredicateFactory.CreateDoesNotMatch(song, option.TargetField, option.ComparisonField);
            default:
               throw new InvalidOperationException(
                 string.Format("Cannot generate preidcate for criteria {0}", option.Reason));
         }
      }

      private static IDv3ReconcileAction GetReconcileAction(IDv3ReconcilableFile song, IDv3MistmatchOptions option)
      {
         switch (option.Reason)
         {
            case IDv3MetaMismatchReason.Empty:
               return IDv3ReconilerActionFactory.CreateFixEmptyField(song, option);
            case IDv3MetaMismatchReason.DoesNotMatch:
               return IDv3ReconilerActionFactory.CreateUpdateFieldToMatch(song, option);
            case IDv3MetaMismatchReason.Blocked:
               return IDv3ReconilerActionFactory.CreateUnblockFile(song, option);
            case IDv3MetaMismatchReason.UrlFormatted:
               return IDv3ReconilerActionFactory.CreateFixUrlField(song, option);
            default:
               throw new InvalidOperationException("Could not find Reconile action");
         }
      }
   }
}
