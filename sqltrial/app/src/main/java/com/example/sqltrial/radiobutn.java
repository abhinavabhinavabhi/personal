package com.example.sqltrial;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.view.View;
import android.widget.Button;
import android.widget.RadioButton;
import android.widget.RadioGroup;
import android.widget.Toast;

public class radiobutn extends AppCompatActivity {
RadioButton rb;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_radiobutn);
        Bundle bn=getIntent().getExtras();
        Toast.makeText(this, bn.getString("key"), Toast.LENGTH_SHORT).show();

        Button b1=findViewById(R.id.show);

        b1.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                RadioGroup rg=findViewById(R.id.radiooo);
                int radioid=rg.getCheckedRadioButtonId();
                rb=findViewById(radioid);
                Toast.makeText(radiobutn.this, rb.getText(), Toast.LENGTH_SHORT).show();
            }
        });




    }
}
