package com.example.demo1;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.widget.TextView;

public class Main2Activity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main2);
        Intent intent=getIntent();
        String messa= intent.getStringExtra("date");
        messa+=intent.getStringExtra("time");
        TextView tv=findViewById(R.id.textView3);
        tv.setText(messa);

    }
}
