package igniteone;

import java.util.Collections;

import org.apache.ignite.Ignite;
import org.apache.ignite.IgniteCache;
import org.apache.ignite.IgniteException;
import org.apache.ignite.Ignition;
import org.apache.ignite.configuration.IgniteConfiguration;
import org.apache.ignite.failure.NoOpFailureHandler;
import org.apache.ignite.lang.IgniteRunnable;
import org.apache.ignite.resources.IgniteInstanceResource;
import org.apache.ignite.spi.discovery.tcp.TcpDiscoverySpi;
import org.apache.ignite.spi.discovery.tcp.ipfinder.multicast.TcpDiscoveryMulticastIpFinder;

public class ignitehello {

	public static void main(String[] args)throws IgniteException  {
		// TODO Auto-generated method stub
		IgniteConfiguration cfg = new IgniteConfiguration();

        // The node will be started as a client node.
      cfg.setClientMode(true);

        // Classes of custom Java logic will be transferred over the wire from this app.
        cfg.setPeerClassLoadingEnabled(true);

        // Setting up an IP Finder to ensure the client can locate the servers.
        TcpDiscoveryMulticastIpFinder ipFinder = new TcpDiscoveryMulticastIpFinder();
        ipFinder.setAddresses(Collections.singletonList("127.0.0.1:8080"));
        cfg.setDiscoverySpi(new TcpDiscoverySpi().setIpFinder(ipFinder));

        // Starting the node
        Ignite ignite = Ignition.start(cfg);

        // Create an IgniteCache and put some values in it.
        IgniteCache<Integer, String> cache = ignite.getOrCreateCache("myCache");
        cache.put(1, "abhinav");
        cache.put(2, "rajiv");

        System.out.println(">> Created the cache and add the values.");

        // Executing custom Java compute task on server nodes.
       ignite.compute(ignite.cluster().forServers()).broadcast(new RemoteTask());

        System.out.println(">> Compute task is executed, check for output on the server nodes.");
        System.out.println(">> Executing the compute task");

      /*  System.out.println(
            "   Node ID: " + ignite.cluster().localNode().id() + "\n" +
            "   OS: " + System.getProperty("os.name") +
            "   JRE: " + System.getProperty("java.runtime.name"));

       
        System.out.println(">> " + cache.get(1) + " " + cache.get(2));
       */
        ignite.close();
	}
	
	private static class RemoteTask implements IgniteRunnable {

		@IgniteInstanceResource
		Ignite ignite;
		public void run() {
			
			 System.out.println(">> Executing the compute task");

	            System.out.println(
	                "   Node ID: " + ignite.cluster().localNode().id() + "\n" +
	                "   OS: " + System.getProperty("os.name") +
	                "   JRE: " + System.getProperty("java.runtime.name"));

	            IgniteCache<Integer, String> cache = ignite.cache("myCache");

	            System.out.println(">> " + cache.get(1) + " " + cache.get(2));
		}
		
		
	}
}
