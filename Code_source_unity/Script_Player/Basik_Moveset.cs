using UnityEngine;

public class Basik_Moveset : MonoBehaviour
{
    [Header ("Idle")]
    public Sprite[] idleRight;
    public Sprite[] idleLeft;
    public float idleFPS = 4f;

    [Header("Run")]
    public Sprite[] runRight;
    public Sprite[] runLeft;
    public float runFPS = 12f;

    [Header("Jump (One Shot)")]
    public Sprite[] jumpRight;
    public Sprite[] jumpLeft;
    public float jumpFPS = 6f;

    [Header("Fall (One Shot)")]
    public Sprite[] fallRight;
    public Sprite[] fallLeft;
    public float fallFPS = 4f;

    [Header("Attack (One Shot)")]
    public Sprite[] attackRight;
    public Sprite[] attackLeft;
    public float attackFPS = 10f;

    private SpriteRenderer sr;
    private PlayerController controller;
    private Rigidbody2D rb;

    private float timer;
    private int frameIndex;

    private enum AnimState { Idle, Run, Jump, Fall, Attack }
    private AnimState currentState;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        controller = GetComponent<PlayerController>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        UpdateState();
        PlayerAnimation();
    }

    void UpdateState()
    {
        // 1. Si on est déjà en train d’attaquer, on ne touche plus à l’état
        if (currentState == AnimState.Attack)
            return;

        // 2. Si une attaque vient d’être déclenchée
        if (controller.isAttacking)
        {
            SetState(AnimState.Attack);
            return;
        }

        // 3. Logique normale de mouvement
        bool grounded = controller.isGrounded;
        float moveX = controller.MoveX;
        float velY = rb.velocity.y;

        if (!grounded)
        {
            if (velY > 0.1f)
                SetState(AnimState.Jump);
            else if (velY < -0.1f)
                SetState(AnimState.Fall);
        }
        else
        {
            if (Mathf.Abs(moveX) > 0.1f)
                SetState(AnimState.Run);
            else
                SetState(AnimState.Idle);
        }
    }

    void SetState(AnimState newState)
    {
        if (newState == currentState)
            return;

        currentState = newState;
        frameIndex = 0;
        timer = 0f;
    }

    void PlayerAnimation()
    {
        Sprite[] anim = null;
        float fps = 6f;

        bool facingRight = controller.isFacingRight;

        switch (currentState)
        {
            case AnimState.Idle:
                anim = facingRight ? idleRight : idleLeft;
                fps = idleFPS;
                break;

            case AnimState.Run:
                anim = facingRight ? runRight : runLeft;
                fps = runFPS;
                break;

            case AnimState.Jump:
                anim = facingRight ? jumpRight : jumpLeft;
                fps = jumpFPS;
                break;

            case AnimState.Fall:
                anim = facingRight ? fallRight : fallLeft;
                fps = fallFPS;
                break;

            case AnimState.Attack:
                anim = facingRight ? attackRight : attackLeft;
                fps = attackFPS;
                break;
        }

        if (anim == null || anim.Length == 0)
            return;

        timer += Time.deltaTime;

        if (timer >= 1f / fps)
        {
            timer = 0f;
            frameIndex++;

            if (currentState == AnimState.Idle || currentState == AnimState.Run)
            {
                frameIndex %= anim.Length;
            }
            else
            {
                if (frameIndex >= anim.Length)
                {
                    if (currentState == AnimState.Attack)
                    {
                        frameIndex = 0;
                        controller.EndAttack();
                        SetState(AnimState.Idle);
                    }
                    else
                    {
                        frameIndex = anim.Length - 1;
                    }
                }
            }
        }

        // Sécurité si on change de direction et donc de tableau
        frameIndex = Mathf.Clamp(frameIndex, 0, anim.Length - 1);

        sr.sprite = anim[frameIndex];
    }
}

