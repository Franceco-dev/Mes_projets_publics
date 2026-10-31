int switchState = 0;

void setup() {
  pinMode(3, OUTPUT); // Manipuler la broche 3.
  pinMode(4, OUTPUT); // Manipule la broche 4.
  pinMode(5, OUTPUT); // Manipule la broche 5.
  pinMode(2, INPUT); // Manipule la broche 2.
}

void loop() {

  switchState = digitalRead(2); // Variable qui sert à indiquer la tension sur une broche.
  
  // Si la variable ne reçoit pas de courant.
  if (switchState == LOW){ 

    digitalWrite(3, HIGH); // La led verte allumée.
    digitalWrite(4, LOW); // Led rouge éteinte.
    digitalWrite(5, LOW); // Led rouge éteinte aussi.

  } // Cette condition dit que si on n'appuie pas sur le bouton les leds rouges s'éteignent et la verte s'allume.

  else {

    digitalWrite(3, LOW); // La led 3 s'éteint.
    digitalWrite(4, LOW); // Euuuh deuxième led rouge éteinte aussi ah en fait j'ai compris ^-^.
    digitalWrite(5, HIGH); // Led rouge en gros la dernière est allumée.

    delay(250); // 0.25 secondes par intervalle.
    digitalWrite(4, HIGH); // Pendant cet intervalle la led rouge sera allumée.
    digitalWrite(5, LOW);
    delay(250); // Encore attendre 0.25 secondes.

  } // Ce sinon dit que si le bouton est pressé la dernière led la rouge en gros s'allume.

  
}
