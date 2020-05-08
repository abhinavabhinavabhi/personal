package com.example.sqltrial;

import androidx.appcompat.app.AppCompatActivity;

import android.app.DatePickerDialog;
import android.app.TimePickerDialog;
import android.content.Intent;
import android.database.Cursor;
import android.os.Bundle;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.AutoCompleteTextView;
import android.widget.Button;
import android.widget.DatePicker;
import android.widget.EditText;
import android.widget.SimpleAdapter;
import android.widget.TextView;
import android.widget.TimePicker;
import android.widget.Toast;

import java.text.SimpleDateFormat;
import java.util.Calendar;

public class MainActivity extends AppCompatActivity {
 Button time,date,show,add,next;

 String currdate,dage,dtime,dname,ddate;
 TextView age;
 EditText name,details;
    sqldatabase sqldb=new sqldatabase(this);

 int myear,mmonth,mday,mhour,mmin;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        date=findViewById(R.id.datepic);
        time=findViewById(R.id.timesel);
        String[] texts={"abhinav","rajiv","sujina","amal","raghavan","leela","mukhundan","susheela"};
        AutoCompleteTextView tv=(AutoCompleteTextView)findViewById(R.id.autotext);
        //ArrayAdapter arrayAdapter=new ArrayAdapter(this,android.R.layout.simple_spinner_dropdown_item,texts);
        ArrayAdapter arrayAdapter=new ArrayAdapter(this,R.layout.support_simple_spinner_dropdown_item,texts);
        tv.setAdapter(arrayAdapter);
        show=findViewById(R.id.show);
        next=findViewById(R.id.next);
        add=findViewById(R.id.addd);
        age=findViewById(R.id.age);
        name=findViewById(R.id.name);
        Bundle b=getIntent().getExtras();
       tv.setText(b.getString("occu"));
        details=findViewById(R.id.details);
       SimpleDateFormat sf=new SimpleDateFormat("yyyy");
      Calendar c=Calendar.getInstance();
      currdate=sf.format(c.getTime());
        // SimpleDateFormat df= new SimpleDateFormat("yyyy");
       // Calendar c= Calendar.getInstance();
        //currdate=df.format(c.getTime());
        next.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent i=new Intent(getApplicationContext(),optionsacti.class);
                i.putExtra("name",name.getText().toString());
                startActivity(i);

            }
        });




    }
    public void dateset(View v)
    {

        Calendar c= Calendar.getInstance();
        myear=c.get(Calendar.YEAR);
        mmonth=c.get(Calendar.MONTH);
        mday=c.get(Calendar.DAY_OF_MONTH);
        DatePickerDialog dp=new DatePickerDialog(this, new DatePickerDialog.OnDateSetListener() {
            @Override
            public void onDateSet(DatePicker view, int year, int month, int dayOfMonth) {
                //  date.setText(String.valueOf(dayOfMonth)+"/"+String.valueOf(month)+"/"+String.valueOf(year));
                // age.setText(year);
                String dateval=String.valueOf(dayOfMonth)+"/"+String.valueOf(month+1)+"/"+String.valueOf(year);
                date.setText(dateval);
                int agee=Integer.parseInt(currdate)-Integer.valueOf(year);
                age.setText(String.valueOf(agee));
                dage=String.valueOf(agee);


                ddate=dateval;

            }
        },myear,mmonth,mday);
        dp.show();
    }
    public void timeshow(View v)
    {
        Calendar c = Calendar.getInstance();
        mhour=c.get(Calendar.HOUR_OF_DAY);
        mmin=c.get(Calendar.MINUTE);



        TimePickerDialog p=new TimePickerDialog(this, new TimePickerDialog.OnTimeSetListener() {
            @Override
            public void onTimeSet(TimePicker view, int hourOfDay, int minute) {
                time.setText(String.valueOf(hourOfDay)+":"+String.valueOf(minute));
                dtime=String.valueOf(hourOfDay)+":"+String.valueOf(minute);
            }
        },mhour,mmin,true);
        p.show();

    }
    public  void dataadd(View v)
    {
        dname=name.getText().toString();
        boolean b=sqldb.insert(dname,dage,ddate,dtime);
        if(b==true)
        {
            Toast.makeText(this, "sucessfully inserted", Toast.LENGTH_SHORT).show();
        }
        else
        {
            Toast.makeText(this, "not inserted", Toast.LENGTH_SHORT).show();
        }



    }
    /*public  void get(View v)
    {
        Cursor c=sqldb.show();
        String name,age,dob,time;
        StringBuilder sb=new StringBuilder();
        while (c.moveToNext())
        {
            name=c.getString(0);
            age=c.getString(1);
            dob=c.getString(2);
            time=c.getString(3);
            sb.append(name+" "+age+" "+dob+" "+time+"\n");

        }
        details.setText(sb);
    }*/
    public void  get(View view)
    {StringBuilder sb=new StringBuilder();
        Cursor cb=sqldb.show();
        while(cb.moveToNext())
        {
            sb.append(cb.getString(0)+" "+cb.getString(1)+" "+cb.getString(2)+" "+cb.getString(3));

        }
        details.setText(sb);
    }
}
