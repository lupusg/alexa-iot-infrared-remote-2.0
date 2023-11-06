#ifndef ARDUINO_IOT_CLOUD_CONNECTION_H_
#define ARDUINO_IOT_CLOUD_CONNECTION_H_

#include <ArduinoIoTCloud.h>
#include <Arduino_ConnectionHandler.h>
#include <Arduino_ESP32_OTA.h>

#include "config.h"

class ArduinoIoTCloudConnection {
 public:
  ArduinoIoTCloudConnection(const char *wifi_ssid, const char *wifi_password,
                            const char *device_login_name,
                            const char *device_key);
  void setup();
  void loop();
  bool get_ir_receiver_state();

 private:
  const char *device_login_name_;
  const char *device_key_;
  WiFiConnectionHandler arduino_iot_preferred_connection_;

  static CloudSwitch ir_signal_output1_;
  static CloudSwitch ir_signal_output2_;
  static CloudSwitch ir_signal_output3_;
  static CloudSwitch ir_signal_output4_;
  static CloudSwitch ir_receiver_;

  static void OnIrSignalOutput1Change();
  static void OnIrSignalOutput2Change();
  static void OnIrSignalOutput3Change();
  static void OnIrSignalOutput4Change();
  static void OnIrReceiverChange();
};

#endif  // ARDUINO_IOT_CLOUD_H_