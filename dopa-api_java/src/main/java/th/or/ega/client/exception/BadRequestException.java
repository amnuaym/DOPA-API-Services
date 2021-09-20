/*
 * Electronic Government Agency (Public Organization)
 */
package th.or.ega.client.exception;

/**
 *
 * @author Thapanut Khanteetao <thapanut.khanteetao@ega.or.th>
 */
public class BadRequestException extends EGAWSClientException {

    public BadRequestException() {
    }

    public BadRequestException(String message) {
        super(message);
    }

    public BadRequestException(Throwable cause) {
        super(cause);
    }

    public BadRequestException(String message, Throwable cause) {
        super(message, cause);
    }
}
