using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
namespace Password_Cracking_Program
{ 
    
    class Operations
    {
       //Getters and setters for needed information and a constructor. Along with variables

       private LinkedList<string> Termlist;
           private LinkedList<string> Text;
           private String rightanswer;
           //Initializing variablesFor method to use
        private   LinkedList<string> words = new LinkedList<string>();
         private  LinkedList<string> passkey = new LinkedList<string>();
          private LinkedList<string> Information = new LinkedList<string>();
        private   string word, Key, secretinfo, Newfilename, Fname;
        private int number = 0, Counter = 0, end = 0, Even;
           private StreamWriter writer;
           private Boolean found;
           private FileInfo textfile;
           //Grab the given directory is and put them into variables
           private String Wordlistpath = System.Environment.CurrentDirectory + @"\Data\wordlists\";
           private String Passwordpath = System.Environment.CurrentDirectory + @"\Data\passwords\";
           private String Gameinfopath = System.Environment.CurrentDirectory + @"\Data\gameinformation\";
           private String extension = ".txt";
           private Char confirmation, Confirmation2;
           private String temp, Line;
           private Boolean exist;
           
           public LinkedList<string> Message
           {
              get {return Text;}
              set { Text = value; }

           }
        public LinkedList<string> Wordlist
        {
            get
            {
                return Termlist;
            }
           set
           {

              Termlist  = value;
           }
        }
        public string Answer
        {
           get { return rightanswer; }
           set { rightanswer = value; }
        }
       
       
        public Operations()
        {
       
            Termlist = new LinkedList<string>();
        
        }
    
