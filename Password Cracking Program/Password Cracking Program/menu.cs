using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
namespace Password_Cracking_Program
{
   class menu
   {
      static private Regex numbervalidation = new Regex(@"^\d+$");
     //Method to show main menu and donumber validations and exceptions
      public static void Mainmenu()
      {
         Operations o = new Operations();
         byte Choice = 0;
         String temp;
         try
         {

            Console.Clear();
            Console.WriteLine("Main Menu");
            Console.WriteLine();
            Console.WriteLine("To Create a New group of files           Press 1");
            Console.WriteLine("To Crack a password                     Press 2");
            Console.WriteLine("Exit                                    Press 3");
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
  //Activate menu option given user input

            switch (Choice)
            {
               case 1:
                  Console.Clear();
                  o.Creation();     
             
                  break;
               case 2:
                  Console.Clear();
                  secondmenu();
                  break;
               case 3:
                  Environment.Exit(-1);
                  break;
               default:
                  Console.Clear();
                  Mainmenu();
                  break;
            }
         }
         catch (NotImplementedException e)
         {
            Console.Clear();
            Console.WriteLine("An error has occurred." + e.Message);
            Console.WriteLine("Press any key to return to main menu.");
            Console.ReadKey();
            Mainmenu();
         }
         catch (Exception e)
         {
            Console.Clear();
            Console.WriteLine("An error has occurred." + e.Message);
            Console.WriteLine("Press any key to return to main menu.");
            Console.ReadKey();
            Mainmenu();
         }
      }

      public static void secondmenu()
      {
         Operations o = new Operations();
         DirectoryInfo Wordlistsdirectory = new DirectoryInfo(System.Environment.CurrentDirectory + @"\Data\wordlists\");
         FileInfo[] Listfiles = Wordlistsdirectory.GetFiles();
         String filename,  choice;
         int Number = 0, Numberoption=0;
       
         int  Finalnumber;
         LinkedList<string> Filestorage = new LinkedList<string>();
         //For each File in array add filename to link list
         foreach (FileInfo i in Listfiles)
         {
            filename = Path.GetFileName(i.ToString());
            Filestorage.AddLast(filename);

         }
         Console.WriteLine("Please select a file.");
         Console.WriteLine();
         //For each member of link list show number position +1 and Choose a file
         for (int b = 0; b < Filestorage.Count; b++)
         {
            Number = b + 1;
            Console.WriteLine("To Load File Group {0}          Press {0}", Number);
         }
         Finalnumber = Filestorage.Count + 1;
         Console.WriteLine("Exit                          Press {0}", Finalnumber);
         Console.WriteLine();
         Console.Write("Choice:");
         choice = Console.ReadLine();
         //If choice is a valid number then store it in integer variable. Else call menu again
         if (numbervalidation.IsMatch(choice))
         {
           Numberoption=Convert.ToInt32(choice);
         }
         else
         {
            secondmenu();
         }
         //Convert integer variables back to link list index values
         Numberoption = Numberoption - 1;
         Finalnumber = Finalnumber - 1;
         //Loop through link list and if index value = integer value then grabbed the file name at that position and load the three corresponding files
         //associated with that nameAnd begin main part of program. Else call menu again
         for (int b = 0; b < Filestorage.Count; b++)
         {
            if (b == Numberoption)
            {
               filename = Filestorage.ElementAt(b);
               o.Loadwordlist(filename);
               o.loadpassword(filename);
               o.loadgameinformation(filename);
               o.useroperation(o.Message, o.Wordlist, o.Answer);
               
            }
            if (Numberoption == Finalnumber)
            {
               Console.Clear();
               Mainmenu();
              
            }
            if (Numberoption > Finalnumber)
            {
               Console.Clear();
               secondmenu();
            }
         }
      }
   }

      }
