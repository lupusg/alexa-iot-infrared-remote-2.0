#include "infrared-receiver-service.h"

InfraredReceiverService::InfraredReceiverService(
    InfraredReceiver& infrared_receiver, HTTPClientSecure& http_client)
    : infrared_receiver_(infrared_receiver), http_client_(http_client) {}

void InfraredReceiverService::post_ir_signal() {
  decode_results results = infrared_receiver_.get_decoded_ir_signal();
  if (results.decode_type != UNUSED) {
    String content_type = "text/plain";
    String payload = resultToSourceCode(&results);

    http_client_.post(API_RESOURCE_SERVER_URL "/api/board/infrared-signal",
                      content_type, payload);
  }
}