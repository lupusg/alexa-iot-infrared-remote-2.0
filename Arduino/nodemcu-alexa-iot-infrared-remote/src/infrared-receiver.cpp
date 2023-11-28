#include "infrared-receiver.h"

InfraredReceiver::InfraredReceiver(uint16_t recv_pin,
                                   uint16_t capture_buffer_size,
                                   uint16_t min_unknwon_size, bool save_buffer,
                                   uint8_t tolerance)
    : recv_pin_(recv_pin),
      capture_buffer_size_(capture_buffer_size),
      tolerance_(tolerance),
      min_unknown_size_(min_unknwon_size),
      save_buffer_(save_buffer),
      irrecv_(recv_pin, capture_buffer_size, tolerance, save_buffer) {
#if DECODE_AC
  timeout_ = 50;
#else   // DECODE_AC
  timeout_ = 15;
#endif  // DECODE_AC
}

void InfraredReceiver::setup() {
  assert(irutils::lowLevelSanityCheck() == 0);

  Serial.printf("\n" D_STR_IRRECVDUMP_STARTUP "\n", recv_pin_);
#if DECODE_HASH
  irrecv_.setUnknownThreshold(min_unknown_size_);
#endif  // DECODE_HASH
  irrecv_.setTolerance(tolerance_);
  irrecv_.enableIRIn();
}

decode_results InfraredReceiver::get_decoded_ir_signal() {
  if (irrecv_.decode(&results_)) {
    yield();
    irrecv_.resume();
    Serial.println(resultToSourceCode(&results_));
    
    return results_;
  } else {
    return decode_results{};
  }
}
