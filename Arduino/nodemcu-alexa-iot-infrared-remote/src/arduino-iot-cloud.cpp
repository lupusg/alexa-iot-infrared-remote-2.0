#include "arduino-iot-cloud-connection.h"

CloudSwitch ArduinoIoTCloudConnection::infrared_output1_;
CloudSwitch ArduinoIoTCloudConnection::infrared_output2_;
CloudSwitch ArduinoIoTCloudConnection::infrared_output3_;
CloudSwitch ArduinoIoTCloudConnection::infrared_output4_;
CloudSwitch ArduinoIoTCloudConnection::infrared_receiver_;

InfraredTransmitter *ArduinoIoTCloudConnection::infrared_transmitter_ = nullptr;
HTTPClientSecure *ArduinoIoTCloudConnection::http_client_secure_ = nullptr;

ArduinoIoTCloudConnection::ArduinoIoTCloudConnection(
    InfraredTransmitter &infrared_transmitter,
    HTTPClientSecure &http_client_secure, const char *wifi_ssid,
    const char *wifi_password, const char *device_login_name,
    const char *device_key)
    : device_login_name_(device_login_name),
      device_key_(device_key),
      arduino_iot_preferred_connection_(wifi_ssid, wifi_password) {
  infrared_transmitter_ = &infrared_transmitter;
  http_client_secure_ = &http_client_secure;
}

void ArduinoIoTCloudConnection::setup() {
  ArduinoCloud.setBoardId(device_login_name_);
  ArduinoCloud.setSecretDeviceKey(device_key_);

  ArduinoCloud.addProperty(infrared_output1_, READWRITE, ON_CHANGE,
                           &ArduinoIoTCloudConnection::OnIrSignalOutput1Change);
  ArduinoCloud.addProperty(infrared_output2_, READWRITE, ON_CHANGE,
                           &ArduinoIoTCloudConnection::OnIrSignalOutput2Change);
  ArduinoCloud.addProperty(infrared_output3_, READWRITE, ON_CHANGE,
                           &ArduinoIoTCloudConnection::OnIrSignalOutput3Change);
  ArduinoCloud.addProperty(infrared_output4_, READWRITE, ON_CHANGE,
                           &ArduinoIoTCloudConnection::OnIrSignalOutput4Change);
  ArduinoCloud.addProperty(infrared_receiver_, READWRITE, ON_CHANGE,
                           &ArduinoIoTCloudConnection::OnIrReceiverChange);

  ArduinoCloud.begin(arduino_iot_preferred_connection_);
  setDebugMessageLevel(2);
  ArduinoCloud.printDebugInfo();
}

void ArduinoIoTCloudConnection::loop() { ArduinoCloud.update(); }

bool ArduinoIoTCloudConnection::get_ir_receiver_state() { return infrared_receiver_; }

void ArduinoIoTCloudConnection::OnIrSignalOutput1Change() {
  uint16_t length;
  static uint16_t *buffer = nullptr;

  http_client_secure_->read_octet_stream(
      API_RESOURCE_SERVER_URL "/api/board/infrared-signal/1", buffer, length);
  infrared_transmitter_->sendRaw(buffer, length);

  delete[] buffer;
}

void ArduinoIoTCloudConnection::OnIrSignalOutput2Change() {
  uint16_t length;
  static uint16_t *buffer = nullptr;

  http_client_secure_->read_octet_stream(
      API_RESOURCE_SERVER_URL "/api/board/infrared-signal/2", buffer, length);
  infrared_transmitter_->sendRaw(buffer, length);

  delete[] buffer;
}

void ArduinoIoTCloudConnection::OnIrSignalOutput3Change() {
  uint16_t length;
  static uint16_t *buffer = nullptr;

  http_client_secure_->read_octet_stream(
      API_RESOURCE_SERVER_URL "/api/board/infrared-signal/3", buffer, length);
  infrared_transmitter_->sendRaw(buffer, length);

  delete[] buffer;
}

void ArduinoIoTCloudConnection::OnIrSignalOutput4Change() {
  uint16_t length;
  static uint16_t *buffer = nullptr;

  http_client_secure_->read_octet_stream(
      API_RESOURCE_SERVER_URL "/api/board/infrared-signal/4", buffer, length);
  infrared_transmitter_->sendRaw(buffer, length);

  delete[] buffer;
}

void ArduinoIoTCloudConnection::OnIrReceiverChange() {
  if (infrared_receiver_) {
    Serial.println("Infrared receiving is turned on!");
  } else {
    Serial.println("Infrared receiving is turned off!");
  }
}
