using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class King_game_over : MonoBehaviour
{
    public float RestartDelay = 5f;

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.CompareTag("Enemy")) // si le tag Enemy touche le roi  
        {
            StartCoroutine(KingDeathSequence()); // commencer à recharger la scene
        }
    }

    IEnumerator KingDeathSequence()
    {
        Debug.Log("le Roi est touché ! game over mon coco");

        GameObject player = GameObject.FindGameObjectWithTag("Player");

        if (player != null)
        {
            player.GetComponent<SpriteRenderer>().enabled = false; // on fais dépop le joueur

            player.GetComponent<PlayerController>().enabled = false; // pas de controlle

            player.GetComponent<Rigidbody2D>().velocity = Vector2.zero;


        }

        yield return new WaitForSeconds(RestartDelay);

        SceneManager.LoadScene(SceneManager.GetActiveScene().name);

    }
}

