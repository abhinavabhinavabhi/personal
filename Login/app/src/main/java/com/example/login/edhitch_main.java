package com.example.login;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.webkit.WebView;

public class edhitch_main extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_edhitch_main);
        WebView wb1=findViewById(R.id.edhiweb);
        wb1.loadUrl("https://www.edhitch.com/login.html");


    }
}
