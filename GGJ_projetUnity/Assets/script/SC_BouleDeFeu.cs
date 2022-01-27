using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SC_BouleDeFeu : MonoBehaviour
{
    GamepadControler controls;

    // BdF controlable
    private bool isControlable;
    private Rigidbody2D bossRb;


    private Rigidbody2D rb;
    public float speed;
    private float tempsDeVie;
    public float tempsDeVieControlable;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        tempsDeVie = 10.0f;

        controls = new GamepadControler();

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
                Vector2 direction = (positionSouris - posBdF);

                

                if(Mathf.Abs(direction.x) < 0.2 && Mathf.Abs(direction.y) < 0.2)
                {
                    rb.velocity = Vector2.zero;
                }
                else {
                    rb.velocity = direction.normalized * speed * (4f/8f);
                }
            }
        }
        else
        {
            destroySelf();
        }
        if (rb.velocity != Vector2.zero)
        {
            Vector2 direct = rb.velocity.normalized;
            transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direct.y, direct.x) * Mathf.Rad2Deg);
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
        transform.localScale = transform.localScale * 2.5f;
        tempsDeVie = tempsDeVieControlable;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if(isControlable)
        //{
        //    bossRb.gameObject.GetComponent<SC_Boss>().tirEnCour = false;
        //}
        
        if (collision.CompareTag("Boss"))
        {
            if(!isControlable)
            {
                collision.gameObject.GetComponent<SC_Boss>().getHitBoss(1);
                Destroy(gameObject);
            }
        } else if (collision.CompareTag("Surface") || collision.CompareTag("Plateforme"))
        {
            destroySelf();
        } else if (collision.CompareTag("Bombe"))
        {
            //On détruit les bombes si on tire dessus
            collision.gameObject.GetComponent<SC_Bombe>().Exploser();
            destroySelf();
        } else if (collision.CompareTag("Player"))
        {
            if(isControlable)
            {
                collision.gameObject.GetComponent<SC_Player>().getHitPlayer(1);
                destroySelf();
            }
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

    private void destroySelf()
    {
        if (isControlable)
        {
            bossRb.gameObject.GetComponent<SC_Boss>().tirEnCour = false;
        }
        Destroy(gameObject);
    }
}
