#include "http-client-secure.h"

HTTPClientSecure::HTTPClientSecure(const char* ssid, const char* password,
                                   const char* certs)
    : ssid_(ssid), password_(password), certs_(certs) {}

void HTTPClientSecure::setup() {
  WiFi.mode(WIFI_STA);
  WiFi.begin(ssid_, password_);

  Serial.print("Connecting to WiFi ..");

  while (WiFi.status() != WL_CONNECTED) {
    Serial.print('.');
    delay(1000);
  }

  Serial.println(WiFi.localIP());
}

void HTTPClientSecure::loop() {}

String HTTPClientSecure::get(const char* url) {
  WiFiClientSecure* client = new WiFiClientSecure;
  if (client) {
    // set secure client with certificate
    client->setCACert(certs_);

    HTTPClient https;

    Serial.print("[HTTPS] begin...\n");
    if (https.begin(*client, url)) {
      Serial.print("[HTTPS] GET...\n");

      int httpCode = https.GET();
      if (httpCode > 0) {
        Serial.printf("[HTTPS] GET... code: %d\n", httpCode);

        if (httpCode == HTTP_CODE_OK ||
            httpCode == HTTP_CODE_MOVED_PERMANENTLY) {
          String payload = https.getString();
          Serial.println(payload);
          delete client;
          return payload;
        }
      } else {
        Serial.printf("[HTTPS] GET... failed, error: %s\n",
                      https.errorToString(httpCode).c_str());
      }
      https.end();
    }
    delete client;
  } else {
    Serial.printf("[HTTPS] Unable to connect\n");
  }
  return "";
}

String HTTPClientSecure::post(const char* url, String payload) {
  WiFiClientSecure* client = new WiFiClientSecure;
  if (client) {
    // set secure client with certificate
    client->setCACert(certs_);

    HTTPClient https;

    Serial.print("[HTTPS] begin...\n");
    if (https.begin(*client, url)) {
      Serial.print("[HTTPS] POST...\n");

      https.addHeader("Content-Type", "application/json");
      int httpCode = https.POST(payload);
      if (httpCode > 0) {
        Serial.printf("[HTTPS] POST... code: %d\n", httpCode);

        if (httpCode == HTTP_CODE_OK ||
            httpCode == HTTP_CODE_MOVED_PERMANENTLY) {
          String payload = https.getString();
          Serial.println(payload);
          delete client;
          return payload;
        }
      } else {
        Serial.printf("[HTTPS] POST... failed, error: %s\n",
                      https.errorToString(httpCode).c_str());
      }
      https.end();
    }
    delete client;
  } else {
    Serial.printf("[HTTPS] Unable to connect\n");
  }
  return "";
}
