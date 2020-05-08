package com.example.sqltrial;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.ListView;
import android.widget.Toast;

public class selectbox extends AppCompatActivity {
ListView lv;
public String[] list={"abhinav","rajiv","sujina","amal","raghavan","leela","susheela","mukhundan"};
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_selectbox);
        ArrayAdapter arr=new ArrayAdapter(this,R.layout.support_simple_spinner_dropdown_item,list);
        lv=findViewById(R.id.listv);
        lv.setAdapter(arr);
        lv.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                String idn = parent.getItemAtPosition(position).toString();
                Toast.makeText(selectbox.this, idn, Toast.LENGTH_SHORT).show();
            }
        });

    }
}
