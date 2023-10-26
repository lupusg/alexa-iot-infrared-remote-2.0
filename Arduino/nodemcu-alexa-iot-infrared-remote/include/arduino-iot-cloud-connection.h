#ifndef ARDUINO_IOT_CLOUD_CONNECTION_H_
#define ARDUINO_IOT_CLOUD_CONNECTION_H_

#include <ArduinoIoTCloud.h>
#include <Arduino_ConnectionHandler.h>
#include <Arduino_ESP32_OTA.h>

#include "config.h"
    
class ArduinoIoTCloudConnection
{
    public:
    void setup();
    void loop();

    private:
    CloudSwitch ir_signal_output1_;
    CloudSwitch ir_signal_output2_;
    CloudSwitch ir_signal_output3_;
    CloudSwitch ir_signal_output4_;
    CloudSwitch ir_signal_output5_;
    WiFiConnectionHandler arduino_iot_preferred_connection_{WIFI_SSID, WIFI_PASSWORD};

    static void OnIrSignalOutput1Change();
    static void OnIrSignalOutput2Change();
    static void OnIrSignalOutput3Change();
    static void OnIrSignalOutput4Change();
    static void OnIrSignalOutput5Change();
};

#endif  // ARDUINO_IOT_CLOUD_H_