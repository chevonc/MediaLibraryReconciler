using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MediaLibraryReconciler.Models
{
   public class IDv3ReconileResult
   {
      public IDv3ReconileResult(bool succeeded, string oldvalue, string newValue, Exception errors = null)
      {
         Succeeded = succeeded;
         Errors = errors;
         OldValue = oldvalue;
         NewValue = newValue;
      }

      public string OldValue
      {
         get;
         private set;
      }

      public string NewValue
      {
         get;
         private set;
      }
      public bool Succeeded
      {
         get;
         private set;
      }

      public Exception Errors
      {
         get;
         private set;
      }
   }
}
