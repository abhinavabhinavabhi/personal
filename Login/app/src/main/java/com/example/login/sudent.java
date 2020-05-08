package com.example.login;

import androidx.appcompat.app.AppCompatActivity;

import android.os.Bundle;
import android.webkit.WebView;

public class sudent extends AppCompatActivity {

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_sudent);
        WebView wb=findViewById(R.id.studweb);
        wb.loadUrl("https://my-pgi.com/KnowledgePro/StudentLogin.do");
    }
}
