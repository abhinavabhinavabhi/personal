package javatojdbc;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;

public class demojdbc {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
   String url="jdbc:sqlserver://DESKTOP-E7LFMHO;databaseName=demo";
   try {
	Connection con=DriverManager.getConnection(url);
	System.out.println("sucess");
} catch (SQLException e) {
	System.out.println("not sucess");
	e.printStackTrace();
} 
   

	}

}
