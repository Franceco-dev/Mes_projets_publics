using UnityEngine; // Jutilisé de l'IA pour comprendre comment ça marche de manière générale.
using UnityEngine.SceneManagement;
using System.Collections;

public class King_game_over : MonoBehaviour
{
    // Le délai de redémarrage. On utilise "float" pour la coroutine car c'est plus précis.
    // Cela permet de temporiser l'ordinateur qui, lui, calcule de nombreuses fois par seconde.
    public float RestartDelay = 5f; 

    // Une méthode similaire au script "Enemy" qui se charge de détecter les collisions.
    private void OnCollisionEnter2D(Collision2D collision) 
    {
        // Si un objet avec le tag "Enemy" touche le roi.
        if (collision.gameObject.CompareTag("Enemy")) 
        {
            StartCoroutine(KingDeathSequence()); // Commencer la séquence de rechargement de la scène
        }
    }

    IEnumerator KingDeathSequence()
    {
        // On informe la console pour vérifier si le script fonctionne correctement.
        Debug.Log("Le Roi est touché ! Game over mon coco !"); 

        // Variable de type GameObject pour trouver l'objet ayant le tag "Player".
        GameObject player = GameObject.FindGameObjectWithTag("Player"); 

        if (player != null) // Si le joueur existe bien dans la scène.
        {
            player.GetComponent<SpriteRenderer>().enabled = false; // On fait disparaître le visuel du joueur.

            player.GetComponent<PlayerController>().enabled = false; // On désactive ses contrôles.

            player.GetComponent<Rigidbody2D>().velocity = Vector2.zero; // On annule sa vitesse.
        }

        // On indique à la coroutine le nombre de secondes à attendre (RestartDelay).
        yield return new WaitForSeconds(RestartDelay); 

        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Et on recharge la scène actuelle ! ^-^
    }
}

