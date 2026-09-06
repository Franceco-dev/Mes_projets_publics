const int buttonPin = 2; // Ce sont des variables. 
const int Note1 = 294;
const int Note2 = 587;
const int Note3 = 440;
const int Note4 = 415;
const int Note5 = 392;
const int Note6 = 349;
const int Note7 = 262;
const int Note8 = 247;
const int Note9 = 233;



void setup(){
  pinMode(buttonPin, INPUT); // Configurer la broche 2 à appuyer.
  Serial.begin(9600); 

}

void loop(){ // Je sais qu'il y a une méthode avec les tableaux mais je n'ai pas encore vraiment appris en C++ Arduino.

  if(digitalRead(buttonPin) == HIGH){
    Serial.println("J'ai appuyé sur ce bouton");

    

    jouer(Note1, 100 );
    jouer(Note1, 100);
    jouer(Note2, 200);
    jouer(Note3, 200);
    delay(120);

    jouer(Note4, 200);
    jouer(Note5, 200);
    jouer(Note6, 150);

    jouer(Note1, 100);
    jouer(Note6, 100);
    jouer(Note5, 100);

    jouer(Note7, 100);
    jouer(Note7, 100);
    jouer(Note2, 200);
    jouer(Note3, 200);
    delay(120);

    jouer(Note4, 200);
    jouer(Note5, 200);
    jouer(Note6, 150);

    jouer(Note1, 100);
    jouer(Note6, 100);
    jouer(Note5, 100);

    jouer(Note8, 100);
    jouer(Note8, 100);
    jouer(Note2, 200);
    jouer(Note3, 200);
    delay(120);

    jouer(Note4, 200);
    jouer(Note5, 200);
    jouer(Note6, 150);

    jouer(Note1, 100);
    jouer(Note6, 100);
    jouer(Note5, 100);

    jouer(Note9, 100);
    jouer(Note9, 100);
    jouer(Note2, 200);
    jouer(Note3, 200);
    delay(120);

    jouer(Note4, 200);
    jouer(Note5, 200);
    jouer(Note6, 150);

    jouer(Note1, 100);
    jouer(Note6, 100);
    jouer(Note5, 100);

    jouer(Note1, 100 );
    jouer(Note1, 100);
    jouer(Note2, 200);
    jouer(Note3, 200);
    delay(120);

    jouer(Note4, 200);
    jouer(Note5, 200);
    jouer(Note6, 150);

    jouer(Note1, 100);
    jouer(Note6, 100);
    jouer(Note5, 100);

    jouer(Note7, 100);
    jouer(Note7, 100);
    jouer(Note2, 200);
    jouer(Note3, 200);
    delay(120);

    jouer(Note4, 200);
    jouer(Note5, 200);
    jouer(Note6, 150);

    jouer(Note1, 100);
    jouer(Note6, 100);
    jouer(Note5, 100);

    jouer(Note8, 100);
    jouer(Note8, 100);
    jouer(Note2, 200);
    jouer(Note3, 200);
    delay(120);

    jouer(Note4, 200);
    jouer(Note5, 200);
    jouer(Note6, 150);

    jouer(Note1, 100);
    jouer(Note6, 100);
    jouer(Note5, 100);

    jouer(Note9, 100);
    jouer(Note9, 100);
    jouer(Note2, 200);
    jouer(Note3, 200);
    delay(120);

    jouer(Note4, 200);
    jouer(Note5, 200);
    jouer(Note6, 150);

    jouer(Note1, 100);
    jouer(Note6, 100);
    jouer(Note5, 100);

    

    

   

    

    
    
    
  } 
} // Si le bouton est pressé, jouer ces notes ci-dessus. 

void jouer(int note, int duree){
  tone(8, note, duree);
  delay(duree + 50);
} // Fonction qui permet de faire jouer les notes à une certaine durée.
