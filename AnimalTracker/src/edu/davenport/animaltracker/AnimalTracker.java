
package edu.davenport.animaltracker;
import android.os.AsyncTask;
import android.os.Bundle;


import android.app.AlertDialog;
import android.app.ListActivity;
import android.content.Intent;
import android.database.Cursor;
import android.view.Menu;

import android.view.MenuItem;
import android.view.View;
import android.widget.AdapterView;
import android.widget.AdapterView.OnItemClickListener;
import android.widget.CursorAdapter;
import android.widget.ListView;
import android.widget.SimpleCursorAdapter;



public class AnimalTracker extends ListActivity
{
	private static final String ROW_ID = "row_id";
	private ListView AnimalTrackerListView;
	private CursorAdapter AnimalTrackerAdapter;
	private static final String AnimaLTypeCode = "ANIMAL_NAME_DATE";

	@Override
	protected void onCreate(Bundle savedInstanceState)
	{
		
		super.onCreate(savedInstanceState);
		AnimalTrackerListView = getListView();
		AnimalTrackerListView.setOnItemClickListener(viewAnimalTrackerListener);

		String[] from = new String[] {AnimaLTypeCode };
		int[] to = new int[] { R.id.NameTextView,};

		AnimalTrackerAdapter = new SimpleCursorAdapter(AnimalTracker.this,R.layout.animal_tracker,null,from,to);


		setListAdapter(AnimalTrackerAdapter);
		}

		
	
	@Override
	protected void onStop()
	{
		Cursor cursor = AnimalTrackerAdapter.getCursor();

		if( cursor != null )
			cursor.deactivate();

		AnimalTrackerAdapter.changeCursor(null);
		super.onStop();
	}

	@Override
	protected void onResume()
	{
		super.onResume();

		new GetAllTask().execute((Object[]) null);
	}



	
	@Override
	public boolean onCreateOptionsMenu(Menu menu)
	{

		super.onCreateOptionsMenu(menu);
		getMenuInflater().inflate(R.menu.animal_tracker, menu);
		return true;
	}

	OnItemClickListener viewAnimalTrackerListener = new OnItemClickListener()
	{
		@Override
		public void onItemClick(AdapterView<?> arg0, View arg1, int arg2,
				long arg3)
		{
			Intent viewAB = new Intent(AnimalTracker.this, ViewAT.class);
			viewAB.putExtra(ROW_ID, arg3);
			startActivity(viewAB);
			//Toast.makeText(getApplicationContext(), String.valueOf(arg3), Toast.LENGTH_SHORT).show();
		}
	};

	public boolean onOptionsItemSelected(MenuItem item) 
	{
	    // Handle item selection
	    switch (item.getItemId()) 
	    {
	    	case R.id.menu_add:
	    	{
	    		Intent addAT = new Intent(AnimalTracker.this,AddAT.class);
	    		startActivity(addAT);
	    		break;
	    	}
	    	case R.id.menu_all:
	    	{
	   new GetAllTask().execute((Object[]) null);
	    	
	    		break;
	    	}
	    	case R.id.menu_active:
	    	{
	new	 GetActiveTask().execute((Object[]) null);
	    	
	    		break;
	    	}
	    	case R.id.menu_deleted:
	    	{
	new GetDeletedTask().execute((Object[]) null);
	    	
	    		break;
	    	}
	    }
        return true;
	}


	
	private class GetAllTask extends AsyncTask<Object, Object, Cursor>
		{
		
		AnimalDatabase	db=new AnimalDatabase(AnimalTracker.this) ;
AnimalList al = new AnimalList (db);

			@Override
			protected Cursor doInBackground(Object... parms)
			{
	
		//	al.Add(0, 1, "03/05/07 2:15 PM", "ABC", 0,0, "A");
				db.open();
		
			
				return  al.ListAll();
			}
		
				

			protected void onPostExecute(Cursor result)
			{
				if (result.getColumnCount()==0)
				 {
						   db.close();
						   ApplicationMessage (); // display the Dialog
			         }
			
				else
					   {
				            // create a new AlertDialog Builder
					AnimalTrackerAdapter.changeCursor(result);
					db.close();
					   }
			}
		}

			
			

		
		
		
		private class GetDeletedTask extends AsyncTask<Object, Object, Cursor>
		{
			AnimalDatabase	db=new AnimalDatabase(AnimalTracker.this) ;
			AnimalList al = new AnimalList (db);
			@Override
			protected Cursor doInBackground(Object... parms)
			{
		
				db.open();
				
				return al.DeletedList();
			}

			protected void onPostExecute(Cursor result)
			{
				if (result.getColumnCount()==0)
				 {
						   db.close();
						   ApplicationMessage ();
						   }
			
				else
					   {
				            // create a new AlertDialog Builder
					AnimalTrackerAdapter.changeCursor(result);
					db.close();
					   }
			}
		}

			
			
		private class GetActiveTask extends AsyncTask<Object, Object, Cursor>
		{
			AnimalDatabase	db=new AnimalDatabase(AnimalTracker.this) ;
			AnimalList al = new AnimalList (db);
			@Override
			protected Cursor doInBackground(Object... parms)
			{
			
				db.open();

				return al.ActiveList();
			}

			protected void onPostExecute(Cursor result)
			{
				
				if (result.getColumnCount()==0)
				 {
						   db.close();
				           ApplicationMessage ();
				 }
			
				else
					   {
				            // create a new AlertDialog Builder
					AnimalTrackerAdapter.changeCursor(result);
					db.close();
					   }
			}
		}
			public void ApplicationMessage ()
			{
				 AlertDialog.Builder builder = new AlertDialog.Builder(AnimalTracker.this);
			      
		            // set dialog title & message, and provide Button to dismiss
		            builder.setTitle(R.string.applicationerrorTitle); 
		            builder.setMessage(R.string.applicationerrorMessage);
		            builder.setPositiveButton(R.string.applicationerrorButton, null); 
		            builder.show(); 
			}
			
		}

			
		
		
		
		

