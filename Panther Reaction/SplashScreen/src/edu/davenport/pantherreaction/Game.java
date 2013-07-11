package edu.davenport.pantherreaction;



import android.os.Bundle;
import android.app.Activity;
import android.view.Menu;


public class Game extends Activity 
{
 //Variable
	private Game_View Game;


	@Override
	//calls game_view class and those that class
	protected void onCreate(Bundle savedInstanceState) 
	{
		super.onCreate(savedInstanceState);

		Game = new Game_View(this.getApplicationContext());
		setContentView(Game);
		
		
	}
	
	
	@Override
	public boolean onCreateOptionsMenu(Menu menu) {
		// Inflate the menu; this adds items to the action bar if it is present.
		// getMenuInflater().inflate(R.menu.activity_play_game, menu);
		return true;
	}

}



