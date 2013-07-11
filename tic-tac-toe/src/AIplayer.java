import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;
import java.util.*;
public class AIplayer 
{
	//Variable declaration
	private char [][]board = new char [3][3];
	private String player1;
	private String PC;
	private int currentPlayer;
	private char marker1;
   private char PCmarker;
    private int plays;
    private BufferedReader br = new BufferedReader(new InputStreamReader (System.in));
 
   //Setup gameboard with digits one through nine in three rows.
    //Allow first player to go and set the number of places zero.
    public void beginningboard()
    {
    	int counter = 0;
        for (int rows = 0; rows < 3; rows++) 
        {
            for (int columns = 0; columns < 3; columns++)
            {
            board [rows][columns]=Character.forDigit(++counter, 10);
            }
            }
        currentPlayer =getCurrentPlayer() ;
        plays = 0;
    }
  public void changeplayers()
  //Switch from player one's turn to player two's turn or vice versa
  //update the amount of plays
  {
	  if (getCurrentPlayer() ==1)
	  {
		  setCurrentPlayer(2);
		  
	  }
	  else
	  {
		  setCurrentPlayer(1);  
	  }
	  setPlays(getPlays() + 1);
  }
  //Place x  or o on the board in the correct position given by user
 public boolean placeMarker(int play) 
 {
	  for (int rows = 0; rows < 3;rows++) 
	  {
	  for (int columns = 0; columns < 3;columns++) 
	  {
		  if (board[rows][columns] == Character.forDigit(play, 10)) {
			  board[rows][columns] = (getCurrentPlayer() == 1) ? getMarker1() : getPCmarker();
			  return true;
			  }
			  }
			  }
			  return false;
			  }

//Checking if game is over meaning there are three characters in one column or row or diagonally. Indexes started zero

 public boolean winner() {
	//Checking rows
	char position = ' ';
	for (int columns = 0; columns < 3; columns++) 
	{
		int rows= 0;
		for (rows = 0; rows < 3; rows++) {
		if (!Character.isLetter(board[columns][rows])) {
		break;
		}
		if (rows == 0) {
		position = board[columns][rows];
		} else if (position != board[columns][rows]) {
		break;
		}

	if (rows == 2)
	{
	//Found winner
	return true;
	}
	}
	}
	//Checking columns
	for (int rows = 0; rows < 3; rows++) 
	{
	position = ' ';
	int columns= 0;
	for (columns = 0; columns < 3; columns++) {
	if (columns == 0)
	{
	position = board[columns][rows];
	} 
	else if (position != board[columns][rows]) {
	break;
	}
	if (columns == 2) {
	//Found winner
	return true;
	}
	}
	}
	//Checking diagonals
	position = board[0][0];
	if (Character.isLetter(position) && board[1][1] == position && board[2][2] == position) 
	{
	return true;
	}
	position = board[2][0];
	if (Character.isLetter(position) && board[1][1] == position && board[0][2] == position) 
	{
	return true;
	}
	else
	{
	return false;
	}
	}
 //Draw board to screen and update with moves
 public String createBoard() 
 {
	 String draw ="Game board: \n";
	
	 for (int rows = 0; rows < 3; rows++)
	 {	
	 for (int columns = 0; columns < 3; columns++) 
	 {
	 draw+=("[" + board[rows][columns] + "]");
	 }
	draw+= ("\n");
	 }
	 return draw.toString();
 }
//Get the names of the  players
public void names()
{
System.out.println("Welcome! Tic Tac Toe  one player game.");
System.out.print("Enter player one's name: ");
try {
	setPlayer1(br.readLine());
} catch (IOException e) {
	// TODO Auto-generated catch block
	e.printStackTrace();
}


	setPC("computer");
}

//Have the players select the appropriate game pieces. Whoever selects x will go first and the other player will be automatically assigned  the oor vice versa
public  void gamepieces ()
{
	String firstchoice= "";
	String secondchoice = "";
    boolean markervalid = false;
    System.out.println("the X marker will go first " );
    while (!markervalid) 
    {//Getting information from user
        System.out.print("Select x or o as " + getPlayer1() + "'s marker: ");
    	try {
				firstchoice= br.readLine();
			} catch (IOException e) {
				// TODO Auto-generated catch block
				e.printStackTrace();
			}
    	//guarding against invalid choices and setting the markers to the appropriate letters
            if (firstchoice.equalsIgnoreCase("X")&&
                    Character.isLetter(firstchoice.toCharArray()[0])) 
            {
                markervalid = true;
               setMarker1(firstchoice.toCharArray()[0]);
               secondchoice ="o";
               secondchoice.equals("o") ;  
               Character.isLetter(secondchoice.toCharArray()[0]);
               setPCmarker(secondchoice.toCharArray()[0]);
               
            }
           	//guarding against invalid choices and setting the markers to the appropriate letters
            else if (firstchoice.equalsIgnoreCase("O")&
                       Character.isLetter(firstchoice.toCharArray()[0])) 
               {
                   markervalid = true;
                  setMarker1(firstchoice.toCharArray()[0]);
                  secondchoice ="x";
                  secondchoice.equals("x") ;  
                  Character.isLetter(secondchoice.toCharArray()[0]);
                  setPCmarker(secondchoice.toCharArray()[0]);
                  
            } //If user selects something other than the two choices  ask again
            else if (!firstchoice.equalsIgnoreCase("X")||!firstchoice.equalsIgnoreCase("O")) 

            {
                System.out.println("Invalid marker, try again");
            }
    }
               System.out.print(getMarker1 ()+" is " + getPlayer1()+"'s marker " );
         System.out.print( getPCmarker ()+" is "+ getPC()+ "'s marker. ");
    
         System.out.println ();
	
}

public void playerorder ()
{//Determine who goes first based on x 
	if (getMarker1()=='x'||getMarker1()=='X')
	{
		setCurrentPlayer(1);
		
		   System.out.println(  getPlayer1()+" will be going first");
	}

	else if (getPCmarker()=='x'||getPCmarker()=='X') 
	{
		setCurrentPlayer(2);
		   System.out.println(  getPC()+" will be going first");
		   
	}
} 
public boolean humanchoice (String square,String player, int pick, boolean allowed)
{
	while (!allowed)
    {
        System.out.print("It is " + player + "'s turn. Pick a square: ");
        try {
			square =br.readLine();
		} catch (IOException e1) {
			// TODO Auto-generated catch block
			e1.printStackTrace();
		}//check if players entry is valid and converted to character
        if (square.length() == 1 && Character.isDigit(square.toCharArray()[0])) {
            
            try {
            	//convert entry to integer
                pick = Integer.parseInt(square);
} catch (NumberFormatException e) {
                //Do nothing here, it'll evaluate as an invalid pick on the next row.
            }
            //place marker and appropriate spot
            allowed = placeMarker(pick);
        }
        if (!allowed) 
        {//if entries are invalid  try again
            System.out.println("Square can not be selected. Retry");
        }

}
	return allowed;
	}
 public boolean strategyRandom(String square,String player, boolean allowed)
 
