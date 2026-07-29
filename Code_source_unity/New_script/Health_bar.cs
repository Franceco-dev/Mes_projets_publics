using UnityEngine; // un peu de tutoriel et un peu de documentation par ici
using UnityEngine.UI; // blibliothèque pour le visuel

public class Health_bar : MonoBehaviour
{
    public Slider slider; // c'est une classe Slider contient toute les informations
    
    public void SetMaxHealth(int health) // autre methode pour la valeur maximalou donne l'information de la variable health
    {
        slider.maxValue = health; // un gameobject un slider on utilise celà pour les barre de vie et on dit que la valeu maxiam correspond à la variable health
        slider.value = health; // et pareil pour la valeur si elle baisse
    }

    public void SetHealth(int health)
    {
        slider.value = health; // on indique aussi pour la valeur cette fois
    }
}



