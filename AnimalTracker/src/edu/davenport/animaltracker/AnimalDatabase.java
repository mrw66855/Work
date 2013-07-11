//Animal database
package edu.davenport.animaltracker;


import android.content.Context;

import android.database.SQLException;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteDatabase.CursorFactory;
import android.database.sqlite.SQLiteOpenHelper;

public class AnimalDatabase 
{
	private static final String DB_NAME = "AnimalTracker";
	
	
	private DatabaseOpenHelper dbOpenHelper;


	private SQLiteDatabase DB;

	private static final int currentversion=2;
	private static final int previousversion=1;

	public AnimalDatabase(  Context context)
	{
		
		dbOpenHelper = new DatabaseOpenHelper(context, DB_NAME, null, currentversion);
	}
	public SQLiteDatabase getDB()
	{
		return DB;
	}
	public void open() throws SQLException
	{
		DB = dbOpenHelper.getWritableDatabase();
	}
	
	public void close()
	{
		if( DB != null )
			DB.close();
	}	
	
}
	
	 class DatabaseOpenHelper extends SQLiteOpenHelper
	 {
		
		 Context b;
		
		public DatabaseOpenHelper(Context context, String name, CursorFactory factory, int version) 
	 	{
	 		super(context, name, factory, version);
	 		
			context=b;
			;
			   
	 	}



	@Override
	public void onCreate(SQLiteDatabase sdb)
	
	{
		String SQL=null ;
		StringBuilder temp=new StringBuilder ();
		temp.append("CREATE TABLE ANIMAL_LIST");
		temp.append("(");
		temp.append("_id integer primary key autoincrement, ");
		temp.append ("ANIMAL_LIST_CD INTEGER REFERENCES ANIMAL_TYBE(ANIMAL_TYPE_CD) ON UPDATE CASCADE,");
		temp.append ("COUNT_NO INTEGER,");
		temp.append ("SEENON_DTM TEXT,");		
		temp.append ("COMMENTS_TXT TEXT,");
		temp.append ("LOC_LATITUDE REAL,");
		temp.append ("LOC_LONGITUDE REAL,");
		temp.append ("DELETION_CD TEXT");
		temp.append (");");
		SQL=temp.toString();
		
		sdb.execSQL(SQL);
		
		SQL=null ;
		 temp=new StringBuilder ();
		temp.append("CREATE TABLE ANIMAL_TYPE");
		temp.append("(");
		temp.append ("ANIMAL_TYPE_CD INTEGER PRIMARY KEY,");
		temp.append ("ANIMAL_TYPE_MM TEXT");	
		temp.append (");");
		SQL=temp.toString();
		sdb.execSQL(SQL);

Insert (sdb);

	 
	}
	
	

	public void onUpgrade(SQLiteDatabase sdb, int oldVersion, int newVersion) 
	{
		String SQL=null ;
		StringBuilder temp=new StringBuilder ();
		temp.append("CREATE TABLE ANIMAL_TYPE");
		temp.append("(");
		temp.append ("ANIMAL_TYPE_CD INTEGER PRIMARY KEY,");
		temp.append ("ANIMAL_TYPE_MM TEXT");	
		temp.append (");");
		SQL=temp.toString();
		sdb.execSQL(SQL);
	SQL=null ;
	temp=new StringBuilder ();
	temp.append ("ALTER TABLE Animal_List ADD LOC_LATITUDE REAL;");
	SQL=temp.toString();
	sdb.execSQL(SQL);
	SQL=null; 
	temp.append ("ALTER TABLE Animal_List ADD LOC_LONGITUDE REAL;");
	SQL=temp.toString();
	sdb.execSQL(SQL);
	Insert (sdb);
	}
public void Insert(SQLiteDatabase sdb)
{
	String strSQL = "INSERT INTO ANIMAL_TYPE(ANIMAL_TYPE_CD,ANIMAL_TYPE_MM) VALUES (0,'Dog')";
	sdb.execSQL(strSQL);
	strSQL = "INSERT INTO ANIMAL_TYPE(ANIMAL_TYPE_CD,ANIMAL_TYPE_MM) VALUES (1,'Rabbit')";
sdb.execSQL(strSQL);
 strSQL = "INSERT INTO ANIMAL_TYPE(ANIMAL_TYPE_CD,ANIMAL_TYPE_MM) VALUES (2, 'Fox');";
sdb.execSQL(strSQL);
 strSQL = "INSERT INTO ANIMAL_TYPE(ANIMAL_TYPE_CD,ANIMAL_TYPE_MM) VALUES  (3, 'Deer');";
sdb.execSQL(strSQL);
strSQL = "INSERT INTO ANIMAL_TYPE(ANIMAL_TYPE_CD,ANIMAL_TYPE_MM) VALUES (4, 'Squirrel');";
sdb.execSQL(strSQL);
 strSQL = "INSERT INTO ANIMAL_TYPE(ANIMAL_TYPE_CD,ANIMAL_TYPE_MM) VALUES  (5, 'Bald Eagle');";
sdb.execSQL(strSQL);
strSQL = "INSERT INTO ANIMAL_TYPE(ANIMAL_TYPE_CD,ANIMAL_TYPE_MM) VALUES  (6, 'Skunk');";
sdb.execSQL(strSQL);
strSQL = "INSERT INTO ANIMAL_TYPE(ANIMAL_TYPE_CD,ANIMAL_TYPE_MM) VALUES (7, 'Raccoon');";
sdb.execSQL(strSQL);
strSQL = "INSERT INTO ANIMAL_TYPE(ANIMAL_TYPE_CD,ANIMAL_TYPE_MM) VALUES  (8, 'Robin');";
sdb.execSQL(strSQL);

	
	}
}
	