#ifndef INFRARED_TRANSMITTER_H_
#define INFRARED_TRANSMITTER_H_

#include <Arduino.h>
#include <IRsend.h>

class InfraredTransmitter {
 public:
  InfraredTransmitter(uint16_t send_pin, uint16_t frequency);

  void setup();
  void sendRaw(const uint16_t *buffer, uint16_t length);

 private:
  IRsend ir_send_;
  uint16_t frequency_;  // hz
};

#endif  // INFRARED_TRANSMITTER_H_