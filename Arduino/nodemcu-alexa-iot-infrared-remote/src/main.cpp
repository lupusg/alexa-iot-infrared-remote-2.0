#include <Arduino.h>

#include "api-login-service.h"
#include "arduino-iot-cloud-connection.h"
#include "config.h"
#include "http-client-secure.h"
#include "infrared-receiver-service.h"
#include "infrared-receiver.h"

InfraredReceiver infrared_receiver(RECV_PIN, CAPTURE_BUFFER_SIZE,
                                   MIN_UNKNOWN_SIZE, SAVE_BUFFER, kTolerance);
ArduinoIoTCloudConnection iot_cloud_connection(WIFI_SSID, WIFI_PASSWORD,
                                               DEVICE_LOGIN_NAME, DEVICE_KEY);

HTTPClientSecure http_client_secure(WIFI_SSID, WIFI_PASSWORD, API_DEV_CERTS);

ApiLoginService api_login_service(http_client_secure, API_KEY, API_SECRET);

InfraredReceiverService infrared_receiver_service(infrared_receiver,
                                                  http_client_secure);

void setup() {
  Serial.begin(BAUD_RATE);
  iot_cloud_connection.setup();
  infrared_receiver.setup();
  http_client_secure.setup();

  if (WiFi.status() == WL_CONNECTED) {
    String api_token = api_login_service.login(API_AUTHZ_SERVER_URL);
    http_client_secure.set_bearer_token(api_token);
  }
}

void loop() {
  iot_cloud_connection.loop();

  if (iot_cloud_connection.get_ir_receiver_state()) {
    infrared_receiver_service.post_ir_signal();
  }
  
  http_client_secure.loop();
}