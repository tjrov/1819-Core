#include "Servo.h"

Servo myservo2;
Servo myservo3;
Servo myservo4;
Servo myservo5;
Servo myservo6;
Servo myservo7;

boolean newData = false;
int apples[6];
int index = -1;

void setup()
{
  // put your setup code here, to run once:
  myservo2.attach(2);
  myservo3.attach(3);
  myservo4.attach(4);
  myservo5.attach(5);
  myservo6.attach(6);
  myservo7.attach(7);
  Serial.begin(9600);
  myservo2.writeMicroseconds(1500);
  myservo3.writeMicroseconds(1500);
  myservo4.writeMicroseconds(1500);
  myservo5.writeMicroseconds(1500);
  myservo6.writeMicroseconds(1500);
  myservo7.writeMicroseconds(1500);
  Serial.println("Ready!");
}

void loop() {
  // put your main code here, to run repeatedly:
  recvSpeeds();
  sendSpeeds();
  for (int i = 0; i < 6; i++) {
    Serial.print(apples[i]); Serial.print("   ");
  }
  Serial.println();
}

void recvSpeeds() {
  if (Serial.available() > 5) {
    switch (Serial.read()) {
      case 'A':
        apples[0] = Serial.parseInt();
        break;
      case 'B':
        apples[1] = Serial.parseInt();
        break;
      case 'C':
        apples[2] = Serial.parseInt();
        break;
      case 'D':
        apples[3] = Serial.parseInt();
        break;
      case 'E':
        apples[4] = Serial.parseInt();
        break;
      case 'F':
        apples[5] = Serial.parseInt();
        break;
    }
  }
}

void sendSpeeds() {
  myservo2.writeMicroseconds(apples[0]);
  myservo3.writeMicroseconds(apples[1]);
  myservo4.writeMicroseconds(apples[2]);
  myservo5.writeMicroseconds(apples[3]);
  myservo6.writeMicroseconds(apples[4]);
  myservo7.writeMicroseconds(apples[5]);
}
