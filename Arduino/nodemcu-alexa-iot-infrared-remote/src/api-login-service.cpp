#include "api-login-service.h"

ApiLoginService::ApiLoginService(HTTPClientSecure& httpClient, String api_key,
                                 String api_secret)
    : httpClient(httpClient), api_key_(api_key), api_secret_(api_secret) {}

String ApiLoginService::login(String api_url) {
  api_url += "/connect/token";
  String content_type = "application/x-www-form-urlencoded";
  String body = "grant_type=client_credentials&client_id=" + api_key_ +
                "&client_secret=" + api_secret_ +
                "&scope=dataAIIR&audience=rs_dataAIIR";

  String response = httpClient.post(api_url.c_str(), content_type, body);

  if (response != "") {
    DynamicJsonDocument doc(4000);
    deserializeJson(doc, response);
    String access_token = doc["access_token"];

    return access_token;
  } else {
    return "";
  }
}
