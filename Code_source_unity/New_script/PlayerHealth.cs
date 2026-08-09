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
        currentHealth = MaxHealth; // au départ notre barre de vie actuelle est égale à notre vie maximum logique 
        healthBar.SetMaxHealth(MaxHealth); // et nootre barre de vie est full remplie
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>(); // on récupère le rigidbody
    }

    public void TakeDamage(int damage, Vector2 damageSourcePosition) //mehtode pour les dégats on indique au départ une varaible de type int pour les dégats et pour le knockback
    {
        if (isInvincible || currentHealth <= 0) return; // si on est mort on prend zero dégat 

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

    private IEnumerator DeathSequence() // ralenti les ordinateur pour que on puisse voir nous les 5 secondes sinon tout se ferai trop vite c'est le pricipe d'une coroutine
    {
        Debug.Log("Le player est mort attendre 5 seconde");

        sr.enabled = false;
        if(rb != null)rb.velocity = Vector2.zero; //on stoppe les animation phisyque du joueur

        if(GetComponent<PlayerController>() != null) // par défaut on peut controller le player tant que il est pas mort
            GetComponent<PlayerController>().enabled = false; // on desactive grâce à celà

        yield return new WaitForSeconds(5f); // on attend 5 seconde

        currentHealth = MaxHealth; // quand on reset, notre barre de vie est de retour
        healthBar.SetHealth(MaxHealth); // pour remplire la barre de vie
        sr.enabled = true; // on respawn là ou on est mort

        if(GetComponent<PlayerController>() != null)
            GetComponent<PlayerController>().enabled = true; // il est réapparu on peut lui redonner les controles 

        StartCoroutine(BecomeInvincible()); // on commence la corroutine que quand il est mort on attend un certain moment avant de réapparaitre ce qui explique le message en bas

        Debug.Log("Respawn terminé !");
           
    }

    private IEnumerator BecomeInvincible() //ceci est une coroutine une fonction qui permet d'éviter que les ordinateur calcule trop vite et ici on indique les information de la hase d'invinvibilité
    {
        isInvincible = true; // vu que on est mort on l'active
        float timer = 0; // le timer au début
        while (timer < invincibilityDuration)
        {
            sr.enabled = !sr.enabled;
            yield return new WaitForSeconds(flashInterval);
            timer += flashInterval;
        }
        sr.enabled = true;
        isInvincible = false;
    } //une fois cette boucle terminée le sprite peut réaparaitre et les frames d'ivinciblitée sont coupé

    void ReenableMovement()
    {
        if(GetComponent<PlayerController>() != null)
        {
          GetComponent<PlayerController>().enabled = true;
        }
    }
}
