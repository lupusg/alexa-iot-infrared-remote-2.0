#ifndef HTTP_CLIENT_SECURE_H
#define HTTP_CLIENT_SECURE_H

#include <HTTPClient.h>
#include <WiFi.h>
#include <WiFiClientSecure.h>

class HTTPClientSecure {
 public:
  HTTPClientSecure(const char* ssid, const char* password, const char* certs);
  void setup();
  void loop();

  String get(const char* url);
  String post(const char* url, String payload);

 private:
  const char* ssid_;
  const char* password_;
  const char* certs_;
};

#endif  // HTTP_CLIENT_SECURE_H