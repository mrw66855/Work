using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
 using System.IO;
using System.Xml;
using System.Data;
using System.Data.OleDb;
namespace DVD_server
{
   class database
   {

              string ID;
      string newID;
         string title;
         string first;
         string last;
         string first2;
         string last2;
         string company;
         short genre;
         short runtime;
         char type;
         char status;
      public genre[]  GenreList()
      {
         String strSQL = String.Empty;
         LinkedList<genre> list = new LinkedList<genre>();

       
            String connString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
              @"Data Source=" + System.Environment.CurrentDirectory + @"\Data\DVDB_001_DVD_master.accdb";

            OleDbConnection cn = new OleDbConnection(connString);
               Session.Logmessage("connection string " + connString);
            strSQL = "SELECT Genre,Description FROM DVDT_001_genre_list; ";
            OleDbCommand cm = new OleDbCommand(strSQL, cn);
            OleDbDataReader dr;

            cn.Open();

            dr = cm.ExecuteReader(CommandBehavior.CloseConnection);

            while (dr.Read())
            {
               list.AddLast(new genre(Convert.ToInt16(dr["Genre"]), dr["Description"].ToString()));
            }
         
         
         return list.ToArray();
      }
        
            
      public long Addall(String title, String first, String last, String first2, String last2, string company, short genre, short runtime, char type, char status)
      {
         string strSQL = string.Empty;


        long dvdnumber = 0;
       
            String connString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
              @"Data Source=" + System.Environment.CurrentDirectory + @"\Data\DVDB_001_DVD_master.accdb";

            OleDbConnection cn = new OleDbConnection(connString);
               Session.Logmessage("connection string " + connString);
            strSQL = "INSERT INTO DVDT_001_DVD_master";
            strSQL += "( ";
            strSQL += "DVD_Title,";
            strSQL += "DVD_First,";
            strSQL += "DVD_Last,";
            strSQL += "DVD_First2,";
            strSQL += "DVD_Last2,";
            strSQL += "DVD_Company,";
            strSQL += "DVD_Genre,";
            strSQL += "DVD_Runtime,";
            strSQL += "DVD_Type,";
            strSQL += "DVD_Stat";
            strSQL += ")";
            strSQL += "VALUES";
            strSQL += "( ";
            strSQL += "@DVD_Title,";
            strSQL += "@DVD_First,";
            strSQL += "@DVD_Last,";
            strSQL += "@DVD_First2,";
            strSQL += "@DVD_Last2,";
            strSQL += "@DVD_Company,";
            strSQL += "@DVD_Genre,";
            strSQL += "@DVD_Runtime,";
            strSQL += "@DVD_Type,";
            strSQL += "@DVD_Stat";
            strSQL += ")";
            OleDbCommand cm = new OleDbCommand(strSQL, cn);
            OleDbParameter pm = new OleDbParameter("@DVD_Title", OleDbType.Char, 50);
            pm.Direction = ParameterDirection.Input;
            pm.Value = title;
            cm.Parameters.Add(pm);

            pm = new OleDbParameter("@DVD_First", OleDbType.Char, 30);
            pm.Direction = ParameterDirection.Input;
            pm.Value = first;
            cm.Parameters.Add(pm);
            pm = new OleDbParameter("@DVD_Last", OleDbType.Char, 30);
            pm.Direction = ParameterDirection.Input;
            pm.Value = last;
            cm.Parameters.Add(pm);
            pm = new OleDbParameter("@DVD_First2", OleDbType.Char, 30);
            pm.Direction = ParameterDirection.Input;
            pm.Value = first2;
            cm.Parameters.Add(pm);
            pm = new OleDbParameter("@DVD_Last2", OleDbType.Char, 30);
            pm.Direction = ParameterDirection.Input;
            pm.Value = last2;
            cm.Parameters.Add(pm);
            pm = new OleDbParameter("@DVD_Company", OleDbType.Char, 40);
            pm.Direction = ParameterDirection.Input;
            pm.Value = company;
            cm.Parameters.Add(pm);
            pm = new OleDbParameter("@DVD_Genre", OleDbType.SmallInt);
            pm.Direction = ParameterDirection.Input;
            pm.Value = genre;
            cm.Parameters.Add(pm);
            pm = new OleDbParameter("@DVD_Runtime", OleDbType.SmallInt);
            pm.Direction = ParameterDirection.Input;
            pm.Value = runtime;
            cm.Parameters.Add(pm);
            pm = new OleDbParameter("@DVD_Type", OleDbType.Char, 1);
            pm.Direction = ParameterDirection.Input;
            pm.Value = type;
            cm.Parameters.Add(pm);
            pm = new OleDbParameter("@DVD_Stat", OleDbType.Char, 1);
            pm.Direction = ParameterDirection.Input;
            pm.Value = status;
            cm.Parameters.Add(pm);
            cn.Open();
            cm.ExecuteNonQuery();
            strSQL = "SELECT @@IDENTITY;";
            cm = new OleDbCommand(strSQL, cn);

            dvdnumber = Convert.ToInt64(cm.ExecuteScalar());
            cn.Close();

         
        
         return dvdnumber;

      }

