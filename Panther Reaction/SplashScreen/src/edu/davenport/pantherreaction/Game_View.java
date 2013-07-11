package edu.davenport.pantherreaction;

import java.util.Random;

import android.content.Context;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.graphics.Canvas;
import android.os.CountDownTimer;
import android.view.Display;
import android.view.MotionEvent;
import android.view.WindowManager;
import android.view.View;



public class Game_View extends View
{
	//Variables
	private Audio audio;
	private Bitmap target;
	private Bitmap result;
	private final long TIMER_DELAY = 3000;
	private CountDownTimer timer;
private Point targetlocation;
	private Context context;
	private Display display;
	private Random random;

	private Bitmap percentage;
	private float targetpositionX;
	private float targetpositionY;
	private int targetWidth;
	private int targetHeight;
	private int percentWidth;
	private int percentHeight;
	private int screenWidth;
	private int screenHeight;
	private float hits = 0;
	private float misses = 0;
	private float total = 0;
	private float gamepercent = 0;
	private final long MAX_X = 460;
	private final long MAX_Y = 700;
	private final float TURNS = 20;
	private final int PERCENTAGEWIDTH = 100;
	private final int PERCENTAGEHEIGHT = 200;
	private final int RESULTWIDTH = 100;
	private final int RESULTHEIGHT = 400;
	private boolean hit=false;
	private boolean miss=false;
	//Initializes variables
	public Game_View(Context context) {
		super(context);
		target = BitmapFactory.decodeResource(getResources(),
				R.drawable.panther);
		percentage = BitmapFactory.decodeResource(getResources(),
				R.drawable.percentage0);
		
		result =BitmapFactory.decodeResource(getResources(),
				R.drawable.hit);
		this.context = context;
		WindowManager wm = (WindowManager) context
				.getSystemService(Context.WINDOW_SERVICE);
		display = wm.getDefaultDisplay();

		random = new Random();
		targetlocation = new Point();
		
		audio = new Audio();
		audio.load(this.context);
	//Timer class as part of android
		 timer = new CountDownTimer(TIMER_DELAY, 1000)

		 {

		     public void onTick(long millisUntilFinished)

		    {

		         

		     }




		    public void onFinish()

		     {
//Calls the missed. method
		         onMiss();

		    }

		 }.start();
	}

	public Point location() {
		//return point where target image is at
		targetWidth = target.getWidth();
		targetHeight = target.getHeight();
		screenWidth = display.getWidth();
		screenHeight = display.getHeight();
		targetpositionX = random.nextInt(480);

		targetpositionY = random.nextInt(730);
		if (targetpositionX > 0 && targetpositionX < screenWidth) {
			if (targetpositionX > MAX_X) {
				targetpositionX = targetpositionX - targetWidth;
				targetlocation.setXposition(targetpositionX);
			} else {
				targetlocation.setXposition(targetpositionX);
			}
		}
		if (targetpositionY > 0 && targetpositionY < screenHeight) {
			if (targetpositionY > MAX_Y) {
				targetpositionY = targetpositionY - targetHeight;
				targetlocation.setYposition(targetpositionY);
			} else {
				targetlocation.setYposition(targetpositionY);
			}
		}
		return targetlocation;

	}

	public void onDraw(Canvas c)

	{
		//draws images on screen
		super.onDraw(c);
		if(hit)
		{
			//call the result method
			result(c);
		}
		if(miss)
		{
			//call the result method
			result(c);
		}
		targetWidth = target.getWidth();
		targetHeight = target.getHeight();
//Call location method for target location
		location();
//If the number of turns in the game equals total number of turns possible then game is over 
		//otherwise draw target image on screen
		if (total == TURNS)
		{
			gameover(c);
			
		}
		else 
		{
			c.drawBitmap(target, targetlocation.getXposition(),targetlocation.getYposition(), null);

		}

	}

	public boolean onTouchEvent(MotionEvent event) 
	{
		//Return where the user  touch screen to see if target was touched or not
		float x, y, targetlocationX, targetlocationY;

		if (event.getAction() == MotionEvent.ACTION_DOWN) 
		{

			x = event.getX();
			y = event.getY();

			targetlocationX = targetlocation.getXposition();
			targetlocationY = targetlocation.getYposition();
			targetWidth = target.getWidth();
			targetHeight = target.getHeight();
			if (x >= targetlocationX && x <= (targetlocationX + targetWidth)&& y >= targetlocationY && y <= (targetlocationY + targetHeight)) 
			{
				
			onHit(); 
		
				// image touched
			} 
			else 
			{
				onMiss();
				// image not touched
			}
		
		}
		return false;
	}
	public void onHit( )
	{
		//Cancel the timer, play hit sound increased number of hits  and total terms by one, 
		//redraw screen to  display hit image and restart the timer
		timer.cancel();
			audio.Play(7);
		
			hits = hits + 1;
	hit=true;
		
			total = total + 1;
			invalidate();
			timer.start();
		}

