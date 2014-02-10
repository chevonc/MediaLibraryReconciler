using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibraryReconciler.Models
{
   public enum IDv3MetaMismatchReason
   {
      None,
      Empty,
      DoesNotMatch,
      Blocked,
      UrlFormatted,
   }
}