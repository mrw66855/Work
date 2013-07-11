package edu.davenport.pantherreaction;


import android.content.Context;
import android.media.AudioManager;
import android.media.SoundPool;
import android.media.SoundPool.OnLoadCompleteListener;



public class Audio 
{
	//Variables
private	SoundPool sound;
private int[] order = new int[15];
boolean loaded = false;
//constructor
public Audio()
	{
		 sound=new SoundPool (4, AudioManager.STREAM_MUSIC,0);
		 
		
	}
//Loads the sounds into the array
	public void load(Context context)
	{
		order[0]= sound.load(context, R.raw.intro, 1);
		order [1]= sound.load(context, R.raw.fail, 1);
		order [2]= sound.load(context, R.raw.poor, 1);
		order[3]= sound.load(context, R.raw.average, 1);
		order [4]= sound.load(context, R.raw.excellent, 1);
		order [5]= sound.load(context, R.raw.perfect, 1);
		order[6]= sound.load(context, R.raw.panther, 1);
		order [7]= sound.load(context, R.raw.laser, 1);
		order [8]= sound.load(context, R.raw.gameover, 1);
		 
		 
	}
	//play the sound through a switch statement
	public void Play(int soundnumber)
	{
		switch (soundnumber)
		{
		 case 1:
		     soundnumber=order [0];
		      break;
		    case 2:
		    	 soundnumber=order [1];
		      break;
		    case 3:
		    	 soundnumber=order [2];
		      break;
		    
		    case 4:
		    	 soundnumber=order [3];
		      break;
		    case 5:
			     soundnumber=order [4];
			      break;
			    case 6:
			    	 soundnumber=order [5];
			      break;
			    case 7:
			    	 soundnumber=order [6];
			      break;
			    
			    case 8:
			    	 soundnumber=order [7];
			      break;
			    case 9:
			    	 soundnumber=order [8];
			      break;
		}
		sound.play(soundnumber, 1, 1, 1, 0, 1);
	}
	//Unloads  all sounds that have been loaded
	public void Release()
	{
		sound.release();
	}
}