#ifndef ARDUINO_IOT_CLOUD_CONNECTION_H_
#define ARDUINO_IOT_CLOUD_CONNECTION_H_

#include <ArduinoIoTCloud.h>
#include <Arduino_ConnectionHandler.h>
#include <Arduino_ESP32_OTA.h>

#include "config.h"
#include "http-client-secure.h"
#include "infrared-transmitter.h"

class ArduinoIoTCloudConnection {
 public:
  ArduinoIoTCloudConnection(InfraredTransmitter &infrared_transmitter,
                            HTTPClientSecure &http_client_secure,
                            const char *wifi_ssid, const char *wifi_password,
                            const char *device_login_name,
                            const char *device_key);
  void setup();
  void loop();
  bool get_ir_receiver_state();

 private:
  const char *device_login_name_;
  const char *device_key_;
  WiFiConnectionHandler arduino_iot_preferred_connection_;
  static InfraredTransmitter *infrared_transmitter_;
  static HTTPClientSecure *http_client_secure_;

  static CloudSwitch infrared_output1_;
  static CloudSwitch infrared_output2_;
  static CloudSwitch infrared_output3_;
  static CloudSwitch infrared_output4_;
  static CloudSwitch infrared_receiver_;

  static void OnIrSignalOutput1Change();
  static void OnIrSignalOutput2Change();
  static void OnIrSignalOutput3Change();
  static void OnIrSignalOutput4Change();
  static void OnIrReceiverChange();
};

#endif  // ARDUINO_IOT_CLOUD_H_