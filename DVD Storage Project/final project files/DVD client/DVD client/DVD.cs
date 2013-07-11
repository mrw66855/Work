using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text.RegularExpressions;
namespace DVD_client
{

   class DVD
   {
      private string DVD_action;
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
      private string temp;
      private String Request;
      private String Response;
      private char option;
      private char option2;
     private  char option3;
     private string[] movie;
     private Regex numbervalidation = new Regex(@"^\d+$");
     private Regex charactervalidation = new Regex(@"^[A-Z a-z]{1}$");
      responses r = new responses();
      public DVD()
      {
         DVD_action = String.Empty;
         DVD_ID = "0";
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
     
      public string getAction()
      {
         return DVD_action;
      }
      public void setAction(string action)
      {
         if (action.Equals("addall") || action.Equals("addtitle")|| action.Equals("updateall") ||action.Equals("updatetitle") || action.Equals("updateactor1")|| action.Equals("updateactor2") ||action.Equals(" updatecompany") || action.Equals("updategenre")|| action.Equals("updateruntime") ||action.Equals("updatetype") || action.Equals("searchtitle")|| action.Equals("searchactor1") || action.Equals("searchactor2") ||action.Equals("searchcompany") || action.Equals("searchgenre")|| action.Equals("searchruntime") ||action.Equals("searchtype") ||action.Equals("searchstatus")|| action.Equals("selectID")|| action.Equals("selecttitle") || action.Equals("delete") || action.Equals("temp") || action.Equals("recover")|| action.Equals("disconnect")|| action.Equals("getgenre"))
         {
            DVD_action = action;
         }
         else
         {
            DVD_action = string.Empty;
         }
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


       {
          if (numbervalidation.IsMatch(ID))
          {
             DVD_ID = ID;
          }
          else
          {
             DVD_ID = "0";
          }
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
      else   if (first2.Length > 0 && first2.Length <= 30 )
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
         else if (last2.Length > 0 && last2.Length <= 30 )
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
       else if(company==null)
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
      

     
   
      public void AddAll()
      {

         StringWriter sw = new StringWriter();
         XmlTextWriter xmlWriter = new XmlTextWriter(sw);
       
         try
         {
            
               Console.Clear();
               Console.WriteLine("Add all DVD information");
               Console.WriteLine();
               do
               {
                  Console.Write("View Genre Category List? (Y/N) : ");
                  temp = Console.ReadLine();

                  if (charactervalidation.IsMatch(temp))
                  {
                      option = Convert.ToChar(temp);
                  }

                     option = Char.ToUpper(option);
                 
                  if (option.Equals('Y'))
                  {
                   
                     Genreslist();
                  }
                  else if (option.Equals('N'))
                  {
                     Console.WriteLine();
                     utilities.Connect();
                     DVD_action = "addall";
                     setAction(DVD_action);
                     Console.Write("Title: ");
                     DVD_title = Console.ReadLine();
                     setTitle(DVD_title);
                     Console.Write("First leading actor first name: ");
                     DVD_first = Console.ReadLine();
                     setFirstname(DVD_first);
                     Console.Write("First leading actor Last name: ");
                     DVD_last = Console.ReadLine();
                     setLastname(DVD_last);
                     Console.Write("Second leading actor first name: ");
                     DVD_first2 = Console.ReadLine();
                     setFirstname2(DVD_first2);
                     Console.Write("Second leading actor Last name: ");
                     DVD_last2 = Console.ReadLine();
                     setLastname2(DVD_last2);
                     Console.Write("Production Company: ");
                     DVD_cp = Console.ReadLine();
                     setCompany(DVD_cp);
                     Console.Write("Genre Code Number: ");
                      temp = Console.ReadLine();
                      if (numbervalidation.IsMatch(temp))
                      {
                          DVD_genre = Convert.ToInt16(temp);
                      }
                      else
                      {
                          DVD_genre = 0;
                      }
                     setGenre(DVD_genre);
                     
                     Console.Write("Runtime in minutes : ");
                     temp = Console.ReadLine();
                     if (numbervalidation.IsMatch(temp))
                     {
                         DVD_rt= Convert.ToInt16(temp);
                     }
                     else
                     {
                        DVD_rt = 0;
                     }
                        setRuntime(DVD_rt);
                     
                     
                     Console.Write("Type (D for DVD or B for Blu-ray or U for Unknown): ");
                     temp = Console.ReadLine();
                     
                     if (charactervalidation.IsMatch(temp))
                     {

                        DVD_type = Convert.ToChar(temp);
                     }
                     else
                     {
                        DVD_type = 'u';
                     }
                     DVD_type = Char.ToUpper(DVD_type);

                     setType(DVD_type);
                     DVD_stat = 'E';
                     setStatus(DVD_stat);
                     Console.WriteLine();
                  }
               } while (!option.Equals('Y') && !option.Equals('N'));
            
               
               Console.WriteLine("Please verify all information");
               Console.WriteLine("Title : {0}\nFirst actor's name: {1} {2}\nSecond actor's name: {3} {4}\nProduction Company: {5}\nGenre Code Number: {6}" +
                "\nRuntime: {7} minutes\nType: {8}", getTitle(), getFirstname(), getLastname(), getFirstname2(), getLastname2(), getCompany(), getGenre(), getRuntime(), getType());
               Console.WriteLine();

               do
               {
                  Console.Write("Correct? (Y/N): ");
                  temp = Console.ReadLine();

                  if (charactervalidation.IsMatch(temp))
                  {
                     option2 = Convert.ToChar(temp);
                  }
               
                  option2 = Char.ToUpper(option2);
                  if (option2.Equals('N'))
                  {
                     utilities.Disconnect();
                     AddAll();

                  }
                  if (option2.Equals( 'Y'))
                  {
                     xmlWriter.WriteStartDocument();
                     xmlWriter.WriteStartElement("Request");
                     xmlWriter.WriteElementString("Action", getAction());
                     xmlWriter.WriteElementString("Title", getTitle());
                     xmlWriter.WriteElementString("First", getFirstname());
                     xmlWriter.WriteElementString("Last", getLastname());
                     xmlWriter.WriteElementString("First2", getFirstname2());
                     xmlWriter.WriteElementString("Last2", getLastname2());
                     xmlWriter.WriteElementString("Company", getCompany());
                     xmlWriter.WriteElementString("Genre", getGenre().ToString());
                     xmlWriter.WriteElementString("Runtime", getRuntime().ToString());
                     xmlWriter.WriteElementString("Type", getType().ToString());
                     xmlWriter.WriteElementString("Status", getStatus().ToString());
                     xmlWriter.WriteEndElement();
                     xmlWriter.WriteEndDocument();
                     xmlWriter.Close();
                     Request = sw.ToString();
                     sw.Close();
                   utilities.writer.WriteLine(Request);
                         Response = utilities.reader.ReadLine();
                utilities.Disconnect();
                r.Add(Response);
                  }
               } while (!option2.Equals('Y') && !option2.Equals('N'));
            Console.WriteLine();
           do
           {
               Console.Write("Add another DVD? (Y/N) : ");
               temp = Console.ReadLine();

               if (charactervalidation.IsMatch(temp))
               {
                  option3 = Convert.ToChar(temp);

               }
               option3 = Char.ToUpper(option3);
               if (option3.Equals('Y'))
               {
              
                  AddAll();
               }
               else if (option3.Equals('N'))
               {
             
                  menus.Addmenu();
               }
           }  while (!option3.Equals('Y') && !option3.Equals('N'));
            }
        

         catch (XmlException ex)
         {
            Console.Clear();
            Console.WriteLine("XML Document {0}", ex.Message + "\nPress any key to return to add menu.");
            Console.ReadKey();
           
     utilities.Disconnect();
     xmlWriter.Close();
     sw.Close();
          menus.Addmenu();
         }
         catch (Exception ex)
         {
            Console.Clear();
            Console.WriteLine("Add Full DVD Error: {0}", ex.Message + "\nPress any key to return to add menu.");
            Console.ReadKey();
       utilities.Disconnect();
       xmlWriter.Close();
       sw.Close();
            menus.Addmenu();
         }

      
      }

      public void AddTitle()
      {
         StringWriter sw = new StringWriter();
         XmlTextWriter xmlWriter = new XmlTextWriter(sw);
  
         try
         {
               Console.Clear();
               Console.WriteLine("Add  DVD Title");
               Console.WriteLine();
               utilities.Connect();
               DVD_action = "addtitle";
               setAction(DVD_action);
               Console.Write("Title: ");
               DVD_title = Console.ReadLine();
               setTitle(DVD_title);
            
               DVD_stat = 'E';
               setStatus(DVD_stat);
               Console.WriteLine();
               Console.WriteLine("Please verify all information");
               Console.WriteLine("Title : {0}", getTitle());
               Console.WriteLine();
               do
               {
                  Console.Write("Correct? (Y/N): ");
                  temp = Console.ReadLine();

                  if (charactervalidation.IsMatch(temp))
                  {
                     option = Convert.ToChar(temp);

                  }
                  option = Char.ToUpper(option);
                  if (option.Equals( 'N'))
                  {
                     utilities.Disconnect();
                     AddTitle();
                  }
                  if (option.Equals( 'Y'))
                  {
                     xmlWriter.WriteStartDocument();
                     xmlWriter.WriteStartElement("Request");
                     xmlWriter.WriteElementString("Action", getAction());
                     xmlWriter.WriteElementString("Title", getTitle());
                     xmlWriter.WriteElementString("Status", getStatus().ToString());
                     xmlWriter.WriteEndElement();
                     xmlWriter.WriteEndDocument();
                     xmlWriter.Close();
                     Request = sw.ToString();
                     sw.Close();
                 
                     utilities.writer.WriteLine(Request);
                     Response = utilities.reader.ReadLine();
                   utilities.Disconnect();
                   r.Add(Response);
                  }

               } while (!option.Equals('Y') && !option.Equals( 'N'));
               Console.WriteLine();
               do
               {

                  Console.Write("Add another DVD Title? (Y/N) : ");
                  temp = Console.ReadLine();

                  if (charactervalidation.IsMatch(temp))
                  {
                     option2 = Convert.ToChar(temp);

                  }
                  option2 = Char.ToUpper(option2);
                  if (option2.Equals('Y'))
                  {
                     
                     AddTitle();
                  }
                  else if (option2.Equals('N'))
                  {
                    
                     menus.Addmenu();
                  }
               } while (!option2.Equals('Y') && !option2.Equals( 'N'));
            }

         catch (XmlException ex)
         {
            Console.Clear();
            Console.WriteLine("XML Document {0}", ex.Message + "\nPress any key to return to add menu.");
            Console.ReadKey();
           
            utilities.Disconnect();
            xmlWriter.Close();
            sw.Close();
            menus.Addmenu();
         }
         catch (Exception ex)
         {
            Console.Clear();
            Console.WriteLine("Add Title DVD Error: {0}", ex.Message + "\nPress any key to return to add menu.");
            Console.ReadKey();
            utilities.Disconnect();
            xmlWriter.Close();
            sw.Close();
            menus.Addmenu();
         }

      
      }

      public void UpdateAll()
      {
        
            StringWriter sw = new StringWriter();
            XmlTextWriter xmlWriter = new XmlTextWriter(sw);
            try
            {
              
                  Console.Clear();
                  Console.WriteLine("Update all DVD information");
                  Console.WriteLine();
                  do
                  {
                     Console.Write("View Genre Category List? (Y/N) : ");
                     temp = Console.ReadLine();

                     if (charactervalidation.IsMatch(temp))
                     {
                        option = Convert.ToChar(temp);

                     }
                     option = Char.ToUpper(option);
                     if (option.Equals('Y'))
                     {
                  
                        Genreslist();
                     }
                     else if (option.Equals('N'))
                     {
                        Console.WriteLine();
                            utilities.Connect();
                        DVD_action = "updateall";
                        setAction(DVD_action);
                        Console.Write("DVD ID: ");
                        DVD_ID = Console.ReadLine();
                        setID(DVD_ID);
                        Console.Write("Title: ");
                        DVD_title = Console.ReadLine();
                        setTitle(DVD_title);
                        Console.Write("First leading actor first name: ");
                        DVD_first = Console.ReadLine();
                        setFirstname(DVD_first);
                        Console.Write("First leading actor Last name: ");
                        DVD_last = Console.ReadLine();
                        setLastname(DVD_last);
                        Console.Write("Second leading actor first name: ");
                        DVD_first2 = Console.ReadLine();
                        setFirstname2(DVD_first2);
                        Console.Write("Second leading actor Last name: ");
                        DVD_last2 = Console.ReadLine();
                        setLastname2(DVD_last2);
                        Console.Write("Production Company: ");
                        DVD_cp = Console.ReadLine();
                        setCompany(DVD_cp);
                        Console.Write("Genre Code Number: ");
                        temp = Console.ReadLine();
                        if (numbervalidation.IsMatch(temp))
                        {
                            DVD_genre = Convert.ToInt16(temp);
                        }
                        else
                        {
                            DVD_genre = 0;
                        }
                        setGenre(DVD_genre);

                        Console.Write("Runtime in minutes : ");
                        temp = Console.ReadLine();
                        if (numbervalidation.IsMatch(temp))
                        {
                            DVD_rt = Convert.ToInt16(temp);
                        }
                        else
                        {
                            DVD_rt = 0;
                        }
                        setRuntime(DVD_rt);

                        Console.Write("Type (D for DVD or B for Blu-ray or U for Unknown): ");
                        temp = Console.ReadLine();
                        if (charactervalidation.IsMatch(temp))
                        {

                            DVD_type = Convert.ToChar(temp);
                        }
                        else
                        {
                            DVD_type = 'u';
                        }
                        DVD_type = Char.ToUpper(DVD_type);

                        setType(DVD_type);
                     }
                  } while (!option.Equals('Y') && !option.Equals('N'));
                  Console.WriteLine();
                  Console.WriteLine("Please verify all information");
                  Console.WriteLine("DVD ID: {0}\nTitle : {1}\nFirst actor's name: {2} {3}\nSecond actor's name: {4} {5}\nProduction Company: {6}\nGenre Code Number: {7}" +
                   "\nRuntime: {8} minutes\nType: {9}",getID(), getTitle(), getFirstname(), getLastname(), getFirstname2(), getLastname2(), getCompany(), getGenre(), getRuntime(), getType());
                  Console.WriteLine();
                  do
                  {
                     Console.Write("Correct? (Y/N): ");
                     temp = Console.ReadLine();

                     if (charactervalidation.IsMatch(temp))
                     {
                        option2 = Convert.ToChar(temp);

                     };
                     option2 = Char.ToUpper(option2);
                     if (option2.Equals( 'N'))
                     {
                        utilities.Disconnect();
                        UpdateAll();
                     }
                     if (option2.Equals('Y'))
                     {
                        xmlWriter.WriteStartDocument();
                        xmlWriter.WriteStartElement("Request");
                        xmlWriter.WriteElementString("Action", getAction());
                        xmlWriter.WriteElementString("ID", getID());
                        xmlWriter.WriteElementString("Title", getTitle());
                        xmlWriter.WriteElementString("First", getFirstname());
                        xmlWriter.WriteElementString("Last", getLastname());
                        xmlWriter.WriteElementString("First2", getFirstname2());
                        xmlWriter.WriteElementString("Last2", getLastname2());
                        xmlWriter.WriteElementString("Company", getCompany());
                        xmlWriter.WriteElementString("Genre", getGenre().ToString());
                        xmlWriter.WriteElementString("Runtime", getRuntime().ToString());
                        xmlWriter.WriteElementString("Type", getType().ToString());
                        xmlWriter.WriteEndElement();
                        xmlWriter.WriteEndDocument();
                        Request = sw.ToString();
                     
                      utilities.writer.WriteLine(Request);
                            Response = utilities.reader.ReadLine();
                            
                        r.Modify(Response);
                  
                     }
                  } while (!option2.Equals('Y')&&!option2.Equals('N'));
            Console.WriteLine();
            do
            {
               Console.Write("Update another DVD (Y/N)? : ");
               temp = Console.ReadLine();

               if (charactervalidation.IsMatch(temp))
               {
                  option3 = Convert.ToChar(temp);

               }
               option3 = Char.ToUpper(option3);
               if (option3.Equals('Y'))
               {
                
                  UpdateAll();
               }
               else if (option3.Equals('N'))
               {
      
                  menus.Updatemenu();
               }
            } while (!option3.Equals('Y') && !option3.Equals('N'));
            }

             
         

            catch (XmlException ex)
            {
               Console.Clear();
               Console.WriteLine("XML Document {0}", ex.Message + "\nPress any key to return to update menu.");
               Console.ReadKey();
               Console.Clear();
          utilities.Disconnect();
               menus.Updatemenu();
            }
            catch (Exception ex)
            {
               Console.Clear();
               Console.WriteLine("Update DVD Error: {0}", ex.Message + "\nPress any key to return to update menu.");
               Console.Clear();
               Console.ReadKey();
               Console.Clear();
          utilities.Disconnect();
               menus.Updatemenu();
            }

          
         }

      public void UpdateTitle()
      {
         
      
         StringWriter sw = new StringWriter();
         XmlTextWriter xmlWriter = new XmlTextWriter(sw);
         try
         {

            Console.Clear();
            Console.WriteLine("Update  DVD Title");
            Console.WriteLine();
            DVD_action = "updatetitle";
            setAction(DVD_action);
            utilities.Connect();
            Console.Write("DVD ID: ");
            DVD_ID = Console.ReadLine();
            setID(DVD_ID);
            Console.Write("Title: ");
            DVD_title = Console.ReadLine();
            setTitle(DVD_title);
            Console.WriteLine();
            Console.WriteLine("Please verify all information");
            Console.WriteLine("DVD ID: {0}\nTitle : {1}", getID(), getTitle());
            Console.WriteLine();
            do
            {
               Console.Write("Correct? (Y/N): ");
               temp = Console.ReadLine();

               if (charactervalidation.IsMatch(temp))
               {
                   option = Convert.ToChar(temp);
               }
               option = Char.ToUpper(option);
               if (option.Equals('N'))
               {
                  utilities.Disconnect();
                  UpdateTitle();
               }
               if (option.Equals('Y'))
               {
                  xmlWriter.WriteStartDocument();
                  xmlWriter.WriteStartElement("Request");
                  xmlWriter.WriteElementString("Action", getAction());
                  xmlWriter.WriteElementString("ID", getID());
                  xmlWriter.WriteElementString("Title", getTitle());

                  xmlWriter.WriteEndElement();
                  xmlWriter.WriteEndDocument();
                  Request = sw.ToString();
               
                  utilities.writer.WriteLine(Request);
                  Response = utilities.reader.ReadLine();
                  utilities.Disconnect();
                  r.Modify(Response);

               }
            } while (!option.Equals('Y') && !option.Equals('N'));
            do
            {

               Console.Write("Update another DVD Title (Y/N)? : ");
               temp = Console.ReadLine();

               if (charactervalidation.IsMatch(temp))
               {
                   option2 = Convert.ToChar(temp);
               }
               option2 = Char.ToUpper(option2);
               if (option2.Equals('Y'))
               {
                  UpdateTitle();
               }
               else if (option2.Equals('N'))
               {
                
                  menus.Updatemenu();
               }


            } while (!option2.Equals('Y') && !option2.Equals('N'));
         }


         catch (XmlException ex)
         {
            Console.Clear();
            Console.WriteLine("XML Document {0}", ex.Message + "\nPress any key to return to update menu.");
            Console.ReadKey();
            Console.Clear();
       utilities.Disconnect();
            menus.Updatemenu();
         }
         catch (Exception ex)
         {
            Console.Clear();
            Console.WriteLine("Update Title DVD Error: {0}", ex.Message + "\nPress any key to return to update menu.");
            Console.Clear();
            Console.ReadKey();
            Console.Clear();
       utilities.Disconnect();
            menus.Updatemenu();
         }
      }
    
      

      public void UpdateActor1()
      {
    
         
         StringWriter sw = new StringWriter();
         XmlTextWriter xmlWriter = new XmlTextWriter(sw);
         try
         {
            
               Console.Clear();
               Console.WriteLine("Update  DVD First Actor");
               Console.WriteLine();
               utilities.Connect();
               DVD_action = "updateactor1";
               setAction(DVD_action);
               Console.Write("DVD ID: ");
               DVD_ID = Console.ReadLine();
               setID(DVD_ID);
               Console.Write("First Name: ");
               DVD_first = Console.ReadLine();
              setFirstname(DVD_first);
               Console.Write("Last Name: ");
               DVD_last = Console.ReadLine();
              setLastname(DVD_last);
               Console.WriteLine();
               Console.WriteLine("Please verify all information");
               Console.WriteLine("DVD ID: {0}\n Name : {1} {2}", getID(),getFirstname(),getLastname());
               Console.WriteLine();
              
               do
               {
                  Console.Write("Correct? (Y/N): ");
                  temp = Console.ReadLine();

                  if (charactervalidation.IsMatch(temp))
                  {
                      option = Convert.ToChar(temp);
                  }
                  option = Char.ToUpper(option);
                  if (option.Equals('N'))
                  {
                     utilities.Disconnect();
                     UpdateActor1();
                  }	
                if (option.Equals('Y'))
                  {
            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("Request");
            xmlWriter.WriteElementString("Action", getAction());
            xmlWriter.WriteElementString("ID", getID());
            xmlWriter.WriteElementString("First",getFirstname());
            xmlWriter.WriteElementString("Last",getLastname());
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();
            xmlWriter.Close();
            Request = sw.ToString();
            sw.Close();
         
          utilities.writer.WriteLine(Request);
               Response = utilities.reader.ReadLine();
               utilities.Disconnect();
           r.Modify(Response);
    
                  }
               } while (!option.Equals('Y') && !option.Equals('N'));
            Console.WriteLine();
           do
           {

            Console.Write("Update another DVD First Actor (Y/N)? : ");
            temp = Console.ReadLine();

            if (charactervalidation.IsMatch(temp))
            {
                option2 = Convert.ToChar(temp);
            }
            option2 = Char.ToUpper(option2);
            if (option2.Equals('Y'))
            {
               UpdateActor1();
            }
            else if (option2.Equals('N'))
            {
           
               menus.Updatemenu();
            }
           } while (!option2.Equals('Y') && !option2.Equals('N'));
         }

         catch (XmlException ex)
         {
            Console.Clear();
            Console.WriteLine("XML Document {0}", ex.Message + "\nPress any key to return to update menu.");
            Console.ReadKey();
            Console.Clear();
       utilities.Disconnect();
            menus.Updatemenu();
         }
         catch (Exception ex)
         {
            Console.Clear();
            Console.WriteLine("Update DVD Actor 1 Error: {0}", ex.Message + "\nPress any key to return to update menu.");
            Console.Clear();
            Console.ReadKey();
            Console.Clear();
       utilities.Disconnect();
            menus.Updatemenu();
         }

    
      }
      
      public void UpdateActor2()
      {
       

         StringWriter sw = new StringWriter();
         XmlTextWriter xmlWriter = new XmlTextWriter(sw);
         try
         {
            
               Console.Clear();
               Console.WriteLine("Update  DVD Second Actor");
               Console.WriteLine();
               utilities.Connect();
               DVD_action = "updateactor2";
               setAction(DVD_action);
               Console.Write("DVD ID: ");
               DVD_ID = Console.ReadLine();
               setID(DVD_ID);
               Console.Write("First Name: ");
               DVD_first2 = Console.ReadLine();
              setFirstname2(DVD_first2);
               Console.Write("Last Name: ");
               DVD_last2 = Console.ReadLine();
              setLastname2(DVD_last2);
               Console.WriteLine();
               Console.WriteLine("Please verify all information");
               Console.WriteLine("DVD ID: {0}\n Name : {1} {2}", getID(), getFirstname2(),getLastname2());
               Console.WriteLine();
            do
               {
                  Console.Write("Correct? (Y/N): ");
                  temp = Console.ReadLine();

                  if (charactervalidation.IsMatch(temp))
                  {
                      option = Convert.ToChar(temp);
                  }
                 
                  option = Char.ToUpper(option);
                  if (option.Equals('N'))
                  {
                     utilities.Disconnect();
                     UpdateActor2();
                  }	
                if (option.Equals('Y'))
                  {

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("Request");
            xmlWriter.WriteElementString("Action", getAction());
            xmlWriter.WriteElementString("ID", getID());
            xmlWriter.WriteElementString("First2",getFirstname2());
            xmlWriter.WriteElementString("Last2",getLastname2());
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();
            xmlWriter.Close();
            Request = sw.ToString();
            sw.Close();
         
          utilities.writer.WriteLine(Request);
                Response = utilities.reader.ReadLine();
                utilities.Disconnect();
            r.Modify(Response);
      
                  }
               } while (!option.Equals('Y') && !option.Equals('N'));
            Console.WriteLine();
           do
           {

            Console.Write("Update another DVD Second Actor (Y/N)? : ");
            temp = Console.ReadLine();

            if (charactervalidation.IsMatch(temp))
            {
                option2 = Convert.ToChar(temp);
            }
           
            option2 = Char.ToUpper(option2);
            if (option2.Equals('Y'))
            {
    
               UpdateActor2();
            }
            else if (option2.Equals('N'))
            {
            
               menus.Updatemenu();
            }
           } while (!option2.Equals('Y') && !option2.Equals('N'));
         }


         catch (XmlException ex)
         {
            Console.Clear();
            Console.WriteLine("XML Document {0}", ex.Message + "\nPress any key to return to update menu.");
            Console.ReadKey();
            Console.Clear();
       utilities.Disconnect();
            menus.Updatemenu();
         }
         catch (Exception ex)
         {
            Console.Clear();
            Console.WriteLine("Update DVD Actor 2 Error: {0}", ex.Message + "\nPress any key to return to update menu.");
            Console.Clear();
            Console.ReadKey();
            Console.Clear();
       utilities.Disconnect();
            menus.Updatemenu();
         }

    
      }
      
      
      public void UpdateCompany()
      {
        
       
         StringWriter sw = new StringWriter();
         XmlTextWriter xmlWriter = new XmlTextWriter(sw);
         try
         {
            
               Console.Clear();
               Console.WriteLine("Update  DVD Production Company");
               Console.WriteLine();
               utilities.Connect();
               DVD_action = "updatecompany";
               setAction(DVD_action);
               Console.Write("DVD ID: ");
               DVD_ID = Console.ReadLine();
               setID(DVD_ID);
               Console.Write("Production Company: ");
               DVD_cp = Console.ReadLine();
               setCompany(DVD_cp);


               Console.WriteLine();
               Console.WriteLine("Please verify all information");
               Console.WriteLine("ID: {0}\nProduction Company : {1}", getID(), getCompany());
               Console.WriteLine();
               do
               {
                  Console.Write("Correct? (Y/N): ");
                  temp = Console.ReadLine();

                  if (charactervalidation.IsMatch(temp))
                  {
                      option = Convert.ToChar(temp);
                  }
                  option = Char.ToUpper(option);
                  if (option.Equals('N'))
                  {
                     utilities.Disconnect();
                     UpdateCompany();
                  }
                if (option.Equals('Y'))
                  {

                     xmlWriter.WriteStartDocument();
                     xmlWriter.WriteStartElement("Request");
                     xmlWriter.WriteElementString("Action", getAction());
                     xmlWriter.WriteElementString("ID", getID());
                     xmlWriter.WriteElementString("Company", getCompany());
                     xmlWriter.WriteEndElement();
                     xmlWriter.WriteEndDocument();
                     xmlWriter.Close();
                     Request = sw.ToString();
                     sw.Close();
                
                   utilities.writer.WriteLine(Request);
                         Response = utilities.reader.ReadLine();
                         utilities.Disconnect();
                     r.Modify(Response);
          
                  }
               } while (!option.Equals('Y') && !option.Equals('N'));
            Console.WriteLine();
           do
           {

            Console.Write("Update another DVD Production Company (Y/N) : ");
            temp = Console.ReadLine();

            if (charactervalidation.IsMatch(temp))
            {
                option2 = Convert.ToChar(temp);
            }
            option2 = Char.ToUpper(option2);
            if (option2.Equals('Y'))
            {
           
               UpdateCompany();
            }
            else if (option2.Equals('N'))
            {
         
               menus.Updatemenu();
            }
           } while (!option2.Equals('Y') && !option2.Equals('N'));
         }


         catch (XmlException ex)
         {
            Console.Clear();
            Console.WriteLine("XML Document {0}", ex.Message + "\nPress any key to return to update menu.");
            Console.ReadKey();
            Console.Clear();
       utilities.Disconnect();
            menus.Updatemenu();
         }
         catch (Exception ex)
         {
            Console.Clear();
            Console.WriteLine("Update DVD Company Error: {0}", ex.Message + "\nPress any key to return to update menu.");
            Console.Clear();
            Console.ReadKey();
            Console.Clear();
       utilities.Disconnect();
            menus.Updatemenu();
         }

      }
      
      public void UpdateGenre()
      {
   
         StringWriter sw = new StringWriter();
         XmlTextWriter xmlWriter = new XmlTextWriter(sw);
         try
         {
            
               Console.Clear();
               Console.WriteLine("Update DVD Genre Code Number");
               Console.WriteLine();
             do
                  {
                     Console.Write("View Genre Category List? (Y/N) : ");
                     temp = Console.ReadLine();

                     if (charactervalidation.IsMatch(temp))
                     {
                         option = Convert.ToChar(temp);
                     }
                     option = Char.ToUpper(option);
                     if (option.Equals('Y'))
                     {
                     
                        Genreslist();
                     }
                     else if (option.Equals('N'))
                     {
                        utilities.Connect();
               DVD_action = "updategenre";
               setAction(DVD_action);
               Console.Write("DVD ID: ");
               DVD_ID = Console.ReadLine();
               setID(DVD_ID);
            
               Console.Write("Genre Code Number: ");
               temp = Console.ReadLine();
               if (numbervalidation.IsMatch(temp))
               {
                   DVD_genre = Convert.ToInt16(temp);
               }
               else
               {
                   DVD_genre = 0;
               }
               setGenre(DVD_genre);


                     }

                  } while (!option.Equals('Y') && !option.Equals('N'));
               Console.WriteLine();
               Console.WriteLine("Please verify all information");
               Console.WriteLine("DVD ID: {0}\nGenre Code Number : {1}", getID(), getGenre());
               Console.WriteLine();
               do
               {
                  Console.Write("Correct? (Y/N): ");

                  temp = Console.ReadLine();

                  if (charactervalidation.IsMatch(temp))
                  {
                      option2 = Convert.ToChar(temp);
                  }
                  option2 = Char.ToUpper(option2);
                  if (option2.Equals('N'))
                  {
                     utilities.Disconnect();
                     UpdateGenre();
                  }
                if (option2.Equals('Y'))
                  {

                     xmlWriter.WriteStartDocument();
                     xmlWriter.WriteStartElement("Request");
                     xmlWriter.WriteElementString("Action", getAction());
                     xmlWriter.WriteElementString("ID", getID());
                     xmlWriter.WriteElementString("Genre", getGenre().ToString());
                     xmlWriter.WriteEndElement();
                     xmlWriter.WriteEndDocument();
                     xmlWriter.Close();
                     Request = sw.ToString();
                     sw.Close();
                
                   utilities.writer.WriteLine(Request);
                         Response = utilities.reader.ReadLine();
                         utilities.Disconnect();
                     r.Modify(Response);
                
                  }
               } while (!option2.Equals('Y') && !option2.Equals('N'));
            Console.WriteLine();
           do
           {

            Console.Write("Update another DVD  Genre Code (Y/N) : ");
            temp = Console.ReadLine();

            if (charactervalidation.IsMatch(temp))
            {
                option3 = Convert.ToChar(temp);
            }
            option3 = Char.ToUpper(option3);
            if (option3.Equals('Y'))
            {
           
               UpdateGenre();
            }
            else if (option3.Equals('N'))
            {

               menus.Updatemenu();
            }
           } while (!option3.Equals('Y') && !option3.Equals('N'));
         }


         catch (XmlException ex)
         {
            Console.Clear();
            Console.WriteLine("XML Document {0}", ex.Message + "\nPress any key to return to update menu.");
            Console.ReadKey();
            Console.Clear();
       utilities.Disconnect();
            menus.Updatemenu();
         }
         catch (Exception ex)
         {
            Console.Clear();
            Console.WriteLine("Update DVD Genre Error: {0}", ex.Message + "\nPress any key to return to update menu.");
            Console.Clear();
            Console.ReadKey();
            Console.Clear();
       utilities.Disconnect();
            menus.Updatemenu();
         }
     
      
      }
      public void UpdateRuntime()
      {
        
         StringWriter sw = new StringWriter();
         XmlTextWriter xmlWriter = new XmlTextWriter(sw);
         try
         {
            
               Console.Clear();
               Console.WriteLine("Update DVD Runtime");
               utilities.Connect();
               DVD_action = "updateruntime";
               setAction(DVD_action);
               Console.Write("DVD ID: ");
               DVD_ID = Console.ReadLine();
               setID(DVD_ID);
               Console.Write("Runtime in minutes : ");
              
               temp = Console.ReadLine();
               if (numbervalidation.IsMatch(temp))
               {
                   DVD_rt = Convert.ToInt16(temp);
               }
               else
               {
                   DVD_rt = 0;
               }
               setRuntime(DVD_rt);


               Console.WriteLine();
               Console.WriteLine("Please verify all information");
               Console.WriteLine("DVD ID: {0}\nRuntime : {1}", getID(), getRuntime());
               Console.WriteLine();
              
              do
               {
                  Console.Write("Correct? (Y/N): ");
                  temp = Console.ReadLine();

                  if (charactervalidation.IsMatch(temp))
                  {
                      option = Convert.ToChar(temp);
                  }
                  option = Char.ToUpper(option);
                  if (option.Equals('N'))
                  {
                     utilities.Disconnect();
                     UpdateRuntime();
                  }	
                if (option.Equals('Y'))
                  {

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("Request");
            xmlWriter.WriteElementString("Action", getAction());
            xmlWriter.WriteElementString("ID", getID());
            xmlWriter.WriteElementString("Runtime",getRuntime().ToString());
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();
            xmlWriter.Close();
            Request = sw.ToString();
            sw.Close();
        
         utilities.writer.WriteLine(Request);
               Response = utilities.reader.ReadLine();
               utilities.Disconnect();
           r.Modify(Response);
           
                  }
               } while (!option.Equals('Y') && !option.Equals('N'));
            Console.WriteLine();
           do
           {

            Console.Write("Update another DVD  Runtime (Y/N) : ");
            temp = Console.ReadLine();

            if (charactervalidation.IsMatch(temp))
            {
                option2 = Convert.ToChar(temp);
            }
            option2 = Char.ToUpper(option2);
            if (option2.Equals('Y'))
            {
           
               UpdateRuntime();
            }
            else if (option2.Equals('N'))
            {
          
               menus.Updatemenu();
            }
           } while (!option2.Equals('Y') && !option2.Equals('N'));
         }
        
         catch (XmlException ex)
         {
            Console.Clear();
            Console.WriteLine("XML Document {0}", ex.Message + "\nPress any key to return to update menu.");
            Console.ReadKey();
            Console.Clear();
       utilities.Disconnect();
            menus.Updatemenu();
         }
         catch (Exception ex)
         {
            Console.Clear();
            Console.WriteLine("Update DVD Runtime Error: {0}", ex.Message + "\nPress any key to return to update menu.");
            Console.Clear();
            Console.ReadKey();
            Console.Clear();
       utilities.Disconnect();
            menus.Updatemenu();
         }
      
      }
      
      public void UpdateType()
      {
     
         StringWriter sw = new StringWriter();
         XmlTextWriter xmlWriter = new XmlTextWriter(sw);
         try
         {
         
               Console.Clear();
               Console.WriteLine("Update DVD Type");
               Console.WriteLine();
               utilities.Connect();
               DVD_action = "updatetype";
               setAction(DVD_action);
               Console.Write("DVD ID: ");
               DVD_ID = Console.ReadLine();
               setID(DVD_ID);
                 Console.Write("Type (D for DVD or B for Blu-ray or U for Unknown): ");
                 temp = Console.ReadLine();
                        if (charactervalidation.IsMatch(temp))
                        {

                           DVD_type = Convert.ToChar(temp);
                        }
                        else
                        {
                           DVD_type = 'u';
                        }
                        DVD_type = Char.ToUpper(DVD_type);

                        setType(DVD_type);
                     
               Console.WriteLine();
               Console.WriteLine("Please verify all information");
               Console.WriteLine("DVD ID: {0}\nType: {1}", getID(), getType());
               Console.WriteLine();
               do
               {
                  Console.Write("Correct? (Y/N): ");
                  temp = Console.ReadLine();

                  if (charactervalidation.IsMatch(temp))
                  {
                      option = Convert.ToChar(temp);
                  }
                  option = Char.ToUpper(option);
                  if (option.Equals('N'))
                  {
                     utilities.Disconnect();
                     UpdateType();
                  }
                if (option.Equals('Y'))
                  {

                     xmlWriter.WriteStartDocument();
                     xmlWriter.WriteStartElement("Request");
                     xmlWriter.WriteElementString("Action", getAction());
                     xmlWriter.WriteElementString("ID", getID());
                     xmlWriter.WriteElementString("Type", getType().ToString());
                     xmlWriter.WriteEndElement();
                     xmlWriter.WriteEndDocument();
                     xmlWriter.Close();
                     Request = sw.ToString();
                     sw.Close();
                
                   utilities.writer.WriteLine(Request);
                         Response = utilities.reader.ReadLine();
                     r.Modify(Response);
                utilities.Disconnect();
                  }
               } while (!option.Equals('Y') && !option.Equals('N'));
            Console.WriteLine();
           do
           {

            Console.Write("Update another DVD  Type (Y/N) : ");
            temp = Console.ReadLine();

            if (charactervalidation.IsMatch(temp))
            {
                option2 = Convert.ToChar(temp);
            }
            option2 = Char.ToUpper(option2);
            if (option2.Equals('Y'))
            {
          
               UpdateType();
            }
            else if (option2.Equals('N'))
            {

               menus.Updatemenu();
            }
           } while (!option2.Equals('Y') && !option2.Equals('N'));
            }
         catch (XmlException ex)
         {
            Console.Clear();
            Console.WriteLine("XML Document {0}", ex.Message + "\nPress any key to return to update menu.");
            Console.ReadKey();
            Console.Clear();
       utilities.Disconnect();
            menus.Updatemenu();
         }
         catch (Exception ex)
         {
            Console.Clear();
            Console.WriteLine("Update DVD Type Error: {0}", ex.Message + "\nPress any key to return to update menu.");
            Console.Clear();
            Console.ReadKey();
            Console.Clear();
       utilities.Disconnect();
            menus.Updatemenu();
         }

      
      }
      public void Delete()
      {

         StringWriter sw = new StringWriter();
         XmlTextWriter xmlWriter = new XmlTextWriter(sw);
         try
         {
          
               Console.Clear();
               Console.WriteLine("Temporary Delete DVD");
               Console.WriteLine();
               DVD_action = "temp";
               utilities.Connect();
               setAction(DVD_action);
               Console.Write("DVD ID: ");
               DVD_ID = Console.ReadLine();
               setID(DVD_ID);
              

               Console.WriteLine();
               Console.WriteLine("Please verify all information");
               Console.WriteLine("DVD ID: {0}",getID());
               Console.WriteLine();
                 do
               {
                  Console.Write("Correct? (Y/N): ");
                  temp = Console.ReadLine();

                  if (charactervalidation.IsMatch(temp))
                  {
                     option = Convert.ToChar(temp);

                  }
               
                  option = Char.ToUpper(option);
                  if (option.Equals('N'))
                  {
                     utilities.Disconnect();
                     Delete();
                  }
                  if (option.Equals('Y'))
                  {
                     xmlWriter.WriteStartDocument();
                     xmlWriter.WriteStartElement("Request");
                     xmlWriter.WriteElementString("Action", getAction());
                     xmlWriter.WriteElementString("ID", getID());
                     xmlWriter.WriteEndElement();
                     xmlWriter.WriteEndDocument();
                     xmlWriter.Close();
                     Request = sw.ToString();
                     sw.Close();

                     utilities.writer.WriteLine(Request);
                     Response = utilities.reader.ReadLine();
                     utilities.Disconnect();
                     r.Modify(Response);

                  }
               } while (!option.Equals('Y') && !option.Equals('N'));
            Console.WriteLine();
           do
           {

            Console.Write("Delete another DVD (Y/N) : ");
            temp = Console.ReadLine();

            if (charactervalidation.IsMatch(temp))
            {
               option2 = Convert.ToChar(temp);

            }
            option2 = Char.ToUpper(option2);
            if (option2.Equals('Y'))
            {
            
               Delete();
            }
            else if (option2.Equals('N'))
            {
        
               menus.DeleteandUndomenu();
            }
           } while (!option2.Equals('Y') && !option2.Equals('N'));
         }
         catch (XmlException ex)
         {
            Console.Clear();
            Console.WriteLine("XML Document {0}", ex.Message + "\n Press any key to return to delete & undo menu.");
            Console.ReadKey();
            utilities.Disconnect();
            xmlWriter.Close();
            sw.Close();
            menus.DeleteandUndomenu();
         }
         catch (Exception ex)
         {
            Console.Clear();
            Console.WriteLine("Delete DVD Error: {0}", ex.Message + "\nPress any key to return to delete & undo menu.");
            Console.ReadKey();
            utilities.Disconnect();
            xmlWriter.Close();
            sw.Close();
            menus.DeleteandUndomenu();
         }
      }

      public void Purge()
      {
       
            StringWriter sw = new StringWriter();
            XmlTextWriter xmlWriter = new XmlTextWriter(sw);
            try
            {
             
                  Console.Clear();
                  Console.WriteLine("Purge DVD");
                  Console.WriteLine();
                  utilities.Connect();
                  DVD_action = "delete";
                  setAction(DVD_action);
                  Console.Write("DVD ID: ");
                  DVD_ID = Console.ReadLine();
                  setID(DVD_ID);


                  Console.WriteLine();
                  Console.WriteLine("Please verify all information. Please remember that this will completely remove all information of the DVD  permanently");
                  Console.WriteLine("DVD ID: {0}", getID());
                  Console.WriteLine();
                  do
                  {
                     Console.Write("Correct? (Y/N): ");
                     temp = Console.ReadLine();

                     if (charactervalidation.IsMatch(temp))
                     {
                        option= Convert.ToChar(temp);

                     }
                     option = Char.ToUpper(option);
                     if (option.Equals('N'))
                     {
                        utilities.Disconnect();
                        Purge(); 
                     }
                   if (option.Equals('Y'))
                     {

                        xmlWriter.WriteStartDocument();
                        xmlWriter.WriteStartElement("Request");
                        xmlWriter.WriteElementString("Action", getAction());
                        xmlWriter.WriteElementString("ID", getID());
                        xmlWriter.WriteEndElement();
                        xmlWriter.WriteEndDocument();
                        xmlWriter.Close();
                        Request = sw.ToString();
                        sw.Close();
                    
                      utilities.writer.WriteLine(Request);
                            Response = utilities.reader.ReadLine();
                            utilities.Disconnect();
                        r.Modify(Response);
                   
                     }
                  } while (!option.Equals('Y') && !option.Equals('N'));
               Console.WriteLine();
               do
               {
                  Console.Write("Purge another DVD (Y/N) : ");
                  temp = Console.ReadLine();

                  if (charactervalidation.IsMatch(temp))
                  {
                     option2 = Convert.ToChar(temp);

                  }
                  option2 = Char.ToUpper(option2);
                  if (option2.Equals('Y'))
                  {
                
                     Purge();
                  }
                  else if (option2.Equals('N'))
                  {
         
                     menus.DeleteandUndomenu();
                  }
               } while (!option2.Equals('Y') && !option2.Equals('N'));
            }


            catch (XmlException ex)
            {
               Console.Clear();
               Console.WriteLine("XML Document {0}", ex.Message + "\nPress any key to return to delete & undo menu.");
               Console.ReadKey();
               utilities.Disconnect();
               xmlWriter.Close();
               sw.Close();
               menus.DeleteandUndomenu();
            }
            catch (Exception ex)
            {
               Console.Clear();
               Console.WriteLine("Purge DVD Error: {0}", ex.Message + "\nPress any key to return to delete & undo menu.");
               Console.ReadKey();
            
               utilities.Disconnect();
               xmlWriter.Close();
               sw.Close();
               menus.DeleteandUndomenu();
            }

            
      }
      public void Recovery()
      {

         StringWriter sw = new StringWriter();
            XmlTextWriter xmlWriter = new XmlTextWriter(sw);
            try
            {
              
                  Console.Clear();
                  Console.WriteLine("Undo Deletion");
                  Console.WriteLine();
                  DVD_action = "recover";
                  setAction(DVD_action);
                  utilities.Connect();
                  Console.Write("DVD ID: ");
                  DVD_ID = Console.ReadLine();
                  setID(DVD_ID);
                  Console.WriteLine();
                  Console.WriteLine("Please verify all information");
                  Console.WriteLine("ID: {0}", getID());
                  Console.WriteLine();
                  do
                  {
                     Console.Write("Correct? (Y/N): ");
                     temp = Console.ReadLine();

                     if (charactervalidation.IsMatch(temp))
                     {
                        option = Convert.ToChar(temp);

                     }
                     option = Char.ToUpper(option);
                     if (option.Equals('N'))
                     {
                        utilities.Disconnect();
                        Recovery();
                     }
                   if (option.Equals('Y'))
                     {
                        xmlWriter.WriteStartDocument();
                        xmlWriter.WriteStartElement("Request");
                        xmlWriter.WriteElementString("Action", getAction());
                        xmlWriter.WriteElementString("ID", getID());
                        xmlWriter.WriteEndElement();
                        xmlWriter.WriteEndDocument();
                        xmlWriter.Close();
                        Request = sw.ToString();
                        sw.Close();
                     
                      utilities.writer.WriteLine(Request);
                            Response = utilities.reader.ReadLine();
                            utilities.Disconnect();
                      r.Modify(Response);
                   
                     
                     }
                  } while (!option.Equals('Y') && !option.Equals('N'));
            Console.WriteLine();
            do
            {

               Console.Write("Undo Deletion on another DVD (Y/N) : ");
               temp = Console.ReadLine();

               if (charactervalidation.IsMatch(temp))
               {
                  option2 = Convert.ToChar(temp);

               }
               option2 = Char.ToUpper(option2);
               if (option2.Equals('Y'))
               {
                 
                  Recovery();
               }
               else if (option2.Equals('N'))
               {
          
                  menus.DeleteandUndomenu();
               }
            } while (!option2.Equals('Y') && !option2.Equals('N'));
            }


            catch (XmlException ex)
            {
               Console.Clear();
               Console.WriteLine("XML Document {0}", ex.Message + "\nPress any key to return to delete & undo menu.");
               Console.ReadKey();
               utilities.Disconnect();
               xmlWriter.Close();
               sw.Close();
               menus.DeleteandUndomenu();
            }
            catch (Exception ex)
            {
               Console.Clear();
               Console.WriteLine("Recover DVD Error: {0}", ex.Message + "\nPress any key to return to delete & undo menu.");
               Console.ReadKey();
               utilities.Disconnect();
               xmlWriter.Close();
               sw.Close();
               menus.DeleteandUndomenu();
            }
          
      }
      public void SearchTitle()
      {


         StringWriter sw = new StringWriter();
         XmlTextWriter xmlWriter = new XmlTextWriter(sw);
         try
         {
            
               Console.Clear();
               Console.WriteLine("Search by Title");
               utilities.Connect();
               DVD_action = "searchtitle";
               setAction(DVD_action);
               Console.Write("Title: ");
               DVD_title = Console.ReadLine();
               if (DVD_title.Equals( string.Empty))
               {
                  SearchTitle();
               }
            setTitle(DVD_title);
               Console.WriteLine();
              
            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("Request");
            xmlWriter.WriteElementString("Action", getAction());
            xmlWriter.WriteElementString("Title", getTitle());
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();
            xmlWriter.Close();
            Request = sw.ToString();
            sw.Close();
          
         utilities.writer.WriteLine(Request);
             Response = utilities.reader.ReadLine();
             utilities.Disconnect();
         movie = r.SearchTitle(Response);
     
            Console.WriteLine();
            Console.WriteLine("DVD ID\t Title");
            for (int i = 0; i < movie.Length; i+=2)
            {
               Console.WriteLine("{0}\t{1}",  movie[i],movie[i+1] );

            }
            Console.WriteLine();
           do
           {
              
            Console.Write("Start a new search by Title (Y/N) : ");
            temp = Console.ReadLine();

            if (charactervalidation.IsMatch(temp))
            {
                option = Convert.ToChar(temp);
            }
            option = Char.ToUpper(option);
            if (option.Equals('Y'))
            {
              
               SearchTitle();
            }
            else if (option.Equals('N'))
            {
              
               menus.Searchmenu();
            }
           } while (!option.Equals('Y') && !option.Equals('N'));
            }


         catch (XmlException ex)
         {
            Console.Clear();
            Console.WriteLine("XML Document {0}", ex.Message + "\nPress any key to return to search menu.");
            Console.ReadKey();
            utilities.Disconnect();
            xmlWriter.Close();
            sw.Close();
            menus.Searchmenu();
         }
         catch (Exception ex)
         {
            Console.Clear();
            Console.WriteLine("Search Title DVD Error: {0}", ex.Message + "\nPress any key to return to search menu.");
            Console.ReadKey();
            utilities.Disconnect();
            xmlWriter.Close();
            sw.Close();
            menus.Searchmenu();
         }
      }
      public void SearchActor1()
      {

         StringWriter sw = new StringWriter();
            XmlTextWriter xmlWriter = new XmlTextWriter(sw);
            try
            {

               Console.Clear();
               Console.WriteLine("Search by First Actor");
               Console.WriteLine();
               DVD_action = "searchactor1";
               setAction(DVD_action);
               utilities.Connect();
               Console.Write("Last Name: ");
               DVD_last = Console.ReadLine();
              if (DVD_last.Equals(string.Empty))
               {
                  utilities.Disconnect();
                  SearchActor1();
               }
               setLastname(DVD_last);
               Console.WriteLine();
               xmlWriter.WriteStartDocument();
               xmlWriter.WriteStartElement("Request");
               xmlWriter.WriteElementString("Action", getAction());
               xmlWriter.WriteElementString("Last",getLastname());
               xmlWriter.WriteEndElement();
               xmlWriter.WriteEndDocument();
               xmlWriter.Close();
               Request = sw.ToString();
               sw.Close();
             
             utilities.writer.WriteLine(Request);
                   Response = utilities.reader.ReadLine();
          utilities.Disconnect();
          movie = r.SearchActor1(Response);
        
          Console.WriteLine();
          Console.WriteLine("Firstname\tLastname\tTitle");
          for (int i = 0; i < movie.Length; i +=3)
          {
             Console.WriteLine("{0}\t\t{1}\t{2}", movie[i], movie[i + 1],movie[i+2]);

          }
               Console.WriteLine();
               do
               {


                  Console.Write("Start a new search by First Actor (Y/N) : ");
                  temp = Console.ReadLine();

                  if (charactervalidation.IsMatch(temp))
                  {
                     option = Convert.ToChar(temp);

                  }
                  option = Char.ToUpper(option);
                  if (option.Equals('Y'))
                  {
                  
                     SearchActor1();
                  }
                  else if (option.Equals('N'))
                  {
                 
                     menus.Searchmenu();
                  }
               } while (!option.Equals('Y') && !option.Equals('N'));
            }

           
            catch (XmlException ex)
            {
               Console.Clear();
               Console.WriteLine("XML Document {0}", ex.Message + "\nPress any key to return to search menu.");
     
               Console.ReadKey();
               utilities.Disconnect();
               xmlWriter.Close();
               sw.Close();
               menus.Searchmenu();
            }
            catch (Exception ex)
            {
               Console.Clear();
               Console.WriteLine("Search Actor 1 DVD Error: {0}", ex.Message + "\nPress any key to return to search menu.");
               Console.ReadKey();
               utilities.Disconnect();
               xmlWriter.Close();
               sw.Close();
               menus.Searchmenu();
            }

        
         }
      
      public void SearchActor2()
      {

         StringWriter sw = new StringWriter(); 
            XmlTextWriter xmlWriter = new XmlTextWriter(sw);
            try
            {

               Console.Clear();
               Console.WriteLine("Search by Second Actor");
               Console.WriteLine();
               DVD_action = "searchactor2";
               setAction(DVD_action);
               utilities.Connect();
               Console.Write("Last Name: ");
               DVD_last2 = Console.ReadLine();
               if (DVD_last2.Equals(string.Empty))
               {
                  SearchActor2();
               }
               setLastname2(DVD_last2);
               Console.WriteLine();

               xmlWriter.WriteStartDocument();
               xmlWriter.WriteStartElement("Request");
               xmlWriter.WriteElementString("Action", getAction());
               xmlWriter.WriteElementString("Last2",getLastname2());
               xmlWriter.WriteEndElement();
               xmlWriter.WriteEndDocument();
               xmlWriter.Close();
               Request = sw.ToString();
               sw.Close();
           
             utilities.writer.WriteLine(Request);
             Response = utilities.reader.ReadLine();
             utilities.Disconnect();
             movie = r.SearchActor2(Response);

             Console.WriteLine();
             Console.WriteLine("Firstname\tLastname\tTitle");
             for (int i = 0; i < movie.Length; i += 3)
             {
                Console.WriteLine("{0}\t\t{1}\t{2}", movie[i], movie[i + 1], movie[i + 2]);

             }
             Console.WriteLine();
             do
             {

                Console.Write("Start a new search by Second Actor (Y/N) : ");
                temp = Console.ReadLine();

                if (charactervalidation.IsMatch(temp))
                {
                   option = Convert.ToChar(temp);

                }
                option = Char.ToUpper(option);
                if (option.Equals('Y'))
                {
                   
                   SearchActor2();
                }
                else if (option.Equals('N'))
                {
                   menus.Searchmenu();
                }
             } while (!option.Equals('Y') && !option.Equals('N'));
            }

            catch (XmlException ex)
            {
               Console.Clear();
               Console.WriteLine("XML Document {0}", ex.Message + "\nPress any key to return to search menu.");
               Console.ReadKey();
               utilities.Disconnect();
               xmlWriter.Close();
               sw.Close();
               menus.Searchmenu();
            }
            catch (Exception ex)
            {
               Console.Clear();
               Console.WriteLine("Search Actor 2 DVD Error: {0}", ex.Message + "\nPress any key to return to search menu.");
               Console.ReadKey();
               utilities.Disconnect();
               xmlWriter.Close();
               sw.Close();
               menus.Searchmenu();
            }

       
         }
      public void SearchCompany()
      {
       
         StringWriter sw = new StringWriter();
         XmlTextWriter xmlWriter = new XmlTextWriter(sw);
         try
         {

            Console.Clear();
            Console.WriteLine("Search by Production Company");
            Console.WriteLine();
            DVD_action = "searchcompany";
            setAction(DVD_action);
            utilities.Connect();
            Console.Write("Production Company: ");
            DVD_cp = Console.ReadLine();
            if (DVD_cp.Equals(string.Empty))
            {
               SearchCompany();
            }
            setCompany(DVD_cp);
            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("Request");
            xmlWriter.WriteElementString("Action", getAction());
            xmlWriter.WriteElementString("Company", getCompany());
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();
            xmlWriter.Close();
            Request = sw.ToString();
            sw.Close();
        
          utilities.writer.WriteLine(Request);
          Response = utilities.reader.ReadLine();
          utilities.Disconnect();
          movie = r.SearchCompany(Response);

          Console.WriteLine();
       Console.WriteLine();
       Console.WriteLine("Production Company\t Title");
       for (int i = 0; i < movie.Length; i += 2)
       {
          Console.WriteLine("{0}\t\t{1}", movie[i], movie[i + 1]);

       }

            Console.WriteLine();
            do
            {
            Console.Write("Start a new search by Production Company (Y/N) : ");
            temp = Console.ReadLine();

            if (charactervalidation.IsMatch(temp))
            {
               option = Convert.ToChar(temp);

            }
            option = Char.ToUpper(option);
            if (option.Equals('Y'))
            {
            
               SearchCompany();
            }
            else if (option.Equals('N'))
            {

               menus.Searchmenu();
            }
           } while (!option.Equals('Y') && !option.Equals('N'));
            }


         catch (XmlException ex)
         {
            Console.Clear();
            Console.WriteLine("XML Document {0}", ex.Message + "\nPress any key to return to search menu.");
            Console.ReadKey();
            utilities.Disconnect();
            xmlWriter.Close();
            sw.Close();
            menus.Searchmenu();
         }
         catch (Exception ex)
         {
            Console.Clear();
            Console.WriteLine("Search Company DVD Error: {0}", ex.Message + "\nPress any key to return to search menu.");
            Console.ReadKey();
            utilities.Disconnect();
            xmlWriter.Close();
            sw.Close();
            menus.Searchmenu();
         }
      }
      
      public void SearchGenre()
      {


         StringWriter sw = new StringWriter();
         XmlTextWriter xmlWriter = new XmlTextWriter(sw);
         try
         {
            
               Console.Clear();
               Console.WriteLine("Search by Genre Code Number");
               Console.WriteLine();
             do
               {
                  Console.Write("View Genre Category List? (Y/N) : ");
                  temp = Console.ReadLine();

                  if (charactervalidation.IsMatch(temp))
                  {
                     option = Convert.ToChar(temp);

                  }
                  option = Char.ToUpper(option);
                  if (option.Equals('Y'))
                  {
                    
                     Genreslist();
                  }
                  else if (option.Equals('N'))
                  {
               DVD_action = "searchgenre";
               setAction(DVD_action);
               utilities.Connect();
               Console.Write("Genre Code Number: ");
               temp = Console.ReadLine();
               if (numbervalidation.IsMatch(temp))
               {
                  DVD_genre = Convert.ToInt16(temp);
               }
               else
               {
                  SearchGenre();
               }
               setGenre(DVD_genre);
                  }
             } while (!option.Equals('Y') && !option.Equals('N'));
            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("Request");
            xmlWriter.WriteElementString("Action", getAction());
            xmlWriter.WriteElementString("Genre", getGenre().ToString());
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();
            xmlWriter.Close();
            Request = sw.ToString();
            sw.Close();
        
          utilities.writer.WriteLine(Request);
          Response = utilities.reader.ReadLine();
          utilities.Disconnect();
          movie = r.SearchGenre(Response);

          Console.WriteLine();
       Console.WriteLine();
       Console.WriteLine("Genre Category\tTitle");
       for (int i = 0; i < movie.Length; i += 2)
       {
          Console.WriteLine("{0}\t\t{1}", movie[i], movie[i + 1]);

       }
            Console.WriteLine();
           do
           {

            Console.Write("Start a new search by Genre Code Number (Y/N) : ");
            temp = Console.ReadLine();

            if (charactervalidation.IsMatch(temp))
            {
               option2 = Convert.ToChar(temp);

            }
            option2 = Char.ToUpper(option2);
            if (option2.Equals('Y'))
            {
             
               SearchGenre(); 
            }
            else if (option2.Equals('N'))
            {
            
               menus.Searchmenu();
            }
           } while (!option2.Equals('Y') && !option2.Equals('N'));
         }

         catch (XmlException ex)
         {
            Console.Clear();
            Console.WriteLine("XML Document {0}", ex.Message + "\nPress any key to return to search menu.");
            Console.ReadKey();
            utilities.Disconnect();
            xmlWriter.Close();
            sw.Close();
            menus.Searchmenu();
         }
         catch (Exception ex)
         {
            Console.Clear();
            Console.WriteLine("Search Genre DVD Error: {0}", ex.Message + "\nPress any key to return to search menu.");
            Console.ReadKey();
            utilities.Disconnect();
            xmlWriter.Close();
            sw.Close();
            menus.Searchmenu();
         }

  
      
      }
      public void SearchRuntime()
      {

         StringWriter sw = new StringWriter();
         XmlTextWriter xmlWriter = new XmlTextWriter(sw);
         try
         {

            Console.Clear();
            Console.WriteLine("Search by Runtime");
            Console.WriteLine();
            DVD_action = "searchruntime";
            setAction(DVD_action);
            utilities.Connect();
            Console.Write("Runtime in minutes:  ");
            temp = Console.ReadLine();
            if (numbervalidation.IsMatch(temp))
            {
               DVD_rt = Convert.ToInt16(temp);
            }
            else
            {
              SearchRuntime ();
            }
            setRuntime(DVD_rt);

            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("Request");
            xmlWriter.WriteElementString("Action", getAction());
            xmlWriter.WriteElementString("Runtime", getRuntime().ToString());
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();
            xmlWriter.Close();
            Request = sw.ToString();
            sw.Close();
      
          utilities.writer.WriteLine(Request);
          Response = utilities.reader.ReadLine();
          utilities.Disconnect();
          movie = r.SearchRuntime(Response);

          Console.WriteLine();
       Console.WriteLine("Runtime (minutes)\tTitle");
       for (int i = 0; i < movie.Length; i += 2)
       {
          Console.WriteLine("{0}\t\t\t{1}", movie[i], movie[i + 1]);

       }
            Console.WriteLine();
            do
            {

               Console.Write("Start a new search by Runtime (Y/N) : ");
               temp = Console.ReadLine();

               if (charactervalidation.IsMatch(temp))
               {
                   option = Convert.ToChar(temp);
               }
               option = Char.ToUpper(option);
               if (option.Equals('Y'))
               {
                  Console.Clear();
                  SearchRuntime();
               }
               else if (option.Equals('N'))
               {
                  Console.Clear();
                  menus.Searchmenu();
               }
            } while (!option.Equals('Y') && !option.Equals('N'));
         }
         catch (XmlException ex)
         {
            Console.Clear();
            Console.WriteLine("XML Document {0}", ex.Message + "\nPress any key to return to search menu.");
            Console.ReadKey();
            utilities.Disconnect();
            xmlWriter.Close();
            sw.Close();
            menus.Searchmenu();
         }
         catch (Exception ex)
         {
            Console.Clear();
            Console.WriteLine("Search Runtime DVD Error: {0}", ex.Message + "\nPress any key to return to search menu.");
            Console.ReadKey();
            utilities.Disconnect();
            xmlWriter.Close();
            sw.Close();
            menus.Searchmenu();
         }
      }
     
      public void SearchType ()
      {

         StringWriter sw = new StringWriter();
         XmlTextWriter xmlWriter = new XmlTextWriter(sw);
         try
         {
            
               Console.Clear();
               Console.WriteLine("Search by Type");
               Console.WriteLine();
               DVD_action = "searchtype";
               setAction(DVD_action);
               utilities.Connect();
              Console.Write("Type (D for DVD or B for Blu-ray or U for Unknown): ");
              temp = Console.ReadLine();
                        if (charactervalidation.IsMatch(temp))
                        {

                           DVD_type = Convert.ToChar(temp);
                        }
                        else
                        {
                          SearchType ();
                        }
                        DVD_type = Char.ToUpper(DVD_type);

                        setType(DVD_type);
                     
            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("Request");
            xmlWriter.WriteElementString("Action", getAction());
            xmlWriter.WriteElementString("Type", getType().ToString());
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();
            xmlWriter.Close();
            Request = sw.ToString();
            sw.Close();
         
          utilities.writer.WriteLine(Request);
          Response = utilities.reader.ReadLine();
          utilities.Disconnect();
          movie = r.SearchType(Response);
          Console.WriteLine("DVD Type\t Title");
          for (int i = 0; i < movie.Length; i += 2)
          {
             
             Console.WriteLine("{0}\t{1}", movie[i], movie[i + 1]);

          }
          Console.WriteLine();
            Console.WriteLine();
            do
            {

            Console.Write("Start a new search by Type (Y/N) : ");
            temp = Console.ReadLine();

            if (charactervalidation.IsMatch(temp))
            {
                option = Convert.ToChar(temp);
            }
            option = Char.ToUpper(option);
            if (option.Equals('Y'))
            {
          
               SearchType(); 
            }
            else if (option.Equals('N'))
            {
          
               menus.Searchmenu();
            }
                           
           } while (!option.Equals('Y') && !option.Equals('N'));
            }


         catch (XmlException ex)
         {
            Console.Clear();
            Console.WriteLine("XML Document {0}", ex.Message + "\nPress any key to return to search menu.");
            Console.ReadKey();
            utilities.Disconnect();
            xmlWriter.Close();
            sw.Close();
            menus.Searchmenu();
         }
         catch (Exception ex)
         {
            Console.Clear();
            Console.WriteLine("Search Type DVD Error: {0}", ex.Message + "\nPress any key to return to search menu.");
            Console.ReadKey();
            utilities.Disconnect();
            xmlWriter.Close();
            sw.Close();
            menus.Searchmenu();
         }
     
      
      }
      public void SearchStatus()
      {

         StringWriter sw = new StringWriter();
         XmlTextWriter xmlWriter = new XmlTextWriter(sw);
         try
         {
            
               Console.Clear();
               Console.WriteLine("Search by Status");
               Console.WriteLine();
               DVD_action = "searchstatus";
               setAction(DVD_action);
               utilities.Connect();
            Console.Write("Status (E for exist or N for not exist): ");
            temp = Console.ReadLine();
            if (charactervalidation.IsMatch(temp))
            {

              DVD_stat= Convert.ToChar(temp);
            }
            else
            {
               SearchStatus();
            }
               DVD_stat = Char.ToUpper(DVD_stat);
               setStatus(DVD_stat);
            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("Request");
            xmlWriter.WriteElementString("Action", getAction());
            xmlWriter.WriteElementString("Status",getStatus().ToString());
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();
            xmlWriter.Close();
            Request = sw.ToString();
            
            sw.Close();
         
            utilities.writer.WriteLine(Request);
            Response = utilities.reader.ReadLine();
            utilities.Disconnect();
            movie = r.SearchStatus(Response);

            Console.WriteLine();
            Console.WriteLine("Status\tDVD ID\t\tTitle");
            for (int i = 0; i < movie.Length; i += 3)
            {
               Console.WriteLine("{0}\t{1}\t\t{2}", movie[i], movie[i + 1], movie[i + 2]);

            }
            Console.WriteLine();

            do
            {

            Console.Write("Start a new search by Status (Y/N) : ");
            temp = Console.ReadLine();

            if (charactervalidation.IsMatch(temp))
            {
                option = Convert.ToChar(temp);
            }
            option = Char.ToUpper(option);
            if (option.Equals('Y'))
            {
      
               SearchStatus(); 
            }
            else if (option.Equals('N'))
            {
            
               menus.Searchmenu();
            }
                           
           } while (!option.Equals('Y') && !option.Equals('N'));
            }


         catch (XmlException ex)
         {
            Console.Clear();
            Console.WriteLine("XML Document {0}", ex.Message + "\nPress any key to return to search menu.");
            Console.ReadKey();
            utilities.Disconnect();
            xmlWriter.Close();
            sw.Close();
            menus.Searchmenu();
         }
         catch (Exception ex)
         {
            Console.Clear();
            Console.WriteLine("Search Type DVD Error: {0}", ex.Message + "\nPress any key to return to search menu.");
            Console.ReadKey();
            utilities.Disconnect();
            xmlWriter.Close();
            sw.Close();
            menus.Searchmenu();
         }
     
      
      
      }
      public void SelectID()
      {
        
        
         StringWriter sw = new StringWriter();
         XmlTextWriter xmlWriter = new XmlTextWriter(sw);
         try
         {
           
               Console.Clear();
               Console.WriteLine("Select DVD ID");
               Console.WriteLine();
               DVD_action = "selectID";
               setAction(DVD_action);
               utilities.Connect();
               Console.Write("ID: ");
               DVD_ID = Console.ReadLine();
               setID(DVD_ID);
               Console.WriteLine();
               Console.WriteLine("Please verify all information");
               Console.WriteLine("ID : {0}", getID());
               Console.WriteLine();
               do
               {
                  Console.Write("Correct? (Y/N): ");
                  temp = Console.ReadLine();

                  if (charactervalidation.IsMatch(temp))
                  {
                      option = Convert.ToChar(temp);
                  }
                  option = Char.ToUpper(option);
                  if (option.Equals('N'))
                  {
                     utilities.Disconnect();
                     SelectID();
                  }
                if (option.Equals('Y'))
                  {
                     xmlWriter.WriteStartDocument();
                     xmlWriter.WriteStartElement("Request");
                     xmlWriter.WriteElementString("Action", getAction());
                     xmlWriter.WriteElementString("ID", getID());
                     xmlWriter.WriteEndElement();
                     xmlWriter.WriteEndDocument();
                     xmlWriter.Close();
                     Request = sw.ToString();
                     sw.Close();
                 
                   utilities.writer.WriteLine(Request);
                         Response = utilities.reader.ReadLine();
                     r.Select(Response);
                utilities.Disconnect();
                  }
               } while (!option.Equals('Y') && !option.Equals('N'));
            Console.WriteLine();
           do
           {


            Console.Write("Select another DVD by ID (Y/N) : ");
            temp = Console.ReadLine();

            if (charactervalidation.IsMatch(temp))
            {
                option2 = Convert.ToChar(temp);
            }
            option2 = Char.ToUpper(option2);
            if (option2.Equals('Y'))
            {
       
               SelectID();
            }
            else if (option2.Equals('N'))
            {
               menus.Selectmenu();
            }
           } while (!option2.Equals('Y') && !option2.Equals('N'));
         }


         catch (XmlException ex)
         {
            Console.Clear();
            Console.WriteLine("XML Document {0}", ex.Message + "\nPress any key to return to select menu.");
            Console.ReadKey();
            utilities.Disconnect();
            xmlWriter.Close();
            sw.Close();
            menus.Selectmenu();
         }
         catch (Exception ex)
         {
            Console.Clear();
            Console.WriteLine("Select ID DVD Error: {0}", ex.Message + "\nPress any key to return to select menu.");
            Console.ReadKey();
            utilities.Disconnect();
            xmlWriter.Close();
            sw.Close();
            menus.Selectmenu(); 
         }
      }
    
      public void SelectTitle()
      {

         StringWriter sw = new StringWriter();
            XmlTextWriter xmlWriter = new XmlTextWriter(sw);
            try
            {
             
                  Console.Clear();
                  Console.WriteLine("Select DVD title");
                  Console.WriteLine();
                  DVD_action = "selecttitle";
                  setAction(DVD_action);
                utilities.Connect();
                  Console.Write("Title: ");
                  DVD_title = Console.ReadLine();
                  setTitle(DVD_title);
                  Console.WriteLine();
                  Console.WriteLine("Please verify all information");
                  Console.WriteLine("Title : {0}", getTitle());
                  Console.WriteLine();
                  do
                  {
                     Console.Write("Correct? (Y/N): ");
                     temp = Console.ReadLine();

                     if (charactervalidation.IsMatch(temp))
                     {
                         option = Convert.ToChar(temp);
                     }
                     option = Char.ToUpper(option);
                     if (option.Equals('N'))
                     {
                        utilities.Disconnect();
                        SelectTitle();
                     }
                   if (option.Equals('Y'))
                     {

                        xmlWriter.WriteStartDocument();
                        xmlWriter.WriteStartElement("Request");
                        xmlWriter.WriteElementString("Action", getAction());
                        xmlWriter.WriteElementString("Title", getTitle());
                        xmlWriter.WriteEndElement();
                        xmlWriter.WriteEndDocument();
                        xmlWriter.Close();
                        Request = sw.ToString();
                        sw.Close();
                      
                      utilities.writer.WriteLine(Request);
                            Response = utilities.reader.ReadLine();
                        r.Select(Response);
                   utilities.Disconnect();
                     }
                  } while (!option.Equals('Y') && !option.Equals('N'));
            Console.WriteLine();
            
            {
               Console.Write("Select another DVD Title (Y/N) : ");
               temp = Console.ReadLine();

               if (charactervalidation.IsMatch(temp))
               {
                   option2 = Convert.ToChar(temp);
               }
               option2 = Char.ToUpper(option2);
               if (option2.Equals('Y'))
               {
      
                  SelectTitle();
               }
               else if (option2.Equals('N'))
               {
    
                  menus.Selectmenu();
               }
            } while (!option2.Equals('Y') && !option2.Equals('N'));
            }


            catch (XmlException ex)
            {
               Console.Clear();
               Console.WriteLine("XML Document {0}", ex.Message + "\nPress any key to return to select menu.");
               Console.ReadKey();
               utilities.Disconnect();
               xmlWriter.Close();
               sw.Close();
               menus.Selectmenu();
            }
            catch (Exception ex)
            {
               Console.Clear();
               Console.WriteLine("Select ID DVD Error: {0}", ex.Message + "\nPress any key to return to select menu.");
               Console.ReadKey();
               utilities.Disconnect();
               xmlWriter.Close();
               sw.Close();
               menus.Selectmenu();
            }  
      }
      public void Genreslist()
      {
         byte Choice = 0;
         StringWriter sw = new StringWriter();
         XmlTextWriter xmlWriter = new XmlTextWriter(sw);
      

            Console.Clear();
            Console.WriteLine("Genre Category List");
            Console.WriteLine();
            DVD_action = "getgenre";
            setAction(DVD_action);
            utilities.Connect();
            xmlWriter.WriteStartDocument();
            xmlWriter.WriteStartElement("Request");
            xmlWriter.WriteElementString("Action", getAction());
            xmlWriter.WriteEndElement();
            xmlWriter.WriteEndDocument();
            xmlWriter.Close();
            Request = sw.ToString();
            sw.Close();
           
          utilities.writer.WriteLine(Request);
                Response = utilities.reader.ReadLine();
           movie = r.Generelist(Response);
            utilities.Disconnect();
            Console.WriteLine("Code\t Genre");
            for (int i = 0; i < movie.Length; i++)
            {
               Console.WriteLine("{0}\t{1}", i, movie [i]);

            }
            do
            {
            Console.WriteLine();
            Console.WriteLine("Please select previous screen from list below");
            Console.WriteLine();
           
               Console.WriteLine("Add All               Press 1");
               Console.WriteLine("Update All            Press 2");
               Console.WriteLine("Update Genre          Press 3");
               Console.WriteLine("Search Genre          Press 4");
               Console.WriteLine();
               Console.Write("Choice:");
               temp = Console.ReadLine();
               if (numbervalidation.IsMatch(temp))
               {
                  Choice = Convert.ToByte(temp);
               }
} while (!Choice.Equals(1)&&!Choice.Equals(2)&&!Choice.Equals(3)&&!Choice.Equals(4));
               
            switch (Choice)
            {
               case 1:
                  AddAll();
                  break;
               case 2:
                  UpdateAll();
                  break;
               case 3:
                  UpdateGenre();
                  break;
               case 4:
                  SearchGenre();
                  break;
               default:
                  Genreslist();
                  break;
            }
         }
   }
   }