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
    private bool facingRight;

    //Mouvement
    private Vector2 move;
    public float speed;
    public float jumpVelocity;
    private int nbSaut;
    private float defValueGavity;

    
    void Awake()
    {
        controls = new GamepadControler();

        controls.gamecontroler.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.gamecontroler.Move.canceled += ctx => move = Vector2.zero;

        controls.gamecontroler.Jump.performed += ctx => jump();

        controls.gamecontroler.Grappin.performed += ctx => grappin();
    }


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        grapInstancier = false;
        defValueGavity = rb.gravityScale;
        facingRight = true;
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
            if (Mathf.Pow(distancePlafond.x,2) + Mathf.Pow(distancePlafond.y,2) <= 1f)
            {
                rb.velocity = Vector2.zero;
            }
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

    private void OnEnable()
    {
        controls.gamecontroler.Enable();
    }

    private void OnDisable()
    {
        controls.gamecontroler.Disable();
    }
}
