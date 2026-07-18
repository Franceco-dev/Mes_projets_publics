using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 6f;
    public float acceleration = 10f;

    [Header("Jump")]
    public float jumpForce = 12f;
    public Transform groundCheck;
    public float groundRadius = 0.1f;
    public LayerMask groundLayer;

    [Header("Attack")]
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayer;

    [HideInInspector] public float MoveX;
    [HideInInspector] public bool isGrounded;
    [HideInInspector] public bool isFacingRight = true;
    [HideInInspector] public bool isAttacking = false;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        HandleInput();
        HandleFlip();
    }

    void FixedUpdate()
    {
        ApplyMovement();
        CheckGround();
    }

    void HandleInput()
    {
        MoveX = Input.GetAxisRaw("Horizontal");

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }

        // Attaque : carré PS5 ou clic gauche
        if ((Input.GetKeyDown(KeyCode.JoystickButton0) || Input.GetMouseButtonDown(0)) && !isAttacking)
        {
            StartAttack();
        }
    }

    void StartAttack()
    {
        isAttacking = true;

        Collider2D[] hitEnmies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        foreach (Collider2D enemy in hitEnmies)
        {
            Enemy enemyScript = enemy.GetComponent<Enemy>();

            if (enemyScript != null)
            {
                enemyScript.TakeDamage(1); // on lui enlève 1 coeur
                Debug.Log("On a frappé : " + enemy.name);
            }
        }
    }

    public void EndAttack()
    {
        isAttacking = false;
    }

    void ApplyMovement()
    {
        float targetSpeed = MoveX * moveSpeed;
        float speed = Mathf.Lerp(rb.velocity.x, targetSpeed, acceleration * Time.fixedDeltaTime);

        rb.velocity = new Vector2(speed, rb.velocity.y);
    }

    void CheckGround()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadius, groundLayer);
    }

    void HandleFlip()
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
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        }
    }
}

