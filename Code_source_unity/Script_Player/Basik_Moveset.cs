using UnityEngine;

public class Basik_Moveset : MonoBehaviour // J'ai fait le début avec [Header("")] mais à la fin j'ai dû utiliser de l'IA car cette partie était trop complexe, bien que j'aie documenté la logique globale.
{
    // On peut gérer toutes ces frames grâce aux Headers.
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

    private SpriteRenderer sr; // On applique le visuel.
    private PlayerController controller; // On applique les contrôles.
    private Rigidbody2D rb; // Et la physique.

    private float timer; // Le temps.
    private int frameIndex; // Et le numéro de frame.

    private enum AnimState { Idle, Run, Jump, Fall, Attack } // On définit les états d'animation.
    private AnimState currentState; // On applique l'animation actuelle selon si le joueur attaque, saute, tombe, etc.

    void Start() // Début du jeu.
    {
        sr = GetComponent<SpriteRenderer>();
        controller = GetComponent<PlayerController>(); // La variable controller est égale au script PlayerController.
        rb = GetComponent<Rigidbody2D>(); 
    }

    void Update() // Durant le jeu, on applique les animations et les mises à jour de l'état d'animation.
    {
        UpdateState();
        PlayerAnimation();
    }

    void UpdateState() // Méthode pour changer l'état des animations.
    {
        // 1. Si on est déjà en train d’attaquer, on ne touche plus à l’état.
        if (currentState == AnimState.Attack)
            return;

        // 2. Si une attaque vient d’être déclenchée.
        if (controller.isAttacking)
        {
            SetState(AnimState.Attack); 
            return;
        }

        // 3. Logique normale de mouvement.
        bool grounded = controller.isGrounded; // On vérifie s'il est sur le sol.
        float moveX = controller.MoveX;
        float velY = rb.velocity.y;

        if (!grounded) // S'il n'est pas sur le sol.
        {
            if (velY > 0.1f) 
                SetState(AnimState.Jump); // On commence à jouer l'animation de saut.
            else if (velY < -0.1f)
                SetState(AnimState.Fall); // Une fois le point le plus haut atteint, on descend grâce à l'animation Fall.
        }
        else
        {
            if (Mathf.Abs(moveX) > 0.1f)
                SetState(AnimState.Run);
            else
                SetState(AnimState.Idle); // S'il ne fait rien, on passe à Idle.
        }
    }

    void SetState(AnimState newState) // Méthode qui permet de vérifier l'état de l'animation suivante.
    {
        if (newState == currentState)
            return;

        currentState = newState;
        frameIndex = 0;
        timer = 0f;
    }

    void PlayerAnimation() // Méthode pour les animations du joueur.
    {
        Sprite[] anim = null;
        float fps = 6f;

        bool facingRight = controller.isFacingRight;

        // Cette fonction sert à vérifier à chaque fois l'état des animations actuelles. Évitez de toujours utiliser cela, car on peut se retrouver, si on a 200 animations, avec un switch de 200 lignes.
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
        } // On programme pour les deux côtés.

        if (anim == null || anim.Length == 0)
            return;

        // On n'utilise pas de coroutine, car on ne veut pas qu'en 5 secondes il ait fait trois de ses frames d'animation, tandis que Time.deltaTime sert en gros à adapter les images par seconde par rapport à la puissance de l'ordinateur.
        timer += Time.deltaTime; 
        
        // Si on est en Idle ou Run, on joue l'animation à l'infini, sinon on joue Attack, Jump ou Fall une seule fois.
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

        // Sécurité si on change de direction et donc de tableau.
        frameIndex = Mathf.Clamp(frameIndex, 0, anim.Length - 1);

        sr.sprite = anim[frameIndex];
    }
}
