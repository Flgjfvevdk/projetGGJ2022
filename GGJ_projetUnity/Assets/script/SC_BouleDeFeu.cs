using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_BouleDeFeu : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;

    private float tempsDeVie;
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        tempsDeVie = 10.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if(tempsDeVie >= 0)
        {
            tempsDeVie -= Time.deltaTime;
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    // Cast des boules de feux
    public void partir(Vector2 vect)
    {
        rb.velocity = speed * vect ;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
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
}