		public void onMiss() 
		{
			
			//Cancel the timer, play miss sound increased number of misses and total terms by one, 
			//redraw screen to  display misses  image and restart the timer
			timer.cancel();
			
			audio.Play(8);
			
			misses = misses + 1;
			miss=true;
			total = total + 1;
			invalidate();
			timer.start();
		}


	public void gameover(Canvas c)

	{
		//Cancel the timer, determine the percentage hit out of total turns
		//Display that percentage on screen via image 
		//Play appropriate sound that goes with percentage level
		
	timer.cancel();
		
		gamepercent = hits / TURNS;

		if (gamepercent == .05f) 
		{
			percentage = BitmapFactory.decodeResource(getResources(),R.drawable.percentage5);
			audio.Play(3);
		}
		if (gamepercent == .10f) 
		{
			audio.Play(3);
			percentage = BitmapFactory.decodeResource(getResources(),R.drawable.percentage10);
		}
		if (gamepercent == .15f) 
		{
			audio.Play(3);
			percentage = BitmapFactory.decodeResource(getResources(),R.drawable.percentage15);
		}
		if (gamepercent == .20f) 
		{
			audio.Play(3);
			percentage = BitmapFactory.decodeResource(getResources(),R.drawable.percentage20);
		}
		if (gamepercent == .25f) 
		{
			audio.Play(3);
			percentage = BitmapFactory.decodeResource(getResources(),R.drawable.percentage25);
		}
		if (gamepercent == .30f) 
		{
			percentage = BitmapFactory.decodeResource(getResources(),R.drawable.percentage30);
			audio.Play(3);
		}
		if (gamepercent == .35f) 
		{
			percentage = BitmapFactory.decodeResource(getResources(),R.drawable.percentage35);
			audio.Play(3);
		}
		if (gamepercent == .40f) 
		{
			percentage = BitmapFactory.decodeResource(getResources(),R.drawable.percentage40);
			audio.Play(3);
		}
		if (gamepercent == .45f) 
		{
			audio.Play(3);
			percentage = BitmapFactory.decodeResource(getResources(),R.drawable.percentage45);
		}
		if (gamepercent == .50f)
		{
			audio.Play(3);
			percentage = BitmapFactory.decodeResource(getResources(),R.drawable.percentage50);
		}
		if (gamepercent == .55f) 
		{
			audio.Play(4);
			percentage = BitmapFactory.decodeResource(getResources(),R.drawable.percentage55);
		}
		if (gamepercent == .60f) 
		{
			audio.Play(4);
			percentage = BitmapFactory.decodeResource(getResources(),R.drawable.percentage60);
		}
		if (gamepercent == .65f) 
		{
			percentage = BitmapFactory.decodeResource(getResources(),R.drawable.percentage65);
			audio.Play(4);
		}
		if (gamepercent == .70f) 
		{
			percentage = BitmapFactory.decodeResource(getResources(),
					R.drawable.percentage70);
			audio.Play(4);
		}
		if (gamepercent == .75f) 
		{
			percentage = BitmapFactory.decodeResource(getResources(),R.drawable.percentage75);
			audio.Play(4);
		}
		if (gamepercent == .80f) 
		{
			percentage = BitmapFactory.decodeResource(getResources(),R.drawable.percentage80);
			audio.Play(5);
		}
		if (gamepercent == .85f) 
		{
			percentage = BitmapFactory.decodeResource(getResources(),R.drawable.percentage85);
			audio.Play(5);
		}
		if (gamepercent == .90f)
		{
			percentage = BitmapFactory.decodeResource(getResources(),R.drawable.percentage90);
			audio.Play(5);
		}		
		if (gamepercent == .95f) 
		{
			percentage = BitmapFactory.decodeResource(getResources(),R.drawable.percentage95);
			audio.Play(5);
		}
		if (gamepercent == 1.0f) 
		{
			percentage = BitmapFactory.decodeResource(getResources(),R.drawable.percentage100);
			audio.Play(6);
		}
		if (gamepercent <= 0.0f) 
		{
			percentage = BitmapFactory.decodeResource(getResources(),R.drawable.percentage0);
					audio.Play(2);
		}
		c.drawBitmap(percentage, PERCENTAGEWIDTH, PERCENTAGEHEIGHT, null);
		//call exit method
		 exit ();
	}
	//Exit method unloads the sounds that have been loaded, delay a little so sound can play
	public void exit()
	
	{
		int times = 0;
			 times++;
	while(times<=5)
	{
		 times++;
	}
			 if (times ==5)

			 {

			audio.Release();

			 } 
		
	}
	//Displays hit and miss images when appropriate on-screen and then redraw screen
	public void result(Canvas c)
	{
	if(hit)
	{
		result = BitmapFactory.decodeResource(getResources(),R.drawable.hit);
		c.drawBitmap(result, RESULTWIDTH, RESULTHEIGHT, null);
		hit=false;
	}
	if(miss)
	{
		result = BitmapFactory.decodeResource(getResources(),R.drawable.miss);
		c.drawBitmap(result, RESULTWIDTH, RESULTHEIGHT, null);
		miss=false;
	
	}
	invalidate();
	}
	}

	