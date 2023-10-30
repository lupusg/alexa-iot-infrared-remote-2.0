#include <Arduino.h>

#include "arduino-iot-cloud-connection.h"
#include "config.h"
#include "http-client-secure.h"
#include "infrared-receiver.h"

InfraredReceiver infrared_receiver(RECV_PIN, CAPTURE_BUFFER_SIZE,
                                   MIN_UNKNOWN_SIZE, SAVE_BUFFER, kTolerance);
ArduinoIoTCloudConnection iot_cloud_connection(WIFI_SSID, WIFI_PASSWORD,
                                               DEVICE_LOGIN_NAME, DEVICE_KEY);

HTTPClientSecure http_client_secure(WIFI_SSID, WIFI_PASSWORD, API_CERTS);

void setup() {
  Serial.begin(BAUD_RATE);
  iot_cloud_connection.setup();
  infrared_receiver.setup();
  http_client_secure.setup();
}

void loop() {
  iot_cloud_connection.loop();
  infrared_receiver.loop();
  http_client_secure.loop();
}