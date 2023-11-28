#ifndef INFRARED_RECEIVER_H_
#define INFRARED_RECEIVER_H_

#include <Arduino.h>
#include <IRac.h>
#include <IRrecv.h>
#include <IRremoteESP8266.h>
#include <IRtext.h>
#include <IRutils.h>
#include <assert.h>

class InfraredReceiver {
 public:
  InfraredReceiver(uint16_t recv_pin, uint16_t capture_buffer_size,
                   uint16_t min_unknown_size, bool save_buffer,
                   uint8_t tolerance);
  void setup();
  decode_results get_decoded_ir_signal();

 private:
  const uint16_t recv_pin_;
  const uint16_t capture_buffer_size_;
  const uint16_t min_unknown_size_;
  const uint8_t tolerance_;
  uint8_t timeout_;
  bool save_buffer_;

  IRrecv irrecv_;
  decode_results results_;
};

#endif  // INFRARED_RECEIVER_H_