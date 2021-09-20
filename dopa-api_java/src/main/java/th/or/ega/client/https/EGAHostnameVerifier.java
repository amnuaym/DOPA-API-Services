/*
 * Electronic Government Agency (Public Organization)
 */
package th.or.ega.client.https;

import java.io.IOException;
import java.security.cert.X509Certificate;
import javax.net.ssl.SSLException;
import javax.net.ssl.SSLSession;
import javax.net.ssl.SSLSocket;
import org.apache.http.conn.ssl.X509HostnameVerifier;

/**
 *
 * @author Thapanut Khanteetao <thapanut.khanteetao@ega.or.th>
 */
public class EGAHostnameVerifier implements X509HostnameVerifier {

    private static final String[] HOSTNAME = {"ega.or.th", "164.115.9.34", "164.115.3.19"};

    private void verify(String host) throws SSLException {
        for (String name : HOSTNAME) {
            if (host.contains(name)) {
                return;
            }
        }
        throw new SSLException("invalid host name: " + host);
    }

    @Override
    public void verify(String host, SSLSocket socket) throws IOException {
        verify(host);
    }

    @Override
    public void verify(String host, X509Certificate certificate) throws SSLException {
        verify(host);
    }

    @Override
    public void verify(String host, String[] cn, String[] subject) throws SSLException {
        verify(host);
    }

    @Override
    public boolean verify(String host, SSLSession session) {
        for (String name : HOSTNAME) {
            if (host.contains(name)) {
                return true;
            }
        }
        return false;
    }
}
