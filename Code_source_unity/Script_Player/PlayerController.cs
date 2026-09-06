using UnityEngine;
// J'ai aussi utilisé de l'IA pour les inputs bien qu'encore une fois j'ai essayé de comprendre la logique globale.
public class PlayerController : MonoBehaviour
{
    [Header("Movement")] // Attribut vitesse et accélération.
    public float moveSpeed = 6f;
    public float acceleration = 10f;
    [Header("Jump")] // Attribut de force de gravité.
    public float jumpForce = 12f;
    public Transform groundCheck;
    public float groundRadius = 0.1f;
    public LayerMask groundLayer; 

    [Header("Attack")]
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayer; // Attribut attaque.

    [HideInInspector] public float MoveX; // Les déplacements.
    [HideInInspector] public bool isGrounded; // Vérifie s'il est au sol.
    [HideInInspector] public bool isFacingRight = true; 
    [HideInInspector] public bool isAttacking = false; // On met un booléen pour checker s'il est en train d'attaquer ou non.

    private Rigidbody2D rb; // On applique la physique.

    void Start() // Départ du jeu.
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        HandleInput();
        HandleFlip();
    }

    void FixedUpdate() // Plus optimisé pour la physique que update tout court.
    {
        ApplyMovement(); // Appliquer les mouvements.
        CheckGround(); // On regarde s'il est au sol.
    }

    void HandleInput()
    {
        MoveX = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce); // Si le bouton X de la PS5 est pressé et qu'il est au sol, il peut sauter.
        }

        // Attaque : carré PS5 ou clic gauche
        if ((Input.GetKeyDown(KeyCode.JoystickButton0) || Input.GetMouseButtonDown(0)) && !isAttacking)
        {
            StartAttack(); // On commence à attaquer.
        }
    }

    void StartAttack() // Méthode pour l'attaque.
    {
        isAttacking = true; // On passe à vrai l'attaque.

        Collider2D[] hitEnmies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer); // On contrôle s'il a touché l'ennemi.

        foreach (Collider2D enemy in hitEnmies) // On check sa collision.
        {
            Enemy enemyScript = enemy.GetComponent<Enemy>(); 

            if (enemyScript != null) // Si on l'a touché.
            {
                enemyScript.TakeDamage(1); // On lui enlève 1 cœur.
                Debug.Log("On a frappé : " + enemy.name); // On signale.
            }
        }
    }

    public void EndAttack() // Méthode quand c'est fini.
    {
        isAttacking = false; // On passe à faux.
    }

    void ApplyMovement()
    {
        float targetSpeed = MoveX * moveSpeed;
        float speed = Mathf.Lerp(rb.velocity.x, targetSpeed, acceleration * Time.fixedDeltaTime);

        rb.velocity = new Vector2(speed, rb.velocity.y);
    } // Calcule de manière fluide les déplacements du joueur, on utilise toujours Time.fixedDeltaTime pour une question de physique.

    void CheckGround() // Méthode pour contrôler s'il est au sol.
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayer); 
    }

    void HandleFlip() // Méthode de sécurité.
    {
        // On ne se retourne pas pendant l’attaque
        if (isAttacking) return;

        if (MoveX > 0 && !isFacingRight)
            Flip();
        else if (MoveX < 0 && isFacingRight)
            Flip();
    }

    void Flip() 
    {
        isFacingRight = !isFacingRight;

        if (attackPoint != null)
        {
            Vector3 pos = attackPoint.localPosition;
            pos.x *= -1;
            attackPoint.localPosition = pos;
        }
    } // En gros, quand il se retourne, on veut qu'il attaque dans le sens qu'on a choisi sinon ce serait bizarre.

    void OnDrawGizmosSelected()
    {
        if (attackPoint != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        }
    }
} // Une sorte de hitbox pour l'épée.