        public void Creation()
        {

           Console.WriteLine("Creating game files");
         
           Console.WriteLine();
           CreateWords();
           CreatePassword();
           CreateGameInfo();
           CreateFiles();
           CreateAgain();
        }
        public void CreateWords()
       {
        
           //Make sure to enter an even number of words
            Console.WriteLine("How many words would you like to enter?");
            
           do
           {


              number = Convert.ToInt32(Console.ReadLine());
              Even = number % 2;
             
                 if (Even!=0)
                 {
                    Console.WriteLine("Number of words not even. Please enter an even number of words.");

                 }
              }
           while (Even!=0);
           //Making sure all letters are lowercase in the word and there is no whitespace between letters and that all words are the same length. 
           //If they are add them to link list
           do
           {
              Console.Write("Please enter word: ");
              word = Console.ReadLine();
              word = word.ToLower();
              word = word.Trim();
              if (words.Count > 0)
              {
                 Line =words.Last();
                if (word.Length != Line.Length)
                    {
                       Console.Write("All words in word list not the same length. Please enter word again: ");
                       word = Console.ReadLine();
                       word = word.ToLower();
                       words.AddLast(word);
                    }
                    else
                    {
                       words.AddLast(word);
                    }
                  

                 }
              

              else
              {
                 words.AddLast(word);
              }
              Counter++;
           }
           while (number > Counter);
       }
       public void CreatePassword()
       {
           //Do the same thing with the password as above with a list of words. Also make sure that password is in a linked list of words
           do
           {
              Console.Write("Please enter password: ");
              Key = Console.ReadLine();
              Key = Key.ToLower();
              Key = Key.Trim();
              found = words.Contains(Key);
              if (found == true)
              {
                 passkey.AddLast(Key);
              }

           }

           while (found == false);
       }
    public void CreateGameInfo ()
    {

           Console.WriteLine("Please enter Game information display after the password is cracked: ");
           //Type in information and add each line to link list
           Boolean Informationentered= false;
   do 
           {
              if (Informationentered == true)
              {
                 Console.WriteLine("Continue writing game information: ");
              }
              secretinfo = Console.ReadLine();
              Information.AddLast(secretinfo);
              Console.Write("Are you done writing the information? (Y/N): ");
              confirmation = Convert.ToChar(Console.ReadLine());
              confirmation = Char.ToUpper(confirmation);
              Informationentered = true;

           }
   while(confirmation.Equals('N')&&!confirmation.Equals('Y'));
    }
       public void CreateFiles ()
       {
          //Create the files and store them in the proper directories
          //if file is already created user is asked to overwrite the files if applicable
   Console.Write("Please enter the filename: ");
   Fname = Console.ReadLine();
   Fname = Fname.Trim();
   do
   {
     
      Newfilename = Wordlistpath + Fname + extension;
      textfile = new FileInfo(Newfilename);
      exist = File.Exists(Newfilename);
      if (exist == true)
      {
         Console.Write("File already exists. Would you like to override it? (Y/N): ");
         confirmation = Convert.ToChar(Console.ReadLine());
         confirmation = Char.ToUpper(confirmation);
         if (confirmation.Equals('Y'))
         {
            textfile.Delete();
            Newfilename = Passwordpath+Fname+ extension;
            textfile = new FileInfo(Newfilename);
            textfile.Delete();
            Newfilename = Gameinfopath+Fname  + extension;
            textfile = new FileInfo(Newfilename);
            textfile.Delete();
      
         }
         if (confirmation.Equals('N'))
         {
            Console.Write("Please enter the filename: ");
            Fname = Console.ReadLine();
            Fname=Fname.Trim();
            Newfilename = Wordlistpath + Fname + extension;
            textfile = new FileInfo(Newfilename);
         }
      }
      else
      {
         writer =textfile.CreateText();
         end = words.Count - 1;
         for (int i = 0; i < words.Count; i++)
         {
            temp = words.ElementAt(i);
           if (i == end)
           {
                writer.Write(temp );

           }

           else
           {
              writer.Write(temp+ "," );

           }

           

   }
         writer.Close();
         Newfilename =   Passwordpath+Fname + extension;
         textfile = new FileInfo(Newfilename);
        writer = textfile.CreateText();
        for (int i = 0; i < passkey.Count; i++)
        {
           temp = passkey.ElementAt(i);
           writer.Write(temp);
        }
        writer.Close();
         Newfilename = Gameinfopath+Fname + extension;
         textfile = new FileInfo(Newfilename);
        writer = textfile.CreateText();
        for (int i = 0; i < Information.Count; i++)
        {
           temp = Information.ElementAt(i);
           writer.Write(temp);
        }
        writer.Close();
      }
      
   }

   
   while (exist == true);

   Console.WriteLine("Files have been written to the folders with the current filename of: {0}", Fname + extension);
   Console.WriteLine();
       }
       public void CreateAgain ()
       {
          //user is asked to start the process over and create another set of files. If yes call creation method if no,Go to main menu
   Console.WriteLine("Do you want to create another set of files. (Y/N)");

           Confirmation2= Convert.ToChar(Console.ReadLine());
         Confirmation2 = Char.ToUpper(Confirmation2);
         if (Confirmation2.Equals('Y'))
         {
            Console.Clear();
            Creation();
         }
         if (Confirmation2.Equals('N'))
         {
            Console.Clear();
            menu.Mainmenu();
         }
        }
        public void Loadwordlist(String Filename)
        {
        //Load list of words from the file into link list
           LinkedList<string> Terms = new LinkedList<string>();
            Termlist.Clear();   // remove all elements    

            StreamReader sr = new StreamReader(System.Environment.CurrentDirectory+@"\Data\wordlists\" + Filename);

            String line = null;

            line = sr.ReadLine();

            while (line != null)
            {
               String[] elements = line.Split(',');
               foreach (string i in elements)
               {
                  Termlist.AddLast(i);
               }
                
               line = sr.ReadLine();
            }

            sr.Close();
           //Set list of terms setter
            Wordlist = Termlist;
            
           
        }
             public void loadpassword(String Filename) 
        {
           //Load Password from the file into String
           StreamReader sr = new StreamReader(System.Environment.CurrentDirectory + @"\Data\passwords\" + Filename);

            String line = null;
            String rightanswer = null;

            line = sr.ReadLine();

            while (line != null)
            {
               rightanswer= line;
                
               line = sr.ReadLine();
            }

            sr.Close();
            //Set Password setter
            Answer = rightanswer;
           
        }
             public void loadgameinformation(string Filename)
             {
                //Load Game information from the file into link list
                 LinkedList<string> Text = new LinkedList<string>();

                 StreamReader sr = new StreamReader(System.Environment.CurrentDirectory + @"\Data\gameinformation\" + Filename);

                 String line = null;

                 line = sr.ReadLine();

                 while (line != null)
                 {
                     Text.AddLast(line);

                     line = sr.ReadLine();
                 }

                 sr.Close();
                 //Set Information message setter
                 Message = Text;
             }
             public void useroperation(LinkedList<String> Text, LinkedList<string> Termlist, string rightanswer)
             {
                //User get three chances to guess the correct password
                //if users exceed more Game information will display
                //Otherwise A shutdown message will display

                //Variables
                bool available;
                LinkedListNode<String> node=Termlist.First;
                string first, second,  Guess, Prediction, Unlocked;
                 StringBuilder password = new StringBuilder(rightanswer.Length);
                 LinkedList<string> Storage = new LinkedList<string>();
                 char guesscharacter, answercharacter, predictioncharacter,wrongcharacter = '*';
                //Chances = number of user's Try Count = number of letters
                //Count= number of letters right
                //letter  = the letter that is being currently checked
                //Index =The index value of the letter position
                 //Index2 =The index value of the letter position If one word or more has Entered
                 //index2next =Move to the next index value
                //Remove =The index value of the placeholder character
                //Wordsentered=Number of words entered
                 int chances  = 1, Count = 0, Letter = 0, Index, Index2,index2next=0,Remove=0,Wordsentered = 0;
             
                Console.Clear();
                 Console.WriteLine("Welcome to NOVA 3000 series");
                 Console.WriteLine();
                //Display word terms into rows
                 for (int x = 0; x < Termlist.Count; x += 2)
                 {
                    first = node.Value;
                    node = node.Next;
                    second = node.Value;
                    node = node.Next;
                    Console.WriteLine("{0}\t{1}", first, second);
                 }

                 do
                 {
                    //User enters a password Guess

                    Console.Write("Password: ");
                    Guess = Console.ReadLine();
                    Guess = Guess.ToLower();
                    Guess = Guess.Trim();
                    //If users guess is a list of termsThen added to list of words already guess
                    //If users guess = password then display game information and breakout Of loop
                    available = Termlist.Contains(Guess);
                    if (available == true)
                    {
                       Storage.AddLast(Guess);
                     
                       if (Guess.Equals(rightanswer))
                       {
                          Console.WriteLine();
                          foreach (string line in Text)
                          {
                             Console.WriteLine(line);
                          }
                          break;
                       }
                       else
                       {
                          //Else goes through the password from the file and the user's guess character by character
                          //to see if the characters and character position Matches. 
                          //If they doIncrease the number of correct letters by 1 for every character
                          //Add it later to the password string
                          //Else Add wrong character placeholder to password in the index position indicated
                          //Only do this when users first guess
                          for (int x = 0; x <rightanswer.Length; ++x)
                          {
                             answercharacter = rightanswer[x];
                             for (int i = Letter; i <Guess.Length; i = +Guess.Length)
                             {
                                guesscharacter = Guess[i];
                                Index = i;
                                if (guesscharacter.Equals(answercharacter) && Count != Guess.Length && Wordsentered== 0)
                                {

                                   Count++;
                                   password.Append(guesscharacter);
                                }

                                else if (!guesscharacter.Equals(answercharacter) && Wordsentered == 0)
                                {
                                   password.Append(wrongcharacter);


                                }
                                ////If user is passed first try then fill in wrong answer characters with the correct characters at the right indexes
                                if (Wordsentered >= 1)
                                {
                                 Prediction=password.ToString();
                         
                                   for (int a = 0; a < Prediction.Length; a++)
                                   {
                                      predictioncharacter = Prediction[a];
                                      Index2 = Prediction.IndexOf(predictioncharacter);
                                      if (Count != Guess.Length && predictioncharacter.Equals(wrongcharacter))
                                      {

                                         if (Prediction.ElementAt(Index2).Equals(wrongcharacter) && Index != Index2)
                                         {

                                            Index2=index2next++;
                                         }
                                         if (Index == Index2 && a == Index2)
                                         {
                                            Remove = Index2++ ;
                                            if (guesscharacter.Equals(answercharacter))
                                            {
                                               password.Insert(Remove, guesscharacter);
                                               password.Remove(Index2, 1);
                                               Count++;
                                            }
                                         }
                                      }
                                      else
                                      {
                                         index2next++;
                                      }
                                   }
                             index2next=0;
                                }
                               Letter++;
                             }
                            
                          }
                        
                        Letter =0;
                       }
                      Wordsentered++;
                       //Display number of letters correct and if password string = password from file display  information
                    Console.WriteLine("number correct: {0}",  Count);
                    Console.WriteLine();
                    Unlocked = password.ToString();

                    if (Unlocked.Equals(rightanswer))
                    {
                       foreach (string line in Text)
                       {
                          Console.WriteLine(line);
                       }
                       break;
                    }
                    if (chances > 1)
                    {
                       //Show previous word tries
                       Console.Write(" previous attempts include:");
                       foreach (string guess in Storage)
                       {
                          Console.Write(guess + ",");
                       }
                    }
                    Console.WriteLine();
                    chances++;
                    }
                    else

                    {
                       //if word Is not in word list
                       Console.WriteLine();
                       Console.WriteLine("Entry is not a possible password.Please try again");
                    }
                 }while (chances <= 3||available==false);
                //If user does not guess password display message
                 if (chances > 3)
                 {
                    Console.WriteLine();
                     Console.WriteLine("login failed, system locked. Please contact system administrator");
                     
                 }
             }
       
        }
}
