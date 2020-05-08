package com.example.login;

import androidx.appcompat.app.AppCompatActivity;

import android.app.LauncherActivity;
import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.ListView;
import android.widget.SimpleAdapter;
import android.widget.Toast;

import java.util.ArrayList;
import java.util.List;

public class MainActivity extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_main);
        ListView lw=(ListView) findViewById(R.id.liist);
        final List<String> array=new ArrayList<String>();

        array.add("Edhitch Login");
        array.add("Student Login");
        array.add("Result ");
        ArrayAdapter<String> arrayAdapter=new ArrayAdapter<String>(this,R.layout.support_simple_spinner_dropdown_item,array);
        lw.setAdapter(arrayAdapter);
        lw.setOnItemClickListener(new AdapterView.OnItemClickListener() {
            @Override
            public void onItemClick(AdapterView<?> parent, View view, int position, long id) {
                String s=parent.getItemAtPosition(position).toString();
                Toast.makeText(MainActivity.this, s, Toast.LENGTH_SHORT).show();
                if(s=="Edhitch Login")
                {
                    Intent i=new Intent(getApplicationContext(),edhitch_main.class);
                    startActivity(i);


                }
                if(s=="Student Login")
                {
                    Intent i=new Intent(getApplicationContext(),sudent.class);
                    startActivity(i);
                }
                if(s=="Result ")
                {
                    Intent i=new Intent(getApplicationContext(),result.class);
                    startActivity(i);
                }

            }
        });

    }
}
