using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibraryReconciler.Models
{
   public class IDv3ReconcileAction
   {

      private readonly Func<string> r_getCurrentValue;
      private readonly Func<string> r_getNewValue;
      private readonly Action r_reconcileValues;

      public IDv3ReconcileAction(Func<string> getCurrentValue, Func<string> getNewValue, 
         Action reconcileValues)
      {
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
            r_reconcileValues();
            return new IDv3ReconileResult(true, oldValue, NewValue);
         }
         catch(Exception e)
         {
            return new IDv3ReconileResult(false, oldValue, null, e);
         }
      }
   }
    public class IDv3ReconilePackage
    {
       public IDv3ReconilePackage(IDv3MistmatchOptions mismatchOption,
          Func<bool> reconciliationPredicate, Func<IDv3ReconileResult> reconcileAction)
       {
          if(reconciliationPredicate == null || reconcileAction == null)
          {
             throw new ArgumentNullException("The reconciliationPredicate or reconcileAction cannot be null");
          }

          m_mismatchOption = mismatchOption;
          m_needsToBeReconciliation = reconciliationPredicate;
          m_reconcile = reconcileAction;
       }

       private readonly Func<IDv3ReconileResult> m_reconcile;
       private readonly Func<bool> m_needsToBeReconciliation;
       private readonly IDv3MistmatchOptions m_mismatchOption;
       public IDv3MistmatchOptions MismatchOption
       {
          get
          {
             return m_mismatchOption;
          } 
       }

       public Func<bool> NeedsToBeReconciliation
       {
          get
          {
             return m_needsToBeReconciliation;
          } 
       }

       public Func<IDv3ReconileResult> Reconcile
       {
          get
          {
             return m_reconcile;
          } 
       }
    }
}
