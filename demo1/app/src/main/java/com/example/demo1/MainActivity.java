package com.example.demo1;

import androidx.appcompat.app.AppCompatActivity;

import android.app.DatePickerDialog;
import android.app.TimePickerDialog;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.webkit.WebView;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.DatePicker;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.TimePicker;

import java.time.Year;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.List;

class MainActivity extends AppCompatActivity {
    final Calendar c=Calendar.getInstance();
    String date,time;
    int yyyy,mm,dd,hh,MM,ss;
    TextView t1,t2;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        WebView wv=(WebView)  findViewById(R.id.web);
        List<String> arr=new ArrayList<String>();
        arr.add("Student");
        arr.add("faculty");
        arr.add("owner");
        t1=findViewById(R.id.textView);
        t2=findViewById(R.id.textView2);
        ArrayAdapter<String> arrayAdapter=new ArrayAdapter<>(this,R.layout.support_simple_spinner_dropdown_item,arr);
        Spinner sp=findViewById(R.id.spinner);
        sp.setAdapter(arrayAdapter);
        sp.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                String str=parent.getItemAtPosition(position).toString();

            }
        });
        wv.loadUrl("http://www.google.com/");
    }
    public  void dateshow(View view)
    {
        yyyy=c.get(Calendar.YEAR);
        mm=c.get(Calendar.MONTH);
        dd=c.get(Calendar.DAY_OF_MONTH);
        DatePickerDialog datePickerDialog=new DatePickerDialog(this, new DatePickerDialog.OnDateSetListener() {
            @Override
            public void onDateSet(DatePicker view, int year, int month, int dayOfMonth) {
                date+=String.valueOf(year)+"/"+String.valueOf(month)+"/"+String.valueOf(dayOfMonth);
            }
        },yyyy,mm,dd);

        datePickerDialog.show();
        t1.setText(date);
    }
    public void timeshow(View view)
    {
        hh=c.get(Calendar.HOUR_OF_DAY);
        mm=c.get(Calendar.MINUTE);

        TimePickerDialog timePickerDialog=new TimePickerDialog(this, new TimePickerDialog.OnTimeSetListener() {
            @Override
            public void onTimeSet(TimePicker view, int hourOfDay, int minute) {
                time+=String.valueOf(hourOfDay)+":"+String.valueOf(minute);
            }
        },hh,mm,false);
        timePickerDialog.show();
        t2.setText(time);

    }
    public  void  nextpage(View view)
    {
        Intent in=new Intent(getApplicationContext(),Main2Activity.class);
        in.putExtra("time",time);
        in.putExtra("date",date);
        startActivity(in);


    }
}
