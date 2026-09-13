using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Ici, ce sont les variables. ^-^
    [Header("Stats")]
    public int MaxHealth = 3; // L'ennemi a trois points de vie.
    private int currentHealth; // Barre de vie actuelle.
    public int contactDamage = 20;
    public float speed = 3f;

    public Transform target; // Ici, c'est la cible pour que l'ennemi sache vers où aller. 
    
    [Header("Effects")]
    public GameObject HitParticles; // Emplacement graphique pour glisser les particules.

    private Rigidbody2D rb; // On applique la physique à notre ennemi.

    void Start() // Action de départ, normalement exécutée au lancement de l'objet.
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = MaxHealth; // La vie actuelle est égale à la vie maximale.
    }

    public void TakeDamage(int damage) // Ceci est une méthode pour les dégâts.
    {
        currentHealth -= damage; // La barre de vie actuelle est réduite par la valeur "damage" (dégâts).
        Debug.Log("L'ennemi est touché ! Points de vie restants : " + currentHealth); // La console de Unity indique quand on touche l'ennemi.

        if (HitParticles != null)
        {
            Instantiate(HitParticles, transform.position, Quaternion.identity);
        }
        if (currentHealth <= 0) // Si la barre de vie actuelle de l'ennemi est inférieure ou égale à zéro.
        {
            Die(); // Ceci est une fonction pour tuer l'ennemi, il est carrément supprimé du moteur.
        }
    }

    void Die()
    {
        Debug.Log("L'ennemi est vaincu !"); // Je pense que c'est assez clair. ^-^
        Destroy(gameObject); // Détruire le gameObject.
    }

    void FixedUpdate() // FixedUpdate s'exécute à intervalle régulier (environ 50 fois par seconde, peu importe si le jeu rame ou pas).
    {
        if (target == null) return; // Sécurité : on veut que la cible soit là, sinon le code s'arrête ici.

        float direction = target.position.x - transform.position.x;
        float distance = Mathf.Abs(direction);

        float moveDir = direction > 0 ? 1 : -1;  
        // Si on est loin de la cible.
        if (distance > 0.2f) // 0.2f est assez raisonnable, on est sûr qu'il l'atteint.
        {
           rb.velocity = new Vector2(moveDir * speed, rb.velocity.y); // On avance horizontalement.

           transform.localScale = new Vector2(moveDir * 4f, 4f); // On retourne le sprite selon la direction de marche.
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y); // Sinon, on l'arrête.
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) // Cette méthode gère les collisions physiques et s'exécute lors du contact initial.
    {
      if (collision.gameObject.CompareTag("Player")) // Si l'ennemi touche le joueur.
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>(); // On récupère le composant de vie du joueur.

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(contactDamage, transform.position); // On inflig les dégâts ici.
            }
        }  
    }
}
