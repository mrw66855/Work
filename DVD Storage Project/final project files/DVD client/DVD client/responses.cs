using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
namespace DVD_client
{
   class responses
   {
      private string ID;
      private string title;
      private string first;
      private string last;
      private string first2;
      private string last2;
      private string company;
      private string genre;
      private string description;
      private string runtime;
      private string type;
      private string status;
      private string code;
      private string message;
      const int value1 = 0;
      const int value2 = 1;
      const int value3 = 2;

      public void Add(string Response)
      {
         ID = utilities.getNodeText("//Response/ID", Response);
         if (!ID.Equals(String.Empty))
         {
            Console.WriteLine();
            Console.WriteLine("DVD was added with  an ID of {0} ", ID);
         }
         else
         {
            Console.WriteLine();
            message = utilities.getNodeText("//Response/Message", Response);
            Console.WriteLine(message);
         }
      }
      public void Modify(String Response)
      {
         code = utilities.getNodeText("//Response/ErrorCode", Response);
         message = utilities.getNodeText("//Response/Message", Response);
         if (code.Equals("0"))
         {
            Console.WriteLine();
            Console.WriteLine(message);
            Console.WriteLine();
         }
         else
         {
            Console.WriteLine();
            Console.WriteLine(message);
            Console.WriteLine();
         }
      }
      public void Select(String Response)
      {
         code = utilities.getNodeText("//Response/ErrorCode", Response);
         if (code.Equals("0"))
         {
            code = utilities.getNodeText("//Response/ErrorCode", Response);
            ID = utilities.getNodeText("//Response/ID", Response);
            title = utilities.getNodeText("//Response/Title", Response);
            first = utilities.getNodeText("//Response/First", Response);
            last = utilities.getNodeText("//Response/Last", Response);
            first2 = utilities.getNodeText("//Response/First2", Response);
            last2 = utilities.getNodeText("//Response/Last2", Response);
            company = utilities.getNodeText("//Response/Company", Response);
            genre = utilities.getNodeText("//Response/Genre", Response);
            description = utilities.getNodeText("//Response/Description", Response);
            runtime = utilities.getNodeText("//Response/Runtime", Response);
            type = utilities.getNodeText("//Response/Type", Response);
            status = utilities.getNodeText("//Response/Status", Response);
            Console.WriteLine();
            Console.WriteLine("DVD ID: {0}", ID);
            Console.WriteLine("Title: {0}", title);
            Console.WriteLine("First Actor's Name: {0} {1}", first, last);
            Console.WriteLine("Second Actor's Name: {0} {1}", first2, last2);
            Console.WriteLine("Production Company: {0}", company);
            Console.WriteLine("Genre Code: {0},Genre: {1}", genre, description);
            Console.WriteLine("Runtime: {0} minutes", runtime);
            Console.WriteLine("Type {0}", type);
            Console.WriteLine("Status: {0}", status);
         }
         else
         {
            Console.WriteLine();
            message = utilities.getNodeText("//Response/Message", Response);
            Console.WriteLine(message);
         }
      }
      public string[] Generelist(String Response)
      {
         LinkedList<string> list = new LinkedList<string>();
         XmlDocument xmlDoc = new XmlDocument();
         xmlDoc.LoadXml(Response);

         code = utilities.getNodeText("//Response/ErrorCode", Response);
         if (code.Equals("0"))
         {

            XmlNodeList nodeList = xmlDoc.SelectNodes("//Response/Genres/Genre");

            ID = String.Empty;
            description = String.Empty;



            foreach (XmlNode node in nodeList)
            {
               ID = node.ChildNodes.Item(value1).InnerText;
               description = node.ChildNodes.Item(value2).InnerText;
               list.AddLast(description);
            }
         }
         else
         {
            message = utilities.getNodeText("//Response/Message", Response);
            list.AddLast(message);
         }

         return list.ToArray();
      }
      public string[] SearchTitle(String Response)
         {
            LinkedList<string> titleresults = new LinkedList<string>();
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(Response);

            code = utilities.getNodeText("//Response/ErrorCode", Response);
            if (code.Equals("0"))
            {

               XmlNodeList nodeList = xmlDoc.SelectNodes("//Response/DVDS/DVD");

               ID = String.Empty;
              title = String.Empty;



               foreach (XmlNode node in nodeList)
               {
                  ID = node.ChildNodes.Item(value1).InnerText;
                  title = node.ChildNodes.Item(value2).InnerText;
                  titleresults.AddLast(ID);
                  titleresults.AddLast(title);
               }
            }
            else
            {
               message = utilities.getNodeText("//Response/Message", Response);
               titleresults.AddLast(message);
            }

            return titleresults.ToArray();
         }
      public string[] SearchActor1(String Response)
      {
         LinkedList<string> actor1results = new LinkedList<string>();
         XmlDocument xmlDoc = new XmlDocument();
         xmlDoc.LoadXml(Response);

         code = utilities.getNodeText("//Response/ErrorCode", Response);
         if (code.Equals("0"))
         {

            XmlNodeList nodeList = xmlDoc.SelectNodes("//Response/DVDS/DVD");

            first = string.Empty;
            last = string.Empty;
            title = String.Empty;



            foreach (XmlNode node in nodeList)
            {
              first = node.ChildNodes.Item(value1).InnerText;
              last = node.ChildNodes.Item(value2).InnerText;
               title = node.ChildNodes.Item(value3).InnerText;
              actor1results.AddLast(first);
              actor1results.AddLast(last);
               actor1results.AddLast(title);
            }
         }
         else
         {
            message = utilities.getNodeText("//Response/Message", Response);
            actor1results.AddLast(message);
         }

         return actor1results.ToArray();
      }
      public string[] SearchActor2(String Response)
      {
         LinkedList<string> actor2results = new LinkedList<string>();
         XmlDocument xmlDoc = new XmlDocument();
         xmlDoc.LoadXml(Response);

         code = utilities.getNodeText("//Response/ErrorCode", Response);
         if (code.Equals("0"))
         {

            XmlNodeList nodeList = xmlDoc.SelectNodes("//Response/DVDS/DVD");

            first2 = string.Empty;
            last2 = string.Empty;
            title = String.Empty;



            foreach (XmlNode node in nodeList)
            {
               first2 = node.ChildNodes.Item(value1).InnerText;
               last2 = node.ChildNodes.Item(value2).InnerText;
               title = node.ChildNodes.Item(value3).InnerText;
               actor2results.AddLast(first2);
               actor2results.AddLast(last2);
               actor2results.AddLast(title);
            }
         }
         else
         {
            message = utilities.getNodeText("//Response/Message", Response);
            actor2results.AddLast(message);
         }

         return actor2results.ToArray();
      }
      public string[] SearchCompany(String Response)
      {
         LinkedList<string> companyresults = new LinkedList<string>();
         XmlDocument xmlDoc = new XmlDocument();
         xmlDoc.LoadXml(Response);

         code = utilities.getNodeText("//Response/ErrorCode", Response);
         if (code.Equals("0"))
         {

            XmlNodeList nodeList = xmlDoc.SelectNodes("//Response/DVDS/DVD");

            company = string.Empty;
            title = String.Empty;



            foreach (XmlNode node in nodeList)
            {
               company = node.ChildNodes.Item(value1).InnerText;
               title = node.ChildNodes.Item(value2).InnerText;
               companyresults.AddLast(company);
             companyresults.AddLast(title);
            }
         }
         else
         {
            message = utilities.getNodeText("//Response/Message", Response);
         companyresults.AddLast(message);
         }

         return companyresults.ToArray();
      }
      public string[] SearchGenre(String Response)
      {
         LinkedList<string>  genreresults= new LinkedList<string>();
         XmlDocument xmlDoc = new XmlDocument();
         xmlDoc.LoadXml(Response);

         code = utilities.getNodeText("//Response/ErrorCode", Response);
         if (code.Equals("0"))
         {

            XmlNodeList nodeList = xmlDoc.SelectNodes("//Response/DVDS/DVD");

            description = string.Empty;
            title = String.Empty;



            foreach (XmlNode node in nodeList)
            {
               description = node.ChildNodes.Item(value1).InnerText;
               title = node.ChildNodes.Item(value2).InnerText;
                genreresults.AddLast(description);
                genreresults.AddLast(title);
            }
         }
         else
         {
            message = utilities.getNodeText("//Response/Message", Response);
           genreresults.AddLast(message);
         }

         return genreresults.ToArray();
      }
      public string[] SearchRuntime(String Response)
      {
         LinkedList<string> timeresults = new LinkedList<string>();
         XmlDocument xmlDoc = new XmlDocument();
         xmlDoc.LoadXml(Response);

         code = utilities.getNodeText("//Response/ErrorCode", Response);
         if (code.Equals("0"))
         {

            XmlNodeList nodeList = xmlDoc.SelectNodes("//Response/DVDS/DVD");

           runtime= String.Empty;
            title = String.Empty;



            foreach (XmlNode node in nodeList)
            {
               runtime = node.ChildNodes.Item(value1).InnerText;
               title = node.ChildNodes.Item(value2).InnerText;
             timeresults.AddLast(runtime);
               timeresults.AddLast(title);
            }
         }
         else
         {
            message = utilities.getNodeText("//Response/Message", Response);
            timeresults.AddLast(message);
         }

         return timeresults.ToArray();
      }
      public string[] SearchType(String Response)
      {
         LinkedList<string> typeresults = new LinkedList<string>();
         XmlDocument xmlDoc = new XmlDocument();
         xmlDoc.LoadXml(Response);

         code = utilities.getNodeText("//Response/ErrorCode", Response);
         if (code.Equals("0"))
         {

            XmlNodeList nodeList = xmlDoc.SelectNodes("//Response/DVDS/DVD");

            type = String.Empty;
            title = String.Empty;



            foreach (XmlNode node in nodeList)
            {
               type = node.ChildNodes.Item(value1).InnerText;
               title = node.ChildNodes.Item(value2).InnerText;
               typeresults.AddLast(type);
              typeresults.AddLast(title);
            }
         }
         else
         {
            message = utilities.getNodeText("//Response/Message", Response);
            typeresults.AddLast(message);
         }

         return typeresults.ToArray();
      }
      public string[] SearchStatus(String Response)
      {
         LinkedList<string> statusresults = new LinkedList<string>();
         XmlDocument xmlDoc = new XmlDocument();
         xmlDoc.LoadXml(Response);

         code = utilities.getNodeText("//Response/ErrorCode", Response);
         if (code.Equals("0"))
         {

            XmlNodeList nodeList = xmlDoc.SelectNodes("//Response/DVDS/DVD");

            ID = string.Empty;
            status = string.Empty;
            title = String.Empty;



            foreach (XmlNode node in nodeList)
            {
               status= node.ChildNodes.Item(value1).InnerText;
               title = node.ChildNodes.Item(value2).InnerText;
               ID = node.ChildNodes.Item(value3).InnerText;
              statusresults.AddLast(status);
               statusresults.AddLast(ID);
               statusresults.AddLast(title);
            }
         }
         else
         {
            message = utilities.getNodeText("//Response/Message", Response);
           statusresults.AddLast(message);
         }

         return statusresults.ToArray();
      }
      }
   }