      public long AddTitle(String title, char status)
      {
         String strSQL = string.Empty;


         long dvdnumber = 0;
        
            String connString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
               @"Data Source=" + System.Environment.CurrentDirectory + @"\Data\DVDB_001_DVD_master.accdb";

            OleDbConnection cn = new OleDbConnection(connString);
               Session.Logmessage("connection string " + connString);
            strSQL = "INSERT INTO DVDT_001_DVD_master";
            strSQL += "( ";
            strSQL += "DVD_Title,";
            strSQL += "DVD_Stat";
            strSQL += ")";
            strSQL += "VALUES";
            strSQL += "( ";
            strSQL += "@DVD_Title,";
            strSQL += "@DVD_Stat";
            strSQL += ")";
            OleDbCommand cm = new OleDbCommand(strSQL, cn);
            OleDbParameter pm = new OleDbParameter("@DVD_Title", OleDbType.Char, 50);
            pm.Direction = ParameterDirection.Input;
            pm.Value = title;
            cm.Parameters.Add(pm);
            pm = new OleDbParameter("@DVD_Stat", OleDbType.Char, 1);
            pm.Direction = ParameterDirection.Input;
            pm.Value = status;
            cm.Parameters.Add(pm);
            cn.Open();
            cm.ExecuteNonQuery();
            strSQL = "SELECT @@IDENTITY;";
            cm = new OleDbCommand(strSQL, cn);

            dvdnumber = Convert.ToInt64(cm.ExecuteScalar());
            cn.Close();

       
         return dvdnumber;
      }



