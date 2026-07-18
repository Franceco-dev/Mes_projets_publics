using UnityEngine;

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
    public GameObject HitParticles;

    private Rigidbody2D rb;

    void Start() // action de départ normalement ici c'est quand on lance le programme 
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = MaxHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage; // la barre de vie actuelle est réduite par la fonction damage si j'ai bien compris
        Debug.Log("L'enemy est touché ! Il lui reste :  point de vie" + currentHealth); // la console de unity nous indique quand on touche l'enemy

        if (HitParticles != null)
        {
            Instantiate(HitParticles, transform.position, Quaternion.identity);
        }
        if (currentHealth <= 0) // si la barre de vie actuelle de l'enemy est plus petit ou égal à zero 
        {
            Die(); // meurs hahahahahahahahahahahahahahahahahahahahahah dans ce monde c'est tuer ou être tué
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
        if (distance > 0.2f)
        {
           

           rb.velocity = new Vector2(moveDir * speed, rb.velocity.y); // on avance  

           transform.localScale = new Vector2(moveDir * 4f, 4f); // on retourne le sprite si il doit se diriger à gauche d'après ce que j'ai compris

        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
      if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(contactDamage, transform.position);
            }
        }  
    }
   
     
}
