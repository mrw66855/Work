using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.IO;
using System.Net;
using System.Net.Sockets;
namespace DVD_client
{
   class menus
   {
     static private Regex numbervalidation = new Regex(@"^\d+$");

    static byte Choice = 0;
    static string temp;
     
      public  static void Mainmenu()
      {

          DVD d = new DVD();
      
         try
         {

            Console.Clear();
            Console.WriteLine("Welcome to DVD collection program. Please select an option from the menu below.");
            Console.WriteLine();
           
            Console.WriteLine("Add DVD                Press 1");
            Console.WriteLine("Update DVD             Press 2");
            Console.WriteLine("Delete or Undo DVD     Press 3");
            Console.WriteLine("Search for DVD         Press 4");
            Console.WriteLine("Select DVD             Press 5");
            Console.WriteLine("Exit                   Press 6");
            Console.WriteLine();
            
            Console.Write("Choice:");
            temp = Console.ReadLine();
            if (numbervalidation.IsMatch(temp))
            {
               Choice = Convert.ToByte(temp);
            }
            else
            {
               Mainmenu();
            }

        
            
            switch (Choice)
            {
               case 1:
                  Addmenu();
                  break;
               case 2:
                  Updatemenu();
                  break;
               case 3:
                  DeleteandUndomenu();
                  break;
               case 4:
                  Searchmenu();
                  break;
               case 5:
                  Selectmenu();
                  break;
               case 6:
                  Environment.Exit(-1);
                  break;
               default:
                  Mainmenu();
                  break;
            }
         }
         catch (NotImplementedException ex)
         {
            Console.Clear();
            Console.WriteLine("Main Menu Loading Error: {0}", ex.Message+ "\n Press any key to return to main menu.");
            Console.ReadKey();
            Mainmenu();
         }
         catch (OverflowException ex)
         {
            Console.Clear();
            Console.WriteLine("Overflow Error: {0}", ex.Message + "\n Press any key to return to Main menu.");
            Console.ReadKey();
            Mainmenu();
         }
         catch (Exception ex)
         {
            Console.Clear();
            Console.WriteLine("General Error: {0}", ex.Message + "\n Press any key to return to main menu.");
            Console.ReadKey();
            Mainmenu();
         }
        
      }
      
      public static void Selectmenu()
     
      {
          DVD d = new DVD();
         
         try
         {
          
               Console.Clear();
               Console.WriteLine("Select Menu.");
               Console.WriteLine();
               Console.WriteLine("Select DVD by ID              Press 1");
               Console.WriteLine("Select DVD by Title           Press 2");
               Console.WriteLine("Back to Main Menu             Press 3");
               Console.WriteLine();
               Console.Write("Choice:");

               temp = Console.ReadLine();
               if (numbervalidation.IsMatch(temp))
               {
                   Choice = Convert.ToByte(temp);
               }
               else
               {
                  Selectmenu();
               }
               Console.Clear(); 
            
            switch (Choice)
            {
               case 1:
                  d.SelectID();
                  break;
               case 2:
                  d.SelectTitle();
                  break;
               case 3:
                  Mainmenu();
                  break;
               default:
                  Selectmenu();
                  break;
            }
         }
         catch (NotImplementedException ex)
         {
            Console.Clear();
          Console.WriteLine("Select Menu Loading Error: {0}", ex.Message+ "\nPress any key to return to main menu.");
            Console.ReadKey();
            Mainmenu();
         }
         catch (OverflowException ex)
         {
            Console.Clear();
            Console.WriteLine("Overflow Error: {0}", ex.Message + "\n Press any key to return to select menu.");
            Console.ReadKey();
            Selectmenu();
         }

         catch (Exception ex )
         {
            Console.Clear();
              Console.WriteLine("General Error: {0}", ex.Message+ "\nPress any key to return to main menu.");
            Console.ReadKey();
            Mainmenu();
         }
      }
      

