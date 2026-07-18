int switchState = 0;

void setup() {
  pinMode(3, OUTPUT); // manipuler le pin 3
  pinMode(4, OUTPUT); // manipule le pin 4
  pinMode(5, OUTPUT); // manipule le pin 5
  pinMode(2, INPUT); // manipule le pin 2
}

void loop() {

  switchState = digitalRead(2); // variable qui sert a indiquer la tension sur une broche
  
  // si la variable ne reçois pas de courant
  if (switchState == LOW){ 

    digitalWrite(3, HIGH); // la led verte allumer
    digitalWrite(4, LOW); // led rouge éteind
    digitalWrite(5, LOW); // led rouge éteind aussi

  } // cette condition dit que si on appuie pas sur le bouton les leds rouges s'éteignent et la verte s'allume

  else {

    digitalWrite(3, LOW); // la led 3 s'éteind
    digitalWrite(4, LOW); // euuuh deuxième led rouge éteind aussi ah enfait j'ai compris ^-^
    digitalWrite(5, HIGH); // led rouge en gros la dernièere est allumé

    delay(250); // 0.25 secondes par intervale
    digitalWrite(4, HIGH); // pendant cet interval la led rouge sera allumé
    digitalWrite(5, LOW);
    delay(250); // encore attentre 0.25 secondes

  } // ce sinon dis que si bouton presser la dernière led la rouge en gros s'allume

  
}
