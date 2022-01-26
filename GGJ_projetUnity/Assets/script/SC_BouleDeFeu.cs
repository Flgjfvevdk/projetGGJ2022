using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SC_BouleDeFeu : MonoBehaviour
{
    GamepadControler controls;

    // BdF controlable
    private bool isControlable;
    private Vector2 positionSouris;
    private Rigidbody2D bossRb;

    private Rigidbody2D rb;
    public float speed;
    private float tempsDeVie;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        tempsDeVie = 10.0f;

        controls = new GamepadControler();
        // controls.ClavierSouris.PositionSouris.performed += ctx => positionSouris = ctx.ReadValue<Vector2>();

    }

    // Update is called once per frame
    void Update()
    {

        if(tempsDeVie >= 0)
        {
            tempsDeVie -= Time.deltaTime;
            if(isControlable)
            {
                Vector2 positionSouris = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
                Vector2 posBdF = transform.position;
                Vector2 direction = (positionSouris - posBdF).normalized;

                

                if(Mathf.Abs(direction.x) < 0.5 && Mathf.Abs(direction.y) < 0.5)
                {
                    rb.velocity = Vector2.zero;
                }
                else {
                    rb.velocity = direction * speed * (1f/2f);
                }
            }
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Cast BdF normale
    public void partir(Vector2 vect)
    {
        rb.velocity = speed * vect ;
        isControlable = false;
    }

    // Cast BdF controlable
    public void partirControlable(Rigidbody2D plRb)
    {
        this.bossRb = plRb;
        isControlable = true;
        transform.localScale = transform.localScale + new Vector3(0.25f, 0.25f, 0.25f); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(isControlable)
        {
            bossRb.gameObject.GetComponent<SC_Boss>().tirEnCour = false;
        }
        
        if (collision.CompareTag("Boss"))
        {
            //On lui fait des d�g�ts !
        } else if (collision.CompareTag("Surface"))
        {
            Destroy(gameObject);
        } else if (collision.CompareTag("Bombe"))
        {
            //On détruit les bombes si on tire dessus
            collision.gameObject.GetComponent<SC_Bombe>().Exploser();
            Destroy(gameObject);
        }
    }

    private void OnEnable()
    {
        controls.ClavierSouris.Enable();
    }

    private void OnDisable()
    {
        controls.ClavierSouris.Disable();
    }
}
