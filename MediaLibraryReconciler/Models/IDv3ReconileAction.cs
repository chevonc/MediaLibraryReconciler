using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibraryReconciler.Models
{
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
