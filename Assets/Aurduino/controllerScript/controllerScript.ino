int pinOfRedButton = 4;
int pinOfBlueButton = 2;

int previousPotValue = 0;

int redButtonFlag = 0;
int blueButtonFlag = 0;

void setup() {
  Serial.begin(9600);
  pinMode(pinOfRedButton, INPUT);
  pinMode(pinOfBlueButton, INPUT);
}

void loop() {
  int potValue = analogRead(A0); 
  int redButtonValue = digitalRead(pinOfRedButton);
  int blueButtonValue = digitalRead(pinOfBlueButton);

  if (redButtonValue == HIGH){
    redButtonFlag = 1;
    }
    else{
       redButtonFlag = 0;
      }

  if (blueButtonValue == HIGH){
    blueButtonFlag = 1;
    }
  else{
       blueButtonFlag = 0;
      }

      
 String message = String(String(potValue) + ',' + String(redButtonFlag) + ',' + String(blueButtonFlag));
// message += ",";
 //message += blueButtonFlag;
  Serial.println(message);

  delay(20);
/*
  if (potValue != previousPotValue){
    Serial.println(potValue);
    }

*/
  previousPotValue = potValue;
  //if every print is commented out, the hardware works fine
  //Serial.println(potValue);
  //Serial.println(redButtonValue);
  //Serial.println(blueButtonValue);

}
