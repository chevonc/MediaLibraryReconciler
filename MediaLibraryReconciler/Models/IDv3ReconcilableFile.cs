using Id3Lib;
using Mp3Lib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MediaLibraryReconciler.Models
{
   internal class IDv3ReconcilableFile
   {
      private Mp3File m_file;
      private string m_path;
      public IDv3ReconcilableFile(string path)
      {
         if(string.IsNullOrEmpty(path))
         {
            throw new ArgumentNullException("path");
         }
         if(!File.Exists(path))
         {
            throw new FileNotFoundException(string.Format("{File does not exist. Name: {0}", path));
         }

         m_file = new Mp3File(path);
         m_path = path;
      }

      public TagHandler TagHandler
      {
         get
         {
            return m_file.TagHandler;
         }
      }

      public string Path
      {
         get
         {
            return m_path;
         }
      }

      public void RenameFile(string newFullPathName)
      {
         if(File.Exists(newFullPathName))
         {
            throw new ArgumentException(string.Format("File already exists! Name: {0}", newFullPathName));
         }

         try
         {
            m_file.Update();
            m_file = null;
            File.Move(Path, newFullPathName);
            m_path = newFullPathName;
            m_file = new Mp3File(newFullPathName);
         }
         catch(Exception e)
         {
            //TODO: handle properly
            throw e;
         }
      }

   }
}
