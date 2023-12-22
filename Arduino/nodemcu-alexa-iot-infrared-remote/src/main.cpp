#include <Arduino.h>

#include "api-login-service.h"
#include "arduino-iot-cloud-connection.h"
#include "config.h"
#include "http-client-secure.h"
#include "infrared-receiver-service.h"
#include "infrared-receiver.h"
#include "infrared-transmitter.h"

InfraredReceiver infrared_receiver(IR_RECV_PIN, CAPTURE_BUFFER_SIZE,
                                   MIN_UNKNOWN_SIZE, SAVE_BUFFER, kTolerance);

InfraredTransmitter infrared_transmitter(IR_SEND_PIN, IR_SEND_FREQUENCY);

HTTPClientSecure http_client_secure(WIFI_SSID, WIFI_PASSWORD, API_DEV_CERTS);

ArduinoIoTCloudConnection iot_cloud_connection(infrared_transmitter,
                                               http_client_secure, WIFI_SSID,
                                               WIFI_PASSWORD, DEVICE_LOGIN_NAME,
                                               DEVICE_KEY);

ApiLoginService api_login_service(http_client_secure, API_KEY, API_SECRET);

InfraredReceiverService infrared_receiver_service(infrared_receiver,
                                                  http_client_secure);

void setup() {
  Serial.begin(BAUD_RATE);
  iot_cloud_connection.setup();
  infrared_receiver.setup();
  http_client_secure.setup();
  infrared_transmitter.setup();

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