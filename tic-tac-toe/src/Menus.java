import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStreamReader;


public class Menus 
{
private static BufferedReader br = new BufferedReader(new InputStreamReader (System.in));

public static void Mainmenu() 
{
	int number=0;
	//menu options
		System.	out.println("Tic-Tac-Toe Game Menu"); 
		
		System.	out.println("Player vs. Player, Press 1"); 
		System.	out.println("Player vs. Computer, Press 2"); 
		System.	out.println("Game Rules, press  3"); 
		System.out.println("About Tic-Tac-Toe Game, press 4"); 
	System.out.println("Exit, Press 5");
		try {
			number =Integer.parseInt(br.readLine());
		} catch (NumberFormatException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}//user input menu option.
	//Call indicated method based on user selected option
		if (number == 1) 
		{

		Human ();
		}
		if
		(number ==2) 
		{
		AI (); 
		}if (number ==3)
		{
			Rules( );
		}
		if (number ==4)
		{
			About( );
		}

		if (number ==5)
		{
			System.out.println (" The program is done running.");
		System.exit (0);
		}
		else if(number >5)
		{
			System.out.println (" invalid entry. Please try again");
			System.out.println ("pick a number between 1 and 5");
			System.out.println ();
			Mainmenu() ;
		}
		    }
//purpose for creating the game
public static void About()
{
		System.out.println ("About Tic-Tac-Toe Game");
		System.out.println ("This game was created by Matthew Weaver.");
		System.out.println ("The game wasa project for Artificial Intelligence class.");
		System.out.println ("Permission is given to use this as an example or to use portions of code to anyone");
		System.out.println ();
		  System.out.print("Return to Main Menu? Press Y: ");
	      try {
				String choice =br.readLine();
				 if (choice.equalsIgnoreCase("Y")) 
				 {
					Mainmenu() ;
				}
		} catch (IOException e) {
			// TODO Auto-generated catch block
			e.printStackTrace();
		}
	
}
static public void Rules() 
{
	 //Rules of the game
	System.out.println ("Game Rules");
	System.out.println ("Players take turns marking a square. ");
	System.out.println ("Only squares not already marked can be picked. " );
	System.out.println ("Once a player has marked three squares in a row, they win! ");
	System.out.println ("If all squares are marked and no three squares are the same, the game is tied .");
	System.out.println ();
	  System.out.print("Return to Main Menu? Press Y: ");
      try {
			String choice =br.readLine();
			 if (choice.equalsIgnoreCase("Y"))
			{
				Mainmenu() ;
			}
	} catch (IOException e) {
		// TODO Auto-generated catch block
		e.printStackTrace();
	}

}
public static void AI() 
//Creating computer verse player game
{
	AIplayer oneplayer =new AIplayer();
	oneplayer.names();//calling enter names function
	oneplayer.gamepieces();//calling peace decision function
	oneplayer.playerorder();//deciding first player
    oneplayer.game();//calling play game function

}
public static void Human() 
{
	//Creating player versus player game
	Humanplayers twoplayer =new Humanplayers();
	twoplayer.names();//calling enter names function
	twoplayer.gamepieces();//deciding pieces function
	twoplayer.playerorder();//deciding first player function
    twoplayer.game();//calling play game function

        

}
}

	


