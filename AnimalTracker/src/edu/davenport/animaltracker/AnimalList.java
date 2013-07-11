//Animal database
package edu.davenport.animaltracker;

import android.content.ContentValues;
import android.database.Cursor;


public class AnimalList 
{

	private static final String Primary_Table ="ANIMAL_LIST";
	private static final String AnimaLListCode = "ANIMAL_LIST_CD";
	private static final String Count ="COUNT_NO";
	private static final String Seenon ="SEENON_DTM";	
	private static final String Comments ="COMMENTS_TXT";
	private static final String Status = "DELETION_CD";
	private static final String Latitude ="LOC_LATITUDE";
	private static final String Longitude = "LOC_LONGITUDE";
	private static final String ID ="_id";
	private static final String SelectedID ="_id=";
	private String jointlistall="select _id, ANIMAL_TYPE_MM||''||':'||SEENON_DTM AS 'ANIMAL_NAME_DATE' from ANIMAL_LIST, ANIMAL_TYPE where  ANIMAL_LIST_CD =ANIMAL_TYPE_CD";

	private String jointlistactive="select _id, ANIMAL_TYPE_MM||' '||':'||SEENON_DTM AS 'ANIMAL_NAME_DATE' from ANIMAL_LIST, ANIMAL_TYPE where DELETION_CD='A'and ANIMAL_LIST_CD =ANIMAL_TYPE_CD";
	
	
	private String jointlistdeleted="select _id, ANIMAL_TYPE_MM||' '||':'|| SEENON_DTM AS'ANIMAL_NAME_DATE' from ANIMAL_LIST, ANIMAL_TYPE where DELETION_CD='D'and ANIMAL_LIST_CD =ANIMAL_TYPE_CD";
private String joinstatement="select _id, ANIMAL_TYPE_CD,ANIMAL_TYPE_MM from ANIMAL_LIST, ANIMAL_TYPE where  ANIMAL_LIST_CD =ANIMAL_TYPE_CD";
private AnimalDatabase db;
AnimalList(AnimalDatabase ad)
{
	db=ad;
}

	public long Add(int animalcode, int count, String seen, String comments,float latitude, float longitude ,String status )
	{
		long id = 0;
		ContentValues values = new ContentValues ();
		values.put(AnimaLListCode, animalcode);
		values.put(Count, count);
		values.put(Seenon, seen);
		values.put(Comments, comments);
		values.put(Latitude, latitude);
		values.put(Longitude,longitude);
		values.put(Status, status);
db.open();
	db.getDB().insert(Primary_Table, null, values);
	db.close();
		return id;
		
	}
	public long Update( long id, int count, String comments)
	{
		long number= 0;
		ContentValues values = new ContentValues ();
	;
		values.put(Count, count);
		values.put(Comments, comments);
	
		db.open();
	db.getDB().update(Primary_Table, values, SelectedID + id, null);
	db.close();
		return number;
		
	}
	
	public Cursor ListAll( )
	{
		return  db.getDB().rawQuery(jointlistall, null);
	
	}
	public Cursor Inquire(  long id)
	{
		
		return  db.getDB().query(Primary_Table,databasearray(), SelectedID + id,null, null,null,null,null);
	
	}
	public Cursor ActiveList(  )
	{
		return  db.getDB().rawQuery(jointlistactive, null);
	
	}
	
	public Cursor DeletedList()
	{

		return  db.getDB().rawQuery(jointlistdeleted, null);
	
	}
	public Cursor JoinList( )
	{
		return  db.getDB().rawQuery(joinstatement, null);
	
	}
	

	public int Delete(  long id)
	
	{
		int deleted = 0;
		
		 db.open();
		 db.getDB().delete(Primary_Table, SelectedID + id , null);
		db.close ();
		return deleted;
	}
	public long UpdatStatus( long id, String status)
	{
		long number= 0;
		ContentValues values = new ContentValues ();
		
		values.put(Status, status);
		
		 db.open();
		db.getDB().update(Primary_Table, values, SelectedID + id, null);
		db.close();
		return number;
	}
public void DeleteTable()
	
	{
db.open();
	db.getDB().delete(Primary_Table, null, null);
 db.close ();
		
	}
	private String[] databasearray() 
	{
	String [] array  =	new String[] {ID,AnimaLListCode,Count,Seenon,Comments,Latitude,Longitude,Status};
		return array;
	}
	

}