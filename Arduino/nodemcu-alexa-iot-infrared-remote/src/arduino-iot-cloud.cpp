#include "arduino-iot-cloud-connection.h"

CloudSwitch ArduinoIoTCloudConnection::ir_signal_output1_;
CloudSwitch ArduinoIoTCloudConnection::ir_signal_output2_;
CloudSwitch ArduinoIoTCloudConnection::ir_signal_output3_;
CloudSwitch ArduinoIoTCloudConnection::ir_signal_output4_;
CloudSwitch ArduinoIoTCloudConnection::ir_receiver_;

ArduinoIoTCloudConnection::ArduinoIoTCloudConnection(
    const char *wifi_ssid, const char *wifi_password,
    const char *device_login_name, const char *device_key)
    : device_login_name_(device_login_name),
      device_key_(device_key),
      arduino_iot_preferred_connection_(wifi_ssid, wifi_password) {}

void ArduinoIoTCloudConnection::setup() {
  ArduinoCloud.setBoardId(device_login_name_);
  ArduinoCloud.setSecretDeviceKey(device_key_);

  ArduinoCloud.addProperty(ir_signal_output1_, READWRITE, ON_CHANGE,
                           &ArduinoIoTCloudConnection::OnIrSignalOutput1Change);
  ArduinoCloud.addProperty(ir_signal_output2_, READWRITE, ON_CHANGE,
                           &ArduinoIoTCloudConnection::OnIrSignalOutput2Change);
  ArduinoCloud.addProperty(ir_signal_output3_, READWRITE, ON_CHANGE,
                           &ArduinoIoTCloudConnection::OnIrSignalOutput3Change);
  ArduinoCloud.addProperty(ir_signal_output4_, READWRITE, ON_CHANGE,
                           &ArduinoIoTCloudConnection::OnIrSignalOutput4Change);
  ArduinoCloud.addProperty(ir_receiver_, READWRITE, ON_CHANGE,
                           &ArduinoIoTCloudConnection::OnIrReceiverChange);

  ArduinoCloud.begin(arduino_iot_preferred_connection_);
  setDebugMessageLevel(2);
  ArduinoCloud.printDebugInfo();
}

void ArduinoIoTCloudConnection::loop() { ArduinoCloud.update(); }

bool ArduinoIoTCloudConnection::get_ir_receiver_state() { return ir_receiver_; }

void ArduinoIoTCloudConnection::OnIrSignalOutput1Change() {
  Serial.println("IrSignalOutput 1 changed");
}

void ArduinoIoTCloudConnection::OnIrSignalOutput2Change() {
  Serial.println("IrSignalOutput 2 changed");
}

void ArduinoIoTCloudConnection::OnIrSignalOutput3Change() {
  Serial.println("IrSignalOutput 3 changed");
}

void ArduinoIoTCloudConnection::OnIrSignalOutput4Change() {
  Serial.println("IrSignalOutput 4 changed");
}

void ArduinoIoTCloudConnection::OnIrReceiverChange() {
  if (ir_receiver_) {
    Serial.println("Infrared receiving is turned on!");
  } else {
    Serial.println("Infrared receiving is turned off!");
  }
}