     public static void Searchmenu()
      {
         DVD d = new DVD();
        
         try
         {
           
               Console.Clear();
               Console.WriteLine("Search Menu.");
               Console.WriteLine();
               Console.WriteLine("Search by Title              Press 1");
               Console.WriteLine("Search by First Actor        Press 2");
               Console.WriteLine("Search by Second Actor       Press 3");
               Console.WriteLine("Search by Production Company Press 4");
               Console.WriteLine("Search by  Genre             Press 5");
               Console.WriteLine("Search by Runtime            Press 6");
               Console.WriteLine("Search by Type               Press 7");
               Console.WriteLine("Search by Status             Press 8");
               Console.WriteLine("Back to Main Menu            Press 9");
               Console.WriteLine();
               Console.Write("Choice:");
               temp = Console.ReadLine();
               if (numbervalidation.IsMatch(temp))
               {
                   Choice = Convert.ToByte(temp);
               }
               else
               {
                Searchmenu ();
               }
               Console.Clear();
            
            switch (Choice)
            {
               case 1:
                  d.SearchTitle();
                  break;
               case 2:
                  d.SearchActor1();
                  break;
               case 3:
                  d.SearchActor2();
                  break;
               case 4:
                  d.SearchCompany();
                  break;
               case 5:
                  d.SearchGenre();
                  break;
               case 6:
                  d.SearchRuntime();
                  break;
               case 7:
                  d.SearchType();
                  break;
               case 8:
                  d.SearchStatus();
                  break;
               case 9:
                  Mainmenu();
                  break;
               default:
                  Searchmenu();
                  break;
            }
         }
         catch (NotImplementedException ex)
         {
            Console.Clear();
            Console.WriteLine("Search Menu Loading Error: {0}", ex.Message + " \n Press any key to return to main menu.");
            Console.ReadKey();
            Mainmenu();
         }
         catch (OverflowException ex)
         {
            Console.Clear();
            Console.WriteLine("Overflow Error: {0}", ex.Message + "\n Press any key to return to search menu.");
            Console.ReadKey();
            Searchmenu(); 
         }
         catch (Exception ex)
         {
            Console.Clear();
            Console.WriteLine("General Error: {0}", ex.Message + "\n Press any key to return to main menu.");
            Console.ReadKey();
            Mainmenu();
         }
      }

     public static void DeleteandUndomenu()
      {
          DVD d = new DVD();
         try
         {
           
               Console.Clear();
               Console.WriteLine("Delete & Undo Menu.");
               Console.WriteLine();
               Console.WriteLine("Temporary Delete               Press 1");
               Console.WriteLine("Permanently Delete             Press 2");
               Console.WriteLine("Undo Deletion                  Press 3");
               Console.WriteLine("Back to Main Menu              Press 4");
               Console.WriteLine();
               Console.Write("Choice:");
               temp = Console.ReadLine();
               if (numbervalidation.IsMatch(temp))
               {
                   Choice = Convert.ToByte(temp);
               }
               else
               {
                  DeleteandUndomenu();
               }
               Console.Clear();
       
            switch (Choice)
            {
               case 1:
                  d.Delete();
                  break;
               case 2:
                  d.Purge();
                  break;
               case 3:
                  d.Recovery();
                  break;
               case 4:
                  Mainmenu();
                  break;
               default:
                  DeleteandUndomenu();
                  break;
            }
         }
         catch (NotImplementedException ex)
         {
            Console.Clear();
            Console.WriteLine("Delete & Undo Menu Loading Error: {0}", ex.Message + "Press any key to return to main menu.");
            Console.ReadKey();
            Mainmenu();
         }
         catch (OverflowException ex)
         {
            Console.Clear();
            Console.WriteLine("Overflow Error: {0}", ex.Message + "\n Press any key to return to delete & undo.");
            Console.ReadKey();
            DeleteandUndomenu();
         }
         catch (Exception ex)
         {
            Console.Clear();
            Console.WriteLine("General Error: {0}", ex.Message + "\n Press any key to return to main menu.");
            Console.ReadKey();
            Mainmenu();
         }
      }

