#include <Arduino.h>

#include "api-login-service.h"
#include "arduino-iot-cloud-connection.h"
#include "config.h"
#include "http-client-secure.h"
#include "infrared-receiver.h"

InfraredReceiver infrared_receiver(RECV_PIN, CAPTURE_BUFFER_SIZE,
                                   MIN_UNKNOWN_SIZE, SAVE_BUFFER, kTolerance);
ArduinoIoTCloudConnection iot_cloud_connection(WIFI_SSID, WIFI_PASSWORD,
                                               DEVICE_LOGIN_NAME, DEVICE_KEY);

HTTPClientSecure http_client_secure(WIFI_SSID, WIFI_PASSWORD, API_DEV_CERTS);

ApiLoginService api_login_service(http_client_secure, API_KEY, API_SECRET);

void setup() {
  Serial.begin(BAUD_RATE);
  iot_cloud_connection.setup();
  infrared_receiver.setup();
  http_client_secure.setup();

  // TODO: Login to API
  // if (WiFi.status() == WL_CONNECTED) {
  //   String api_token = api_login_service.login(API_AUTHZ_SERVER_URL);
  //   http_client_secure.set_bearer_token(api_token);
  //   http_client_secure.get(API_RESOURCE_SERVER_URL "/api/WeatherForecast");
  // }
}

void loop() {
  iot_cloud_connection.loop();
  if (iot_cloud_connection.get_ir_receiver_state()) {
    infrared_receiver.loop();
  }
  http_client_secure.loop();
}