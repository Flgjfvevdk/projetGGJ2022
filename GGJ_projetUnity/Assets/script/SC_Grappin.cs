using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Grappin : MonoBehaviour
{
    //Player
    private Transform playerTransform;
    private Rigidbody2D playerRb;
    //Objet Grappin
    private Rigidbody2D rb;
    private LineRenderer line;
    

    public float speed;
    private float tempsDeVie;

    // Start is called before the first frame update
    void Awake()
    {
        line = GetComponent<LineRenderer>();
        rb = GetComponent<Rigidbody2D>();
        tempsDeVie = 1.0f;
    }

    //Met les bon paramètres pour le grappin
    public void SetUpGrappin(Transform playerTransform, bool facingRight)
    {
        line.positionCount = 2;
        this.playerTransform = playerTransform;
        if(facingRight)
        {
            rb.velocity = speed * (new Vector2(45, 45)).normalized;
        }
        else
        {
            rb.velocity = speed * (new Vector2(-45, 45)).normalized;
        }
    }

    // Update is called once per frame
    private void Update() {
        if(tempsDeVie >= 0)
        {
            tempsDeVie -= Time.deltaTime;
            line.SetPosition(0, playerTransform.position);
            line.SetPosition(1, transform.position);
        }
        else if (playerTransform.gameObject.GetComponent<SC_Mouvement>().grapAccroche == false) 
        {
            playerTransform.gameObject.GetComponent<SC_Mouvement>().grapAccroche = false;
            playerTransform.gameObject.GetComponent<SC_Mouvement>().grapInstancier = false;
            Destroy(this.gameObject);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // On s'acroche et tire le joueur si on touche une surface
        if (collision.CompareTag("Surface"))
        {
            rb.velocity = Vector2.zero;
            playerTransform.gameObject.GetComponent<SC_Mouvement>().grapAccroche = true;

            playerRb = playerTransform.gameObject.GetComponent<Rigidbody2D>();
            Vector2 direction = (playerTransform.position - transform.position);
            playerRb.velocity = - direction.normalized * speed;
        }
    }
}