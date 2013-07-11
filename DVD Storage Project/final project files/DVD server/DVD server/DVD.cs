using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Text.RegularExpressions;
namespace DVD_server
{
   class DVD
   {
      private string DVD_ID;
      private string DVD_title;
      private string DVD_first;
      private string DVD_last;
      private string DVD_first2;
      private string DVD_last2;
      private string DVD_cp;
      private short DVD_genre;
      private short DVD_rt;
      private char DVD_type;
      private char DVD_stat;
     
      public DVD()
      {

         DVD_ID = String.Empty;
         DVD_title = "Title";
         DVD_first = "First";
         DVD_last = "Last";
         DVD_first2 = "First2";
         DVD_last2 = "Last2";
         DVD_cp = "Company";
         DVD_genre = 0;
         DVD_rt = 0;
         DVD_type = 'U';
         DVD_stat = 'E';
      }
      public DVD(string ID, string title, string first, string last, string first2, string last2, string company, short genre, short runtime, char type, char status)
      {
         setID(ID);
         setTitle(title);
         setLastname(last);
         setFirstname(first);
         setFirstname2(first2);
         setLastname2(last2);
         setCompany(company);
         setGenre(genre);
         setRuntime(runtime);
         setStatus(status);
         setType(type);
      }

      public string getID()
      {
         return DVD_ID;
      }
      public void setID(string ID)
      {

         if (ID == null)
         {
            DVD_ID = "0";
         }
         else if (ID.Length > 0)
         {
            DVD_ID = ID;
         }
         else
         {
            DVD_ID = "0";
         }

      }
      public string getTitle()
      {
         return DVD_title;
      }
      public void setTitle(string title)
      {
         if (title == null)
         {
            DVD_title = "Title";
         }


         else if (title.Length > 0 && title.Length <= 50)
         {
            DVD_title = title;
         }

         else
         {
            DVD_title = "Title";
         }
      }
      public string getFirstname()
      {
         return DVD_first;
      }
      public void setFirstname(string first)
      {
         if (first == null)
         {
            DVD_first = "First";
         }
         else if (first.Length > 0 && first.Length <= 30)
         {
            DVD_first = first;

         }

         else
         {
            DVD_first = "First";
         }

      }
      public string getLastname()
      {
         return DVD_last;
      }
      public void setLastname(string last)
      {
         if (last == null)
         {
            DVD_last = "Last";
         }
         else if (last.Length > 0 && last.Length <= 30)
         {
            DVD_last = last;
         }

         else
         {
            DVD_last = "Last";
         }
      }
      public string getFirstname2()
      {
         return DVD_first2;
      }
      public void setFirstname2(string first2)
      {
         if (first2 == null)
         {
            DVD_first2 = "First2";
         }
         else if (first2.Length > 0 && first2.Length <= 30)
         {
            DVD_first2 = first2;

         }

         else
         {
            DVD_first2 = "First2";
         }
      }
      public string getLastname2()
      {
         return DVD_last2;
      }
      public void setLastname2(string last2)
      {
         if (last2 == null)
         {
            DVD_last2 = "Last2";
         }
         else if (last2.Length > 0 && last2.Length <= 30)
         {
            DVD_last2 = last2;
         }

         else
         {
            DVD_last2 = "Last2";
         }

      }
      public string getCompany()
      {
         return DVD_cp;
      }
      public void setCompany(string company)
      {
         if (company == null)
         {
            DVD_cp = "Company";
         }

         else if (company.Length > 0 && company.Length <= 40)
         {
            DVD_cp = company;
         }
         else if (company == null)
         {
            DVD_cp = "Company";
         }
         else
         {
            DVD_cp = "Company";
         }
      }
      public short getGenre()
      {
         return DVD_genre;
      }
      public void setGenre(short genre)
      {
      
            if (genre >= 0 && genre < 30)
            {
               DVD_genre = genre;
            }

            else
            {
               DVD_genre = 0;
            }
      }
      public short getRuntime()
      {
         return DVD_rt;
      }
      public void setRuntime(short runtime)
      {
        
           
            if (runtime >= 0 && runtime <= 300)
            {
               DVD_rt = runtime;
            }
            else
            {
               DVD_rt = 0;
            }
         }
      
      public char getType()
      {
         return DVD_type;
      }
      public void setType(char type)
      {
         
            if (type == 'D' || type == 'B' || type == 'U')
            {
               DVD_type = type;
            }

            else
            {
               DVD_type = 'U';
            }
         }
 
      public char getStatus()
      {
         return DVD_stat;
      }
      public void setStatus(char status)
      {
        
        
            if (status == 'E' || status == 'N')
            {
               DVD_stat = status;
            }

            else
            {
               DVD_stat = 'E';
            }
         }

      }
   }
