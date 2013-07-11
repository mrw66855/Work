using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Xml;

namespace DVD_server
{
    class Session
    {
       private long sessionID;
        private static long session_id = 0;
        private TcpClient DVD_client;
        private StreamReader reader;
        private StreamWriter writer;
        private bool listening;
        serveractions sa = new serveractions();
       
        

        public Session(TcpClient client)
        {
            // Increment the session ID
          sessionID= ++session_id;

            DVD_client = client;
            reader = new StreamReader(client.GetStream());
            writer = new StreamWriter(client.GetStream());
            writer.AutoFlush = true;

           listening = true;

         Logmessage("Client Session {0}  Initialized from {1}.", session_id, client.Client.RemoteEndPoint.ToString());
        }
        
          public static void Logmessage(String message, params object[] args)
          {
             // Apply the formatting requested by the user
             String s = String.Format(message, args);

             // add the date/time to the message 
             Console.WriteLine("{0}\t{1}", DateTime.Now.ToString(), s);

             //write a log file entry
             if (server.logWriter == null)
                server.logWriter = logwriter.instance();

             server.logWriter.WriteLogMessage(String.Format("{0}\t:{1}", DateTime.Now.ToString(), s));
          }

        public void Run()
        {
           string request = string.Empty;
           string response = string.Empty;
          
           while (listening)
           {

              try
              {
                 // Wait for a request
                 request = reader.ReadLine();
              }
              catch (IOException)
              {
                 Logmessage("client disconnected without shutting down server first. Session: {0}",sessionID);
              }
             

            Logmessage(" request: {0}",request);
              string action = utilities.getNodeText("//Request/Action", request);
              if (action != null)
              {
                 if (action.Equals("addall"))
                 {
                    try
                    {
                       response =sa.AddAll(request);
                    }
                    catch (Exception ex)
                    {
                       response = sa.AddAll(request,ex);
                    }
             
                 }
                 if (action.Equals("addtitle"))
                 {

                    try
                    {
                       response = sa.AddTitle(request);
                    }
                    catch (Exception ex)
                    {
                       response = sa.AddTitle(request, ex);
                    }
                   
                 }
                 if (action.Equals("updateall"))
                 {
                    try
                    {
                       response = sa.UpdateAll(request);
                    }
                    catch (Exception ex)
                    {
                       response = sa.UpdateAll(request, ex);
                    }
                 }
                 if (action.Equals("updatetitle"))
                 {
                    try
                    {
                       response = sa.Updatetitle(request);
                    }
                    catch (Exception ex)
                    {
                       response = sa.Updatetitle(request, ex);
                    }
                 }
                 if (action.Equals("updateactor1"))
                 {
                    try
                    {
                       response = sa.UpdateActor1(request);
                    }
                    catch (Exception ex)
                    {
                       response = sa.UpdateActor1(request, ex);
                    }
                 }
                 if (action.Equals("updateactor2"))
                 {
                    try
                    {
                       response = sa.UpdateActor2(request);
                    }
                    catch (Exception ex)
                    {
                       response = sa.UpdateActor2(request, ex);
                    }
                 }
                 if (action.Equals("updatecompany"))
                 {
                    try
                    {
                       response = sa.UpdateCompany(request);
                    }
                    catch (Exception ex)
                    {
                       response = sa.UpdateCompany(request, ex);
                    }
                 }
                 if (action.Equals("updategenre"))
                 {
                    try
                    {
                       response = sa.Updategenre(request);
                    }
                    catch (Exception ex)
                    {
                       response = sa.Updategenre(request, ex);
                    }
                 }
                 if (action.Equals("updateruntime"))
                 {
                    try
                    {
                       response = sa.UpdateRuntime(request);
                    }
                    catch (Exception ex)
                    {
                       response = sa.UpdateRuntime(request, ex);
                    }
               
                 }
                 if (action.Equals("updatetype"))
                 {
                    try
                    {
                       response = sa.Updatetype(request);
                    }
                    catch (Exception ex)
                    {
                       response = sa.Updatetype(request, ex);
                    }
                 
                 }
                 if (action.Equals("searchtitle"))
                 {
                    try
                    {
                       response = sa.SearchTitle(request);
                    }
                    catch (Exception ex)
                    {
                       response = sa.SearchTitle(request, ex);
                    }
                 }
                 if (action.Equals("searchactor1"))
                 {
                     try
                    {
                       response = sa.SearchActor1(request);
                    }
                    catch (Exception ex)
                    {
                       response = sa.SearchActor1(request, ex);
                    }
                 }
                 if (action.Equals("searchactor2"))
                 {
                       try
                    {
                       response = sa.SearchActor2(request);
                    }
                    catch (Exception ex)
                    {
                       response = sa.SearchActor2(request, ex);
                    }
                 
                 }
                 if (action.Equals("searchcompany"))
                 {
                       try
                    {
                       response = sa.SearchCompany(request);
                    }
                    catch (Exception ex)
                    {
                       response = sa.SearchCompany(request, ex);
                    }
                 
                 }
                 if (action.Equals("searchgenre"))
                 {
                       try
                    {
                       response = sa.SearchGenre(request);
                    }
                    catch (Exception ex)
                    {
                       response = sa.SearchGenre(request, ex);
                    }
                 
                 }
                 if (action.Equals("searchruntime"))
                 {
                       try
                    {
                       response = sa.SearchRuntime(request);
                    }
                    catch (Exception ex)
                    {
                       response = sa.SearchRuntime(request, ex);
                    }
                 
                 }
                 if (action.Equals("searchtype"))
                 {
                       try
                    {
                       response = sa.SearchType(request);
                    }
                    catch (Exception ex)
                    {
                       response = sa.SearchType(request, ex);
                    }
                 }
                 if (action.Equals("searchstatus"))
                 {
                    try
                    {
                       response = sa.SearchStatus(request);
                    }
                    catch (Exception ex)
                    {
                       response = sa.SearchStatus(request, ex);
                    }
                 }
                 if (action.Equals("selectID"))
                 {
                    try
                    {
                       response = sa.SelectID(request);
                    }
                    catch (Exception ex)
                    {
                       response = sa.SelectID(request, ex);
                    }
                 }
                 if (action.Equals("selecttitle"))
                 {
                    try
                    {
                       response = sa.SelectTitle(request);
                    }
                    catch (Exception ex)
                    {
                       response = sa.SelectTitle(request, ex);
                    }
                 }
                 if (action.Equals("delete"))
                 {
                    try
                    {
                       response = sa.Purge(request);
                    }
                    catch (Exception ex)
                    {
                       response = sa.Purge(request, ex);
                    }
                  
                 }
                 if (action.Equals("temp"))
                 {
                    try
                    {
                       response = sa.Delete(request);
                    }
                    catch (Exception ex)
                    {
                       response = sa.Delete(request, ex);
                    }
                    
                 }
                 if (action.Equals("recover"))
                 {
                    try
                    {
                       response = sa.Undo(request);
                    }
                    catch (Exception ex)
                    {
                       response = sa.Undo(request, ex);
                    }
                 
                 }
                 if (action.Equals("getgenre"))
                 {
                    try
                    {
                       response = sa.GetGenres(request);
                    }
                    catch (Exception ex)
                    {
                       response = sa.GetGenres(request, ex);
                    }
                 }

                 if (action.Equals("disconnect"))
                 {
                    listening = false;
                 }

              }
              Logmessage(" Response: {0}",response);
              writer.WriteLine(response);

              request = string.Empty;
              response = string.Empty;
           }
                
            

            reader.Close();
            writer.Close();
            DVD_client.Close();
            Logmessage("Session {0} disconnected.", sessionID);

           
        }

}
    }

