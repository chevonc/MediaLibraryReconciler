using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace MediaLibraryReconciler.Models
{
   [DebuggerDisplay(@"M: {MismatchOption}\R: {Reconcile}")]
    public class IDv3ReconcilePackage
    {
       public IDv3ReconcilePackage(IDv3MistmatchOption mismatchOption,
          Func<bool> reconciliationPredicate, IDv3ReconcileAction reconcileAction)
       {
          if(reconciliationPredicate == null || reconcileAction == null)
          {
             throw new ArgumentNullException("The reconciliationPredicate or reconcileAction cannot be null");
          }

          r_mismatchOption = mismatchOption;
          r_needsToBeReconciliation = reconciliationPredicate;
          r_reconcile = reconcileAction;
       }

       private readonly IDv3ReconcileAction r_reconcile;
       private readonly Func<bool> r_needsToBeReconciliation;
       private readonly IDv3MistmatchOption r_mismatchOption;
       public IDv3MistmatchOption MismatchOption
       {
          get
          {
             return r_mismatchOption;
          } 
       }

       public Func<bool> NeedsReconciliation
       {
          get
          {
             return r_needsToBeReconciliation;
          } 
       }

       public IDv3ReconcileAction Reconcile
       {
          get
          {
             return r_reconcile;
          } 
       }
    }
}
