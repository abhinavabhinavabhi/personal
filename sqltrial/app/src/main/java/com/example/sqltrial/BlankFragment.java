package com.example.sqltrial;


import android.content.Intent;
import android.os.Bundle;

import androidx.fragment.app.Fragment;

import android.view.LayoutInflater;
import android.view.MenuItem;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.Spinner;
import android.widget.Toast;


public class BlankFragment extends Fragment {
    Button b1;
    Spinner s1;
    String slected;
    String[] occupation={"Student","House maid","buisness","Gov job","Others"};
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
       final View view= inflater.inflate(R.layout.fragment_blank, container, false);
       b1=view.findViewById(R.id.frag1butt);
       s1=view.findViewById(R.id.frag1spinner);
       b1.setOnClickListener(new View.OnClickListener() {
           @Override
           public void onClick(View v) {
               Intent i=new Intent(view.getContext(),MainActivity.class);
               i.putExtra("occu",slected);
               startActivity(i);
           }
       });
        ArrayAdapter aray=new ArrayAdapter(this.getActivity(),android.R.layout.simple_spinner_dropdown_item,occupation);
        aray.setDropDownViewResource(R.layout.support_simple_spinner_dropdown_item);
        s1.setAdapter(aray);
        s1.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
            @Override
            public void onItemSelected(AdapterView<?> parent, View view, int position, long id) {
                slected=parent.getItemAtPosition(position).toString();
                Toast.makeText(view.getContext(), slected, Toast.LENGTH_SHORT).show();
            }

            @Override
            public void onNothingSelected(AdapterView<?> parent) {

            }
        });
        return view;
    }


}
