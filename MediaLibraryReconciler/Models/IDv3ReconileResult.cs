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
         Exception = errors;
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

      public string Errors
      {
         get
         {
            if(Exception != null)
            {
               return Exception.Message;
            }
            return string.Empty;
         }
      }
      public Exception Exception
      {
         get;
         private set;
      }
   }
}
