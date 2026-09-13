using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int MaxHealth = 100; // Nombre de points de vie au total.
    public int currentHealth; // Vie actuelle.

    [Header("Invincibilité")]
    public float invincibilityDuration = 2f; // Combien de temps dure la frame d'invincibilité.
    public float flashInterval = 0.15f; // Combien de temps ça clignote, l'intervalle quoi.
    private bool isInvincible = false; // Variable de type booléen pour dire que l'on ne clignote pas au début.

    [Header("Recul (knockback)")]
    public float knockbackForce = 7f; // Force de recul.

    public Health_bar healthBar; // Pour indiquer que c'est en lien avec la barre de vie (health bar).
    private SpriteRenderer sr; 
    private Rigidbody2D rb; // C'est pour éviter qu'on bouge à la mort.

    void Start()
    {
        currentHealth = MaxHealth; // Au départ, notre barre de vie actuelle est égale à notre vie maximale, logique.
        healthBar.SetMaxHealth(MaxHealth); // Et notre barre de vie est entièrement remplie.
        sr = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>(); // On récupère le Rigidbody.
    }

    // Méthode pour les dégâts : on indique au départ une variable de type int pour les dégâts et pour le knockback.
    public void TakeDamage(int damage, Vector2 damageSourcePosition) 
    {
        if (isInvincible || currentHealth <= 0) return; // Si on est mort, on prend zéro dégât.

        currentHealth -= damage; // Les dégâts réduisent la barre de vie actuelle.
        healthBar.SetHealth(currentHealth); // La barre de vie se vide.

        if(rb != null)
        {
          if(GetComponent<PlayerController>() != null) GetComponent<PlayerController>().enabled = false;

          Vector2 pushDirection = (transform.position - (Vector3)damageSourcePosition).normalized;
          rb.velocity = Vector2.zero; // On stoppe la vitesse actuelle.
          rb.AddForce(pushDirection * knockbackForce, ForceMode2D.Impulse);

          Invoke("ReenableMovement", 0.2f);
        }

        if (currentHealth > 0) // S'il y a encore de la vie, on clignote.
        {
            StartCoroutine(BecomeInvincible()); // On clignote.
        }
        else
        {
            StartCoroutine(DeathSequence()); // Sinon, on meurt.
        }
    }

// Une fonction pour laisser un temps de délai de 5 secondes. Il s'agit de la coroutine.
    private IEnumerator DeathSequence() 
    {
        Debug.Log("Le joueur est mort, attente de 5 secondes...");

        sr.enabled = false;
        if(rb != null)rb.velocity = Vector2.zero; // On stoppe les animations physiques du joueur.

        if(GetComponent<PlayerController>() != null) // Par défaut, on peut contrôler le joueur tant qu'il n'est pas mort.
            GetComponent<PlayerController>().enabled = false; // On le désactive grâce à celà.

        //On annule le mouvement prévu pour éviter qu'il bouge pendant qu'il est mort.
        CancelInvoke("ReenableMovement"); 

        yield return new WaitForSeconds(5f); // On attend 5 secondes.

        currentHealth = MaxHealth; // Quand on réinitialise, notre barre de vie es de retour.
        healthBar.SetHealth(MaxHealth); // Pour remplir la barre de vie.
        sr.enabled = true; // On réapparaît là où on est mort.

        if(GetComponent<PlayerController>() != null)
            GetComponent<PlayerController>().enabled = true; // Il est réapparu, on peut lui redonner les contrôles.

        // On commence la coroutine quand il est mort. On attend un certain moment avant de réapparaître, ce qui explique le message en bas.
        StartCoroutine(BecomeInvincible()); 

        Debug.Log("Respawn terminé !");
           
    }

    // Ceci est une coroutine : une fonction qui permet d'éviter que l'ordinateur "calcule trop vite". Ici, on indique les informations de la phase d'invincibilité.
    private IEnumerator BecomeInvincible() 
    {
        isInvincible = true; // Vu qu'on a pris des dégâts (ou réapparu), on l'active.
        float timer = 0; // Le timer au début.
        while (timer < invincibilityDuration)
        {
            sr.enabled = !sr.enabled;
            yield return new WaitForSeconds(flashInterval);
            timer += flashInterval;
        }
        sr.enabled = true;
        isInvincible = false;
    } // Une fois cette boucle terminée, le sprite peut réapparaître et les frames d'invincibilité sont coupées.

    void ReenableMovement()
    {
        //On vérifie que le joueur est bien vivant avant de lui redonner les contrôles.
        if(GetComponent<PlayerController>() != null && currentHealth > 0)
        {
          GetComponent<PlayerController>().enabled = true;
        }
    }
}