      public void UpdateAll(long DVD_ID, String title, String first, String last, String first2, String last2, string company, short genre, short runtime, char type)
      {
         String strSQL = String.Empty;

       
            String connString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
                 @"Data Source=" + System.Environment.CurrentDirectory + @"\Data\DVDB_001_DVD_master.accdb";

            OleDbConnection cn = new OleDbConnection(connString);
               Session.Logmessage("connection string " + connString);

            strSQL = "update DVDT_001_DVD_master ";
         strSQL+= "SET ";
         strSQL += "DVD_Title=@DVD_Title, ";
         strSQL += "DVD_First=@DVD_First, ";
         strSQL += "DVD_Last=@DVD_Last, ";
         strSQL += "DVD_First2=@DVD_First2, ";
         strSQL += "DVD_Last2=@DVD_Last2, ";
         strSQL += "DVD_Company=@DVD_Company, ";
         strSQL += "DVD_Genre=@DVD_Genre, ";
         strSQL += "DVD_Runtime=@DVD_Runtime, ";
         strSQL += "DVD_Type=@DVD_Type ";
         strSQL += "where DVD_ID=@DVD_ID; ";
            OleDbCommand cm = new OleDbCommand(strSQL, cn);
            OleDbParameter pm = new OleDbParameter("@DVD_Title", OleDbType.Char, 50);
            pm.Direction = ParameterDirection.Input;
            pm.Value = title;
            cm.Parameters.Add(pm);

            pm = new OleDbParameter("@DVD_First", OleDbType.Char, 30);
            pm.Direction = ParameterDirection.Input;
            pm.Value = first;
            cm.Parameters.Add(pm);
            pm = new OleDbParameter("@DVD_Last", OleDbType.Char, 30);
            pm.Direction = ParameterDirection.Input;
            pm.Value = last;
            cm.Parameters.Add(pm);
            pm = new OleDbParameter("@DVD_First2", OleDbType.Char, 30);
            pm.Direction = ParameterDirection.Input;
            pm.Value = first2;
            cm.Parameters.Add(pm);
            pm = new OleDbParameter("@DVD_Last2", OleDbType.Char, 30);
            pm.Direction = ParameterDirection.Input;
            pm.Value = last2;
            cm.Parameters.Add(pm);
            pm = new OleDbParameter("@DVD_Company", OleDbType.Char, 40);
            pm.Direction = ParameterDirection.Input;
            pm.Value = company;
            cm.Parameters.Add(pm);
            pm = new OleDbParameter("@DVD_Genre", OleDbType.SmallInt);
            pm.Direction = ParameterDirection.Input;
            pm.Value = genre;
            cm.Parameters.Add(pm);
            pm = new OleDbParameter("@DVD_Runtime", OleDbType.SmallInt);
            pm.Direction = ParameterDirection.Input;
            pm.Value = runtime;
            cm.Parameters.Add(pm);
            pm = new OleDbParameter("@DVD_Type", OleDbType.Char, 1);
            pm.Direction = ParameterDirection.Input;
            pm.Value = type;
            cm.Parameters.Add(pm);
            pm = new OleDbParameter("@DVD_ID", OleDbType.BigInt);
            pm.Direction = ParameterDirection.Input;
            pm.Value = DVD_ID;
            cm.Parameters.Add(pm); 
            cn.Open();
          cm.ExecuteNonQuery();
            cn.Close();
        
         
      }
      public void UpdateTitle(long DVD_ID, String title)
      {
       
         String strSQL = String.Empty;
    
            String connString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
               @"Data Source=" + System.Environment.CurrentDirectory + @"\Data\DVDB_001_DVD_master.accdb";

            OleDbConnection cn = new OleDbConnection(connString);
               Session.Logmessage("connection string " + connString);
            strSQL = "UPDATE DVDT_001_DVD_master ";
            strSQL += "SET ";
            strSQL += "DVD_Title=@DVD_Title ";
            strSQL += "WHERE DVD_ID = @DVD_ID; " ;
            OleDbCommand cm = new OleDbCommand(strSQL, cn);
            OleDbParameter pm = new OleDbParameter("@DVD_Title", OleDbType.Char, 50);
            pm.Direction = ParameterDirection.Input;
            pm.Value = title;
            cm.Parameters.Add(pm);
            pm = new OleDbParameter("@DVD_ID", OleDbType.BigInt);
            pm.Direction = ParameterDirection.Input;
            pm.Value = DVD_ID;
            cm.Parameters.Add(pm);
            cn.Open();
            cm.ExecuteNonQuery();
            cn.Close();
      
      }
      public void UpdateActor1(long DVD_ID, String first, String last)
      {
         
         String strSQL = string.Empty;
       
            String connString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
               @"Data Source=" + System.Environment.CurrentDirectory + @"\Data\DVDB_001_DVD_master.accdb";

            OleDbConnection cn = new OleDbConnection(connString);
               Session.Logmessage("connection string " + connString);
            strSQL = "UPDATE DVDT_001_DVD_master ";
            strSQL += "SET ";
            strSQL += "DVD_First=@DVD_First, ";
            strSQL += "DVD_Last=@DVD_Last ";
            strSQL += "WHERE DVD_ID = @DVD_ID; ";
            OleDbCommand cm = new OleDbCommand(strSQL, cn);
            OleDbParameter pm = new OleDbParameter("@DVD_First", OleDbType.Char, 30);
            pm.Direction = ParameterDirection.Input;
            pm.Value = first;
            cm.Parameters.Add(pm);
            pm = new OleDbParameter("@DVD_Last", OleDbType.Char, 30);
            pm.Direction = ParameterDirection.Input;
            pm.Value = last;
            cm.Parameters.Add(pm);
            pm = new OleDbParameter("@DVD_ID", OleDbType.BigInt);
            pm.Direction = ParameterDirection.Input;
            pm.Value = DVD_ID;
            cm.Parameters.Add(pm);
            cn.Open();
          cm.ExecuteNonQuery();
            cn.Close();

      }
      public void UpdateActor2(long DVD_ID, String first2, String last2)
      {
         String strSQL = string.Empty;
      
            String connString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
               @"Data Source=" + System.Environment.CurrentDirectory + @"\Data\DVDB_001_DVD_master.accdb";

            OleDbConnection cn = new OleDbConnection(connString);
               Session.Logmessage("connection string " + connString);
            strSQL = "UPDATE DVDT_001_DVD_master ";
            strSQL += "SET ";
            strSQL += "DVD_First2=@DVD_First2, ";
            strSQL += "DVD_Last2=@DVD_Last2 ";
            strSQL += "WHERE DVD_ID = @DVD_ID; ";
            OleDbCommand cm = new OleDbCommand(strSQL, cn);
            OleDbParameter pm = new OleDbParameter("@DVD_First2", OleDbType.Char, 30);
            pm.Direction = ParameterDirection.Input;
            pm.Value = first2;
            cm.Parameters.Add(pm);
            pm = new OleDbParameter("@DVD_Last2", OleDbType.Char, 30);
            pm.Direction = ParameterDirection.Input;
            pm.Value = last2;
            cm.Parameters.Add(pm);
            pm = new OleDbParameter("@DVD_ID", OleDbType.BigInt);
            pm.Direction = ParameterDirection.Input;
            pm.Value = DVD_ID;
            cm.Parameters.Add(pm);
            cn.Open();
            cm.ExecuteNonQuery();
            cn.Close();
      
      }
      public void UpdateCompany(long DVD_ID, string company)
      {
         
         String strSQL = string.Empty;
       
            String connString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
               @"Data Source=" + System.Environment.CurrentDirectory + @"\Data\DVDB_001_DVD_master.accdb";

            OleDbConnection cn = new OleDbConnection(connString);
               Session.Logmessage("connection string " + connString);
            strSQL = "UPDATE DVDT_001_DVD_master ";
            strSQL += "SET ";
            strSQL += "DVD_Company=@DVD_Company ";
            strSQL += "WHERE DVD_ID = @DVD_ID; ";
            OleDbCommand cm = new OleDbCommand(strSQL, cn);
            OleDbParameter pm = new OleDbParameter("@DVD_Company", OleDbType.Char, 40);
            pm.Direction = ParameterDirection.Input;
            pm.Value = company;
            cm.Parameters.Add(pm);
            pm = new OleDbParameter("@DVD_ID", OleDbType.BigInt);
            pm.Direction = ParameterDirection.Input;
            pm.Value = DVD_ID;
            cm.Parameters.Add(pm);
            cn.Open();
             cm.ExecuteNonQuery();
            cn.Close();
         
      }
      public void UpdateGenre(long DVD_ID, short genre)
      {
         String strSQL = string.Empty;
            String connString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
               @"Data Source=" + System.Environment.CurrentDirectory + @"\Data\DVDB_001_DVD_master.accdb";

            OleDbConnection cn = new OleDbConnection(connString);
               Session.Logmessage("connection string " + connString);
            strSQL = "UPDATE DVDT_001_DVD_master ";
            strSQL += "SET ";
            strSQL += "DVD_Genre=@DVD_Genre ";
            strSQL += "WHERE DVD_ID = @DVD_ID; ";
            OleDbCommand cm = new OleDbCommand(strSQL, cn);
            OleDbParameter pm = new OleDbParameter("@DVD_Genre", OleDbType.SmallInt);
            pm.Direction = ParameterDirection.Input;
            pm.Value = genre;
            cm.Parameters.Add(pm);
            pm = new OleDbParameter("@DVD_ID", OleDbType.BigInt);
            pm.Direction = ParameterDirection.Input;
            pm.Value = DVD_ID;
            cm.Parameters.Add(pm);

            cn.Open();
             cm.ExecuteNonQuery();
            cn.Close();
         }
         
