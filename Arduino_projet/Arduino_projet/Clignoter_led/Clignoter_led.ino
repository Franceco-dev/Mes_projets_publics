void setup(){ // Départ comme dans Unity.

  pinMode(3, OUTPUT); // C'est une fonction qui permet de manipuler une broche.

}

void loop(){ // Pendant le programme comme dans Unity.

  digitalWrite(3, HIGH); // Une autre fonction qui permet d'envoyer en boucle du courant, en vrai le C++ Arduino c'est simple.
  delay(500); // Facile : c'est le délai de 500 millisecondes.
  digitalWrite(3, LOW); // Une fonction qui enlève le courant.
  delay(500); // On enlève le courant pendant 500 millisecondes littéralement.

}
