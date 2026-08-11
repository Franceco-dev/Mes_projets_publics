using UnityEngine;

public class Basik_Moveset : MonoBehaviour // j'ai fais le début avec [Header("")] mais à la fin j'ai du utilisé de l'IA car c'était aussi complexe cette parti bien que j'ai documenté la logiue globale
{
    //on peut tout gerer ces frames grâce à header
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

    private SpriteRenderer sr; // on applique le visuel
    private PlayerController controller; // on applique les controles
    private Rigidbody2D rb; // et la phisyque

    private float timer; //le temp
    private int frameIndex;// et les frames d'invicibilité

    private enum AnimState { Idle, Run, Jump, Fall, Attack } //on applique les animations
    private AnimState currentState; // on applique l'animation actuelle si elle attaque, saute, tombe etc

    void Start() // début du jeu
    {
        sr = GetComponent<SpriteRenderer>();
        controller = GetComponent<PlayerController>(); // la variable controller = au script PlayerController
        rb = GetComponent<Rigidbody2D>(); 
    }

    void Update() // durant le jeu on applique les animation et les mises à jour de l'état d'animation
    {
        UpdateState();
        PlayerAnimation();
    }

    void UpdateState() //methode pour changer l'état des animations
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
        bool grounded = controller.isGrounded; //on check si il est sur le sol
        float moveX = controller.MoveX;
        float velY = rb.velocity.y;

        if (!grounded) // si il 'est pas sur le sol
        {
            if (velY > 0.1f) 
                SetState(AnimState.Jump); // on commence à faire l'animation de saut
            else if (velY < -0.1f)
                SetState(AnimState.Fall); // une fois le point le plus haut on descentgrâce à l'animation fall
        }
        else
        {
            if (Mathf.Abs(moveX) > 0.1f)
                SetState(AnimState.Run);
            else
                SetState(AnimState.Idle); // si l fait rien on passe à idle
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

    void PlayerAnimation() //méthode pur les animations du joueur
    {
        Sprite[] anim = null;
        float fps = 6f;

        bool facingRight = controller.isFacingRight;

        switch (currentState) // c'est quoi switch ??
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
        } // on programme pour les 2 coté

        if (anim == null || anim.Length == 0)
            return;

        timer += Time.deltaTime; // on utilise pas de corutine car on veut pas que en 5 secondes l a fais trois de ses frames d'animation tandis que Time.deltaTime pour en gros adapter les image seconde par rapport à la puissance de l'ordinateur
        
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
        } // j'ai pas tout compris car c'est un peu dur il faut être bon en math et tout non ???

        // Sécurité si on change de direction et donc de tableau
        frameIndex = Mathf.Clamp(frameIndex, 0, anim.Length - 1);

        sr.sprite = anim[frameIndex];
    }
}

