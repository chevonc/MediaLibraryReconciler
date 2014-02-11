using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MediaLibraryReconciler.Models
{
   [DebuggerDisplay(@"Current: {CurrentValue}\ New: {NewValue}")]
   public class IDv3ReconcileAction
   {

      private readonly Func<string> r_getCurrentValue;
      private readonly Func<string> r_getNewValue;
      private readonly Action r_reconcileValues;

      public IDv3ReconcileAction(Func<string> getCurrentValue, Func<string> getNewValue,
         Action reconcileValues)
      {
         if(getCurrentValue == null || getNewValue == null || reconcileValues == null)
         {
            throw new ArgumentNullException("No arguments can be null!");
         }
         r_getCurrentValue = getCurrentValue;
         r_getNewValue = getNewValue;
         r_reconcileValues = reconcileValues;
      }
      public string CurrentValue
      {
         get { return r_getCurrentValue(); }
      }

      public string NewValue
      {
         get { return r_getNewValue(); }
      }

      public IDv3ReconileResult Apply()
      {
         string oldValue = CurrentValue;
         try
         {
            if(r_reconcileValues != null)
            {
               r_reconcileValues();
            }

            return new IDv3ReconileResult(true, oldValue, NewValue);
         }
         catch (Exception e)
         {
            return new IDv3ReconileResult(false, oldValue, null, e);
         }
      }
   }
}
