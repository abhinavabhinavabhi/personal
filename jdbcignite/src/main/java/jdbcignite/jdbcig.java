package jdbcignite;



import java.util.Collections;
import java.util.HashSet;
import java.util.LinkedHashMap;
import java.util.Set;

import javax.cache.configuration.Factory;
import javax.sql.DataSource;

import org.apache.ignite.Ignite;
import org.apache.ignite.IgniteCache;
import org.apache.ignite.Ignition;
import org.apache.ignite.cache.CacheAtomicityMode;
import org.apache.ignite.cache.CacheMode;
import org.apache.ignite.cache.QueryEntity;
import org.apache.ignite.cache.store.jdbc.CacheJdbcPojoStoreFactory;
import org.apache.ignite.cache.store.jdbc.JdbcType;
import org.apache.ignite.cache.store.jdbc.JdbcTypeField;
import org.apache.ignite.cache.store.jdbc.dialect.SQLServerDialect;
import org.apache.ignite.configuration.CacheConfiguration;
import org.apache.ignite.configuration.IgniteConfiguration;

import com.microsoft.sqlserver.jdbc.SQLServerDataSource;

public class jdbcig {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		IgniteConfiguration igniteCfg = new IgniteConfiguration();

		CacheConfiguration<Integer, person> personCacheCfg = new CacheConfiguration<>();

		personCacheCfg.setName("PersonCache");
		personCacheCfg.setCacheMode(CacheMode.PARTITIONED);
		personCacheCfg.setAtomicityMode(CacheAtomicityMode.ATOMIC);

		personCacheCfg.setReadThrough(true);
		personCacheCfg.setWriteThrough(true);

		CacheJdbcPojoStoreFactory<Integer, person> factory = new CacheJdbcPojoStoreFactory<>();
		factory.setDialect(new SQLServerDialect());
		
		factory.setDataSourceFactory((Factory<DataSource>)()-> {
			SQLServerDataSource dataSource = new SQLServerDataSource();
		    dataSource.setURL("jdbc:sqlserver://DESKTOP-E7LFMHO;databaseName=demo;integratedSecurity=true");
		    /*dataSource.setPassword("password");
		    dataSource.setServerName("hostname");
		    dataSource.setDatabaseName("db");*/
			return dataSource;
		});
		
		/*factory.setDataSourceFactory((Factory<DataSource>)() -> {
		   SQ
			
			MysqlDataSource mysqlDataSrc = new MysqlDataSource();
		    mysqlDataSrc.setURL("jdbc:mysql://[host]:[port]/[database]");
		    mysqlDataSrc.setUser("YOUR_USER_NAME");
		    mysqlDataSrc.setPassword("YOUR_PASSWORD");
		    return mysqlDataSrc;
		});
*/
		JdbcType personType = new JdbcType();
		
		personType.setCacheName("PersonCache");
		personType.setKeyType(Integer.class);
		personType.setValueType(person.class);
		// Specify the schema if applicable
		// personType.setDatabaseSchema("MY_DB_SCHEMA");
		personType.setDatabaseTable("PERSON");

		personType.setKeyFields(new JdbcTypeField(java.sql.Types.INTEGER, "id", Integer.class, "id"));

		personType.setValueFields(new JdbcTypeField(java.sql.Types.INTEGER, "id", Integer.class, "id"));
		personType.setValueFields(new JdbcTypeField(java.sql.Types.VARCHAR, "name", String.class, "name"));

		factory.setTypes(personType);

		personCacheCfg.setCacheStoreFactory(factory);

		QueryEntity qryEntity = new QueryEntity();

		qryEntity.setKeyType(Integer.class.getName());
		qryEntity.setValueType(person.class.getName());
		qryEntity.setKeyFieldName("id");

		Set<String> keyFields = new HashSet<>();
		keyFields.add("id");
		qryEntity.setKeyFields(keyFields);

		LinkedHashMap<String, String> fields = new LinkedHashMap<>();
		fields.put("id", "java.lang.Integer");
		fields.put("name", "java.lang.String");

		qryEntity.setFields(fields);

		personCacheCfg.setQueryEntities(Collections.singletonList(qryEntity));

		igniteCfg.setCacheConfiguration(personCacheCfg);
		Ignite ignite = Ignition.start(igniteCfg);
		IgniteCache<Integer, person> personCache = ignite.cache("PersonCache");
		personCache.loadCache(null);
		person p=new person();
		p.setId(3);
		p.setName("trial");
		personCache.put(3,p);
		String res= personCache.get(3).toString();
		System.out.println(res);
	}
}
