package javajdbcmaven;
import java.sql.Connection;
	import java.sql.DriverManager;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;

public class mavenjdbc {

		public static void main(String[] args) {
			// TODO Auto-generated method stub
	   String url="jdbc:sqlserver://DESKTOP-E7LFMHO;databaseName=demo;integratedSecurity=true";
	  
	   
	   try {
		Connection con=DriverManager.getConnection(url);
		System.out.println("sucess");
		show(con);
		
	} catch (SQLException e) {
		System.out.println("not sucess");
		e.printStackTrace();
	} 
	   

		

	}
		private static void add(Connection con) {
			// TODO Auto-generated method stub
			String addsql="INSERT INTO student values(88,'jdbc tria','muzupillangad','kannur',5656)";
			Statement stat;
			int rows=0;
			try {
				stat = con.createStatement();
				rows=stat.executeUpdate(addsql);
			} catch (SQLException e) {
				
				e.printStackTrace();
			}
			
		if(rows>0)
		{
			System.out.println("row inserted");
		}
		}
		
		private static void show(Connection con) {
			String select="select * from student";
			try {
				Statement state=con.createStatement();
				ResultSet res= state.executeQuery(select);
				while(res.next())
				{
					String name=res.getString("name");
					int id=res.getInt(1);
					System.out.printf("id  :%d   name  : %s\n",id,name);
				}
			} catch (Exception e) {
				// TODO: handle exception
				System.out.println("error");
			}
			
			
			
			
		}

}


