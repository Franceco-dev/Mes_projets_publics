#include <Servo.h> // C'est une bibliothèque qui permet de communiquer avec le servomoteur.

Servo MonServo; // Classe Servo si tu connais la POO.

int ValeurLumiere = 0;


void setup() {
  Serial.begin(9600);

  pinMode(A0, INPUT);
 
  MonServo.attach(5); // Le servomoteur est attaché à la broche 5. 
  MonServo.write(0); // L'angle de départ du servomoteur est de zéro degré.
  
   



}

void loop() {

  ValeurLumiere = analogRead(A0);  
  Serial.println(ValeurLumiere);

  if(ValeurLumiere > 500){
    MonServo.write(179); // En gros si la valeur lumière est supérieur à 500, le servomoteur tourne à 179 degrés.

  }
  else{
    MonServo.write(0);
  }
  delay(100);
  
}