      public void UpdateRuntime(long DVD_ID, short runtime)
      {
         String strSQL;
    
            String connString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
               @"Data Source=" + System.Environment.CurrentDirectory + @"\Data\DVDB_001_DVD_master.accdb";

            OleDbConnection cn = new OleDbConnection(connString);
               Session.Logmessage("connection string " + connString);
            strSQL = "UPDATE DVDT_001_DVD_master ";
            strSQL += "SET ";
            strSQL += "DVD_Runtime=@DVD_Runtime ";
            strSQL += "WHERE DVD_ID = @DVD_ID; ";
            OleDbCommand cm = new OleDbCommand(strSQL, cn);
            OleDbParameter pm = new OleDbParameter("@DVD_Runtime", OleDbType.SmallInt);
            pm.Direction = ParameterDirection.Input;
            pm.Value = runtime;
            cm.Parameters.Add(pm);
            pm = new OleDbParameter("@DVD_ID", OleDbType.BigInt);
            pm.Direction = ParameterDirection.Input;
            pm.Value = DVD_ID;
            cm.Parameters.Add(pm);
            cn.Open();
            cm.ExecuteNonQuery();
            cn.Close();
         }
    
      public void UpdateType(long DVD_ID, char type)
      {
         
         String strSQL = string.Empty;
            String connString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
               @"Data Source=" + System.Environment.CurrentDirectory + @"\Data\DVDB_001_DVD_master.accdb";

            OleDbConnection cn = new OleDbConnection(connString);
               Session.Logmessage("connection string " + connString);
            strSQL = "UPDATE DVDT_001_DVD_master ";
            strSQL += "SET ";
            strSQL += "DVD_Type=@DVD_Type ";
            strSQL += "WHERE DVD_ID = @DVD_ID; ";
            OleDbCommand cm = new OleDbCommand(strSQL, cn);
            OleDbParameter pm = new OleDbParameter("@DVD_Type", OleDbType.Char, 1);
            pm.Direction = ParameterDirection.Input;
            pm.Value = type;
            cm.Parameters.Add(pm);
            pm = new OleDbParameter("@DVD_ID", OleDbType.BigInt);
            pm.Direction = ParameterDirection.Input;
            pm.Value = DVD_ID;
            cm.Parameters.Add(pm);
            cn.Open();
          cm.ExecuteNonQuery();
            cn.Close();
         
       
      }
      public void Ddelete(long DVD_ID)
      {
         
         string strSQL = string.Empty;

            String connString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
              @"Data Source=" + System.Environment.CurrentDirectory + @"\Data\DVDB_001_DVD_master.accdb";
            OleDbConnection cn = new OleDbConnection(connString);
               Session.Logmessage("connection string " + connString);
            strSQL = "UPDATE DVDT_001_DVD_master ";
            strSQL += "SET ";
            strSQL += "DVD_Stat = 'N' ";
            strSQL += "WHERE DVD_ID = @DVD_ID; ";
            OleDbCommand cm = new OleDbCommand(strSQL, cn);

            OleDbParameter pm = new OleDbParameter("@DVD_ID", OleDbType.BigInt);
            pm.Direction = ParameterDirection.Input;
            pm.Value = DVD_ID;
            cm.Parameters.Add(pm);
            cn.Open();
            cm.ExecuteNonQuery();
            cn.Close();
         }
         
         
      public void Undelete(long DVD_ID)
      {
         
         string strSQL = string.Empty;
            String connString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
              @"Data Source=" + System.Environment.CurrentDirectory + @"\Data\DVDB_001_DVD_master.accdb";
            OleDbConnection cn = new OleDbConnection(connString);
               Session.Logmessage("connection string " + connString);
            strSQL = "UPDATE DVDT_001_DVD_master ";
            strSQL += "SET ";
            strSQL += "DVD_Stat ='E' ";
            strSQL += "WHERE DVD_ID = @DVD_ID; ";
            OleDbCommand cm = new OleDbCommand(strSQL, cn);

            OleDbParameter pm = new OleDbParameter("@DVD_ID", OleDbType.BigInt);
            pm.Direction = ParameterDirection.Input;
            pm.Value = DVD_ID;
            cm.Parameters.Add(pm);
            cn.Open();
            cm.ExecuteNonQuery();
            cn.Close();
  
       
      }
      public void Purge(long DVD_ID)
      {
            String strSQL = string.Empty;
   
            String connString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
              @"Data Source=" + System.Environment.CurrentDirectory + @"\Data\DVDB_001_DVD_master.accdb";
            OleDbConnection cn = new OleDbConnection(connString);
               Session.Logmessage("connection string " + connString);
            strSQL = "DELETE FROM DVDT_001_DVD_master ";
            strSQL += "WHERE DVD_ID = @DVD_ID AND DVD_Stat= 'N'; ";


            OleDbCommand cm = new OleDbCommand(strSQL, cn);

            OleDbParameter pm = new OleDbParameter("@DVD_ID", OleDbType.BigInt);
            pm.Direction = ParameterDirection.Input;
            pm.Value = DVD_ID;
            cm.Parameters.Add(pm);

            cn.Open();
             cm.ExecuteNonQuery();
            cn.Close();
         }
         
   
      public DVD[] SearchActor1(string last)
      {

         LinkedList<DVD> lastname = new LinkedList<DVD>();

         String strSQL = string.Empty;
         OleDbDataReader dr = null;
        
            String connString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
              @"Data Source=" + System.Environment.CurrentDirectory + @"\Data\DVDB_001_DVD_master.accdb";
            OleDbConnection cn = new OleDbConnection(connString);
               Session.Logmessage("connection string " + connString);

            strSQL = "SELECT DVD_Title, DVD_First, DVD_Last FROM DVDT_001_DVD_master WHERE DVD_Last LIKE @DVD_Last";

            OleDbCommand cm = new OleDbCommand(strSQL, cn);

            OleDbParameter pm = new OleDbParameter("DVD_Last", OleDbType.Char, 30);
            pm.Direction = ParameterDirection.Input;
            pm.Value = last +"%";
            cm.Parameters.Add(pm);
            cn.Open();
            dr = cm.ExecuteReader(CommandBehavior.CloseConnection);

            while (dr.Read())
            {
             
               title = dr["DVD_Title"].ToString();
               first = dr["DVD_First"].ToString();
               last = dr["DVD_Last"].ToString();
               DVD d = new DVD(newID, title, first, last, first2, last2, company, genre, runtime, type, status);
               lastname.AddLast(d);
            }
         return lastname.ToArray();
         }



        
     
