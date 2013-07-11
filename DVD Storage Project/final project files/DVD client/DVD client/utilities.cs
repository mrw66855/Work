using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Net;
using System.Net.Sockets;
namespace DVD_client
{
   class utilities
   {
     public static StreamReader reader;
     public static StreamWriter writer;
     public static TcpClient DVDclient = null;

      public static string getNodeText(string xPath, XmlDocument xDoc)
      {
         String value = String.Empty;
         XmlNode xNode = null;
         try
         {
            xNode = xDoc.SelectSingleNode(xPath);		// extract a single node based upon the xpath string provided 

            if (xNode != null)
            {
               value = xNode.InnerText;	// save the text; otherwise return null
            }
         }
         catch (XmlException ex)
         {
            Console.Clear();
            Console.WriteLine("XML Parsing Error: {0}", ex.Message);
            value = null;
         }
         catch (Exception ex)
         {
            Console.Clear();
            Console.WriteLine("General Error: {0}", ex.Message);
            value = null;
         }
         return value;
      }

      public static String getNodeText(String xPath, String xml)
      {
         XmlDocument xmlDoc = new XmlDocument();

         String Value = String.Empty;

         try
         {
            xmlDoc.LoadXml(xml);
            Value = getNodeText(xPath, xmlDoc);
         }
         catch (XmlException ex)
         {
            Console.Clear();
            Console.WriteLine("XML Parsing Error: {0}", ex.Message);
            Value = String.Empty;
         }
         catch (Exception ex)
         {
            Console.Clear();
            Console.WriteLine("General Error: {0}", ex.Message);
            Value = String.Empty;
         }

         return Value;
      }
      public static void Connect()
      {
         DVDclient = new TcpClient("localhost", 5000);
         reader = new StreamReader(DVDclient.GetStream());
         writer= new StreamWriter(DVDclient.GetStream());
        writer.AutoFlush = true;
        
        
      }
      public static void Disconnect()
      {
         writer.WriteLine("<Request><Action>disconnect</Action></Request>");

         reader.ReadLine();

         writer.Close();
         reader.Close();
         DVDclient.Close();
      }
   }
}