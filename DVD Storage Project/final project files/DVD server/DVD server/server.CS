using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Threading;

using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Text.RegularExpressions;
using System.Data.OleDb;

namespace DVD_server
{
   class server
   {
      private static int m_port = 5000;

      private static Boolean listening = true;
      private static TcpClient DVD_client = null;
      private static TcpListener listener = null;
      public static logwriter logWriter = null;
      private static void Logmessage(String message, params object[] args)
      {
         // Apply the formatting requested by the user
         String s = String.Format(message, args);

         // add the date/time to the message 
         Console.WriteLine("{0}\t{1}", DateTime.Now.ToString(), s);

         //write a log file entry
         if (logWriter == null)
            logWriter = logwriter.instance();

         logWriter.WriteLogMessage(String.Format("{0}\t{1}", DateTime.Now.ToString(), s));
      }

      static void Main(string[] args)
      {
  
             server.Logmessage("Start System Initialization");


             listener = new TcpListener(System.Net.IPAddress.Any, m_port);

             // Start the listener
             listener.Start();
             Logmessage("Server Started.");

             while (listening)
             {
                Logmessage("Awaiting connection on port {0}.", m_port);
                DVD_client = listener.AcceptTcpClient();
                Logmessage("Accepted a Connection from: {0}.", DVD_client.Client.RemoteEndPoint.ToString());

                // Create a new session
                Session s = new Session(DVD_client);

                // Create a new thread and start it to it will execute asynchronously
                Thread newThread;
                newThread = new Thread(s.Run);
                newThread.Start();
             }

             Logmessage("Server Shutdown Initiated.");
             listener.Stop();
             Logmessage("Server Shutdown Completed.");
      }
   }
}