      public DVD[] SearchActor2(string last2)
      {

         LinkedList<DVD> lastname2 = new LinkedList<DVD>();

         String strSQL = string.Empty;
         OleDbDataReader dr = null;
      
            String connString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
              @"Data Source=" + System.Environment.CurrentDirectory + @"\Data\DVDB_001_DVD_master.accdb";
            OleDbConnection cn = new OleDbConnection(connString);
               Session.Logmessage("connection string " + connString);

            strSQL = "SELECT DVD_Title, DVD_First2, DVD_Last2 FROM DVDT_001_DVD_master WHERE DVD_Last2 LIKE @DVD_Last2";

            OleDbCommand cm = new OleDbCommand(strSQL, cn);

            OleDbParameter pm = new OleDbParameter("@DVD_Last2", OleDbType.Char, 30);
            pm.Direction = ParameterDirection.Input;
            pm.Value = last2  +"%" ;
            cm.Parameters.Add(pm);
            cn.Open();
            dr = cm.ExecuteReader(CommandBehavior.CloseConnection);

            while (dr.Read())
            {

               title = dr["DVD_Title"].ToString();
               first2 = dr["DVD_First2"].ToString();
               last2 = dr["DVD_Last2"].ToString();
               DVD d = new DVD(newID, title, first, last, first2, last2, company, genre, runtime, type, status);
               lastname2.AddLast(d);
            }
           return lastname2.ToArray();
         }


     
         
