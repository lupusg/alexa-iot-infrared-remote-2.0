#ifndef CONFIG_H
#define CONFIG_H

// API Settings
#define API_PROD_CERTS                                                 \
  "-----BEGIN CERTIFICATE-----\n"                                      \
  "MIIFrDCCBJSgAwIBAgIQDvt+VH7fD/EGmu5XaW17oDANBgkqhkiG9w0BAQwFADBh\n" \
  "MQswCQYDVQQGEwJVUzEVMBMGA1UEChMMRGlnaUNlcnQgSW5jMRkwFwYDVQQLExB3\n" \
  "d3cuZGlnaWNlcnQuY29tMSAwHgYDVQQDExdEaWdpQ2VydCBHbG9iYWwgUm9vdCBH\n" \
  "MjAeFw0yMzA2MDgwMDAwMDBaFw0yNjA4MjUyMzU5NTlaMF0xCzAJBgNVBAYTAlVT\n" \
  "MR4wHAYDVQQKExVNaWNyb3NvZnQgQ29ycG9yYXRpb24xLjAsBgNVBAMTJU1pY3Jv\n" \
  "c29mdCBBenVyZSBSU0EgVExTIElzc3VpbmcgQ0EgMDgwggIiMA0GCSqGSIb3DQEB\n" \
  "AQUAA4ICDwAwggIKAoICAQCy7oIFzcDVZVbomWZtSwrAX8LiKXsbCcwuFL7FHkD5\n" \
  "m67olmOdTueOKhNER5ykFs/meKG1fwzd35/+Q1+KTxcV89IIXmErtSsj8EWu7rdE\n" \
  "AVYnYMFbstqwkIVNEoz4OIM82hn+N5p57zkHGPogzF6TOPRUOK8yYyCPeqnHvoVp\n" \
  "E5b0kZL4QT8bdyhSRQbUsUiSaOuF5y3eZ9Vc92baDkhY7CFZE2ThLLv5PQ0WxzLo\n" \
  "t3t18d2vQP5x29I0n6NFsj37J2d/EH/Z6a/lhAVzKjfYloGcQ1IPyDEIGh9gYJnM\n" \
  "LFZiUbm/GBmlpKVr8M03OWKCR0thRbfnU6UoskrwGrECAnnojFEUw+j8i6gFLBNW\n" \
  "XtBOtYvgl8SHCCVKUUUl4YOfR5zF4OkKirJuUbOmB2AOmLjYJIcabDvxMcmryhQi\n" \
  "nog+/+jgHJnY62opgStkdaImMPzyLB7ZaWVnxpRdtFKO1ZvGkZeRNvbPAUKR2kNe\n" \
  "knuh3NtFvz2dY3xP7AfhyLE/t8vW72nAzlRKz++L70CgCvj/yeObPwaAPDd2sZ0o\n" \
  "j2u/N+k6egGq04e+GBW+QYCSoJ5eAY36il0fu7dYSHYDo7RB5aPTLqnybp8wMeAa\n" \
  "tcagc8U9OM42ghELTaWFARuyoCmgqR7y8fAU9Njhcqrm6+0Xzv/vzMfhL4Ulpf1G\n" \
  "7wIDAQABo4IBYjCCAV4wEgYDVR0TAQH/BAgwBgEB/wIBADAdBgNVHQ4EFgQU9n4v\n" \
  "vYCjSrJwW+vfmh/Y7cphgAcwHwYDVR0jBBgwFoAUTiJUIBiV5uNu5g/6+rkS7QYX\n" \
  "jzkwDgYDVR0PAQH/BAQDAgGGMB0GA1UdJQQWMBQGCCsGAQUFBwMBBggrBgEFBQcD\n" \
  "AjB2BggrBgEFBQcBAQRqMGgwJAYIKwYBBQUHMAGGGGh0dHA6Ly9vY3NwLmRpZ2lj\n" \
  "ZXJ0LmNvbTBABggrBgEFBQcwAoY0aHR0cDovL2NhY2VydHMuZGlnaWNlcnQuY29t\n" \
  "L0RpZ2lDZXJ0R2xvYmFsUm9vdEcyLmNydDBCBgNVHR8EOzA5MDegNaAzhjFodHRw\n" \
  "Oi8vY3JsMy5kaWdpY2VydC5jb20vRGlnaUNlcnRHbG9iYWxSb290RzIuY3JsMB0G\n" \
  "A1UdIAQWMBQwCAYGZ4EMAQIBMAgGBmeBDAECAjANBgkqhkiG9w0BAQwFAAOCAQEA\n" \
  "loABcB94CeH6DWKwa4550BTzLxlTHVNseQJ5SetnPpBuPNLPgOLe9Y7ZMn4ZK6mh\n" \
  "feK7RiMzan4UF9CD5rF3TcCevo3IxrdV+YfBwvlbGYv+6JmX3mAMlaUb23Y2pONo\n" \
  "ixFJEOcAMKKR55mSC5W4nQ6jDfp7Qy/504MQpdjJflk90RHsIZGXVPw/JdbBp0w6\n" \
  "pDb4o5CqydmZqZMrEvbGk1p8kegFkBekp/5WVfd86BdH2xs+GKO3hyiA8iBrBCGJ\n" \
  "fqrijbRnZm7q5+ydXF3jhJDJWfxW5EBYZBJrUz/a+8K/78BjwI8z2VYJpG4t6r4o\n" \
  "tOGB5sEyDPDwqx00Rouu8g==\n"                                         \
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

#define API_AUTHZ_SERVER_URL "https://aiir-web2.azurewebsites.net"
#define API_RESOURCE_SERVER_URL "https://aiir-web2.azurewebsites.net/resource-server"
#define API_KEY ""
#define API_SECRET ""

// IOT Cloud settings
#define DEVICE_LOGIN_NAME ""
#define DEVICE_KEY ""

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