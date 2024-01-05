#ifndef CONFIG_H
#define CONFIG_H

// API settings
#define API_PROD_CERTS                                                 \
  "-----BEGIN CERTIFICATE-----\n"                                      \
  "MIIF8zCCBNugAwIBAgIQCq+mxcpjxFFB6jvh98dTFzANBgkqhkiG9w0BAQwFADBh\n" \
  "MQswCQYDVQQGEwJVUzEVMBMGA1UEChMMRGlnaUNlcnQgSW5jMRkwFwYDVQQLExB3\n" \
  "d3cuZGlnaWNlcnQuY29tMSAwHgYDVQQDExdEaWdpQ2VydCBHbG9iYWwgUm9vdCBH\n" \
  "MjAeFw0yMDA3MjkxMjMwMDBaFw0yNDA2MjcyMzU5NTlaMFkxCzAJBgNVBAYTAlVT\n" \
  "MR4wHAYDVQQKExVNaWNyb3NvZnQgQ29ycG9yYXRpb24xKjAoBgNVBAMTIU1pY3Jv\n" \
  "c29mdCBBenVyZSBUTFMgSXNzdWluZyBDQSAwMTCCAiIwDQYJKoZIhvcNAQEBBQAD\n" \
  "ggIPADCCAgoCggIBAMedcDrkXufP7pxVm1FHLDNA9IjwHaMoaY8arqqZ4Gff4xyr\n" \
  "RygnavXL7g12MPAx8Q6Dd9hfBzrfWxkF0Br2wIvlvkzW01naNVSkHp+OS3hL3W6n\n" \
  "l/jYvZnVeJXjtsKYcXIf/6WtspcF5awlQ9LZJcjwaH7KoZuK+THpXCMtzD8XNVdm\n" \
  "GW/JI0C/7U/E7evXn9XDio8SYkGSM63aLO5BtLCv092+1d4GGBSQYolRq+7Pd1kR\n" \
  "EkWBPm0ywZ2Vb8GIS5DLrjelEkBnKCyy3B0yQud9dpVsiUeE7F5sY8Me96WVxQcb\n" \
  "OyYdEY/j/9UpDlOG+vA+YgOvBhkKEjiqygVpP8EZoMMijephzg43b5Qi9r5UrvYo\n" \
  "o19oR/8pf4HJNDPF0/FJwFVMW8PmCBLGstin3NE1+NeWTkGt0TzpHjgKyfaDP2tO\n" \
  "4bCk1G7pP2kDFT7SYfc8xbgCkFQ2UCEXsaH/f5YmpLn4YPiNFCeeIida7xnfTvc4\n" \
  "7IxyVccHHq1FzGygOqemrxEETKh8hvDR6eBdrBwmCHVgZrnAqnn93JtGyPLi6+cj\n" \
  "WGVGtMZHwzVvX1HvSFG771sskcEjJxiQNQDQRWHEh3NxvNb7kFlAXnVdRkkvhjpR\n" \
  "GchFhTAzqmwltdWhWDEyCMKC2x/mSZvZtlZGY+g37Y72qHzidwtyW7rBetZJAgMB\n" \
  "AAGjggGtMIIBqTAdBgNVHQ4EFgQUDyBd16FXlduSzyvQx8J3BM5ygHYwHwYDVR0j\n" \
  "BBgwFoAUTiJUIBiV5uNu5g/6+rkS7QYXjzkwDgYDVR0PAQH/BAQDAgGGMB0GA1Ud\n" \
  "JQQWMBQGCCsGAQUFBwMBBggrBgEFBQcDAjASBgNVHRMBAf8ECDAGAQH/AgEAMHYG\n" \
  "CCsGAQUFBwEBBGowaDAkBggrBgEFBQcwAYYYaHR0cDovL29jc3AuZGlnaWNlcnQu\n" \
  "Y29tMEAGCCsGAQUFBzAChjRodHRwOi8vY2FjZXJ0cy5kaWdpY2VydC5jb20vRGln\n" \
  "aUNlcnRHbG9iYWxSb290RzIuY3J0MHsGA1UdHwR0MHIwN6A1oDOGMWh0dHA6Ly9j\n" \
  "cmwzLmRpZ2ljZXJ0LmNvbS9EaWdpQ2VydEdsb2JhbFJvb3RHMi5jcmwwN6A1oDOG\n" \
  "MWh0dHA6Ly9jcmw0LmRpZ2ljZXJ0LmNvbS9EaWdpQ2VydEdsb2JhbFJvb3RHMi5j\n" \
  "cmwwHQYDVR0gBBYwFDAIBgZngQwBAgEwCAYGZ4EMAQICMBAGCSsGAQQBgjcVAQQD\n" \
  "AgEAMA0GCSqGSIb3DQEBDAUAA4IBAQAlFvNh7QgXVLAZSsNR2XRmIn9iS8OHFCBA\n" \
  "WxKJoi8YYQafpMTkMqeuzoL3HWb1pYEipsDkhiMnrpfeYZEA7Lz7yqEEtfgHcEBs\n" \
  "K9KcStQGGZRfmWU07hPXHnFz+5gTXqzCE2PBMlRgVUYJiA25mJPXfB00gDvGhtYa\n" \
  "+mENwM9Bq1B9YYLyLjRtUz8cyGsdyTIG/bBM/Q9jcV8JGqMU/UjAdh1pFyTnnHEl\n" \
  "Y59Npi7F87ZqYYJEHJM2LGD+le8VsHjgeWX2CJQko7klXvcizuZvUEDTjHaQcs2J\n" \
  "+kPgfyMIOY1DMJ21NxOJ2xPRC/wAh/hzSBRVtoAnyuxtkZ4VjIOh\n"             \
  "-----END CERTIFICATE-----\n"

