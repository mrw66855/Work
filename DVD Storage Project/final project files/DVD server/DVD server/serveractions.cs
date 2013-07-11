using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.OleDb;
using System.Net;
using System.Net.Sockets;
using System.IO;
using System.Xml;
namespace DVD_server
{
   class serveractions : genre
   {
    
      database db = new database();
      genre[] genrelist;
      private long newID;
      private short genreID;
    private  string returnedID;
     private string DVD_title;
      private string DVD_first;
     private string DVD_last;
 private   string DVD_first2;
 private     string DVD_last2;
   private   string DVD_cp;
    private  string DVD_genre;
    private  string DVD_rt;
    private  string DVD_type;
  private    string DVD_stat;
  private string description;
      String DVD_ID;
    
      public String AddAll(String request, Exception ex = null)
      {
         StringWriter sw = new StringWriter();
         XmlTextWriter xmlWriter = new XmlTextWriter(sw);

         if (ex == null)
         {
            DVD_title = utilities.getNodeText("//Request/Title", request);
            DVD_first = utilities.getNodeText("//Request/First", request);
            DVD_last = utilities.getNodeText("//Request/Last", request);
            DVD_first2 = utilities.getNodeText("//Request/First2", request);
            DVD_last2 = utilities.getNodeText("//Request/Last2", request);
            DVD_cp = utilities.getNodeText("//Request/Company", request);
            DVD_genre = utilities.getNodeText("//Request/Genre", request);
            DVD_rt = utilities.getNodeText("//Request/Runtime", request);
            DVD_type = utilities.getNodeText("//Request/Type", request);
            DVD_stat = utilities.getNodeText("//Request/Status", request);
            newID = db.Addall(DVD_title, DVD_first, DVD_last, DVD_first2, DVD_last2, DVD_cp, Convert.ToInt16(DVD_genre), Convert.ToInt16(DVD_rt), Convert.ToChar(DVD_type), Convert.ToChar(DVD_stat));


            Session.Logmessage("Record Added!  New ID: " + newID.ToString());

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("Response");
            xmlWriter.WriteElementString("ErrorCode", "0");
            xmlWriter.WriteElementString("ID", newID.ToString());
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();
            xmlWriter.Close();

         }
         else
         {
            Session.Logmessage("Error: Error Occurred When Adding DVD");
            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("Response");
            xmlWriter.WriteElementString("ErrorCode", "-1");
            xmlWriter.WriteElementString("Message", "Could not add DVD please try again");
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();
            xmlWriter.Close();

         }
         return sw.ToString();
         }
      public string AddTitle(String request, Exception ex = null)
      {
         StringWriter sw = new StringWriter();
         XmlTextWriter xmlWriter = new XmlTextWriter(sw);
         if (ex == null)
         {
            DVD_title = utilities.getNodeText("//Request/Title", request);
            DVD_stat = utilities.getNodeText("//Request/Status", request);
            newID = db.AddTitle(DVD_title, Convert.ToChar(DVD_stat));


            Session.Logmessage("Record Added!  New ID: " + newID.ToString());

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("Response");
            xmlWriter.WriteElementString("ErrorCode", "0");
            xmlWriter.WriteElementString("ID", newID.ToString());
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();
            xmlWriter.Close();
         }
         else
         {
            Session.Logmessage("Error: Error Occurred When Adding DVD");
            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("Response");
            xmlWriter.WriteElementString("ErrorCode", "-1");
            xmlWriter.WriteElementString("Message", "Could not add DVD please try again");
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();
            xmlWriter.Close();

         }
         return sw.ToString();
      }
      public string UpdateAll(String request, Exception ex=null)
      {
         StringWriter sw = new StringWriter();
         XmlTextWriter xmlWriter = new XmlTextWriter(sw);
         if (ex == null)
         {
            DVD_ID = utilities.getNodeText("//Request/ID", request);
            DVD_title = utilities.getNodeText("//Request/Title", request);
            DVD_first = utilities.getNodeText("//Request/First", request);
            DVD_last = utilities.getNodeText("//Request/Last", request);
            DVD_first2 = utilities.getNodeText("//Request/First2", request);
            DVD_last2 = utilities.getNodeText("//Request/Last2", request);
            DVD_cp = utilities.getNodeText("//Request/Company", request);
            DVD_genre = utilities.getNodeText("//Request/Genre", request);
            DVD_rt = utilities.getNodeText("//Request/Runtime", request);
            DVD_type = utilities.getNodeText("//Request/Type", request);
            db.UpdateAll(Convert.ToInt64(DVD_ID), DVD_title, DVD_first, DVD_last, DVD_first2, DVD_last2, DVD_cp, Convert.ToInt16(DVD_genre), Convert.ToInt16(DVD_rt), Convert.ToChar(DVD_type));

            Session.Logmessage("Record updated!" + " DVD ID " + DVD_ID + "updated");

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("Response");
            xmlWriter.WriteElementString("ErrorCode", "0");
            xmlWriter.WriteElementString("Message", " DVD ID " + DVD_ID + " updated ");
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();

         }
         else
         {
            Session.Logmessage("Error: Error Occurred When Updating DVD");
            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("Response");
            xmlWriter.WriteElementString("ErrorCode", "-1");
            xmlWriter.WriteElementString("Message", " Could not update DVD please try again ");
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();

         }
         return sw.ToString();
      }
      public string Updatetitle(String request, Exception ex=null)
      {
         StringWriter sw = new StringWriter();
         XmlTextWriter xmlWriter = new XmlTextWriter(sw);
         if (ex == null)
         {
            DVD_ID = utilities.getNodeText("//Request/ID", request);
            DVD_title = utilities.getNodeText("//Request/Title", request);

            db.UpdateTitle(Convert.ToInt64(DVD_ID), DVD_title);

            Session.Logmessage("Record updated!" + "DVD ID" + DVD_ID + "updated");


            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("Response");
            xmlWriter.WriteElementString("ErrorCode", "0");
            xmlWriter.WriteElementString("Message", " DVD ID " + DVD_ID + " title updated ");
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();

         }
         else
         {
            Session.Logmessage("Error: Error Occurred When Updating DVD Title");
            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("Response");
            xmlWriter.WriteElementString("Error Code", "-1");
            xmlWriter.WriteElementString("Message", " Could not update DVD title please try again ");
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();

         }
       return sw.ToString();
      }
      public string UpdateActor1(String request,Exception ex=null)
      {
         StringWriter sw = new StringWriter();
         XmlTextWriter xmlWriter = new XmlTextWriter(sw);
         if (ex == null)
        {

         DVD_ID = utilities.getNodeText("//Request/ID", request);
        
         DVD_first = utilities.getNodeText("//Request/First", request);
         DVD_last = utilities.getNodeText("//Request/Last", request);

        db.UpdateActor1(Convert.ToInt64(DVD_ID), DVD_first, DVD_last);
        
              Session.Logmessage("Record updated!" + " DVD ID " + DVD_ID + "updated");


            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("Response");
            xmlWriter.WriteElementString("ErrorCode", "0");
            xmlWriter.WriteElementString("Message", " DVD ID " + DVD_ID + " Actor 1 updated ");
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();
            xmlWriter.Close();
         }
         else
         {
               Session.Logmessage("Error: Error Occurred When Updating DVD");
            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("Response");
            xmlWriter.WriteElementString("ErrorCode", "-1");
            xmlWriter.WriteElementString("Message", " Could not update DVD Actor 1 please try again ");
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();
            xmlWriter.Close();
            
         }
        return sw.ToString();
      }
      public string UpdateActor2(String request, Exception ex=null)
      {
         StringWriter sw = new StringWriter();
         XmlTextWriter xmlWriter = new XmlTextWriter(sw);
        if (ex == null)
        {
         DVD_ID = utilities.getNodeText("//Request/ID", request);
         DVD_first2 = utilities.getNodeText("//Request/First2", request);
         DVD_last2 = utilities.getNodeText("//Request/Last2", request);

         db.UpdateActor2(Convert.ToInt64(DVD_ID), DVD_first2, DVD_last2);
           Session.Logmessage("Record updated!" + "DVD ID" + DVD_ID + "updated");

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("Response");
            xmlWriter.WriteElementString("ErrorCode", "0");
            xmlWriter.WriteElementString("Message", " DVD ID " + DVD_ID + " Actor 2 updated ");
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();
            xmlWriter.Close();
           
         }
         else
         {
               Session.Logmessage("Error: Error Occurred When Updating DVD");
            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("Response");
            xmlWriter.WriteElementString("ErrorCode", "-1");
            xmlWriter.WriteElementString("Message", " Could not update DVD Actor 2 please try again ");
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();
            xmlWriter.Close();
         
         }
         return sw.ToString();
      }
      public string UpdateCompany(String request, Exception ex=null)
     
