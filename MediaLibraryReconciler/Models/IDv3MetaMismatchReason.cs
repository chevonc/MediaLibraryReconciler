using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibraryReconciler.Models
{
   public enum IDv3MetaMismatchCriteria
   {
      None,
      Empty,
      DoesNotMatch,
      Blocked,
      UrlFormatted,
   }
}