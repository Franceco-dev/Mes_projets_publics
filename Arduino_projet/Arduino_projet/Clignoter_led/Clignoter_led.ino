void setup(){ // départ comme dans unity

  pinMode(3, OUTPUT); // c'est une fonction qui permet de manipuler un pin

}

void loop(){ // pendant le programme comme dans unity

  digitalWrite(3, HIGH); // une autre fonction  qui permet d'envoyer en boucle du courant en vrai c++ arduino c'est simple
  delay(500); // facile c'est le delay 500 miliscondes
  digitalWrite(3, LOW); // une fonction qui enlève le courant 
  delay(500); // on enlève le courant pendant 500 millisecondes littéralement

}
