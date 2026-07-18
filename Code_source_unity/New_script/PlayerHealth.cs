using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int MaxHealth = 100; // nbre de point de vie au total 
    public int currentHealth; // vie actuelle

    [Header("Invinibilité")]
    public float invincibilityDuration = 2f; // combien de temp dure la frame d'invincibilité
    public float flashInterval = 0.15f; //combien de temp ça clignote l'intervale quoi 
    private bool isInvincible = false; // variable de type booléan pour dire que on ne clignote pas au début

    [Header("recul (knockback)")]
    public float knockbackForce = 7f; // force de recul

    public Health_bar healthBar; // pour indiquer que c'est en lien avec la health bar
    private SpriteRenderer sr; 
    private Rigidbody2D rb; // c'est pour éviter qu'on bouge à la mort

    void Start()
    {
        currentHealth = MaxHealth; // au départ notre barre de vie actuelle est égale à notre vie maximum logique nn
        healthBar.SetMaxHealth(MaxHealth); // et nootre barre de vie est full remplie
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>(); // on récupère le rigidbody
    }

    public void TakeDamage(int damage, Vector2 damageSourcePosition) 
    {
        if (isInvincible || currentHealth <= 0) return; // si on est mort on prend zero dégat comme Saitama

        currentHealth -= damage; // les dégats enlèvent la barre de vie actuelle
        healthBar.SetHealth(currentHealth); // la barre de vie se vide

        if(rb != null)
        {
          if(GetComponent<PlayerController>() != null) GetComponent<PlayerController>().enabled = false;

          Vector2 pushDirection = (transform.position - (Vector3)damageSourcePosition).normalized;
          rb.velocity = Vector2.zero; // on stop la vitesse actuelle
          rb.AddForce(pushDirection * knockbackForce, ForceMode2D.Impulse);

          Invoke("ReenableMovement", 0.2f);
        }

        if (currentHealth > 0) // si il y a encore de la vie on clignote
        {
            StartCoroutine(BecomeInvincible()); // on on clignote
        }
        else
        {
            StartCoroutine(DeathSequence()); // sinon on meurt
        }
    }

    private IEnumerator DeathSequence() // pour eviter que unity speedrun
    {
        Debug.Log("Le player est mort attendre 5 seconde");

        sr.enabled = false;
        if(rb != null)rb.velocity = Vector2.zero; // on cache le player pour quand il est mort

        if(GetComponent<PlayerController>() != null) // par défaut on peut controller le player tant que il est pas mort
            GetComponent<PlayerController>().enabled = false;

        yield return new WaitForSeconds(5f); // on attend 5 seconde

        currentHealth = MaxHealth; // quand on reset, notre barre de vie est de retour
        healthBar.SetHealth(MaxHealth); // pour remplire la barre de vie
        sr.enabled = true; // on respawn là ou on est mort

        if(GetComponent<PlayerController>() != null)
            GetComponent<PlayerController>().enabled = true; // mtn si on est mort on peut plus rien controller

        StartCoroutine(BecomeInvincible());

        Debug.Log("Respawn terminé !");
           
    }

    private IEnumerator BecomeInvincible() // pour eviter que unity speedrun
    {
        isInvincible = true; 
        float timer = 0;
        while (timer < invincibilityDuration)
        {
            sr.enabled = !sr.enabled;
            yield return new WaitForSeconds(flashInterval);
            timer += flashInterval;
        }
        sr.enabled = true;
        isInvincible = false;
    }

    void ReenableMovement()
    {
        if(GetComponent<PlayerController>() != null)
        {
          GetComponent<PlayerController>().enabled = true;
        }
    }
}
