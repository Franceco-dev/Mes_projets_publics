const int buttonPin = 2; // ce sont des variables 
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
  pinMode(buttonPin, INPUT); // configurer le pin 2 appuyer
  Serial.begin(9600); 

}

void loop(){ // je sais que il y a une methode des arrays mais j'ai pas encore vraiment appris en cpp Arduino

  if(digitalRead(buttonPin) == HIGH){
    Serial.println("j'ai appuyer sur ce bouton");

    

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
} //si bouton presser jouer ces notes ci dessus 

void jouer(int note, int duree){
  tone(8, note, duree);
  delay(duree + 50);
} // fonction qui permet de faire jouer les notes à une certaine durée  
