#include "infrared-transmitter.h"

InfraredTransmitter::InfraredTransmitter(uint16_t send_pin, uint16_t frequency)
    : ir_send_(send_pin), frequency_(frequency) {}

void InfraredTransmitter::setup() { ir_send_.begin(); }

void InfraredTransmitter::sendRaw(const uint16_t* buffer, uint16_t length) {
  if (buffer != nullptr && length > 0) {
    ir_send_.sendRaw(buffer, length, frequency_);
  } else {
    if (buffer == nullptr) {
      Serial.println("[InfraredTransmitter::sendRaw] Buffer is null.");
    } else if (length == 0) {
      Serial.println("[InfraredTransmitter::sendRaw] Buffer length is zero.");
    }
  }
}