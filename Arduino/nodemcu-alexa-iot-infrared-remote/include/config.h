#ifndef CONFIG_H
#define CONFIG_H

// API Settings
#define API_PROD_CERTS                                                 \
  "-----BEGIN CERTIFICATE-----\n"                                      \
  "MIIFrDCCBJSgAwIBAgIQBRllJkSaXj0aOHSPXc/rzDANBgkqhkiG9w0BAQwFADBh\n" \
  "MQswCQYDVQQGEwJVUzEVMBMGA1UEChMMRGlnaUNlcnQgSW5jMRkwFwYDVQQLExB3\n" \
  "d3cuZGlnaWNlcnQuY29tMSAwHgYDVQQDExdEaWdpQ2VydCBHbG9iYWwgUm9vdCBH\n" \
  "MjAeFw0yMzA2MDgwMDAwMDBaFw0yNjA4MjUyMzU5NTlaMF0xCzAJBgNVBAYTAlVT\n" \
  "MR4wHAYDVQQKExVNaWNyb3NvZnQgQ29ycG9yYXRpb24xLjAsBgNVBAMTJU1pY3Jv\n" \
  "c29mdCBBenVyZSBSU0EgVExTIElzc3VpbmcgQ0EgMDMwggIiMA0GCSqGSIb3DQEB\n" \
  "AQUAA4ICDwAwggIKAoICAQCUaitvevlZirydcTjMIt2fr5ei7LvQx7bdIVobgEZ1\n" \
  "Qlqf3BH6etKdmZChydkN0XXAb8Ysew8aCixKtrVeDCe5xRRCnKaFcEvqg2cSfbpX\n" \
  "FevXDvfbTK2ed7YASOJ/pv31stqHd9m0xWZLCmsXZ8x6yIxgEGVHjIAOCyTAgcQy\n" \
  "8ItIjmxn3Vu2FFVBemtP38Nzur/8id85uY7QPspI8Er8qVBBBHp6PhxTIKxAZpZb\n" \
  "XtBf2VxIKbvUGEvCxWCrKNfv+j0oEqDpXOqGFpVBK28Q48u/0F+YBUY8FKP4rfgF\n" \
  "I4lG9mnzMmCL76k+HjyBtU5zikDGqgm4mlPXgSRqEh0CvQS7zyrBRWiJCfK0g67f\n" \
  "69CVGa7fji8pz99J59s8bYW7jgyro93LCGb4N3QfJLurB//ehDp33XdIhizJtopj\n" \
  "UoFUGLnomVnMRTUNtMSAy7J4r1yjJDLufgnrPZ0yjYo6nyMiFswCaMmFfclUKtGz\n" \
  "zbPDpIBuf0hmvJAt0LyWlYUst5geusPxbkM5XOhLn7px+/y+R0wMT3zNZYQxlsLD\n" \
  "bXGYsRdE9jxcIts+IQwWZGnmHhhC1kvKC/nAYcqBZctMQB5q/qsPH652dc73zOx6\n" \
  "Bp2gTZqokGCv5PGxiXcrwouOUIlYgizBDYGBDU02S4BRDM3oW9motVUonBnF8JHV\n" \
  "RwIDAQABo4IBYjCCAV4wEgYDVR0TAQH/BAgwBgEB/wIBADAdBgNVHQ4EFgQU/glx\n" \
  "QFUFEETYpIF1uJ4a6UoGiMgwHwYDVR0jBBgwFoAUTiJUIBiV5uNu5g/6+rkS7QYX\n" \
  "jzkwDgYDVR0PAQH/BAQDAgGGMB0GA1UdJQQWMBQGCCsGAQUFBwMBBggrBgEFBQcD\n" \
  "AjB2BggrBgEFBQcBAQRqMGgwJAYIKwYBBQUHMAGGGGh0dHA6Ly9vY3NwLmRpZ2lj\n" \
  "ZXJ0LmNvbTBABggrBgEFBQcwAoY0aHR0cDovL2NhY2VydHMuZGlnaWNlcnQuY29t\n" \
  "L0RpZ2lDZXJ0R2xvYmFsUm9vdEcyLmNydDBCBgNVHR8EOzA5MDegNaAzhjFodHRw\n" \
  "Oi8vY3JsMy5kaWdpY2VydC5jb20vRGlnaUNlcnRHbG9iYWxSb290RzIuY3JsMB0G\n" \
  "A1UdIAQWMBQwCAYGZ4EMAQIBMAgGBmeBDAECAjANBgkqhkiG9w0BAQwFAAOCAQEA\n" \
  "AQkxu6RRPlD3yrYhxg9jIlVZKjAnC9H+D0SSq4j1I8dNImZ4QjexTEv+224CSvy4\n" \
  "zfp9gmeRfC8rnrr4FN4UFppYIgqR4H7jIUVMG9ECUcQj2Ef11RXqKOg5LK3fkoFz\n" \
  "/Nb9CYvg4Ws9zv8xmE1Mr2N6WDgLuTBIwul2/7oakjj8MA5EeijIjHgB1/0r5mPm\n" \
  "eFYVx8xCuX/j7+q4tH4PiHzzBcfqb3k0iR4DlhiZfDmy4FuNWXGM8ZoMM43EnRN/\n" \
  "meqAcMkABZhY4gqeWZbOgxber297PnGOCcIplOwpPfLu1A1K9frVwDzAG096a8L0\n" \
  "+ItQCmz7TjRH4ptX5Zh9pw==\n"                                         \
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
#define API_RESOURCE_SERVER_URL \
  "https://aiir-web2.azurewebsites.net/resource-server"
#define API_KEY "vlad_super_secret_arduino_key0201"
#define API_SECRET "vlad_super_secret_arduino_password0201"

// IOT Cloud settings
#define DEVICE_LOGIN_NAME "31f14eb8-ee6f-4b39-85d8-e4e709014780"
#define DEVICE_KEY "xHEeLx1j7uizCdXJuUXnYjFT8"

// Wi-Fi settings
#define WIFI_SSID "Home 2.4G"
#define WIFI_PASSWORD "nudauparola7789"

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