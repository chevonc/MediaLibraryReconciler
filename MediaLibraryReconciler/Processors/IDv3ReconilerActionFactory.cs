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
   internal class IDv3ReconilerActionFactory
   {
      private static Action CreateNotYetImplementedReconcileAction(IDv3MistmatchOptions options)
      {
         return () =>
         {
            throw new NotImplementedException(string.Format("Reconciliation not yet implemented for {0} > {1} > {2}",
               options.TargetField, options.Reason, options.ComparisonField));
         };
      } 
      internal static IDv3ReconcileAction CreateUpdateFieldToMatch(IDv3ReconcilableFile song, IDv3MistmatchOptions options)
      {
         Func<string> getCurrentValue = () => IDv3MistmatchHelper.GetIDv3MismatchFieldValueAs<string>(song, options.TargetField);
         Func<string> getNewValue = () => IDv3MistmatchHelper.GetIDv3MismatchFieldValueAs<string>(song, options.ComparisonField);
         Action reconcile = null;
         switch (options.TargetField)
         {
            case IDv3MetaMismatchField.FileName:
               getNewValue = () =>
                  {
                     string newValue = IDv3MistmatchHelper.GetIDv3MismatchFieldValueAs<string>(song, options.ComparisonField);
                     string currentFilePath = getCurrentValue();
                     string newFilePath = Path.Combine(Path.GetDirectoryName(currentFilePath),
                        string.Format("{0}.{1}", newValue, Path.GetExtension(currentFilePath)));
                     return newFilePath;
                  };
               reconcile = () =>
                  {
                     string newFilePath = getNewValue();
                     song.RenameFile(newFilePath);
                  };
               break;
            case IDv3MetaMismatchField.Title:
               reconcile = () =>
                {
                   string newValue = getNewValue();
                   IDv3MistmatchHelper.SetIDv3FieldValue(song, options.TargetField, newValue);
                };
               break;
            default:
               reconcile = CreateNotYetImplementedReconcileAction(options);
               break;
         }

         return new IDv3ReconcileAction(getCurrentValue, getNewValue, reconcile);
      }

      internal static IDv3ReconcileAction CreateFixEmptyField(IDv3ReconcilableFile song, IDv3MistmatchOptions options)
      {
         Func<string> getCurrentValue = () => IDv3MistmatchHelper.GetIDv3MismatchFieldValueAs<string>(song, options.TargetField);
         Func<string> getNewValue = () => null;
         Action reconcile = null;

         switch (options.TargetField)
         {
            case IDv3MetaMismatchField.Title:
               getNewValue = () =>
                  {
                     string filePath = IDv3MistmatchHelper.GetIDv3MismatchFieldValueAs<string>(
                                       song, IDv3MetaMismatchField.FileName);
                     string fileName = Path.GetFileName(filePath).Split('.')[0];
                     return fileName;
                  };
               break;
            case IDv3MetaMismatchField.Artist:
               getNewValue = () =>
                  {
                     string grandparentFolder = IDv3MistmatchHelper.GetIDv3MismatchFieldValueAs<string>(
                        song, IDv3MetaMismatchField.GrandparentFolder);
                     return grandparentFolder;
                  };
               break;
            case IDv3MetaMismatchField.Album:
               getNewValue = () =>
               {
                  string parentFolder = IDv3MistmatchHelper.GetIDv3MismatchFieldValueAs<string>(
                     song, IDv3MetaMismatchField.Folder);
                  return parentFolder;
               };
               break;
            default:
               reconcile = CreateNotYetImplementedReconcileAction(options);
               break;
         }

         if(getNewValue == null)
         {
            getNewValue = () => { return string.Empty; };
            reconcile = CreateNotYetImplementedReconcileAction(options);
         }
         else
         {
            reconcile = () =>
               {
                  string newValue = getNewValue();
                  IDv3MistmatchHelper.SetIDv3FieldValue(song, options.TargetField, newValue);
               };
         }

         return new IDv3ReconcileAction(getCurrentValue, getNewValue, reconcile);
      }

      internal static IDv3ReconcileAction CreateUnblockFile(IDv3ReconcilableFile song, IDv3MistmatchOptions options)
      {
         if(options.TargetField != IDv3MetaMismatchField.FileName)
         {
            throw new InvalidOperationException("Only the FileName field can be unblocked");
         };

         Func<string> notApplicable = () => { return "Not Applicable"; };
         Action reconile = () =>
            {
               string filePath = IDv3MistmatchHelper.GetIDv3MismatchFieldValueAs<string>(
                  song, options.TargetField);
               DownloadedFileUnblocker.UnblockFile(filePath);
            };

         return new IDv3ReconcileAction(notApplicable, notApplicable, reconile);
      }

      internal static IDv3ReconcileAction CreateFixUrlField(IDv3ReconcilableFile song, IDv3MistmatchOptions options)
      {
         Func<string> getCurrentValue = () => IDv3MistmatchHelper.GetIDv3MismatchFieldValueAs<string>(song, options.TargetField);
         Func<string> getNewValue = null;
         Action reconcile = null;

         switch (options.TargetField)
         {
            case IDv3MetaMismatchField.Title:
               getNewValue = () =>
               {
                  string filePath = IDv3MistmatchHelper.GetIDv3MismatchFieldValueAs<string>(
                                    song, IDv3MetaMismatchField.FileName);
                  string fileName = Path.GetFileName(filePath).Split('.')[0];
                  return fileName;
               };
               break;
            case IDv3MetaMismatchField.Artist:
               getNewValue = () =>
               {
                  string grandparentFolder = IDv3MistmatchHelper.GetIDv3MismatchFieldValueAs<string>(
                     song, IDv3MetaMismatchField.GrandparentFolder);
                  return grandparentFolder;
               };
               break;
            case IDv3MetaMismatchField.Album:
               getNewValue = () =>
               {
                  string parentFolder = IDv3MistmatchHelper.GetIDv3MismatchFieldValueAs<string>(
                     song, IDv3MetaMismatchField.Folder);
                  return parentFolder;
               };
               break;
         }
         if (getNewValue == null)
         {
            getNewValue = () => { return string.Empty; };
            reconcile = CreateNotYetImplementedReconcileAction(options);
         }
         else
         {
            reconcile = () =>
            {
               string newValue = getNewValue();
               IDv3MistmatchHelper.SetIDv3FieldValue(song, options.TargetField, newValue);
            };
         }
         return new IDv3ReconcileAction(getCurrentValue, getNewValue, reconcile);
      }
   }
}