      {
         StringWriter sw = new StringWriter();
         XmlTextWriter xmlWriter = new XmlTextWriter(sw);
         if (ex == null)
        {
         DVD_ID = utilities.getNodeText("//Request/ID", request);
        
         DVD_cp = utilities.getNodeText("//Request/Company", request);

         db.UpdateCompany(Convert.ToInt64(DVD_ID), DVD_cp);
        
               Session.Logmessage("Record updated!" + "DVD ID" + DVD_ID + "updated");

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("Response");
            xmlWriter.WriteElementString("ErrorCode", "0");
            xmlWriter.WriteElementString("Message", " DVD ID " + DVD_ID + " Production Company updated ");
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();
            xmlWriter.Close();
           
         }
         else
         {
               Session.Logmessage("Error: Error Occurred When Updating DVD");
            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("Response");
            xmlWriter.WriteElementString("ErrorCode", "-1");
            xmlWriter.WriteElementString("Message", " Could not update DVD Company please try again ");
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();
            xmlWriter.Close();
         }
         return sw.ToString();
      }
   
      public string Updategenre(String request,Exception ex=null)
      {
         StringWriter sw = new StringWriter();
         XmlTextWriter xmlWriter = new XmlTextWriter(sw);
          if (ex == null)
        {
         DVD_ID = utilities.getNodeText("//Request/ID", request);

         DVD_genre = utilities.getNodeText("//Request/Genre", request);

         db.UpdateGenre(Convert.ToInt64(DVD_ID), Convert.ToInt16(DVD_genre));
         
               Session.Logmessage("Record updated!" + "DVD ID" + DVD_ID + "updated");

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("Response");
            xmlWriter.WriteElementString("ErrorCode", "0");
            xmlWriter.WriteElementString("Message", " DVD ID " + DVD_ID + " Genre Code updated ");
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();
            xmlWriter.Close();
         }
         else
         {
               Session.Logmessage("Error: Error Occurred When Updating DVD");
            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("Response");
            xmlWriter.WriteElementString("ErrorCode", "-1");
            xmlWriter.WriteElementString("Message", " Could not update DVD  Genre please try again ");
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();
            xmlWriter.Close();
            
         }
         return sw.ToString();
      }
      public string UpdateRuntime(String request, Exception ex=null)
      {
         StringWriter sw = new StringWriter();
         XmlTextWriter xmlWriter = new XmlTextWriter(sw);
          if (ex == null)
        {
         DVD_ID = utilities.getNodeText("//Request/ID", request);
        
         DVD_rt = utilities.getNodeText("//Request/Runtime", request);

         db.UpdateRuntime(Convert.ToInt64(DVD_ID), Convert.ToInt16(DVD_rt));
         
               Session.Logmessage("Record updated!" + "DVD ID" + DVD_ID + "updated");


            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("Response");
            xmlWriter.WriteElementString("ErrorCode", "0");
            xmlWriter.WriteElementString("Message", " DVD ID " + DVD_ID + " Runtime updated ");
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();
            xmlWriter.Close();
          
         }
         else
         {
               Session.Logmessage("Error: Error Occurred When Updating DVD");
            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("Response");
            xmlWriter.WriteElementString("ErrorCode", "-1");
            xmlWriter.WriteElementString("Message", " Could not update DVD Runtime please try again ");
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();
            xmlWriter.Close();
         }
         return sw.ToString();
      }


