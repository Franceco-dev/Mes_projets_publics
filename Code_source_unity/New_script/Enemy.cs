using UnityEngine

public class Enemy : MonoBehaviour
{
    // ici c'est les variable ^-^
    [Header("Stats")]
    public int MaxHealth = 3; // l'enemy a trois points de vie
    private int currentHealth; // barre de vie actuelle
    public int contactDamage = 20;
    public float speed = 3f;

    public Transform target; // ici c'est le tag pour que l'enemy sache ce qu'on doit faire 
    
    [Header("effect")]
    public GameObject HitParticles; // tableau graphique pour glisser les particules

    private Rigidbody2D rb; // on applque la physique à notre enemy

    void Start() // action de départ normalement ici c'est quand on lance le programme 
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = MaxHealth; // vie actuelle est égale à la vie maximale
    }

    public void TakeDamage(int damage) // ceci est une méthode pour les dégats
    {
        currentHealth -= damage; // la barre de vie actuelle est réduite par la fonction damage si j'ai bien compris
        Debug.Log("L'enemy est touché ! Il lui reste :  point de vie" + currentHealth); // la console de unity nous indique quand on touche l'enemy

        if (HitParticles != null)
        {
            Instantiate(HitParticles, transform.position, Quaternion.identity);
        }
        if (currentHealth <= 0) // si la barre de vie actuelle de l'enemy est plus petit ou égal à zero 
        {
            Die(); // ceci est une fonction pour tuer l'enemy est carrement supprimmer du moteur
        }
    }

    void Die()
    {
        Debug.Log("Vous avez vaincu !"); // je pense que c'est assez clair ^-^
        Destroy(gameObject); // détruire le gameObject
    }

    void FixedUpdate() // fixedUpdate s'éxecute à chaque interval régulier en gros (50 fois par fois par seconde peu importe si le jeu rame ou pas)
    {
        if (target == null) return; // sécurité le roi on veut qu'il soit là sinon c'est quoi le but du jeu

        float direction = target.position.x - transform.position.x;
        float distance = Mathf.Abs(direction);

        float moveDir = direction > 0 ? 1 : -1;  
        // si on est loin du roi 
        if (distance > 0.2f) // 0.2f est assez raisonable on est sur que il le touche
        {
           

           rb.velocity = new Vector2(moveDir * speed, rb.velocity.y); // on avance seulement

           transform.localScale = new Vector2(moveDir * 4f, 4f); // on retourne le sprite si il doit se diriger à gauche d'après ce que j'ai compris si il pars de la droite

        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y); // sinon on laisse tel quelle
        }
    }

    private void OnCollisionEnter2D(Collision2D collision) // ceci est une autre méthode comparé à un void fixed update il contient des informations importante pour les collision le nom de la méthode ne change pas
    {
      if (collision.gameObject.CompareTag("Player")) // si l'enemy touche le joueur 
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>(); // cette ligne contient une classe ou un heritage je crois et je crois que elle enlève de la vie au joueur

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(contactDamage, transform.position); // c'est juste ici
            }
        }  
    }
   
     
}
