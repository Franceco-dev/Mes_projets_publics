void setup(){ // Départ comme dans unity.

  pinMode(3, OUTPUT); // C'est une fonction qui permet de manipuler un pin.

}

void loop(){ // Pendant le programme comme dans unity.

  digitalWrite(3, HIGH); // Une autre fonction qui permet d'envoyer en boucle du courant.
  delay(500); // Facile c'est le delay 500 millisecondes.
  digitalWrite(3, LOW); // Une fonction qui enlève le courant.
  delay(500); // On enlève le courant pendant 500 millisecondes littéralement.

}
