using UnityEngine;
//j'ai aussi utilisé de l'IA pour les inputs bien qu'encore une fois j'ai essayé de comprendre la logique globale
public class PlayerController : MonoBehaviour
{
    [Header("Movement")] // attribut vitesse et accelaration
    public float moveSpeed = 6f;
    public float acceleration = 10f;
    [Header("Jump")] // attribut de force de gravité
    public float jumpForce = 12f;
    public Transform groundCheck;
    public float groundRadius = 0.1f;
    public LayerMask groundLayer; 

    [Header("Attack")]
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayer; // attribut attaque

    [HideInInspector] public float MoveX; // les deplacement
    [HideInInspector] public bool isGrounded; // verifie si il est sur le sol
    [HideInInspector] public bool isFacingRight = true; 
    [HideInInspector] public bool isAttacking = false; // on met une boolean pour checker si il est entrain d'attaquer ou non

    private Rigidbody2D rb; // on applique la phisyque

    void Start() //départ du jeu
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        HandleInput();
        HandleFlip();
    }

    void FixedUpdate() // plus optimisé pour la phisyque que update tout court
    {
        ApplyMovement(); // appliquer les mouvements
        CheckGround(); // on regarde si il est dans le sol
    }

    void HandleInput()
    {
        MoveX = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce); // si boutton x PS5 est pressé est il est sur le sol il peut sauter
        }

        // Attaque : carré PS5 ou clic gauche
        if ((Input.GetKeyDown(KeyCode.JoystickButton0) || Input.GetMouseButtonDown(0)) && !isAttacking)
        {
            StartAttack(); // on commence à attaquer
        }
    }

    void StartAttack() // methode pour l'attaque
    {
        isAttacking = true;// on passe à vrai l'attaque

        Collider2D[] hitEnmies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer); // on controlle si il a touché l'enemy

        foreach (Collider2D enemy in hitEnmies) // on check sa collision
        {
            Enemy enemyScript = enemy.GetComponent<Enemy>(); 

            if (enemyScript != null) // si on la touché
            {
                enemyScript.TakeDamage(1); // on lui enlève 1 coeur
                Debug.Log("On a frappé : " + enemy.name); // on signale
            }
        }
    }

    public void EndAttack() // methode quand c'est fini
    {
        isAttacking = false; //on passe à faux
    }

    void ApplyMovement()
    {
        float targetSpeed = MoveX * moveSpeed;
        float speed = Mathf.Lerp(rb.velocity.x, targetSpeed, acceleration * Time.fixedDeltaTime);

        rb.velocity = new Vector2(speed, rb.velocity.y);
    } //calcule de manière fluide les deplacement des joueur on utilise Time.fixedDeltaTime touours pour une question de physique

    void CheckGround() // methode pour controller si ilest sur le sol
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayer); 
    }

    void HandleFlip() // methode de securité
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
    } // en gros quand il se retourne on veut que il attaque dans le sens ou on a choisi sinon ce serai bizzare

    void OnDrawGizmosSelected()
    {
        if (attackPoint != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        }
    }
} // une sorte de hitbox pour l'épé


