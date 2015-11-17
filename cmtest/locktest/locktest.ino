//lockuse
int outputpin = 4;
int inputpin = 2 ;
int switchon = 0;
//rfid use
#include <SPI.h>
#include <MFRC522.h>
#define SS_PIN 10  
 #define RST_PIN 9  
 MFRC522 mfrc522(SS_PIN, RST_PIN);  
 MFRC522::MIFARE_Key key;  
 int block=0;  
 byte blockcontent[16] = {"Hello world"};  
 byte readbackblock[18];  
String rfidUid = "";

void setup() {
  Serial.begin(9600);
  // lockuse
  pinMode(outputpin,OUTPUT);
  pinMode(inputpin,INPUT);
  digitalWrite(outputpin,HIGH);
  // rfid use
  SPI.begin();  
   mfrc522.PCD_Init();  
   Serial.println("Scan a MIFARE Classic card");  
   for (byte i = 0; i < 6; i++) {  
     key.keyByte[i] = 0xFF;  
   }  
}

void loop() {
  // testlock
  testLock();
  // test rfid
  mfrc522.PCD_Init();  
     if ( ! mfrc522.PICC_IsNewCardPresent()) {  
       return;  
     }  
     if ( !mfrc522.PICC_ReadCardSerial()) {  
       return;  
     }  
   
  String rfidUid2 = "";
    for (byte i = 0; i < mfrc522.uid.size; i++) {
      rfidUid2 += String(mfrc522.uid.uidByte[i] < 0x10 ? "0" : "");
      rfidUid2 += String(mfrc522.uid.uidByte[i], HEX);
    }
  if(rfidUid != rfidUid2){
      Serial.println("beep:"+rfidUid2);    
      rfidUid = rfidUid2;
    }
  //next
  delay(100);
}

void testLock(){
  
  if(switchon != digitalRead(inputpin)){
      if (digitalRead(inputpin) == 0){
         Serial.println("Lock:open");
        }
      else{
         Serial.println("Lock:close");
        }
       
       switchon = !switchon;
    }
  
  
  }
