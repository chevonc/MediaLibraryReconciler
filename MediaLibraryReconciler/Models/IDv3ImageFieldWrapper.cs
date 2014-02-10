using MediaLibraryReconciler.Interop;
using Mp3Lib;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MediaLibraryReconciler.Models
{
   class IDv3ImageFieldWrapper
   {
      private readonly Image r_image;
      public IDv3ImageFieldWrapper(Image image)
      {
         r_image = image;
      }
      Image Image { get { return r_image; } }
   }
}
