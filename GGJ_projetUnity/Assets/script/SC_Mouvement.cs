using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SC_Mouvement : MonoBehaviour
{
    GamepadControler controls;
    
    //Player
    public Transform piedTransf;
    private Rigidbody2D rb;

    //Detection sol
    public float circleRadius;
    public LayerMask whatIsGround;

    //Grappin
    GameObject grap;
    [SerializeField] private GameObject hook;
    public bool grapInstancier;
    public bool grapAccroche;
    [System.NonSerialized]
    public bool facingRight;
    [System.NonSerialized]
    public bool shotRight;

    [System.NonSerialized]
    public bool shotLeft;

    //Mouvement
    private Vector2 move;
    public float speed;
    public float jumpVelocity;
    private int nbSaut;
    private float defValueGavity;

    //Blink
    public SC_Slider_Float sliderTP;
    public float tempsRechargementBlink;
    private float timerRechargeBlink;
    public float distanceBlink;
    public Transform bordPjDevant;
    
    
    void Awake()
    {
        controls = new GamepadControler();

        controls.gamecontroler.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.gamecontroler.Move.canceled += ctx => move = Vector2.zero;

        controls.gamecontroler.Jump.performed += ctx => jump();

        controls.gamecontroler.Grappin.performed += ctx => grappin();

        controls.gamecontroler.Blink.performed += ctx => blink();
    }


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        grapInstancier = false;
        defValueGavity = rb.gravityScale;
        facingRight = true;

        timerRechargeBlink = 0;
        sliderTP.init(tempsRechargementBlink);
        sliderTP.setValue(tempsRechargementBlink - timerRechargeBlink);
    }


    void Update()
    {
        //Plusieurs saut
        if(Physics2D.OverlapCircle(piedTransf.position, circleRadius, whatIsGround))
        {
            nbSaut = 2;
        } else {
            nbSaut = Mathf.Min(nbSaut, 1);
        }

        //Orientation Player
        if((facingRight || shotRight) && transform.localScale.x < 0 && !shotLeft)
        {
            transform.localScale = new Vector2(- transform.localScale.x, transform.localScale.y);
        } else if ( (!facingRight || shotLeft) && transform.localScale.x > 0 && !shotRight)
        {
            transform.localScale = new Vector2(- transform.localScale.x, transform.localScale.y);
        }
       
        //Mouvement Player
        if(!grapAccroche)
        {
            rb.gravityScale = defValueGavity;
            if (move.x != 0)
            {
                rb.velocity = new Vector2(move.x * speed, rb.velocity.y);
                facingRight = move.x > 0;
            }
            else
            {
                rb.velocity = new Vector2(0, rb.velocity.y);
            }
        } else {
            //Le joueur à fini de remonter le grappin
            rb.gravityScale = 0;
            nbSaut = 1;
            Vector2 distancePlafond = grap.transform.position - transform.position;
            if (Mathf.Pow(distancePlafond.x,2) + Mathf.Pow(distancePlafond.y,2) <= 1.5f)
            {
                rb.velocity = Vector2.zero;
            }
        }

        //Blink Player
        if(timerRechargeBlink >= 0)
        {
            timerRechargeBlink -= Time.deltaTime;
            sliderTP.setValue(tempsRechargementBlink - timerRechargeBlink);
        }
    }

    private void jump()
    {
        if (nbSaut > 0)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);
            nbSaut--;
        }

        if(grap != null && grapAccroche)
        {
            Destroy(grap);
            grapInstancier = false;
            grapAccroche = false;
        }
        
    }

    private void grappin()
    {
        if(grapInstancier!=true){
            grapInstancier = true;
            float x = transform.position.x;
            float y = transform.position.y;
            grap = Instantiate(hook, new Vector2(x, y), Quaternion.identity);

            grap.GetComponent<SC_Grappin>().SetUpGrappin(transform, facingRight);
        }
    } 

    private void blink()
    {
        if (timerRechargeBlink <= 0 && !grapAccroche)
        {
            timerRechargeBlink = tempsRechargementBlink;
            sliderTP.setValue(tempsRechargementBlink - timerRechargeBlink);

            Vector3 direction;
            if (facingRight)
            {
                direction = Vector2.right;
            }else
            {
                direction = Vector2.left;
            }

            RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, direction, distanceBlink);
            float distMax = distanceBlink;
            foreach(RaycastHit2D hit in hits)
            {
                LayerMask hitlayer = hit.transform.gameObject.layer;
                if ((hitlayer == LayerMask.NameToLayer("Ground") || hitlayer == LayerMask.NameToLayer("Plateforme")) && hit.collider != null)
                {
                    distMax = Mathf.Min(distMax, Mathf.Abs(hit.point.x - bordPjDevant.position.x));
                }
            }

            transform.position = transform.position + direction * distMax;

            //Le player devient invincible pdt son temps d'invincibilité
            gameObject.GetComponent<SC_Player>().resetInvicibility(2); //(le 2 indique que le temps d'invincibilité va être 2 fois plus long que le temps normal
        }
        
    }

    private void OnEnable()
    {
        controls.gamecontroler.Enable();
    }

    private void OnDisable()
    {
        controls.gamecontroler.Disable();
    }
}
