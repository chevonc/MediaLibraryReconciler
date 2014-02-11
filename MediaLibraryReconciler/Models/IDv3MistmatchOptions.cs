using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MediaLibraryReconciler.Models
{
   [DebuggerDisplay(@"T: {TargetField}\R: {Criteria}\C: {ComparisonField}")]
   public struct IDv3MistmatchOption
   {
      public IDv3MistmatchOption(IDv3MetaMismatchField targetField,
      IDv3MetaMismatchCriteria criteria) :
         this(targetField, criteria, IDv3MetaMismatchField.None)
      {

      }
      public IDv3MistmatchOption(IDv3MetaMismatchField targetField,
         IDv3MetaMismatchCriteria reason, IDv3MetaMismatchField comparisonField):this()
      {
         r_targetField = targetField;
         r_criteria = reason;
         r_comparisonField = comparisonField;
      }

      private readonly IDv3MetaMismatchField r_comparisonField;
      private readonly IDv3MetaMismatchCriteria r_criteria;
      private readonly IDv3MetaMismatchField r_targetField;
      public IDv3MetaMismatchField TargetField
      {
         get { return r_targetField; }
      }
      public IDv3MetaMismatchCriteria Criteria
      {
         get { return r_criteria; }
      }
      public IDv3MetaMismatchField ComparisonField
      {
         get { return r_comparisonField; }
      }

   }

}
