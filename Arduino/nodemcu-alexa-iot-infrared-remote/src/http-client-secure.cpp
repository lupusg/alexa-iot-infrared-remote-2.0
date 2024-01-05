#include "http-client-secure.h"

HTTPClientSecure::HTTPClientSecure(const char* ssid, const char* password,
                                   const char* certs)
    : ssid_(ssid), password_(password), certs_(certs) {
  bearer_token_ = "";
  client_ = new WiFiClientSecure;
  client_->setCACert(certs_);
  client_->setInsecure();
}

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

void HTTPClientSecure::set_bearer_token(String bearer_token) {
  bearer_token_ = bearer_token;
}

String HTTPClientSecure::get(const char* url, String content_type) {
  HTTPClient https;

  Serial.print("[HTTPS] begin...\n");
  if (https.begin(*client_, url)) {
    Serial.print("[HTTPS] GET...\n");

    if (!bearer_token_.isEmpty()) {
      https.addHeader("Authorization", "Bearer " + bearer_token_);
      Serial.println(bearer_token_);
    }
    https.addHeader("Content-Type", content_type);

    int httpCode = https.GET();
    if (httpCode > 0) {
      Serial.printf("[HTTPS] GET... code: %d\n", httpCode);

      if (httpCode == HTTP_CODE_OK || httpCode == HTTP_CODE_MOVED_PERMANENTLY) {
        String payload = https.getString();
        Serial.println(payload);
        return payload;
      }
    } else {
      Serial.printf("[HTTPS] GET... failed, error: %s\n",
                    https.errorToString(httpCode).c_str());
    }
    https.end();
  }
  return "";
}

String HTTPClientSecure::post(const char* url, String& content_type,
                              String& payload) {
  HTTPClient https;

  Serial.print("[HTTPS] begin...\n");
  if (https.begin(*client_, url)) {
    Serial.print("[HTTPS] POST...\n");

    if (!bearer_token_.isEmpty()) {
      https.addHeader("Authorization", "Bearer " + bearer_token_);
    }

    https.addHeader("Content-Type", content_type);
    int httpCode = https.POST(payload);
    if (httpCode > 0) {
      Serial.printf("[HTTPS] POST... code: %d\n", httpCode);

      if (httpCode == HTTP_CODE_OK || httpCode == HTTP_CODE_MOVED_PERMANENTLY) {
        String payload = https.getString();
        Serial.println(payload);
        return payload;
      }
    } else {
      Serial.printf("[HTTPS] POST... failed, error: %s\n",
                    https.errorToString(httpCode).c_str());
    }
    https.end();
  }
  return "";
}

void HTTPClientSecure::read_octet_stream(const char* url, uint16_t*& buffer,
                                         uint16_t& length) {
  HTTPClient https;

  Serial.print("[HTTPS] begin...\n");
  if (https.begin(*client_, url)) {
    Serial.print("[HTTPS Read Stream] GET...\n");

    // Add the authorization token
    if (!bearer_token_.isEmpty()) {
      https.addHeader("Authorization", "Bearer " + bearer_token_);
    }
    https.addHeader("Content-Type", "application/octet-stream");

    int httpCode = https.GET();
    if (httpCode > 0) {
      Serial.printf("[HTTPS Read Stream] GET... code: %d\n", httpCode);

      if (httpCode == HTTP_CODE_OK || httpCode == HTTP_CODE_MOVED_PERMANENTLY) {
        Stream& stream = https.getStream();
        bool isFirstIteration = true;
        uint16_t index = 0;

        while (stream.available() > 1) {
          // Read two bytes
          byte lowByte = stream.read();
          byte highByte = stream.read();

          // Combine the two bytes into a ushort
          uint16_t value = (highByte << 8) | lowByte;
          // Serial.print(value);
          if (isFirstIteration) {
            buffer = new uint16_t[value];
            length = value;
            isFirstIteration = false;
          } else {
            if (index < length) {
              buffer[index] = value;
              index++;
            } else {
              Serial.println(
                  "[HTTPS Read Stream] Error: trying to write past the end of "
                  "the buffer");
              break;
            }
          }
        }
      }
    } else {
      Serial.printf("[HTTPS Read Stream] GET... failed, error: %s\n",
                    https.errorToString(httpCode).c_str());
    }
    https.end();
  } else {
    Serial.printf("[HTTPS Read Stream] Unable to start the client.\n");
  }
}