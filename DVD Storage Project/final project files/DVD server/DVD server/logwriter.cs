using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace DVD_server
{
   class logwriter
   {
      private static StreamWriter  writer;
      private static logwriter logWriter;
      private logwriter()
      {
         writer = new StreamWriter(@".\DVDproject_DVDserver.log", true);
         writer.AutoFlush = true;

      }
      public static logwriter instance()
      {
         if (logWriter == null)
         {
            logWriter = new logwriter();
         
         }
         return logWriter;
      }
      public void WriteLogMessage(String message)
      {
         writer.WriteLine(message);
      }
   }

}
