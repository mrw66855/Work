 //Add
package edu.davenport.animaltracker;


import java.util.ArrayList;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

import edu.davenport.animaltracker.R.string;

import android.location.Location;
import android.location.LocationListener;
import android.location.LocationManager;
import android.os.AsyncTask;
import android.os.Bundle;

import android.app.Activity;
import android.app.AlertDialog;
import android.content.Context;
import android.database.Cursor;
import android.util.Log;
import android.view.Menu;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemSelectedListener;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Spinner;
import android.widget.Toast;


public class AddAT extends Activity implements LocationListener 
{
	
	
	private static final String Active= "A";

private String timevalidation="^(([0]?[1-9])|([1][0-2])):(([0-5][0-9])|([1-9])) [AP][M]$";   
private String datevalidation="^(0?\\d|1[012])\\/([012]?\\d|3[01])\\/\\d{4}$" ;
private String numbervalidation="^\\d+$";
	private String comments,datetime, datepart, timepart,stramount, test;
	private int animalnumber, amount;
	private float latitude, longitude;
	private EditText txtanimalnumber,txtamount,txtdatetime,txtcomments, txtlatitude, txtlongitude;
	private static final String AnimaLTypeCode = "ANIMAL_TYPE_CD ";
	private static final String AnimaLNameCode = "ANIMAL_CD_NAME";
	private Button btnAdd;
	private LocationManager locMgr;
	  private String temporary;
private Boolean okay, okay2,okay3, okay4;
	private Spinner spinner;
	private ArrayList<String> spinnerItems;

	@Override
	protected void onCreate(Bundle savedInstanceState)
	{
		super.onCreate(savedInstanceState);
		setContentView(R.layout.add_entry);
		txtamount = (EditText) findViewById(R.id.txtAmount);spinner = (Spinner) findViewById(R.id.spinner1); 
	
		txtcomments = (EditText) findViewById(R.id.txtComments);
		txtdatetime = (EditText) findViewById(R.id.txtDatetime);
		txtlatitude = (EditText) findViewById(R.id.txtLatitude);
		txtlongitude = (EditText) findViewById(R.id.txtlongitude);
		locMgr = (LocationManager) getSystemService(Context.LOCATION_SERVICE);
		locMgr.requestLocationUpdates(LocationManager.GPS_PROVIDER, 5000, 10, 	this);
		spinner = (Spinner) findViewById(R.id.spinner1); 
		txtlatitude.setText("70");
		txtlongitude.setText("80");
		btnAdd= (Button) findViewById(R.id.btnAdd); 
		btnAdd.setOnClickListener(btnAdd_OnClick);
		 spinnerItems = new ArrayList<String>();
	ArrayAdapter<String>DataAdapter = new ArrayAdapter<String> (this, android.R.layout.simple_spinner_item, spinnerItems);
	DataAdapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
	spinner.setAdapter(DataAdapter);
	
	spinner.setOnItemSelectedListener( new OnItemSelectedListener()
	{
		public void onClick(View v)
		{
			
		}

		@Override
		public void onItemSelected(AdapterView<?> control, View arg1, int pos, long itemId)
		{
			
			
			temporary = control.getItemAtPosition(pos).toString();
			
			
	String [] parts =  temporary.split ("-");
	animalnumber = Integer.parseInt(parts [0]);
	Toast.makeText(getApplicationContext(), String.valueOf(animalnumber), Toast.LENGTH_SHORT).show();
		}
		
		@Override
		public void onNothingSelected(AdapterView<?> control)
		{
			
		}
	}
);

	

	}
	

	
	@Override
	protected void onResume()
	{
		super.onResume();
		new RetrieveTypeTask().execute((Object[]) null);
	}
	@Override
	protected void onStop()
	{
		super.onStop();
	
		
	}
	@Override
	public boolean onCreateOptionsMenu(Menu menu)
	{
		// Inflate the menu; this adds items to the action bar if it is present.
		getMenuInflater().inflate(R.menu.animal_tracker, menu);
		return true;
	}




