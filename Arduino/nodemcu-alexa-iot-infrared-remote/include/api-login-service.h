#ifndef API_LOGIN_SERVICE_H_
#define API_LOGIN_SERVICE_H_

#include <ArduinoJson.h>

#include "http-client-secure.h"

class ApiLoginService {
 private:
  HTTPClientSecure& httpClient;
  String api_key_;
  String api_secret_;

 public:
  ApiLoginService(HTTPClientSecure& httpClient, String api_key,
                  String api_secret);

  String login(String api_url);
};

#endif  // API_LOGIN_SERVICE_