      public string Updatetype(String request, Exception ex=null)
      {
         StringWriter sw = new StringWriter();
         XmlTextWriter xmlWriter = new XmlTextWriter(sw);
          if (ex == null)
        {
         DVD_ID = utilities.getNodeText("//Request/ID", request);
         DVD_type = utilities.getNodeText("//Request/Type", request);
         db.UpdateType(Convert.ToInt64(DVD_ID), Convert.ToChar(DVD_type));
           Session.Logmessage("Record updated!" + "DVD ID" + DVD_ID + "updated");

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("Response");
            xmlWriter.WriteElementString("ErrorCode", "0");
            xmlWriter.WriteElementString("Message", " DVD ID " + DVD_ID + " Type updated ");
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();
            xmlWriter.Close();
         }
         else
         {
               Session.Logmessage("Error: Error Occurred When Updating DVD");
            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("Response");
            xmlWriter.WriteElementString("ErrorCode", "-1");
            xmlWriter.WriteElementString("Message", " Could not update DVD please try again ");
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();
            xmlWriter.Close();
         }
         return sw.ToString();

      }

      public string Delete(String request, Exception ex=null)
      {
         StringWriter sw = new StringWriter();
         XmlTextWriter xmlWriter = new XmlTextWriter(sw);
       if (ex == null)
       {
         DVD_ID = utilities.getNodeText("//Request/ID", request);
         db.Ddelete(Convert.ToInt64(DVD_ID));
        
               Session.Logmessage("Record deleted!" + "DVD ID" + DVD_ID + "deleted");

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("Response");
            xmlWriter.WriteElementString("ErrorCode", "0");
            xmlWriter.WriteElementString("Message", " DVD ID " + DVD_ID + " deleted ");
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();
            xmlWriter.Close();
         }
         else
         {
               Session.Logmessage("Error: Error Occurred When deleting DVD");
            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("Response");
            xmlWriter.WriteElementString("ErrorCode", "-1");
            xmlWriter.WriteElementString("Message", "Could not delete DVD please try again");
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();
            xmlWriter.Close();
         }
         return sw.ToString();

      }
      public string Undo(String request,Exception ex=null)
      {
         StringWriter sw = new StringWriter();
         XmlTextWriter xmlWriter = new XmlTextWriter(sw);
       
       
         DVD_ID = utilities.getNodeText("//Request/ID",request );
   db.Undelete(Convert.ToInt64(DVD_ID));
   if (ex == null)
   {
         Session.Logmessage("Record recovered!" + "DVD ID" + DVD_ID + "recovered");

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("Response");
            xmlWriter.WriteElementString("ErrorCode", "0");
            xmlWriter.WriteElementString("Message", " DVD ID " + DVD_ID + " recovered");
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();
            xmlWriter.Close();
         
         }
         else
         {
               Session.Logmessage("Error: Error Occurred When recovering DVD");
            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("Response");
            xmlWriter.WriteElementString("ErrorCode", "-1");
            xmlWriter.WriteElementString("Message", "Could not recover DVD please try again");
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();
            xmlWriter.Close();
            
         }
   return sw.ToString();
      }

