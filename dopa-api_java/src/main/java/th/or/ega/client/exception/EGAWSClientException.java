/*
 * Electronic Government Agency (Public Organization)
 */
package th.or.ega.client.exception;

/**
 *
 * @author Thapanut Khanteetao <thapanut.khanteetao@ega.or.th>
 */
public class EGAWSClientException extends RuntimeException {

    public EGAWSClientException() {
    }

    public EGAWSClientException(String message) {
        super(message);
    }

    public EGAWSClientException(Throwable cause) {
        super(cause);
    }

    public EGAWSClientException(String message, Throwable cause) {
        super(message, cause);
    }
}
