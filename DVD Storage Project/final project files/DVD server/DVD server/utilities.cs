using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
namespace DVD_server
{
   class utilities
   {
      public static String getNodeText(String xPath, String xml)
      {
         String value = String.Empty;
         XmlNode xNode = null;
         XmlDocument xmlDoc = new XmlDocument();

         try
         {
            // load the xml from a string
            xmlDoc.LoadXml(xml);

            xNode = xmlDoc.SelectSingleNode(xPath);		// extract a single node based upon the XPATH string provided 

            if (xNode != null)
            {
               value = xNode.InnerText;	            // save the text; otherwise return null
            }
         }
         catch (XmlException ex)
         {
             Session. Logmessage("XML Parsing Error: {0}", ex.Message);
            value = null;
         }
         catch (Exception ex)
         {
            Session.Logmessage("General Error: {0}", ex.Message);
            value = null;
         }


         return value;
      }


   }
}