 {//This method will get the computer's choice of move
Random move = new Random ();
int number=0;
 square="";

 System.out.print("It is " + player + "'s turn. Pick a square: ");

while (! allowed)
{
number= 1+ move.nextInt (9);//generating numbers one through nine

square =Integer.toString(number);//converting to string
if ( Character.isDigit(square.toCharArray()[0])) 
{
int pick = 0;
try {
pick = Integer.parseInt(square);//converting string to integer
} catch (NumberFormatException e) {
//Do nothing here, it'll evaluate as an invalid pick on the next row.
}
allowed = placeMarker(pick);//placing number on board
}
}
return allowed;
}


 public void game()
 {//Play game
 Menus home = new Menus ();	

     boolean Playing = true;
     
     String player ="";
     String square = "";
     
     int pick=0;
     while (Playing) {

     	beginningboard();//create the boardthe initial state of the board
         System.out.println(createBoard ());//draw the board
         System.out.println();

         //while no winner has been found and plays are less than nine
         while (!winner() && getPlays() < 9)
         {//allow current player to go 
             player = getCurrentPlayer() == 1 ?getPlayer1() : getPC();
             boolean allowed = false;
             if (player.equals(getPlayer1()))
             {
            	 humanchoice (square, player, pick, allowed);//calling human choice method
             
              changeplayers();//switching players
             System.out.println();
             System.out.println(createBoard());//drawing board of current state
             System.out.println();
             }
             
             if (player.equals(getPC()) )
             {
            	 strategyRandom (square, player, allowed);//calling random strategy
             
             
     changeplayers();//switching players
     System.out.println();
     System.out.println(createBoard());///drawing board of current state
     System.out.println();
             }
        
             }
         
     


         


         if (winner()) 
         	
         {//display who won the game
             System.out.println("Game Over - " + player + " WINS!!!");
         } else 
         {//if no one   won the game is a draw
             System.out.println("Game Over - Draw");
         }
         System.out.println();
         //ask the user if they want to play again if yes start the game over if no  call main menu
         System.out.print("Play again? (Y/N): ");
         try {
         	String choice  =br.readLine();
             if (choice.equalsIgnoreCase("Y")) 
             {
             	playerorder ();
                 Playing =true;
             }
         else if (choice.equalsIgnoreCase("N"))
         {
           Playing = false;
         	home.Mainmenu();
         }
        
     }
 		catch (IOException e) {
 			// TODO Auto-generated catch block
 			e.printStackTrace();
 		}
         }
     }
 
 
	 		
	    /**
		 * @return the pC
		 */
		public String getPC() {
			return PC;
		}
		/**
		 * @param pC the pC to set
		 */
		public void setPC(String p2) {
			 PC=p2;
		}
		/**
		 * @return the player1
		 */
		public String getPlayer1() {
			return player1;
		}
		/**
		 * @param player1 the player1 to set
		 */
		public void setPlayer1(String p1) {
			 player1=p1;
		}
		/**
		 * @return the player2
		 */
		/**
		 * @return the currentPlayer
		 */
		public int getCurrentPlayer() {
			return currentPlayer;
		}
		/**
		 * @param currentPlayer the currentPlayer to set
		 */
		public void setCurrentPlayer(int current) {
			  currentPlayer=current;
		}
		/**
		 * @return the markerX
		 */
		public char getMarker1() {
			return marker1;
		}
		/**
		 * @param markerX the markerX to set
		 */
		public void setMarker1(char piece1)
		{
			if (piece1== 'x'||piece1== 'o'||piece1== 'X'||piece1== 'O')
				marker1= piece1;
		}
		/**
		 * @return the markerO
		 */
		public char getPCmarker() {
			return PCmarker;
		}
		/**
		 * @param markerO the markerO to set
		 */
		public void setPCmarker(char  piece2) {
			if (piece2== 'x'||piece2== 'o'||piece2== 'X'||piece2== 'O')
				PCmarker= piece2;
		}
		
		/**
		 * @return the plays
		 */
		public int getPlays() {
			return plays;
		}
		/**
		 * @param plays the plays to set
		 */
		public void setPlays(int moves) {
			 plays= moves;
		}

	}


