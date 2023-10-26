#include "arduino-iot-cloud-connection.h"

void ArduinoIoTCloudConnection::setup()
{
  ArduinoCloud.setBoardId(DEVICE_LOGIN_NAME);
  ArduinoCloud.setSecretDeviceKey(DEVICE_KEY);
  
  ArduinoCloud.addProperty(ir_signal_output1_, READWRITE, ON_CHANGE, &ArduinoIoTCloudConnection::OnIrSignalOutput1Change);
  ArduinoCloud.addProperty(ir_signal_output2_, READWRITE, ON_CHANGE, &ArduinoIoTCloudConnection::OnIrSignalOutput2Change);
  ArduinoCloud.addProperty(ir_signal_output3_, READWRITE, ON_CHANGE, &ArduinoIoTCloudConnection::OnIrSignalOutput3Change);
  ArduinoCloud.addProperty(ir_signal_output4_, READWRITE, ON_CHANGE, &ArduinoIoTCloudConnection::OnIrSignalOutput4Change);
  ArduinoCloud.addProperty(ir_signal_output5_, READWRITE, ON_CHANGE, &ArduinoIoTCloudConnection::OnIrSignalOutput5Change);

  ArduinoCloud.begin(arduino_iot_preferred_connection_);
  setDebugMessageLevel(2);
  ArduinoCloud.printDebugInfo();
}

void ArduinoIoTCloudConnection::loop()
{
  ArduinoCloud.update();
}

void ArduinoIoTCloudConnection::OnIrSignalOutput1Change()
{
  Serial.println("IrSignalOutput 1 changed");
}

void ArduinoIoTCloudConnection::OnIrSignalOutput2Change()
{
  Serial.println("IrSignalOutput 2 changed");
}

void ArduinoIoTCloudConnection::OnIrSignalOutput3Change()
{
  Serial.println("IrSignalOutput 3 changed");
}

void ArduinoIoTCloudConnection::OnIrSignalOutput4Change()
{
  Serial.println("IrSignalOutput 4 changed");
}

void ArduinoIoTCloudConnection::OnIrSignalOutput5Change()
{
  Serial.println("IrSignalOutput 5 changed");
}
