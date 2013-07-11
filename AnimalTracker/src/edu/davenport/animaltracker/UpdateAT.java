
package edu.davenport.animaltracker;

import android.os.AsyncTask;
import android.os.Bundle;
import android.app.Activity;
import android.database.Cursor;
import android.view.Menu;
import android.view.View;
import android.view.View.OnClickListener;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;




public class UpdateAT extends Activity 
{

	
private static final String ROW_ID = "row_id";
private EditText  txtamount,txtcomments;
private Button btnSave;
private long id;
private static final String AnimaLListCode = "ANIMAL_LIST_CD";
private static final String Count ="COUNT_NO";
private static final String Seenon ="SEENON_DTM";	
private static final String Comments ="COMMENTS_TXT";
private static final String Latitude ="LOC_LATITUDE";
private static final String Longitude = "LOC_LONGITUDE";
private int amount;
private String comments;
private TextView lblAnimalNumber;
private TextView lblLatitude;

private TextView lblDateTime;
private TextView lblLongitude;


@Override
protected void onCreate(Bundle savedInstanceState) 
{
	super.onCreate(savedInstanceState);
	setContentView(R.layout.update_entry);
	
	txtamount = (EditText) findViewById(R.id.txtAmount);
	lblLatitude= (TextView) findViewById(R.id.lblLatitude);
	lblLongitude= (TextView) findViewById(R.id.lbllongitude);

	lblDateTime = (TextView) findViewById(R.id.lblDateTime);
	lblAnimalNumber = (TextView) findViewById(R.id.lblAnimalNumber);
	txtcomments = (EditText) findViewById(R.id.txtComments);

	btnSave = (Button) findViewById(R.id.btnSave);
	
	btnSave.setOnClickListener(btnSave_OnClick);
	
	id = getIntent().getExtras().getLong(ROW_ID);
}


@Override
protected void onResume()
{
	super.onResume();
new RetrieveEntryTask().execute((Object[]) null);
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
	getMenuInflater().inflate(R.menu.update_entry, menu);
	return true;
}

private class RetrieveEntryTask extends AsyncTask<Object, Object, Cursor>
{
	AnimalDatabase db = new AnimalDatabase(UpdateAT.this);
	
    
	AnimalList al = new AnimalList (db);
	@Override
	protected Cursor doInBackground(Object... parms)
	{
		db.open();
		
		return al.Inquire(id);
}

	protected void onPostExecute(Cursor result)
	{
		result.moveToFirst();
		
		lblAnimalNumber.setText(result.getString(result.getColumnIndex(AnimaLListCode )));
		txtamount.setText(result.getString(result.getColumnIndex(Count)));
	lblDateTime.setText(result.getString(result.getColumnIndex(Seenon)));
		txtcomments.setText(result.getString(result.getColumnIndex(Comments)));
		lblLongitude.setText(result.getString(result.getColumnIndex(Longitude)));
		lblLatitude.setText(result.getString(result.getColumnIndex(Latitude)));
		
		
		db.close();
}
}	

   // responds to event generated when user clicks the Done Button
   OnClickListener btnSave_OnClick = new OnClickListener() 
   {
      @Override
      public void onClick(View v) 
      {
  
  	    amount=Integer.parseInt(txtamount.getText().toString());
  	  
  	    comments=txtcomments.getText().toString();
          AsyncTask<Object, Object, Object> saveTask =  new AsyncTask<Object, Object, Object>() 
               {
            	
                  @Override
                  protected Object doInBackground(Object... params) 
                  {
                     saveAT(); // save contact to the database
                     return null;
                  } // end method doInBackground
      
                  @Override
                  protected void onPostExecute(Object result) 
                  {
                     finish(); // return to the previous Activity (inquire)
                  } // end method onPostExecute
               }; // end AsyncTask
               
            // save the contact to the database using a separate thread
               saveTask.execute((Object[]) null); 
       
      } // end method onClick
   }; // end OnClickListener saveContactButtonClicked

   
   // saves contact information to the database
   private void saveAT() 
   {
      // get DatabaseConnector to interact with the SQLite database
	   AnimalDatabase db = new AnimalDatabase(this);
	   AnimalList al = new AnimalList (db);
	   
         // insert the contact information into the database
     al.Update(id, amount, comments);

   } 
   

}