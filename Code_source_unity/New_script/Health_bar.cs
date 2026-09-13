using UnityEngine; // Un peu de tutoriel et un peu de documentation par ici.
using UnityEngine.UI; // Bibliothèque pour le visuel.

public class Health_bar : MonoBehaviour
{
    public Slider slider; // C'est une classe Slider qui contient toutes les informations.
    
    public void SetMaxHealth(int health) // Autre méthode pour la valeur maximale où on donne l'information de la variable health.
    {
        slider.maxValue = health; // Un GameObject, un slider, on utilise cela pour les barres de vie et on dit que la valeur maximale correspond à la variable health.
        slider.value = health; // C'est pour le fond cette fois-ci.
    }

    public void SetHealth(int health)
    {
        slider.value = health; // Ça gère la valeur de la vie quand elle bisse
    }
}



