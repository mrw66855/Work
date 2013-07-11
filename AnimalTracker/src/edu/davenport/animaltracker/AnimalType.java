//Animal database
package edu.davenport.animaltracker;

import android.content.ContentValues;
import android.database.Cursor;

public class AnimalType 
{

	private static final String Primary_Table ="ANIMAL_TYPE";
	private static final String AnimaLTypeCode = "ANIMAL_TYPE_CD";
	private static final String Name ="ANIMAL_TYPE_MM";
	private String jointlistall="select ANIMAL_TYPE_CD||''||'-'||ANIMAL_TYPE_MM AS 'ANIMAL_CD_NAME' from  ANIMAL_TYPE Order by ANIMAL_TYPE_CD";
	private static final String ID ="_id";
	private static final String SelectedID ="_id=";
	private AnimalDatabase db;
	AnimalType (AnimalDatabase ad)
	{
		db=ad;
	}
	
	public long Add( int animalcode,  String name )
	{
		long id = 0;
		ContentValues values = new ContentValues ();
		values.put(AnimaLTypeCode, animalcode);
		values.put(Name, name);
	
db.open();
	db.getDB().insert(Primary_Table, null, values);
	db.close();
		return id;
		
	}
	public long Update(long id, int animalcode,  String name)
	{
		long number= 0;
		ContentValues values = new ContentValues ();
	;
		values.put(AnimaLTypeCode,animalcode);
		values.put(Name, name);
	
		db.open();
	db.getDB().update(Primary_Table, values, SelectedID + id, null);
	db.close();
		return number;
		
	}
	
	public Cursor ListAll( )
	{
		return  db.getDB().rawQuery(jointlistall, null);
	
	}
	public Cursor Inquire(AnimalDatabase db,long id)
	{
		
		return  db.getDB().query(Primary_Table,databasearray(), SelectedID + id,null, null,null,null,null);
	
	}
	public Cursor InquireNumber(AnimalDatabase db, String name)
	{
		
		return  db.getDB().query(Primary_Table,new String[] {AnimaLTypeCode}, Name + name, null, null,null,null,null);
	
	}
	public int Delete(  long id)
	
	{
		int deleted = 0;
		
		 db.open();
		 db.getDB().delete(Primary_Table, SelectedID + id , null);
		db.close ();
		return deleted;
	}
public void DeleteTable()
	
	{
db.open();
	db.getDB().delete(Primary_Table, null, null);
 db.close ();
		
	}
	private String[] databasearray() 
	{
	String [] array  =	new String[] {AnimaLTypeCode,Name};
		return array;
	}

}