#include <Servo.h> // c'est une bibliothèque qui permet de communiquer avec le servomoteur

Servo MonServo; // classe Servo si tu connais la poo

int ValeurLumiere = 0;


void setup() {
  Serial.begin(9600);

  pinMode(A0, INPUT);
 
  MonServo.attach(5); // Le servomoteur est attacher au pin 5 
  MonServo.write(0); // l'angle de départ du servomoteur est de zero degré
  
   



}

void loop() {

  ValeurLumiere = analogRead(A0);  
  Serial.println(ValeurLumiere);

  if(ValeurLumiere > 500){
    MonServo.write(179); // en gros si la valeur lumière est inférieur à 500 le servomoteur tourne à 179 degrés

  }
  else{
    MonServo.write(0);
  }
  delay(100);
  
}
