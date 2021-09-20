<?php
/*
 * Electronic Government Agency (Public Organization).
 */
// Example request personal profile

// TODO : Don't forget install php CURL extenstion

// create curl session
$ch = curl_init();

// TODO: set this value
$headers = array();
$headers[] = 'Content-Type:application/json'; // set content type
$headers[] = 'Consumer-Key:%s'; // set consumer key replace %s
$headers[] = 'Token:%s'; // set access token replace %s

// set request url
curl_setopt($ch, CURLOPT_URL, "https://ws.ega.or.th/ws/dopa/personal/profile/normal?CitizenID=%s"); // set CitizenID replace %s
// set header
curl_setopt($ch, CURLOPT_HTTPHEADER, $headers);
// return header when response
curl_setopt($ch, CURLOPT_HEADER, true);
// return the response
curl_setopt($ch, CURLOPT_RETURNTRANSFER,true);

// send the request and store the response to $data
$data = curl_exec($ch);
// get httpcode 
$httpcode = curl_getinfo($ch, CURLINFO_HTTP_CODE);

if($httpcode == 200){ // if response ok
	// separate header and body
	$header_size = curl_getinfo($ch, CURLINFO_HEADER_SIZE);
	$header = substr($data, 0, $header_size);
	$body = substr($data, $header_size);
	
	// convert json to array or object
	$result = json_decode($body);
	
	// access to data
	$CitizenID = $result->CitizenID;
	$AddressID = $result->AddressID;
	$Address_No = $result->Address_No;
}
// end session
curl_close($ch);
?>