      public string Purge(String request, Exception ex=null)
      {
         StringWriter sw = new StringWriter();
         XmlTextWriter xmlWriter = new XmlTextWriter(sw);
          if (ex == null)
        {

         DVD_ID = utilities.getNodeText("//Request/ID", request);
       db.Purge(Convert.ToInt64(DVD_ID));
       
             Session.Logmessage("Record purged!" + "DVD ID" + DVD_ID + "purged");

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("Response");
            xmlWriter.WriteElementString("ErrorCode", "0");
            xmlWriter.WriteElementString("Message", " DVD ID " + DVD_ID + " purged ");
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();
            xmlWriter.Close();
         }
         else
         {
               Session.Logmessage("Error: Error Occurred When Purging DVD");
            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("Response");
            xmlWriter.WriteElementString("ErrorCode", "-1");
            xmlWriter.WriteElementString("Message", " Could not purge DVD please try again ");
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();
            xmlWriter.Close();
         }
       return sw.ToString();
      }

      public string SelectID(String request, Exception ex = null)
      {
    
       StringWriter sw = new StringWriter();
         XmlTextWriter xmlWriter = new XmlTextWriter(sw);
         if (ex == null)
         {
         genrelist = db.GenreList();
        DVD_ID = utilities.getNodeText("//Request/ID", request);
         OleDbDataReader dr = db.SelectID(Convert.ToInt64(DVD_ID));
         returnedID = dr["DVD_ID"].ToString();
         DVD_title = dr["DVD_Title"].ToString();
         DVD_first = dr["DVD_First"].ToString();
        DVD_last = dr["DVD_Last"].ToString();
        DVD_first2 = dr["DVD_First2"].ToString();
         DVD_last2 = dr["DVD_Last2"].ToString();
         DVD_cp = dr["DVD_Company"].ToString();
         DVD_rt = dr["DVD_Runtime"].ToString();
         DVD_type = dr["DVD_Type"].ToString();
         DVD_stat =dr["DVD_Stat"].ToString();
         genreID = Convert.ToInt16(dr["DVD_Genre"]);
         foreach (genre moviegenre in genrelist)
         {
            if (moviegenre.getGenreID().Equals(genreID))
            {
               description = moviegenre.getGenreDescription();
               setGenreDescription(description);
               
            }
         }
         
                  Session.Logmessage("record found! ");

               xmlWriter.WriteStartDocument();
               xmlWriter.WriteStartElement("Response");
               xmlWriter.WriteElementString("ErrorCode", "0");
               xmlWriter.WriteElementString("ID", returnedID);
               xmlWriter.WriteElementString("Title", DVD_title);
               xmlWriter.WriteElementString("First", DVD_first);
               xmlWriter.WriteElementString("Last", DVD_last);
               xmlWriter.WriteElementString("First2", DVD_first2);
               xmlWriter.WriteElementString("Last2", DVD_last2);
               xmlWriter.WriteElementString("Company", DVD_cp);
               xmlWriter.WriteElementString("Genre", genreID.ToString());
               xmlWriter.WriteElementString("Description",getGenreDescription());
               xmlWriter.WriteElementString("Runtime", DVD_rt);
               xmlWriter.WriteElementString("Type", DVD_type);
               xmlWriter.WriteElementString("Status", DVD_stat);
               xmlWriter.WriteEndElement();
               xmlWriter.WriteEndDocument();
               xmlWriter.Close();
            }
            else
            {
                  Session.Logmessage("no record found! ");
            
            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("Response");
            xmlWriter.WriteElementString("ErrorCode", "-1");
            xmlWriter.WriteElementString("Message", " could not find DVD information. Please try again ");
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();
            xmlWriter.Close();
         }
         return sw.ToString();
      }