      public  static void Updatemenu()
      {
         DVD d = new DVD();
      
         try
         {
            
               Console.Clear();
               Console.WriteLine("Update Menu.");
               Console.WriteLine();
          
               Console.WriteLine("Update Full DVD               Press 1");
               Console.WriteLine("Update Title                  Press 2");
               Console.WriteLine("Update First Actor's Name     Press 3");
               Console.WriteLine("Update Second Actor's Name    Press 4");
               Console.WriteLine("Update Production Company     Press 5");
               Console.WriteLine("Update Genre                  Press 6");
               Console.WriteLine("Update Running Time           Press 7");
               Console.WriteLine("Update Type                   Press 8");
               Console.WriteLine("Back to Main Menu             Press 9");
               Console.WriteLine();
               Console.Write("Choice:");
               temp = Console.ReadLine();
               if (numbervalidation.IsMatch(temp))
               {
                   Choice = Convert.ToByte(temp);
               }
               else
               {
                  Updatemenu() ;
               }
               Console.Clear();
            
            switch (Choice)
            {
               case 1:
                  d.UpdateAll();
                  break;
               case 2:
                  d.UpdateTitle();
                  break;
               case 3:
                  d.UpdateActor1();
                  break;
               case 4:
                  d.UpdateActor2();
                  break;
               case 5:
                  d.UpdateCompany();
                  break;
               case 6:
                  d.UpdateGenre();
                  break;
               case 7:
                  d.UpdateRuntime();
                  break;
               case 8:
                  d.UpdateType();
                  break;
               case 9:
                  Mainmenu();
                  break;
               default:
                  Updatemenu();
                  break;
            }
         }
         catch (NotImplementedException ex)
         {
            Console.Clear();
          Console.WriteLine("Update Menu Loading Error: {0}", ex.Message+ "\n Press any key to return to main menu.");
            Console.ReadKey();
            Mainmenu();
         }
         catch (OverflowException ex)
         {
            Console.Clear();
            Console.WriteLine("Overflow Error: {0}", ex.Message + "\n Press any key to return to update menu.");
            Console.ReadKey();
            Updatemenu();
         }
         catch (Exception ex )
         {
            Console.Clear();
              Console.WriteLine("General Error: {0}", ex.Message+"\n Press any key to return to main menu.");
            Console.ReadKey();
            Mainmenu();
         }
         
      }

      public static void Addmenu()
      {
          DVD d = new DVD();
         try
         {
           
               Console.Clear();
               Console.WriteLine("Add Menu.");
               Console.WriteLine();
               Console.WriteLine("Add Full DVD               Press 1");
               Console.WriteLine("Add Title                  Press 2");
               Console.WriteLine("Back to Main Menu          Press 3");
               Console.WriteLine();
               Console.Write("Choice:");
               temp = Console.ReadLine();
               if (numbervalidation.IsMatch(temp))
               {
                   Choice = Convert.ToByte(temp);
               }
               else
               {
                  Addmenu();
               }
               Console.Clear();
       
            switch (Choice)
            {
               case 1:
                  d.AddAll();
                  break;
               case 2:
                  d.AddTitle();
                  break;
               case 3:
                  Mainmenu();
                  break;
               default:
                  Addmenu();
                  break;
            }
         }
         catch (NotImplementedException ex)
         {
            Console.Clear();
            Console.WriteLine("Add Menu Loading Error: {0}", ex.Message + "\n Press any key to return to main menu.");
            Console.ReadKey();
            Mainmenu();
         }
         catch (OverflowException ex)
         {
            Console.Clear();
            Console.WriteLine("Overflow Error: {0}", ex.Message + "\n Press any key to return to add menu.");
            Console.ReadKey();
            Addmenu();
         }

         catch (Exception ex)
         {
            Console.Clear();
            Console.WriteLine("General Error: {0}", ex.Message + "\n Press any key to return to main menu.");
            Console.ReadKey();
            Mainmenu();
         }
      }

      }
   }
        

