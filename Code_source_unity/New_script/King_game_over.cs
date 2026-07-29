using UnityEngine; // j'ai utilisé de l'IA pour comprendre comment ça marche de manière générale
using UnityEngine.SceneManagement;
using System.Collections;

public class King_game_over : MonoBehaviour
{
    public float RestartDelay = 5f; // le delay de recharge on utilise float car c'est plus précis pour la coroutine vu que ça permet de "ralentir" l'ordinateur qui lui calcule 60 fois par seconde

    private void OnCollisionEnter2D(Collision2D collision) // une méthode à peu près comme le script enemy qui se charge des collisions
    {
        if (collision.gameObject.CompareTag("Enemy")) // si le tag Enemy touche le roi  
        {
            StartCoroutine(KingDeathSequence()); // commencer à recharger la scene
        }
    }

    IEnumerator KingDeathSequence()
    {
        Debug.Log("le Roi est touché ! game over mon coco"); // on informe das la console pour voir si le script tient la route

        GameObject player = GameObject.FindGameObjectWithTag("Player"); // variable de type gameObject  pour trouver le tag layer 

        if (player != null) // si le player est toujours en vie 
        {
            player.GetComponent<SpriteRenderer>().enabled = false; // on fais dépop le joueur

            player.GetComponent<PlayerController>().enabled = false; // pas de controlle

            player.GetComponent<Rigidbody2D>().velocity = Vector2.zero; // plus de vitesse


        }

        yield return new WaitForSeconds(RestartDelay); //on indique à la coroutine le nbre de seconde à recharger RestartDelay 

        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // et on recharge la scene ^-^

    }
}

