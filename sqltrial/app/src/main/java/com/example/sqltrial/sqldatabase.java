package com.example.sqltrial;

import android.content.ContentValues;
import android.content.Context;
import android.database.Cursor;
import android.database.sqlite.SQLiteDatabase;
import android.database.sqlite.SQLiteOpenHelper;
import android.os.strictmode.SqliteObjectLeakedViolation;

import androidx.annotation.Nullable;

public class sqldatabase extends SQLiteOpenHelper {
    public static final String dbname="birh.db";
    public static final String table="person";
    public static final String col1="name";
    public static final String col2="age";
    public static final String col3="dob";
    public static final String col4="time";


    public sqldatabase(@Nullable Context context) {
        super(context, dbname, null, 1);
    }

    @Override
    public void onCreate(SQLiteDatabase db) {
        String sql1="CREATE TABLE "+table+"("+col1+" TEXT ,"+col2+" TEXT,"+col3+" TEXT,"+col4+" TEXT)";
        db.execSQL(sql1);
    }

    @Override
    public void onUpgrade(SQLiteDatabase db, int oldVersion, int newVersion) {

    }
    public boolean insert(String name,String age,String date,String time)
    {
     SQLiteDatabase db=this.getWritableDatabase();


        ContentValues content=new ContentValues();
        content.put(col1,name);
        content.put(col2,age);
        content.put(col3,date);
        content.put(col4,time);
        long b=db.insert(table,null,content);
        if(b==-1){
        return false;}
        else {
            return true;
        }


    }
  /*  public Cursor show()
    {
        SQLiteDatabase db=this.getWritableDatabase();
        Cursor data=db.rawQuery("SELECT * FROM "+table,null);
        while (data.moveToNext()){
            return data;
        }
        return data;}
 */
  public  Cursor show()
  {
      SQLiteDatabase db=this.getWritableDatabase();
      Cursor cb=db.rawQuery("SELECT * FROM "+table,null);
      while(cb.moveToNext())
      {
          return cb;
      }
      return cb;

  }

}
