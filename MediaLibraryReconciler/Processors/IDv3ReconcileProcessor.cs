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
      private readonly List<IDv3MistmatchOption> r_options;

      public IDv3ReconcileProcessor(IEnumerable<IDv3MistmatchOption> options)
      {
         if(options == null)
         {
            throw new ArgumentNullException("options");
         }

         r_options = new List<IDv3MistmatchOption>(options);
      }

      public List<IDv3ReconcilePackage> Process(IEnumerable<IDv3ReconcilableFile> files)
      {
         if (files == null)
         {
            throw new ArgumentNullException("file");
         }
         List<IDv3ReconcilePackage> ret = new List<IDv3ReconcilePackage>();
         foreach (IDv3ReconcilableFile file in files)
         {
            foreach (IDv3MistmatchOption option in Options)
            {
               ret.Add(new IDv3ReconcilePackage(
                  option, 
                  GetReconcilePredicate(file, option), 
                  GetReconcileAction(file, option)));
            }
         }
         return ret;
      }

      public List<IDv3MistmatchOption> Options
      {
         get
         {
            return r_options;
         }
      }

      private static Func<bool> GetReconcilePredicate(IDv3ReconcilableFile song, IDv3MistmatchOption option)
      {
         switch (option.Criteria)
         {
            case IDv3MetaMismatchCriteria.Empty:
               return IDv3ReconcilePredicateFactory.CreateIsStringEmpty(song, option.TargetField);
            case IDv3MetaMismatchCriteria.Blocked:
               return IDv3ReconcilePredicateFactory.CreateIsFileBlocked(song, option.TargetField);
            case IDv3MetaMismatchCriteria.UrlFormatted:
               return IDv3ReconcilePredicateFactory.CreateIsUrl(song, option.TargetField);
            case IDv3MetaMismatchCriteria.DoesNotMatch:
               return IDv3ReconcilePredicateFactory.CreateDoesNotMatch(song, option.TargetField, option.ComparisonField);
            default:
               throw new InvalidOperationException(
                 string.Format("Cannot generate preidcate for criteria {0}", option.Criteria));
         }
      }

      private static IDv3ReconcileAction GetReconcileAction(IDv3ReconcilableFile song, IDv3MistmatchOption option)
      {
         switch (option.Criteria)
         {
            case IDv3MetaMismatchCriteria.Empty:
               return IDv3ReconilerActionFactory.CreateFixEmptyField(song, option);
            case IDv3MetaMismatchCriteria.DoesNotMatch:
               return IDv3ReconilerActionFactory.CreateUpdateFieldToMatch(song, option);
            case IDv3MetaMismatchCriteria.Blocked:
               return IDv3ReconilerActionFactory.CreateUnblockFile(song, option);
            case IDv3MetaMismatchCriteria.UrlFormatted:
               return IDv3ReconilerActionFactory.CreateFixUrlField(song, option);
            default:
               throw new InvalidOperationException("Could not find Reconile action");
         }
      }
   }
}
