/*
 * Electronic Government Agency (Public Organization)
 */
package th.or.ega.client.https;

import java.net.Socket;
import java.security.Principal;
import java.security.PrivateKey;
import java.security.cert.X509Certificate;
import javax.net.ssl.KeyManager;
import javax.net.ssl.X509ExtendedKeyManager;

/**
 *
 * @author Thapanut Khanteetao <thapanut.khanteetao@ega.or.th>
 */
public class EGAKeyManagerFactory {

    public static KeyManager[] getKeyManagers() {
        return new KeyManager[]{new EGAX509KeyManager()};
    }

    private static class EGAX509KeyManager extends X509ExtendedKeyManager {

        @Override
        public String[] getClientAliases(String client, Principal[] principals) {
            return new String[]{"ega"};
        }

        @Override
        public String chooseClientAlias(String[] client, Principal[] principals, Socket socket) {
            return "ega";
        }

        @Override
        public String[] getServerAliases(String server, Principal[] principals) {
            return new String[]{"ega"};
        }

        @Override
        public String chooseServerAlias(String server, Principal[] principals, Socket socket) {
            return "ega";
        }

        @Override
        public X509Certificate[] getCertificateChain(String chain) {
            return new X509Certificate[]{};
        }

        @Override
        public PrivateKey getPrivateKey(String key) {
            return null;
        }
    }
}