      public DVD[] SearchTitle(string title)
      {
       
        LinkedList<DVD> Titles=new LinkedList<DVD>();
      
          String strSQL = string.Empty;
          OleDbDataReader dr = null;
         
             String connString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
               @"Data Source=" + System.Environment.CurrentDirectory + @"\Data\DVDB_001_DVD_master.accdb";
             OleDbConnection cn = new OleDbConnection(connString);
                Session.Logmessage("connection string " + connString);

             strSQL = "SELECT DVD_ID, DVD_Title FROM DVDT_001_DVD_master WHERE DVD_Title  LIKE @DVD_Title ";

             OleDbCommand cm = new OleDbCommand(strSQL, cn);

             OleDbParameter pm = new OleDbParameter("@DVD_Title", OleDbType.Char, 50);
             pm.Direction = ParameterDirection.Input;
             pm.Value = title + "%";  // add the wildcard here
             cm.Parameters.Add(pm);
             cn.Open();
             dr = cm.ExecuteReader(CommandBehavior.CloseConnection);

            while (dr.Read())
            {
               newID = dr["DVD_ID"].ToString();
               title = dr["DVD_Title"].ToString();
         

               DVD d = new DVD(newID, title, first, last, first2, last2, company, genre, runtime, type, status);
              Titles.AddLast(d);
          
          }
         return Titles.ToArray();
      }
      public DVD[] SearchCompany(string company)
      {

         LinkedList<DVD> Companies = new LinkedList<DVD>();

         String strSQL = string.Empty;
         OleDbDataReader dr = null;
        
            String connString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
              @"Data Source=" + System.Environment.CurrentDirectory + @"\Data\DVDB_001_DVD_master.accdb";
            OleDbConnection cn = new OleDbConnection(connString);
               Session.Logmessage("connection string " + connString);

            strSQL = "SELECT DVD_Title, DVD_Company FROM DVDT_001_DVD_master WHERE DVD_Company LIKE @DVD_Company";

            OleDbCommand cm = new OleDbCommand(strSQL, cn);

            OleDbParameter pm = new OleDbParameter("@DVD_Company", OleDbType.Char, 40);
            pm.Direction = ParameterDirection.Input;
            pm.Value = company + "%";
            cm.Parameters.Add(pm);
            cn.Open();
            dr = cm.ExecuteReader(CommandBehavior.CloseConnection);

            while (dr.Read())
            {

               title = dr["DVD_Title"].ToString();
               company = dr["DVD_Company"].ToString();
   
               DVD d = new DVD(newID, title, first, last, first2, last2, company, genre, runtime, type, status);
               Companies.AddLast(d);
            }
         return Companies.ToArray();
      }
      public DVD[] SearchGenre(short genre)
      {

         LinkedList<DVD> codes = new LinkedList<DVD>();

         String strSQL = string.Empty;
         OleDbDataReader dr = null;
       
            String connString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
              @"Data Source=" + System.Environment.CurrentDirectory + @"\Data\DVDB_001_DVD_master.accdb";
            OleDbConnection cn = new OleDbConnection(connString);
               Session.Logmessage("connection string " + connString);

            strSQL = "SELECT DVD_Title FROM DVDT_001_DVD_master WHERE DVD_Genre = @DVD_Genre";

            OleDbCommand cm = new OleDbCommand(strSQL, cn);

            OleDbParameter pm = new OleDbParameter("@DVD_Genre", OleDbType.SmallInt);
            pm.Direction = ParameterDirection.Input;
            pm.Value = genre;
            cm.Parameters.Add(pm);
            cn.Open();
            dr = cm.ExecuteReader(CommandBehavior.CloseConnection);

            while (dr.Read())
            {

               title = dr["DVD_Title"].ToString();
           
               DVD d = new DVD(newID, title, first, last, first2, last2, company, genre, runtime, type, status);
               codes.AddLast(d);
            }
         return codes.ToArray();
      }
      public DVD[] SearchRuntime(short runtime)
      {

         LinkedList<DVD> Times= new LinkedList<DVD>();

         String strSQL = string.Empty;
         OleDbDataReader dr = null;
        
            String connString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
              @"Data Source=" + System.Environment.CurrentDirectory + @"\Data\DVDB_001_DVD_master.accdb";
            OleDbConnection cn = new OleDbConnection(connString);
               Session.Logmessage("connection string " + connString);

            strSQL = "SELECT DVD_Title, DVD_Runtime FROM DVDT_001_DVD_master WHERE DVD_Runtime= @DVD_Runtime";

            OleDbCommand cm = new OleDbCommand(strSQL, cn);

            OleDbParameter pm = new OleDbParameter("@DVD_Runtime", OleDbType.SmallInt);
            pm.Direction = ParameterDirection.Input;
            pm.Value = runtime;
            cm.Parameters.Add(pm);
            cn.Open();
            dr = cm.ExecuteReader(CommandBehavior.CloseConnection);


            while (dr.Read())
            {

               title = dr["DVD_Title"].ToString();
              runtime= Convert.ToInt16(dr["DVD_Runtime"]);
               DVD d = new DVD(newID, title, first, last, first2, last2, company, genre, runtime, type, status);
               Times.AddLast(d);
         }
         return Times.ToArray();
      }
      public DVD[] SearchStatus(char status)
      {

         LinkedList<DVD> Statuses = new LinkedList<DVD>();

         String strSQL = string.Empty;
         OleDbDataReader dr = null;
         
            String connString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
              @"Data Source=" + System.Environment.CurrentDirectory + @"\Data\DVDB_001_DVD_master.accdb";
            OleDbConnection cn = new OleDbConnection(connString);
               Session.Logmessage("connection string " + connString);

            strSQL = "SELECT DVD_ID, DVD_Title, DVD_Stat FROM DVDT_001_DVD_master WHERE DVD_Stat = @DVD_Stat";

            OleDbCommand cm = new OleDbCommand(strSQL, cn);

            OleDbParameter pm = new OleDbParameter("@DVD_Stat", OleDbType.Char, 1);
            pm.Direction = ParameterDirection.Input;
            pm.Value = status;
            cm.Parameters.Add(pm);
            cn.Open();
            dr = cm.ExecuteReader(CommandBehavior.CloseConnection);
            while (dr.Read())
            {
               newID = dr["DVD_ID"].ToString();
               title = dr["DVD_Title"].ToString();
               status = Convert.ToChar(dr["DVD_Stat"]);
              
               DVD d = new DVD(newID, title, first, last, first2, last2, company, genre, runtime, type, status);
               Statuses.AddLast(d);
            
         }
         return Statuses.ToArray();
      }
    
