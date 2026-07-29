using UnityEngine; // un peu de tutoriel et un peu de documentation par ici
using UnityEngine.UI; // blibliothèque pour le visuel

public class Health_bar : MonoBehaviour
{
    public Slider slider; // c'est une classe Slider contient toute les informations
    
    public void SetMaxHealth(int health) // autre methode pour la valeur maximal ou donne l'information de la variable health
    {
        slider.maxValue = health; // un gameobject un slider on utilise celà pour les barre de vie et on dit que la valeu maximaée correspond à la variable health
        slider.value = health; // c'est pour le fond cette fois ci
    }

    public void SetHealth(int health)
    {
        slider.value = health; // ça gère la valeur dela vie quad elle baisse
    }
}



