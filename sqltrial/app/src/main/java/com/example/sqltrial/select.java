package com.example.sqltrial;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.Toast;

public class select extends AppCompatActivity {
CheckBox c1,c2,c3;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_select);
        Bundle bb=getIntent().getExtras();
        Toast.makeText(getApplicationContext(), bb.getString("key"), Toast.LENGTH_SHORT).show();
        c1=findViewById(R.id.list1);
        c2=findViewById(R.id.list2);
        c3=findViewById(R.id.list3);
        Button b1=findViewById(R.id.submit);
        b1.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if(c1.isChecked())
                {
                    Toast.makeText(getApplicationContext(), "google selected", Toast.LENGTH_SHORT).show();
                    c1.setChecked(false);
                }
                else if(c2.isChecked())
                {
                    Toast.makeText(getApplicationContext(), "google plus selected", Toast.LENGTH_SHORT).show();
                    c2.setChecked(false);
                }
                else if(c3.isChecked())
                {
                    Toast.makeText(getApplicationContext(), "other selected", Toast.LENGTH_SHORT).show();
                    c3.setChecked(false);

                }
            }
        });

    }
}
