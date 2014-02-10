using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibraryReconciler.Models
{
   public struct IDv3MistmatchOptions
   {
      public IDv3MistmatchOptions(IDv3MetaMismatchField targetField,
      IDv3MetaMismatchReason criteria) :
         this(targetField, criteria, IDv3MetaMismatchField.None)
      {

      }
      public IDv3MistmatchOptions(IDv3MetaMismatchField targetField,
         IDv3MetaMismatchReason reason, IDv3MetaMismatchField comparisonField):this()
      {
         r_targetField = targetField;
         r_reason = reason;
         r_comparisonField = comparisonField;
      }

      private readonly IDv3MetaMismatchField r_comparisonField;
      private readonly IDv3MetaMismatchReason r_reason;
      private readonly IDv3MetaMismatchField r_targetField;
      public IDv3MetaMismatchField TargetField
      {
         get { return r_targetField; }
      }
      public IDv3MetaMismatchReason Reason
      {
         get { return r_reason; }
      }
      public IDv3MetaMismatchField ComparisonField
      {
         get { return r_comparisonField; }
      }
   }
}
