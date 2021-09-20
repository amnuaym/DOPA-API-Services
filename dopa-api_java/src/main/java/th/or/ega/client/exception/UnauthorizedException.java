/*
 * Electronic Government Agency (Public Organization)
 */
package th.or.ega.client.exception;

/**
 *
 * @author Thapanut Khanteetao <thapanut.khanteetao@ega.or.th>
 */
public class UnauthorizedException extends EGAWSClientException {

    public UnauthorizedException() {
    }

    public UnauthorizedException(String message) {
        super(message);
    }

    public UnauthorizedException(Throwable cause) {
        super(cause);
    }

    public UnauthorizedException(String message, Throwable cause) {
        super(message, cause);
    }
}
