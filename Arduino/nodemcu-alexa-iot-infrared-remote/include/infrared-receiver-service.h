#ifndef INFRARED_RECEIVER_SERVICE_H_
#define INFRARED_RECEIVER_SERVICE_H_

#include "config.h"
#include "http-client-secure.h"
#include "infrared-receiver.h"

class InfraredReceiverService {
 public:
  InfraredReceiverService(InfraredReceiver& infrared_receiver,
                          HTTPClientSecure& http_client);

  void post_ir_signal();

 private:
  InfraredReceiver& infrared_receiver_;
  HTTPClientSecure& http_client_;
};

#endif  // INFRARED_RECEIVER_SERVICE_H_