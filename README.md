Alexa-IoT-Infrared-Remote 2.0 is my personal project that connects an IR remote control to Amazon Alexa (it may also work with Google Home). It's based on Arduino and allows you to clone/send signals to multiple devices. You can manage everything from my website by connecting the board to my api. Simply bind your IR signals to Alexa-compatible switches and you can control your devices by voice. For example, you can say "Alexa, turn on switch1" and your device will receive the infrared signal associated with switch1.

# Requirements
To set up and use the Alexa-IoT-Infrared-Remote 2.0 project, you'll need the following components:
- NodeMCU-32S microcontroller
- Infrared receiver/transmitter modules
- Breadboard, jumper wires

# Setup
1. Assemble your board.
2. Setup an account on [Arduino Cloud](https://app.arduino.cc/).
3. Configure your NodeMCU-32s board with Arduino Cloud. (See [Getting Started with Arduino Cloud](https://docs.arduino.cc/arduino-cloud/guides/overview/))
4. Add the following Cloud Variables [Screenshoot](https://prnt.sc/tNIS_IdNYF53)
5. Enable the "Arduino" skill on Alexa app and login into your Arduino Cloud account.
6. Open the Alexa app and select discover new devices or simply say "Alexa, discover new devices".
7. Create an account on [https://iot-infrared-remote.com/](https://iot-infrared-remote.com/)
8. Navigate to "Boards Settings" and add new credentials for your arduino board.
9. Replace API_KEY and API_SECRET with your credentials.
10. Replace DEVICE_LOGIN_NAME and DEVICE_KEY with your credentials from Arduino Cloud.
11. Replace WIFI_SSID and WIFI_PASSWORD with your wifi network name and password.
12. Upload my Arduino code on your board.
13. You can rename switches in Alexa App but DO NOT rename them on Arduino Cloud.

# Usage
To use the iot infrared remote, first clone an infrared signal from your existing remote. Then, visit my website and link the signal to an Alexa switch. You can rename Alexa switches so that instead of saying "Alexa, turn off Infrared Signal Output 1", you say "Alexa, turn off AC" and so on.

1. Access the [https://iot-infrared-remote.com/](https://iot-infrared-remote.com/) website. This website serves as the interface for managing and configuring the infrared signals.
2. Turn on the infrared receiver switch (from alexa app or by voice).
3. Clone the infrared signal. (e.g. press the off button from your old remote)
4. Turn off the IR Receiver and Navigate to "Your Infrared Signals".
5. Click on the green edit icon and select "Infrared Signal Output" and "State"(e.g for Infrared Signal Output 1 and State Off you will say "Alexa, turn off Infrared Signal Output 1", for Infrared Output 3 and State On you will say "Alexa turn on Infrared Output 3").

