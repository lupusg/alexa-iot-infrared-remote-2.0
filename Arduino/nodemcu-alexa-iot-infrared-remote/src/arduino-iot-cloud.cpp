#include "arduino-iot-cloud-connection.h"

CloudSwitch ArduinoIoTCloudConnection::infrared_output1_;
CloudSwitch ArduinoIoTCloudConnection::infrared_output2_;
CloudSwitch ArduinoIoTCloudConnection::infrared_output3_;
CloudSwitch ArduinoIoTCloudConnection::infrared_output4_;
CloudSwitch ArduinoIoTCloudConnection::infrared_receiver_;
const char *ArduinoIoTCloudConnection::base_url_ = API_RESOURCE_SERVER_URL "/api/board/infrared-signal";

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
                           &ArduinoIoTCloudConnection::OnInfraredOutput1Change);
  ArduinoCloud.addProperty(infrared_output2_, READWRITE, ON_CHANGE,
                           &ArduinoIoTCloudConnection::OnInfraredOutput2Change);
  ArduinoCloud.addProperty(infrared_output3_, READWRITE, ON_CHANGE,
                           &ArduinoIoTCloudConnection::OnInfraredOutput3Change);
  ArduinoCloud.addProperty(infrared_output4_, READWRITE, ON_CHANGE,
                           &ArduinoIoTCloudConnection::OnInfraredOutput4Change);
  ArduinoCloud.addProperty(
      infrared_receiver_, READWRITE, ON_CHANGE,
      &ArduinoIoTCloudConnection::OnInfraredReceiverChange);

  ArduinoCloud.begin(arduino_iot_preferred_connection_);
  setDebugMessageLevel(2);
  ArduinoCloud.printDebugInfo();
}

void ArduinoIoTCloudConnection::loop() { ArduinoCloud.update(); }

bool ArduinoIoTCloudConnection::get_ir_receiver_state() {
  return infrared_receiver_;
}

void ArduinoIoTCloudConnection::OnInfraredOutput1Change() {
  static uint16_t *buffer = nullptr;
  char current_url[90];
  uint16_t length;

  snprintf(current_url, sizeof(current_url), "%s/1/%s", base_url_,
           infrared_output1_ ? "true" : "false");

  http_client_secure_->read_octet_stream(current_url, buffer, length);

  infrared_transmitter_->sendRaw(buffer, length);

  delete[] buffer;
}

void ArduinoIoTCloudConnection::OnInfraredOutput2Change() {
  static uint16_t *buffer = nullptr;
  char current_url[90];
  uint16_t length;

  snprintf(current_url, sizeof(current_url), "%s/2/%s", base_url_,
           infrared_output1_ ? "true" : "false");

  http_client_secure_->read_octet_stream(current_url, buffer, length);

  infrared_transmitter_->sendRaw(buffer, length);

  delete[] buffer;
}

void ArduinoIoTCloudConnection::OnInfraredOutput3Change() {
  static uint16_t *buffer = nullptr;
  char current_url[90];
  uint16_t length;

  snprintf(current_url, sizeof(current_url), "%s/3/%s", base_url_,
           infrared_output1_ ? "true" : "false");

  http_client_secure_->read_octet_stream(current_url, buffer, length);

  infrared_transmitter_->sendRaw(buffer, length);

  delete[] buffer;
}

void ArduinoIoTCloudConnection::OnInfraredOutput4Change() {
  static uint16_t *buffer = nullptr;
  char current_url[90];
  uint16_t length;

  snprintf(current_url, sizeof(current_url), "%s/4/%s", base_url_,
           infrared_output1_ ? "true" : "false");

  http_client_secure_->read_octet_stream(current_url, buffer, length);

  infrared_transmitter_->sendRaw(buffer, length);

  delete[] buffer;
}

void ArduinoIoTCloudConnection::OnInfraredReceiverChange() {
  if (infrared_receiver_) {
    Serial.println("Infrared receiving is turned on!");
  } else {
    Serial.println("Infrared receiving is turned off!");
  }
}
