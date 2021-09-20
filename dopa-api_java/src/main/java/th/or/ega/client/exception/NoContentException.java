/*
 * Electronic Government Agency (Public Organization)
 */
package th.or.ega.client.exception;

/**
 *
 * @author Thapanut Khanteetao <thapanut.khanteetao@ega.or.th>
 */
public class NoContentException extends EGAWSClientException {

    public NoContentException() {
    }

    public NoContentException(String message) {
        super(message);
    }

    public NoContentException(Throwable cause) {
        super(cause);
    }

    public NoContentException(String message, Throwable cause) {
        super(message, cause);
    }
}
