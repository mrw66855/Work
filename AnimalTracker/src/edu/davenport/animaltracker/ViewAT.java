package edu.davenport.animaltracker;


import android.os.AsyncTask;
import android.os.Bundle;
import android.app.Activity;
import android.app.AlertDialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.database.Cursor;
import android.util.Log;
import android.view.Menu;
import android.view.MenuItem;
import android.widget.EditText;
import android.widget.TextView;

public class ViewAT extends Activity {
	private static final String ROW_ID = "row_id";
	private TextView lblAnimalNumber, lblAmount, lblDateTime,lblComments,lblStatus,lblLatitude,lblLongitude;
	private long id;
	private static final String AnimaLListCode = "ANIMAL_LIST_CD";
	private static final String Count ="COUNT_NO";
	private static final String Seenon ="SEENON_DTM";	
	private static final String Comments ="COMMENTS_TXT";
	private static final String Status = "DELETION_CD";
	private static final String Active = "A";
	private static final String Deleted = "D";
	private static final String Latitude ="LOC_LATITUDE";
	private static final String Longitude = "LOC_LONGITUDE";
	@Override
	protected void onCreate(Bundle savedInstanceState) 
	{
		super.onCreate(savedInstanceState);
		setContentView(R.layout.view_entry);
		
		lblAnimalNumber = (TextView) findViewById(R.id.lblAnimalNumber);
		lblAmount = (TextView) findViewById(R.id.lblAmount);
		lblDateTime = (TextView) findViewById(R.id.lblDateTime);
		lblComments = (TextView) findViewById(R.id.lblComments);
		lblLatitude= (TextView) findViewById(R.id.lblLatitude);
		lblLongitude= (TextView) findViewById(R.id.lbllongitude);
		lblStatus = (TextView) findViewById(R.id.lblStatus);
		id = getIntent().getExtras().getLong("row_id");
	}

	@Override
	protected void onResume()
	{
		super.onResume();

	new ViewEntryTask().execute((Object[]) null);
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
		getMenuInflater().inflate(R.menu.view_entry, menu);
		return true;
	}

 	private class ViewEntryTask extends AsyncTask<Object, Object, Cursor>
	{
 		 AnimalDatabase db = new AnimalDatabase(ViewAT.this);
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
	    		lblAmount.setText(result.getString(result.getColumnIndex(Count)));
	    		lblDateTime.setText(result.getString(result.getColumnIndex(Seenon)));
	    		lblComments.setText(result.getString(result.getColumnIndex(Comments)));
	    		lblLongitude.setText(result.getString(result.getColumnIndex(Longitude)));
	    		lblLatitude.setText(result.getString(result.getColumnIndex(Latitude)));
	    		lblStatus.setText(result.getString(result.getColumnIndex(Status)));
	    		