      public DVD[] SearchType(char type)
      {

         LinkedList<DVD> Types = new LinkedList<DVD>();

         String strSQL = string.Empty;
         OleDbDataReader dr = null;
       
            String connString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
              @"Data Source=" + System.Environment.CurrentDirectory + @"\Data\DVDB_001_DVD_master.accdb";
            OleDbConnection cn = new OleDbConnection(connString);
               Session.Logmessage("connection string " + connString);

            strSQL = "SELECT DVD_Title, DVD_Type FROM DVDT_001_DVD_master WHERE DVD_Type = @DVD_Type";

            OleDbCommand cm = new OleDbCommand(strSQL, cn);

            OleDbParameter pm = new OleDbParameter("@DVD_Type", OleDbType.Char, 1);
            pm.Direction = ParameterDirection.Input;
            pm.Value = type ;
            cm.Parameters.Add(pm);
            cn.Open();
            dr = cm.ExecuteReader(CommandBehavior.CloseConnection);
            while (dr.Read())
            {
               
               title = dr["DVD_Title"].ToString();
               type = Convert.ToChar(dr["DVD_Type"]);

               DVD d = new DVD(newID, title, first, last, first2, last2, company, genre, runtime, type, status);
               Types.AddLast(d);
            
         }
         return Types.ToArray();
      }
      public OleDbDataReader SelectID(long DVD_ID)
      {
          OleDbDataReader dr=null;
        
             String connString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
               @"Data Source=" + System.Environment.CurrentDirectory + @"\Data\DVDB_001_DVD_master.accdb";
             OleDbConnection cn = new OleDbConnection(connString);
                Session.Logmessage("connection string " + connString);
             String strSQL;

             strSQL = "SELECT DVD_ID, DVD_Title, DVD_First, DVD_Last, DVD_First2 ,DVD_Last2,DVD_Company,DVD_Genre, DVD_Runtime, DVD_Type,DVD_Stat FROM DVDT_001_DVD_master WHERE DVD_ID =@DVD_ID; ";

             OleDbCommand cm = new OleDbCommand(strSQL, cn);

             OleDbParameter pm = new OleDbParameter("@DVD_ID", OleDbType.Integer);
             pm.Direction = ParameterDirection.Input;
             pm.Value = DVD_ID;
             cm.Parameters.Add(pm);
             cn.Open();

             dr = cm.ExecuteReader(CommandBehavior.CloseConnection);
             if (dr.Read())
             {
               newID = dr["DVD_ID"].ToString();
         title = dr["DVD_Title"].ToString();
         first = dr["DVD_First"].ToString();
         last = dr["DVD_Last"].ToString();
         first2 = dr["DVD_First2"].ToString();
         last2 = dr["DVD_Last2"].ToString();
         company = dr["DVD_Company"].ToString();
         runtime = Convert.ToInt16( dr["DVD_Runtime"]);
         type =Convert.ToChar( dr["DVD_Type"]);
         status =Convert.ToChar( dr["DVD_Stat"]);
         genre = Convert.ToInt16(dr["DVD_Genre"]);
             }
             else
             {
                newID = "0";
                title = "Title";
                first = "First";
                last = "Last";
                first2 = "First2";
                last2 = "Last2";
               company = "Company";
                genre = 0;
                runtime= 0;
                type = 'U';
               status = 'E';
        
             }
          
          return dr;
      }

      
      public OleDbDataReader SelectTitle( String DVD_Title)
      {
        
         OleDbDataReader dr = null;
         
            String connString = @"Provider=Microsoft.ACE.OLEDB.12.0;" +
              @"Data Source=" + System.Environment.CurrentDirectory + @"\Data\DVDB_001_DVD_master.accdb";
            OleDbConnection cn = new OleDbConnection(connString);
               Session.Logmessage("connection string " + connString);
            String strSQL;

            strSQL = "SELECT DVD_ID, DVD_Title, DVD_First, DVD_Last, DVD_First2 ,DVD_Last2,DVD_Company,DVD_Genre,DVD_Runtime, DVD_Type,DVD_Stat FROM DVDT_001_DVD_master WHERE DVD_Title =@DVD_Title ";

            OleDbCommand cm = new OleDbCommand(strSQL, cn);

            OleDbParameter pm = new OleDbParameter("@DVD_Title", OleDbType.Char,50);
            pm.Direction = ParameterDirection.Input;
            pm.Value = DVD_Title;
            cm.Parameters.Add(pm);
            cn.Open();
            dr = cm.ExecuteReader(CommandBehavior.CloseConnection);
            if (dr.Read())
            {
               ID = dr["DVD_ID"].ToString();
               title = dr["DVD_Title"].ToString();
               first = dr["DVD_First"].ToString();
               last = dr["DVD_Last"].ToString();
               first2 = dr["DVD_First2"].ToString();
               last2 = dr["DVD_Last2"].ToString();
               company = dr["DVD_Company"].ToString();
               runtime = Convert.ToInt16(dr["DVD_Runtime"]);
               type = Convert.ToChar(dr["DVD_Type"]);
               status = Convert.ToChar(dr["DVD_Stat"]);
               genre = Convert.ToInt16(dr["DVD_Genre"]);
            }
            else
            {
               newID = String.Empty;
               title = "Title";
               first = "First";
               last = "Last";
               first2 = "First2";
               last2 = "Last2";
               company = "Company";
               genre = 0;
               runtime = 0;
               type = 'U';
               status = 'E';
            }
         return dr;
      }

      }
   }
