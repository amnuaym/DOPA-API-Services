/*
 * Electronic Government Agency (Public Organization).
 */
package th.or.ega.client;

import com.google.gson.Gson;
import com.google.gson.GsonBuilder;
import com.google.gson.reflect.TypeToken;
import java.io.IOException;
import java.lang.reflect.Type;
import java.nio.charset.Charset;
import java.util.Map;
import org.apache.http.HttpEntity;
import org.apache.http.HttpResponse;
import org.apache.http.client.HttpClient;
import org.apache.http.client.methods.HttpGet;
import org.apache.http.impl.client.DefaultHttpClient;
import org.apache.http.util.EntityUtils;

/**
 *
 * @author Thapanut Khanteetao <thapanut.khanteetao@ega.or.th>
 */
public class SimpleEGAWSClient {

    public static void main(String[] args) throws IOException {
        Type jsonMapType = new TypeToken<Map<String, Object>>() {
        }.getType(); // create json map type for parser
        Gson gson = new GsonBuilder().create(); // create json parser
        HttpClient client = new DefaultHttpClient(); // create http client

        // TODO: config this value
        String consumerKey = ""; // consumer key for web service
        // TODO: config this value
        String consumerSecret = ""; // consumer secret for web service
        // TODO: config this value
        String agentId = ""; // agent citizen id

        String token = null;

        /*
         * request access token
         */
        String tokenRequestURL = String.format("https://ws.ega.or.th/ws/auth/validate?ConsumerSecret=%s&AgentID=%s", consumerSecret, agentId); // set request url
        HttpGet tokenRequest = new HttpGet(tokenRequestURL); // create http get method
        tokenRequest.setHeader("Content-Type", "application/x-www-form-urlencoded; charset=utf-8"); // set content type header
        tokenRequest.setHeader("Consumer-Key", consumerKey); // set consumer key header
        HttpResponse tokenResponse = client.execute(tokenRequest); // call to server
        if (tokenResponse.getStatusLine().getStatusCode() == 200) { // check response ok
            HttpEntity content = tokenResponse.getEntity(); // get response content
            if (content != null) {
                Map<String, Object> tokenJson = gson.fromJson(EntityUtils.toString(content, Charset.forName("UTF-8")), jsonMapType); // convert json string to map
                token = String.class.cast(tokenJson.get("Result")); // get result
            }
        }
        if (token == null) {
            System.out.println("could not request access token");
            return;
        }

        /*
         * request dopa personal profile
         */
        // TODO: config this value
        String citizenID = ""; // citizen id for request dopa personal profile

        String personalProfileRequestURL = String.format("https://ws.ega.or.th/ws/dopa/personal/profile/normal?CitizenID=%s", citizenID); // set request url
        HttpGet personalProfileRequest = new HttpGet(personalProfileRequestURL); // create http get method
        personalProfileRequest.setHeader("Content-Type", "application/x-www-form-urlencoded; charset=utf-8"); // set content type header
        personalProfileRequest.setHeader("Consumer-Key", consumerKey); // set consumer key header
        personalProfileRequest.setHeader("Token", token); // set access token
        HttpResponse personalProfileResponse = client.execute(personalProfileRequest); // call to server
        if (personalProfileResponse.getStatusLine().getStatusCode() == 200) { // check response ok
            HttpEntity content = personalProfileResponse.getEntity(); // get response content
            if (content != null) {
                Map<String, Object> personalProfileJson = gson.fromJson(EntityUtils.toString(content, Charset.forName("UTF-8")), jsonMapType); // convert json string to map
                System.out.println(String.class.cast(personalProfileJson.get("CitizenID"))); // show citizen id
                System.out.println(String.class.cast(personalProfileJson.get("NameTH_FirstName"))); // show first name
                System.out.println(String.class.cast(personalProfileJson.get("NameTH_SurName"))); // show last name
            }
        }
    }
}
