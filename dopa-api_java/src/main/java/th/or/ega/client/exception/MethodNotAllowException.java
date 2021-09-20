/*
 * Electronic Government Agency (Public Organization)
 */
package th.or.ega.client.exception;

/**
 *
 * @author Thapanut Khanteetao <thapanut.khanteetao@ega.or.th>
 */
public class MethodNotAllowException extends EGAWSClientException {

    public MethodNotAllowException() {
    }

    public MethodNotAllowException(String message) {
        super(message);
    }

    public MethodNotAllowException(Throwable cause) {
        super(cause);
    }

    public MethodNotAllowException(String message, Throwable cause) {
        super(message, cause);
    }
}