      public string SelectTitle (String request, Exception ex = null)
      {
        
           StringWriter sw = new StringWriter();
         XmlTextWriter xmlWriter = new XmlTextWriter(sw);
         if (ex == null)
         {
            genrelist = db.GenreList();
            DVD_title = utilities.getNodeText("//Request/Title", request);
            OleDbDataReader dr = db.SelectTitle(DVD_title);
            returnedID = dr["DVD_ID"].ToString();
            DVD_title = dr["DVD_Title"].ToString();
            DVD_first = dr["DVD_First"].ToString();
            DVD_last = dr["DVD_Last"].ToString();
            DVD_first2 = dr["DVD_First2"].ToString();
            DVD_last2 = dr["DVD_Last2"].ToString();
            DVD_cp = dr["DVD_Company"].ToString();
            DVD_rt = dr["DVD_Runtime"].ToString();
            DVD_type = dr["DVD_Type"].ToString();
            DVD_stat = dr["DVD_Stat"].ToString();
            genreID = Convert.ToInt16(dr["DVD_Genre"]);
            foreach (genre moviegenre in genrelist)
            {
               if (moviegenre.getGenreID().Equals(genreID))
               {
                  description = moviegenre.getGenreDescription();
                  setGenreDescription(description);

               }
            }


            Session.Logmessage("record found! ");

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("Response");
            xmlWriter.WriteElementString("ErrorCode", "0");
            xmlWriter.WriteElementString("ID", returnedID);
            xmlWriter.WriteElementString("Title", DVD_title);
            xmlWriter.WriteElementString("First", DVD_first);
            xmlWriter.WriteElementString("Last", DVD_last);
            xmlWriter.WriteElementString("First2", DVD_first2);
            xmlWriter.WriteElementString("Last2", DVD_last2);
            xmlWriter.WriteElementString("Company", DVD_cp);
            xmlWriter.WriteElementString("Genre", genreID.ToString());
            xmlWriter.WriteElementString("Description", getGenreDescription());
            xmlWriter.WriteElementString("Runtime", DVD_rt);
            xmlWriter.WriteElementString("Type", DVD_type);
            xmlWriter.WriteElementString("Status", DVD_stat);
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();
            xmlWriter.Close();
         }
         else
         {
            Session.Logmessage("no record found! ");

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("Response");
            xmlWriter.WriteElementString("ErrorCode", "-1");
            xmlWriter.WriteElementString("Message", " could not find DVD information. Please try again ");
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();
            xmlWriter.Close();

         }
         return sw.ToString();
      
      }
      public string SearchTitle(String request, Exception ex = null)
      {
            
            StringWriter sw = new StringWriter();
         XmlTextWriter xmlWriter = new XmlTextWriter(sw);
         
        
         if (ex == null)
         {
            DVD_title= utilities.getNodeText("//Request/Title", request);
            DVD[] titlelist = db.SearchTitle(DVD_title);
               Session.Logmessage(" titles found! ");

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("Response");
            xmlWriter.WriteElementString("ErrorCode", "0");
            xmlWriter.WriteStartElement("DVDS");
            foreach(DVD movie in titlelist)
            {
               xmlWriter.WriteStartElement("DVD");
               xmlWriter.WriteElementString("ID", movie.getID());
               xmlWriter.WriteElementString("Title", movie.getTitle());
               xmlWriter.WriteEndElement();                                // end student
            }
            xmlWriter.WriteEndElement();                                // end majors
            xmlWriter.WriteEndElement();                                // end response
            xmlWriter.WriteEndDocument();
            xmlWriter.Close();

         }

         else
         {
               Session.Logmessage("titles not found ");

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("Response");
            xmlWriter.WriteElementString("ErrorCode", "-1");
            xmlWriter.WriteElementString("Message", " could not find information. Please try again ");
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();
            xmlWriter.Close();
         }
         return sw.ToString();
      }
      public string SearchActor1(String request, Exception ex = null)
      {
        
         StringWriter sw = new StringWriter();
         XmlTextWriter xmlWriter = new XmlTextWriter(sw);

         if (ex == null)
         { 
            DVD_last = utilities.getNodeText("//Request/Last", request);
         DVD[] lastnamelist = db.SearchActor1(DVD_last);
               Session.Logmessage(" last names found! ");

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("Response");
            xmlWriter.WriteElementString("ErrorCode", "0");
            xmlWriter.WriteStartElement("DVDS");
            foreach (DVD movie in lastnamelist)
            {
               xmlWriter.WriteStartElement("DVD");
              
               xmlWriter.WriteElementString("First", movie.getFirstname());
               xmlWriter.WriteElementString("Last", movie.getLastname());
               xmlWriter.WriteElementString("Title", movie.getTitle());
               xmlWriter.WriteEndElement();                                // end student
            }
            xmlWriter.WriteEndElement();                                // end majors
            xmlWriter.WriteEndElement();                                // end response
            xmlWriter.WriteEndDocument();
            xmlWriter.Close();
            
         }

         else
         {
               Session.Logmessage("last names not found ");

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("Response");
            xmlWriter.WriteElementString("ErrorCode", "-1");
            xmlWriter.WriteElementString("Message", " could not find information. Please try again ");
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();
            xmlWriter.Close();
         }
         return sw.ToString();
      }
      public string SearchActor2(String request, Exception ex = null)
      {
        
         StringWriter sw = new StringWriter();
         XmlTextWriter xmlWriter = new XmlTextWriter(sw);

         if (ex == null)
         {
             DVD_last2 = utilities.getNodeText("//Request/Last2", request);
         DVD[] lastname2list = db.SearchActor2(DVD_last2);
               Session.Logmessage(" last names found! ");

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("Response");
            xmlWriter.WriteElementString("ErrorCode", "0");
            xmlWriter.WriteStartElement("DVDS");
            foreach (DVD movie in lastname2list)
            {
               xmlWriter.WriteStartElement("DVD");

               xmlWriter.WriteElementString("First2", movie.getFirstname2());
               xmlWriter.WriteElementString("Last2", movie.getLastname2());
               xmlWriter.WriteElementString("Title", movie.getTitle());
               xmlWriter.WriteEndElement();                                // end student
            }
            xmlWriter.WriteEndElement();                                // end majors
            xmlWriter.WriteEndElement();                                // end response
            xmlWriter.WriteEndDocument();
            xmlWriter.Close();
         }

         else
         {
               Session.Logmessage("last names not found ");

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("Response");
            xmlWriter.WriteElementString("ErrorCode", "-1");
            xmlWriter.WriteElementString("Message", " could not find information. Please try again ");
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();
            xmlWriter.Close();
         }
         return sw.ToString();
      }
      public string SearchCompany(String request, Exception ex = null)
      {
        
         StringWriter sw = new StringWriter();
         XmlTextWriter xmlWriter = new XmlTextWriter(sw);

         if (ex == null)
         {
             DVD_cp = utilities.getNodeText("//Request/Company", request);
         DVD[] companieslist = db.SearchCompany(DVD_cp);
               Session.Logmessage(" companies found! ");

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("Response");
            xmlWriter.WriteElementString("ErrorCode", "0");
            xmlWriter.WriteStartElement("DVDS");
            foreach (DVD movie in companieslist)
            {
               xmlWriter.WriteStartElement("DVD");

               xmlWriter.WriteElementString("Company", movie.getCompany());
               xmlWriter.WriteElementString("Title", movie.getTitle());
               xmlWriter.WriteEndElement();                                // end student
            }
            xmlWriter.WriteEndElement();                                // end majors
            xmlWriter.WriteEndElement();                                // end response
            xmlWriter.WriteEndDocument();
            xmlWriter.Close();

         }

         else
         {
               Session.Logmessage("companies not found ");

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("Response");
            xmlWriter.WriteElementString("ErrorCode", "-1");
            xmlWriter.WriteElementString("Message", " could not find information. Please try again ");
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();
            xmlWriter.Close();
         }
         return sw.ToString();
      }
        
