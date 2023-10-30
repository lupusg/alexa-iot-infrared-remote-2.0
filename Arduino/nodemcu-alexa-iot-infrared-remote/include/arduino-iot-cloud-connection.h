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

 private:
  const char *device_login_name_;
  const char *device_key_;

  CloudSwitch ir_signal_output1_;
  CloudSwitch ir_signal_output2_;
  CloudSwitch ir_signal_output3_;
  CloudSwitch ir_signal_output4_;
  CloudSwitch ir_signal_output5_;
  WiFiConnectionHandler arduino_iot_preferred_connection_;

  static void OnIrSignalOutput1Change();
  static void OnIrSignalOutput2Change();
  static void OnIrSignalOutput3Change();
  static void OnIrSignalOutput4Change();
  static void OnIrSignalOutput5Change();
};

#endif  // ARDUINO_IOT_CLOUD_H_