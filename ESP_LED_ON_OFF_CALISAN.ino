#include <SoftwareSerial.h>

SoftwareSerial esp8266(2, 3); // RX, TX

void setup() {
  pinMode(LED_BUILTIN, OUTPUT); // Dahili LED için pin modunu ayarla
  digitalWrite(LED_BUILTIN, LOW); // LED'i başlangıçta söndür

  Serial.begin(9600);   
  esp8266.begin(115200);  

  Serial.println("ESP8266 ile haberleşme başladı");

  // ESP8266'yı resetle ve WiFi ağına bağla (AT komutları)
  esp8266.println("AT+RST");
  delay(1000);
  esp8266.println("AT+CWJAP=\"FiberHGW_ZT2T3R_2.4GHz\",\"HDA3dxXHfq\"");
  delay(10000);

  // Sunucu olarak çalışmaya başla, port 80 (AT komutları)
  esp8266.println("AT+CIPMUX=1");
  delay(3000);
  esp8266.println("AT+CIPSERVER=1,80");
  delay(3000);
  Serial.write(esp8266.read());
}

void loop() {
  // ESP8266'dan gelen veriyi kontrol et
  while (esp8266.available()) {
    String line = esp8266.readStringUntil('\n');
    if (line.indexOf("LED=ON") >= 0) {
      digitalWrite(LED_BUILTIN, HIGH); // LED'i yak
    }
    else if (line.indexOf("LED=OFF") >= 0) {
      digitalWrite(LED_BUILTIN, LOW); // LED'i söndür
    }
  }
}
