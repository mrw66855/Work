package edu.davenport.pantherreaction;


import android.os.Bundle;
import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.util.Log;
import android.view.Menu;
import android.view.View;
import android.widget.Button;



public class SplashScreen extends Activity {
	//variables
	private Context context = null;
	private Audio audio;

	private Button btnPlay;
	@Override
	//initializes everything needed for the screen or on screen
	protected void onCreate(Bundle savedInstanceState) {
		super.onCreate(savedInstanceState);
		setContentView(R.layout.splash_screen);
		btnPlay = (Button) findViewById(R.id.btnPlay);
        
        btnPlay.setOnClickListener(btnPlay_OnClick);
        
        
        context = getApplicationContext();
        audio = new Audio();
		audio.load(this.context);
		//calls intro method
		intro ();
	}

	@Override
	public boolean onCreateOptionsMenu(Menu menu) 
	{
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.splash_screen, menu);
		
		return true;
	}
	//Activate on click listen for button on-screen
	  View.OnClickListener btnPlay_OnClick = new View.OnClickListener()
	    {
	    	@Override
	    	public void onClick(View v)
	    
{
//Calls game activity when button is clicked and goes to the screen
	Intent Game = new Intent(context.getApplicationContext(),  Game.class );
	startActivity(Game);

}
	    };
	    //plays startup sound
	    public void intro()
	    {
	    	audio.Play (1);
	    }
}
