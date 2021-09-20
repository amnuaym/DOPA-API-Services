/*
 * Electronic Government Agency (Public Organization)
 */
package th.or.ega.client.https;

import java.security.cert.CertificateException;
import java.security.cert.X509Certificate;
import javax.net.ssl.TrustManager;
import javax.net.ssl.X509TrustManager;

/**
 *
 * @author Thapanut Khanteetao <thapanut.khanteetao@ega.or.th>
 */
public class EGATrustManagerFactory {

    public static TrustManager[] getTrustManagers() {
        return new TrustManager[]{new EGAX509TrustManager()};
    }

    private static class EGAX509TrustManager implements X509TrustManager {

        @Override
        public void checkClientTrusted(X509Certificate[] certificates, String client) throws CertificateException {
            // do nothing
        }

        @Override
        public void checkServerTrusted(X509Certificate[] certificates, String server) throws CertificateException {
            // do nothing
        }

        @Override
        public X509Certificate[] getAcceptedIssuers() {
            return new X509Certificate[]{};
        }
    }
}
