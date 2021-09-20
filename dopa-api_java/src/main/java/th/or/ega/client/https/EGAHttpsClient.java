/*
 * Electronic Government Agency (Public Organization)
 */
package th.or.ega.client.https;

import java.security.GeneralSecurityException;
import java.security.SecureRandom;
import javax.net.ssl.SSLContext;
import org.apache.http.client.HttpClient;
import org.apache.http.conn.ClientConnectionManager;
import org.apache.http.conn.scheme.Scheme;
import org.apache.http.conn.scheme.SchemeRegistry;
import org.apache.http.conn.ssl.SSLSocketFactory;
import org.apache.http.impl.client.DefaultHttpClient;
import org.apache.http.impl.conn.PoolingClientConnectionManager;

/**
 *
 * @author Thapanut Khanteetao <thapanut.khanteetao@ega.or.th>
 */
public class EGAHttpsClient {

    public static HttpClient getClient() {
        try {
            SSLContext context = SSLContext.getInstance("TLS");
            context.init(EGAKeyManagerFactory.getKeyManagers(), EGATrustManagerFactory.getTrustManagers(), new SecureRandom());
            SSLSocketFactory factory = new SSLSocketFactory(context, new EGAHostnameVerifier());
            SchemeRegistry registry = new SchemeRegistry();
            registry.register(new Scheme("https", 443, factory));
            ClientConnectionManager manager = new PoolingClientConnectionManager(registry);
            return new DefaultHttpClient(manager);
        } catch (GeneralSecurityException ex) {
            throw new th.or.ega.client.exception.EGAWSClientException("could not create ssl client: " + ex.getMessage());
        }
    }

}