      public string SearchGenre(String request, Exception ex = null)
      {

         StringWriter sw = new StringWriter();
           XmlTextWriter xmlWriter = new XmlTextWriter(sw);
         if (ex == null)
         {
         genrelist = db.GenreList();
         DVD_genre= utilities.getNodeText("//Request/Genre", request);
         DVD[] descriptions = db.SearchGenre (Convert.ToInt16(DVD_genre));
         genreID = Convert.ToInt16(DVD_genre);
       
         foreach (genre moviegenre in genrelist)
         {
            if (moviegenre.getGenreID().Equals(genreID))
            {
               description = moviegenre.getGenreDescription();
               setGenreDescription(description);

            }
         }
        

               Session.Logmessage(" movie genres found! ");

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("Response");
            xmlWriter.WriteElementString("ErrorCode", "0");
            xmlWriter.WriteStartElement("DVDS");
            foreach (DVD movie in descriptions)
            {
               xmlWriter.WriteStartElement("DVD");

               xmlWriter.WriteElementString("Description",getGenreDescription());
               xmlWriter.WriteElementString("Title", movie.getTitle());
               xmlWriter.WriteEndElement();                                // end student
            }
            xmlWriter.WriteEndElement();                                // end majors
            xmlWriter.WriteEndElement();                                // end response
            xmlWriter.WriteEndDocument();
            xmlWriter.Close();
         }

         else
         {
               Session.Logmessage("movie genres not found ");

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("Response");
            xmlWriter.WriteElementString("ErrorCode", "-1");
            xmlWriter.WriteElementString("Message", " could not find information. Please try again ");
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();
            xmlWriter.Close();
         }
         return sw.ToString();
      }
      public string SearchRuntime(String request, Exception ex = null)
      {
         StringWriter sw = new StringWriter();
      
         XmlTextWriter xmlWriter = new XmlTextWriter(sw);

         if (ex == null)
         {
             DVD_rt = utilities.getNodeText("//Request/Runtime", request);
         DVD[] timeslist = db.SearchRuntime (Convert.ToInt16(DVD_rt));
               Session.Logmessage(" Runtimes found! ");

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("Response");
            xmlWriter.WriteElementString("ErrorCode", "0");
            xmlWriter.WriteStartElement("DVDS");
            foreach (DVD movie in timeslist)
            {
               xmlWriter.WriteStartElement("DVD");

               xmlWriter.WriteElementString("Runtime", movie.getRuntime().ToString());
               xmlWriter.WriteElementString("Title", movie.getTitle());
               xmlWriter.WriteEndElement();                                // end student
            }
            xmlWriter.WriteEndElement();                                // end majors
            xmlWriter.WriteEndElement();                                // end response
            xmlWriter.WriteEndDocument();
            xmlWriter.Close();
         }

         else
         {
               Session.Logmessage("Runtimes not found ");

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("Response");
            xmlWriter.WriteElementString("ErrorCode", "-1");
            xmlWriter.WriteElementString("Message", " could not find information. Please try again ");
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();
            xmlWriter.Close();
         }
         return sw.ToString();
      }
      public string SearchType(String request, Exception ex = null)
      {
         StringWriter sw = new StringWriter();
         
         XmlTextWriter xmlWriter = new XmlTextWriter(sw);

         if (ex == null)
         {
            DVD_type = utilities.getNodeText("//Request/Type", request);
         DVD[] typeslist= db.SearchType(Convert.ToChar(DVD_type));
               Session.Logmessage(" DVD types found! ");

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("Response");
            xmlWriter.WriteElementString("ErrorCode", "0");
            xmlWriter.WriteStartElement("DVDS");
            foreach (DVD movie in typeslist)
            {
               xmlWriter.WriteStartElement("DVD");

               xmlWriter.WriteElementString("Type", movie.getType().ToString());
               xmlWriter.WriteElementString("Title", movie.getTitle());
               xmlWriter.WriteEndElement();                                // end student
            }
            xmlWriter.WriteEndElement();                                // end majors
            xmlWriter.WriteEndElement();                                // end response
            xmlWriter.WriteEndDocument();
            xmlWriter.Close();
         }

         else
         {
               Session.Logmessage("DVD types not found ");

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("Response");
            xmlWriter.WriteElementString("ErrorCode", "-1");
            xmlWriter.WriteElementString("Message", " could not find information. Please try again ");
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();
            xmlWriter.Close();
         }
         return sw.ToString();
      }
      public string SearchStatus(String request, Exception ex = null)
      {
         StringWriter sw = new StringWriter();
   
         XmlTextWriter xmlWriter = new XmlTextWriter(sw);

         if (ex == null)
         {
             DVD_stat = utilities.getNodeText("//Request/Status", request);
         DVD[] statuslist = db.SearchStatus(Convert.ToChar(DVD_stat));
               Session.Logmessage(" DVD statuses found! ");

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("Response");
            xmlWriter.WriteElementString("ErrorCode", "0");
            xmlWriter.WriteStartElement("DVDS");
            foreach (DVD movie in statuslist)
            {
               xmlWriter.WriteStartElement("DVD");

               xmlWriter.WriteElementString("Status", movie.getStatus().ToString());
               xmlWriter.WriteElementString("Title", movie.getTitle());
               xmlWriter.WriteElementString("ID", movie.getID());
               xmlWriter.WriteEndElement();                                // end student
            }
            xmlWriter.WriteEndElement();                                // end majors
            xmlWriter.WriteEndElement();                                // end response
            xmlWriter.WriteEndDocument();
            xmlWriter.Close();
         }

         else
         {
               Session.Logmessage("DVD statuses not found ");

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("Response");
            xmlWriter.WriteElementString("ErrorCode", "-1");
            xmlWriter.WriteElementString("Message", " could not find information. Please try again ");
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();
            xmlWriter.Close();
         }
         return sw.ToString();
      }
      public string GetGenres(String request, Exception ex = null) 
      {
         StringWriter sw = new StringWriter();
   
         XmlTextWriter xmlWriter = new XmlTextWriter(sw);
        
         if (ex == null)
         {
          genrelist = db. GenreList();
               Session.Logmessage(" genres found! ");

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("Response");
            xmlWriter.WriteElementString("ErrorCode", "0");
            xmlWriter.WriteStartElement("Genres");
            foreach( genre Genre in genrelist)
            {
               xmlWriter.WriteStartElement("Genre");
               xmlWriter.WriteElementString("ID", Genre.getGenreID().ToString());
               xmlWriter.WriteElementString("Description",Genre.getGenreDescription());
               xmlWriter.WriteEndElement();                                // end student
            }
            xmlWriter.WriteEndElement();                                // end majors
            xmlWriter.WriteEndElement();                                // end response
            xmlWriter.WriteEndDocument();
            xmlWriter.Close();

         }

         else
         {
               Session.Logmessage("genres not found ");

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("Response");
            xmlWriter.WriteElementString("ErrorCode", "-1");
            xmlWriter.WriteElementString("Message", " could not find information. Please try again ");
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();
            xmlWriter.Close();
         }
         return sw.ToString();
      }
   }
      

}

