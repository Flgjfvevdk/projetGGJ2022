using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SC_Mouvement : MonoBehaviour
{
    public Transform piedTransf;
    public float circleRadius;
    public LayerMask whatIsGround;
    private bool estSurLeSol;

    private Rigidbody2D rb;
    public float speed;
    public float jumpVelocity;

    GamepadControler controls;
    private Vector2 move;

    void Awake()
    {
        controls = new GamepadControler();

        controls.gamecontroler.Move.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.gamecontroler.Move.canceled += ctx => move = Vector2.zero;

        controls.gamecontroler.Jump.performed += ctx => jump();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        estSurLeSol = Physics2D.OverlapCircle(piedTransf.position, circleRadius, whatIsGround);
        /*
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        } else if(Input.GetAxisRaw("Horizontal") < 0)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        } else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }
        
        if (Input.GetButton("Jump") && estSurLeSol)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);
        }
         */
        if (move.x > 0)
        {
            rb.velocity = new Vector2(move.x * speed, rb.velocity.y);
        }
        else if (move.x < 0)
        {
            rb.velocity = new Vector2(move.x * speed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

    }

    private void jump()
    {
        if (estSurLeSol)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);
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