#define API_DEV_CERTS                                                  \
  "-----BEGIN CERTIFICATE-----\n"                                      \
  "MIIDDDCCAfSgAwIBAgIIUgVimvqrcC0wDQYJKoZIhvcNAQELBQAwFDESMBAGA1UE\n" \
  "AxMJbG9jYWxob3N0MB4XDTIzMDcyMDE2MzUzNloXDTI0MDcyMDE2MzUzNlowFDES\n" \
  "MBAGA1UEAxMJbG9jYWxob3N0MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKC\n" \
  "AQEA6SQgGA5fVeVvPuVvZNLtTSXAYmdlwyG3kX+qguRKTLd5t2jmm+J4GmTQng4E\n" \
  "eMtGqD2KtnO+zT2GltCaChQVLXuSxoOovq4ETrCvfwibpyKAuYg5wMz9iEMo8g6f\n" \
  "FC5ByGrt5MYYDV2oysWdYaUl6bsZfYdpLqW3zhFPbXmQuSRBjJUhwZ6IVSzEO1BW\n" \
  "mcpUC2BsmKg/QXefEm3n02Rq6fCd9zg5UxnxnTP6pj+gbqLnTVqy91Ul8CKdXjd7\n" \
  "Wl/h9bHMBUjn+zHKmB5e8g8SBO27bYXHxk6o+L154nc05UAhvZ8dLP1HSxZb9+2y\n" \
  "i3uhrlUYmkOpemgMdnUKvyCGxQIDAQABo2IwYDAMBgNVHRMBAf8EAjAAMA4GA1Ud\n" \
  "DwEB/wQEAwIFoDAWBgNVHSUBAf8EDDAKBggrBgEFBQcDATAXBgNVHREBAf8EDTAL\n" \
  "gglsb2NhbGhvc3QwDwYKKwYBBAGCN1QBAQQBAjANBgkqhkiG9w0BAQsFAAOCAQEA\n" \
  "vGUSTy/ucKDNPuAK0qDksUZqLisn/BBTYOkug0hQs4F8SYXCW/A2XTfRs16FbK8w\n" \
  "mPJ9K+ufXj9LQxPP4tsr7agQ1agNWkcLwV8JzpqXXSeRtaH5HTE+8B3n5ft7ez6M\n" \
  "/QETR2WbH9aJ+YDp2twD1Qq/yfNZJD3VnOO8s9ZEl+3OvnEeLOEhKliN0B1wnJJo\n" \
  "ASUBp3F/U1ZVA1A02TTPY6dsumY6ANF8NDxBWlMuCRw3YbXx3cKJ6TmcIix4t4z3\n" \
  "sMdewNztU6vcYrKQ3MhTc/R9wkzLDr6C65y9z4VjytKWcshu5BVpoIIERbJ7Oa1O\n" \
  "bVkeQpigCqEilUiyWk1JmQ==\n"                                         \
  "-----END CERTIFICATE-----\n"

#define API_AUTHZ_SERVER_URL "https://192.168.0.104:44395"
#define API_RESOURCE_SERVER_URL "https://192.168.0.104:5001"
#define API_KEY "arduino_client"
#define API_SECRET "arduino_secret"

// IOT Cloud settings
#define DEVICE_LOGIN_NAME "32e14135-92bc-4a68-a92f-b1cd3be389b3"
#define DEVICE_KEY "OAQJIQZYFO36XSZNM8FP"

// Wi-Fi settings
#define WIFI_SSID ""
#define WIFI_PASSWORD ""

// Board settings
#define BAUD_RATE 115200

// Infrared receiver settings
#define IR_RECV_PIN 14
#define IR_SEND_PIN 4
#define IR_SEND_FREQUENCY 38000
#define CAPTURE_BUFFER_SIZE 1024
#define MIN_UNKNOWN_SIZE 12
#define SAVE_BUFFER false

#endif  // CONFIG_H