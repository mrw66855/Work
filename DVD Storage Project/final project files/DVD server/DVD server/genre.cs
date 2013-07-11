using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DVD_server
{
   class genre
   {
      private short DVD_Genre_ID;
      private String DVD_Genre_Descript;
        public genre()
        {
            DVD_Genre_ID= 0;
            DVD_Genre_Descript ="unknown";
        }

        public genre(short code, string description)
        {
           DVD_Genre_ID = code;
           DVD_Genre_Descript = description; 
        }

      public short getGenreID()
      {
         
         return DVD_Genre_ID;
      }
      public void setGenre(short genreID)
      {
         if (genreID >= 0 && genreID < 30)
         {
            DVD_Genre_ID = genreID;
         }
         else
         {
            DVD_Genre_ID = 0;
         }
      }

      public string getGenreDescription()
      {
         return DVD_Genre_Descript;
      }
      public void setGenreDescription(string description)
      {
         if (description.Length > 0 && description.Length <= 20)
         {
            DVD_Genre_Descript = description;

         }
         else
         {
            DVD_Genre_Descript = "unknown";
         }
      }
   }
}