	    		db.close();
}
	}


	@Override
	public boolean onOptionsItemSelected(MenuItem item) 
	{
	    // Handle item selection
	    
	        switch (item.getItemId()) 
		    {
		    	case R.id.menu_update:
		    	{
		    		Intent updateAB = new Intent(ViewAT.this, UpdateAT.class);
		    		updateAB.putExtra(ROW_ID, id);
		    		startActivity(updateAB);
		    		break;
		    	}
				
		    	case R.id.menu_delete:
		    	{
		    			    		
		    		deleteEntry();
		    		
		    		break;
		    	}
		     	case R.id.menu_purge:
		    	{
		    			    		
		    		purgeEntry();
		    		
		    		break;
		    	}
		     	case R.id.menu_restore:
		    	{
		    		Log.i("GPS", String.format("provider enabled:"));
		    			    		
		    		restoreEntry();

		    		
		    	}
		    		break;
		    	
				
		    }
		    
	        return true;
		}
	
	   private void purgeEntry()
	   {
		   if (lblStatus.getText().equals(Deleted))
		   {
	      // create a new AlertDialog Builder
	      AlertDialog.Builder builder =  new AlertDialog.Builder(ViewAT.this);

	      builder.setTitle(R.string.purgeConfirmTitle); // title bar string
	      builder.setMessage(R.string.purgeConfirmMessage); // message to display

	      // provide an OK button that simply dismisses the dialog
	      builder.setPositiveButton(R.string.purgeConfirmButton,
	         new DialogInterface.OnClickListener()
	         {
	         

				@Override
	            public void onClick(DialogInterface dialog, int button)
	            {
					 final AnimalDatabase db = new AnimalDatabase(ViewAT.this);
	               final AnimalList al = new AnimalList (db);
	             

 
	               // create an AsyncTask that deletes the contact in another 
	               // thread, then calls finish after the deletion
	               AsyncTask<Long, Object, Object> deleteTask = new AsyncTask<Long, Object, Object>()
	                  {
	                     @Override
	                     protected Object doInBackground(Long... params)
	                     {
	                    	 
	                   al.Delete(params[0]); 
	                        return null;
	                     } // end method doInBackground

	                     @Override
	                     protected void onPostExecute(Object result)
	                     {
	                        finish(); // return to the AddressBook Activity
	                     } // end method onPostExecute
	                  }; // end new AsyncTask

	               // execute the AsyncTask to delete contact at rowID
	               deleteTask.execute(new Long[] { id });               
	            } // end method onClick
	         } // end anonymous inner class
	      ); // end call to method setPositiveButton
	      
	      builder.setNegativeButton(R.string.purgeCancelButton, null);
	      builder.show ();// display the Dialog
		   }

			   else
		         {
		            // create a new AlertDialog Builder
		            AlertDialog.Builder builder = new AlertDialog.Builder(ViewAT.this);
		      
		            // set dialog title & message, and provide Button to dismiss
		            builder.setTitle(R.string.purgeerrorTitle); 
		            builder.setMessage(R.string.purgeerrorMessage);
		            builder.setPositiveButton(R.string.purgeerrorButton, null); 
		            builder.show(); // display the Dialog
		         } // end else
		   
	   } 
	
	   private void deleteEntry()
	   {
		   if (!lblStatus.getText().equals(Active))
	   
			   {
		      // create a new AlertDialog Builder
		      AlertDialog.Builder builder =  new AlertDialog.Builder(ViewAT.this);

		      builder.setTitle(R.string.deleteConfirmTitle); // title bar string
		      builder.setMessage(R.string.deleteConfirmMessage); // message to display

		      // provide an OK button that simply dismisses the dialog
		      builder.setPositiveButton(R.string.deleteConfirmButton,new DialogInterface.OnClickListener()
		         {
		            @Override
		            public void onClick(DialogInterface dialog, int button)
		            {
		        

	 
		               // create an AsyncTask that deletes the contact in another 
		               // thread, then calls finish after the deletion
		               AsyncTask<Object, Object, Object> saveTask =  new AsyncTask<Object, Object, Object>() 
		                       {
		                    	
		                          @Override
		                          protected Object doInBackground(Object... params) 
		                          {
		                             deletedAT(); // save contact to the database
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
		         } // end anonymous inner class
		      ); // end call to method setPositiveButton
		      
		      builder.setNegativeButton(R.string.deleteCancelButton, null);
		      builder.show ();// display the Dialog
			   }

				   else
			         {
			            // create a new AlertDialog Builder
			            AlertDialog.Builder builder = new AlertDialog.Builder(ViewAT.this);
			      
			            // set dialog title & message, and provide Button to dismiss
			            builder.setTitle(R.string.deleteerrorTitle); 
			            builder.setMessage(R.string.deleteerrorMessage);
			            builder.setPositiveButton(R.string.deleteerrorButton, null); 
			            builder.show(); // display the Dialog
			         } // end else
			   
		   } // end 
				   private void deletedAT() 
				   {
				      // get DatabaseConnector to interact with the SQLite database
					   AnimalDatabase db = new AnimalDatabase(this);
					   AnimalList al = new AnimalList (db);
					   
				         // insert the contact information into the database
					   al.UpdatStatus(id,Deleted);

				   } 
				   


				   private void restoreEntry()
				   {
					   if (lblStatus.getText().equals(Deleted))
				   
						   {
					      // create a new AlertDialog Builder
					      AlertDialog.Builder builder =  new AlertDialog.Builder(ViewAT.this);

					      builder.setTitle(R.string.restoreConfirmTitle); // title bar string
					      builder.setMessage(R.string.restoreConfirmMessage); // message to display

					      // provide an OK button that simply dismisses the dialog
					      builder.setPositiveButton(R.string.restoreConfirmButton,new DialogInterface.OnClickListener()
					         {
					            @Override
					            public void onClick(DialogInterface dialog, int button)
					            {
					        

				 
					               // create an AsyncTask that deletes the contact in another 
					               // thread, then calls finish after the deletion
					               AsyncTask<Object, Object, Object> restoreTask =  new AsyncTask<Object, Object, Object>() 
					                       {
					                    	
					                          @Override
					                          protected Object doInBackground(Object... params) 
					                          {
					                           restoredAT(); // save contact to the database
					                             return null;
					                          } // end method doInBackground
					              
					                          @Override
					                          protected void onPostExecute(Object result) 
					                          {
					                             finish(); // return to the previous Activity (inquire)
					                          } // end method onPostExecute
					                       }; // end AsyncTask
					                       
					                    // save the contact to the database using a separate thread
					                      restoreTask.execute((Object[]) null);
					            } // end method onClick
					         } // end anonymous inner class
					      ); // end call to method setPositiveButton
					      
					      builder.setNegativeButton(R.string.restoreCancelButton, null);
					      builder.show ();// display the Dialog
						   }

							   else
						         {
						            // create a new AlertDialog Builder
						            AlertDialog.Builder builder = new AlertDialog.Builder(ViewAT.this);
						      
						            // set dialog title & message, and provide Button to dismiss
						            builder.setTitle(R.string.restoreerrorTitle); 
						            builder.setMessage(R.string.restoreerrorMessage);
						            builder.setPositiveButton(R.string.restoreerrorButton, null); 
						            builder.show(); // display the Dialog
						         } // end else
						   
				   }// end 
							   private void restoredAT() 
							   {
							      // get DatabaseConnector to interact with the SQLite database
								   AnimalDatabase db = new AnimalDatabase(ViewAT.this);
								   AnimalList al = new AnimalList (db);
								   
							         // insert the contact information into the database
							al.UpdatStatus( id, Active);

							   } 
	}

