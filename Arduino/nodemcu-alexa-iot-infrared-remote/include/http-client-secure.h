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
  void set_bearer_token(String bearer_token);

  String get(const char* url, String content_type);
  String post(const char* url, String& content_type, String& payload);
  void read_octet_stream(const char* url, uint16_t*& buffer, uint16_t& length);

 private:
  const char* ssid_;
  const char* password_;
  const char* certs_;
  String bearer_token_;
  WiFiClientSecure* client_;
};

#endif  // HTTP_CLIENT_SECURE_H