	   // responds to event generated when user clicks the Done Button
	   OnClickListener btnAdd_OnClick = new OnClickListener() 
	   {
		  
	

		@Override
	      public void onClick(View v) 
	      {
			
		latitude = Float.parseFloat(txtlatitude.getText().toString());
		longitude = Float.parseFloat(txtlongitude .getText().toString());
		
	   stramount=txtamount.getText().toString();
	    test=txtdatetime.getText().toString();
	    comments=txtcomments.getText().toString();
	    String [] parts  = test.split(",");
	 ;
	    


	    datepart = parts[0];
	    timepart = parts[1];
	    
	    okay = isValid(timevalidation, timepart);
	    okay2 = IsValidDate (datevalidation,datepart);
	    okay3= isValid(numbervalidation, stramount);
	         if (  okay&&okay2&&okay3)
	         {
	            AsyncTask<Object, Object, Object> saveTask = new AsyncTask<Object, Object, Object>() 
	               {
	            AnimalDatabase db = new AnimalDatabase(AddAT.this);
	                  @Override
	                  protected Object doInBackground(Object... params) 
	                  {
	                	  db.open();
	                     addAT(); // save contact to the database
	                     return null;
	                  } // end method doInBackground
	      
	                  @Override
	                  protected void onPostExecute(Object result) 
	                  {
	                     db.close();
	                     // return to the previous Activity (inquire)
	                  } // end method onPostExecute
	               }; // end AsyncTask
	               
	            // save the contact to the database using a separate thread
	               saveTask.execute((Object[]) null); 
	         } // end if
	         else
	         {
	            // create a new AlertDialog Builder
	            AlertDialog.Builder builder = 
	               new AlertDialog.Builder(AddAT.this);
	      
	            // set dialog title & message, and provide Button to dismiss
	            builder.setTitle(R.string.errorTitle); 
	            builder.setMessage(R.string.errorMessage);
	            builder.setPositiveButton(R.string.errorButton, null); 
	            builder.show(); // display the Dialog
	         } // end else
	         if (okay2 == false )
	         {
	        	    // create a new AlertDialog Builder
	        	  AlertDialog.Builder builder = 
	        	     new AlertDialog.Builder(AddAT.this);

	        	  // set dialog title & message, and provide Button to dismiss
	        	  builder.setTitle(R.string.DateTimeerrorTitle); 
	        	  builder.setMessage(R.string.DateTimeerrorMessage);
	        	  builder.setPositiveButton(R.string.DateTimeerrorButton, null); 
	        	  builder.show(); // display the Dialog
	         }
	      } // end method onClick
	   }; // end OnClickListener saveContactButtonClicked


	
		private class RetrieveTypeTask extends AsyncTask<Object, Object, Cursor>
		{
			AnimalDatabase db = new AnimalDatabase(AddAT.this);
		AnimalType type = new AnimalType(db);
       
		
		@Override
		protected Cursor doInBackground(Object... parms)
		{
			db.open();
			
			return type.ListAll();
		}

		protected void onPostExecute(Cursor result)
		{
			result.moveToFirst();
			
			// looping through all rows and adding to list
	        if (result.moveToFirst())
	        {
	            do {
	                spinnerItems.add(result.getString(result.getColumnIndex(AnimaLNameCode)));;
	            } while (result.moveToNext());
	        }			
	 
			
			db.close();
		}
	}	


	   // saves contact information to the database
	   private void addAT() 
	   {
	      // get DatabaseConnector to interact with the SQLite database
		   AnimalDatabase db = new AnimalDatabase(this);
	      AnimalList al = new AnimalList (db);
	      amount = Integer.parseInt(stramount);
	      datetime=  datepart + timepart;
	   
	     
	 al.Add(animalnumber, amount, datetime, comments, latitude, longitude, Active);
	 

	   }

	   public boolean isValid( String pattern, String value )
	    {
	    	boolean valid = false;
	    	
	    	Pattern p = Pattern.compile(pattern);
	    	Matcher m = p.matcher(value);
	    	
	    	if( m.matches() )
	    		valid = true;
	    	
	    	return valid;
	    }
	  public boolean IsValidDate ( String pattern, String value )
	    {
	    	boolean valid = false;
Pattern p = Pattern.compile(pattern);
	    	Matcher m = p.matcher(value);
	    	 
	    	if(m.matches())
	    	{
	    		m.reset();

	    		if(m.find())
	    		{

      String day = m.group(0);
    String month = m.group(1);
    int year = Integer.parseInt(m.group(2));

    if (day.equals("31") && (month.equals("4") || month .equals("6") || month.equals("9") || month.equals("11") || month.equals("04") || month .equals("06") || month.equals("09")))
    {
   	 valid = false;
    
		return valid; // only 1,3,5,7,8,10,12 has 31 days
    } 
    else if (month.equals("2") || month.equals("02"))
    {      //leap year
	  if(year % 4==0)
	  {
		  if(day.equals("30") || day.equals("31"))
		  {
			  valid = false;
		  
			  return valid;
		  }
		  else
		  {
			  valid = true;
		  }
			  return valid;
		  }
	  }
    else
    {
	         if(day.equals("29")||day.equals("30")||day.equals("31"))
	         {
	        	 valid = false;
			  return valid;
	         }
	         else
	         {
	        	 valid = true;
			  return valid;
	         		}
	  				}
	    			}
	    		else
	    		{	
	    	valid = true;		
	return valid;				 
	    		}
	    		}
	    	else
	    	{
	    		valid = false;
	    	}
	      return valid;
  }		  

@Override
public void onLocationChanged(Location arg0) {
	String lat = String.valueOf(arg0.getLatitude());
	String lon = String.valueOf(arg0.getLongitude());

	Log.i("GPS", String.format("Location Changed: (%s, %s)", lat, lon));
	txtlatitude.setText(lat.toString());
		txtlongitude.setText(lon.toString());
latitude = Float.parseFloat(txtlatitude.getText().toString());
longitude = Float.parseFloat(txtlongitude .getText().toString());
}

public void onProviderDisabled(String arg0) 
{
	Log.i("GPS", String.format("provider disabled: %s" + arg0));
}

public void onProviderEnabled(String arg0) 
{
	Log.i("GPS", String.format("provider enabled: %s" + arg0));
}

public void onStatusChanged(String arg0, int arg1, Bundle arg2) 
{
	Log.i("GPS", String.format("status changed to %s[%s]",  arg0, arg1));
}
}