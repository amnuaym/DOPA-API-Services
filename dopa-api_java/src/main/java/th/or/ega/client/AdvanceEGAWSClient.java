/*
 * Electronic Government Agency (Public Organization)
 */
package th.or.ega.client;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import com.google.gson.reflect.TypeToken;
import java.io.IOException;
import java.lang.reflect.Type;
import java.nio.charset.Charset;
import java.util.Map;
import java.util.logging.Logger;
import org.apache.http.HttpEntity;
import org.apache.http.HttpResponse;
import org.apache.http.HttpStatus;
import org.apache.http.client.HttpClient;
import org.apache.http.client.methods.HttpGet;
import org.apache.http.util.EntityUtils;
import th.or.ega.client.exception.BadRequestException;
import th.or.ega.client.exception.EGAWSClientException;
import th.or.ega.client.exception.ForbiddenException;
import th.or.ega.client.exception.InternalServerErrorException;
import th.or.ega.client.exception.MethodNotAllowException;
import th.or.ega.client.exception.NoContentException;
import th.or.ega.client.exception.NotFoundException;
import th.or.ega.client.exception.ServiceUnavailableException;
import th.or.ega.client.exception.UnauthorizedException;
import th.or.ega.client.https.EGAHttpsClient;

/**
 *
 * @author Thapanut Khanteetao <thapanut.khanteetao@ega.or.th>
 */
public class AdvanceEGAWSClient {

    private static final Logger log = Logger.getLogger(AdvanceEGAWSClient.class.getName());
    //
    private static final Gson gson = new GsonBuilder().create(); // create json parser
    //
    private static final Type JSON_MAP_TYPE = new TypeToken<Map<String, Object>>() {
    }.getType(); // create json map type for parser
    //
    private static final String CONTENT_TYPE = "application/x-www-form-urlencoded; charset=utf-8";

    // TODO: config this value
    private static final String CONSUMER_KEY = ""; // consumer key for web service
    // TODO: config this value
    private static final String CONSUMER_SECRET = ""; // consumer secret for web service
    // TODO: config this value
    private static final String AGENT_ID = ""; // agent citizen id

    /*
     * handle error and parse response
     */
    private String handleResponse(HttpResponse response) throws IOException {
        if (response.getStatusLine().getStatusCode() != 200) {
            switch (response.getStatusLine().getStatusCode()) {
                case HttpStatus.SC_NO_CONTENT: // 204
                    throw new NoContentException();
                case HttpStatus.SC_BAD_REQUEST: // 400
                    throw new BadRequestException();
                case HttpStatus.SC_UNAUTHORIZED: // 401
                    throw new UnauthorizedException();
                case HttpStatus.SC_FORBIDDEN: // 403
                    throw new ForbiddenException();
                case HttpStatus.SC_NOT_FOUND: // 404
                    throw new NotFoundException();
                case HttpStatus.SC_METHOD_NOT_ALLOWED: // 405
                    throw new MethodNotAllowException();
                case HttpStatus.SC_INTERNAL_SERVER_ERROR: // 500
                    throw new InternalServerErrorException();
                case HttpStatus.SC_SERVICE_UNAVAILABLE: // 503
                    throw new ServiceUnavailableException();
                default:
                    throw new EGAWSClientException();
            }
        }
        HttpEntity content = response.getEntity();
        if (content == null) {
            return null;
        }
        return EntityUtils.toString(content, Charset.forName("UTF-8"));
    }

    public void request() throws IOException {
        HttpClient client = EGAHttpsClient.getClient(); // create http client
        String token = null;

        /*
         * request access token
         */
        String tokenRequestURL = String.format("https://ws.ega.or.th/ws/auth/validate?ConsumerSecret=%s&AgentID=%s", CONSUMER_SECRET, AGENT_ID); // set request url
        HttpGet tokenRequest = new HttpGet(tokenRequestURL); // create http get method
        tokenRequest.setHeader("Content-Type", CONTENT_TYPE); // set content type header
        tokenRequest.setHeader("Consumer-Key", CONSUMER_KEY); // set consumer key header
        String tokenContent = handleResponse(client.execute(tokenRequest)); // parse response data
        if (tokenContent != null) {
            Map<String, Object> tokenJson = gson.fromJson(tokenContent, JSON_MAP_TYPE); // convert json string to map
            token = String.class.cast(tokenJson.get("Result")); // get result
        }
        if (token == null) {
            throw new EGAWSClientException("could not request access token");
        }

        /*
         * request dopa personal profile
         */
        // TODO: config this value
        String citizenID = ""; // citizen id for request dopa personal profile

        String personalProfileRequestURL = String.format("https://ws.ega.or.th/ws/dopa/personal/profile/normal?CitizenID=%s", citizenID); // set request url
        HttpGet personalProfileRequest = new HttpGet(personalProfileRequestURL); // create http get method
        personalProfileRequest.setHeader("Content-Type", CONTENT_TYPE); // set content type header
        personalProfileRequest.setHeader("Consumer-Key", CONSUMER_KEY); // set consumer key header
        personalProfileRequest.setHeader("Token", token); // set access token
        String personalProfileContent = handleResponse(client.execute(personalProfileRequest)); // parse response data
        if (personalProfileContent != null) {
            Map<String, Object> personalProfileJson = gson.fromJson(personalProfileContent, JSON_MAP_TYPE); // convert json string to map
            log.info(String.class.cast(personalProfileJson.get("CitizenID"))); // show citizen id
            log.info(String.class.cast(personalProfileJson.get("NameTH_FirstName"))); // show first name
            log.info(String.class.cast(personalProfileJson.get("NameTH_SurName"))); // show last name
        }
    }

    public static void main(String[] args) throws IOException {
        new AdvanceEGAWSClient().request();
    }
}
