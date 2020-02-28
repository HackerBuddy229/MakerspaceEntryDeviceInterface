#include <Stepper.h>


int pinInput;
int pinOn;
Stepper stepper = Stepper(200, 8, 9, 10, 11);


void setup() {

  // Use GPIO Pin 13 as output.
  int pinOne = 8;
  int pinTwo = 9;
  int pinThree = 10;
  int pinFour = 11;
  pinInput = 12;
  pinOn = 13;

  stepper = Stepper(200, pinOne, pinTwo, pinThree, pinFour);
  stepper.setSpeed(5);
  
  pinMode(pinOn, OUTPUT);
  digitalWrite(pinOn, 1);

  pinMode(pinInput, INPUT);
  
}

void loop() {
  digitalRead(pinInput);


  stepper.step(-55);

  delay(10000);
  
  stepper.step(55);

}
