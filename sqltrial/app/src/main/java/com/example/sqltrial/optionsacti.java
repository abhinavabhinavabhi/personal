package com.example.sqltrial;

import androidx.annotation.NonNull;
import androidx.annotation.Nullable;
import androidx.appcompat.app.AppCompatActivity;
import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentManager;
import androidx.fragment.app.FragmentTransaction;

import android.content.Intent;
import android.os.Bundle;
import android.provider.DocumentsProvider;
import android.view.Menu;
import android.view.MenuInflater;
import android.view.MenuItem;
import android.view.View;
import android.widget.Button;
import android.widget.FrameLayout;
import android.widget.TextView;
import android.widget.Toast;

import java.io.FileDescriptor;
import java.io.PrintWriter;
import java.util.List;

public class optionsacti extends AppCompatActivity {
Button b1,b2,b3;
    BlankFragment fr1=new BlankFragment();
    BlankFragment2 fr2=new BlankFragment2();

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_optionsacti);
        TextView t1=findViewById(R.id.heading);
        Bundle b=getIntent().getExtras();
        t1.setText("hii"+b.getString("name"));
        b1=findViewById(R.id.selct);
        b2=findViewById(R.id.radi);
        b3=findViewById(R.id.list);
        b1.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent ii=new Intent(getApplicationContext(),select.class);
                ii.putExtra("key","key");
                startActivity(ii);


            }
        });
        b2.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent in=new Intent(getApplicationContext(),radiobutn.class);
                in.putExtra("key","key");
                startActivity(in);
            }
        });
        b3.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                try {
                    Intent inn = new Intent(getApplicationContext(),selectbox.class);
                    startActivity(inn);



                }catch (Exception e)
                {

                }
            }
        });



    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
       MenuInflater min=getMenuInflater();
        min.inflate(R.menu.options, menu);

        return true;
    }

    @Override
    public boolean onOptionsItemSelected(@NonNull MenuItem item) {
        switch(item.getItemId())
        {

            case R.id.frag1:{
                try { FragmentManager fm=getSupportFragmentManager();
                        fm.popBackStack();
                    FragmentTransaction ft=fm.beginTransaction();
                    ft.add(R.id.fragment2,fr1);


                    ft.commit();
                }catch (Exception e)
                {
                    Toast.makeText(getApplicationContext(), "error"+e.getMessage().toString(), Toast.LENGTH_SHORT).show();
                }


                return true;

            }
            case R.id.frag2:{
                try { FragmentManager fm=getSupportFragmentManager();
                    fm.popBackStack();

                    FragmentTransaction ft=fm.beginTransaction();
                    ft.add(R.id.fragment2,fr2);

                    ft.commit();
                }catch (Exception e)
                {
                    Toast.makeText(getApplicationContext(), "error"+e.getMessage().toString(), Toast.LENGTH_SHORT).show();
                }


                return true;
            }
            case R.id.homeal:
            {
                try {
                    Intent i=new Intent(getApplicationContext(),MainActivity.class);
                    startActivity(i);
                    return true;
                }catch (Exception e)
                {
                    Toast.makeText(this, e.getMessage(), Toast.LENGTH_SHORT).show();
                }

            }
            default:return false;



        }

    }
}
