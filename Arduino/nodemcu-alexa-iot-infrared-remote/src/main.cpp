#include <Arduino.h>

#include "arduino-iot-cloud-connection.h"
#include "config.h"

ArduinoIoTCloudConnection iot_cloud_connection;

void setup()
{
  Serial.begin(BAUD_RATE);
  iot_cloud_connection.setup();
}

void loop()
{
  iot_cloud_connection.loop();
}