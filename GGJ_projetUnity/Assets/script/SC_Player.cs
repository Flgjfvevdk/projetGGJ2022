using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Player : MonoBehaviour
{
    public GameObject bouleGO;

    private Rigidbody2D rb;

    private bool tirDroite;

    public float tirRate;

    private float tempsAvantProchainTir;
    // Start is called before the first frame update
    void Start()
    {
        tirDroite = true;
        rb = GetComponent<Rigidbody2D>();
        tempsAvantProchainTir = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(rb.velocity.x != 0)
        {
            tirDroite = rb.velocity.x > 0;
        }

        if (Input.GetButton("Fire1") && tempsAvantProchainTir <= 0)
        {
            
            GameObject bouleTir = Instantiate(bouleGO, transform.position, Quaternion.identity);
            SC_BouleDeFeu scriptBoule = bouleTir.GetComponent<SC_BouleDeFeu>();
            if (scriptBoule)
            {
                if (tirDroite)
                {
                    scriptBoule.partir(Vector2.right);
                } else
                {
                    scriptBoule.partir(Vector2.left);
                }
                
            }
            tempsAvantProchainTir = tirRate;

        }

        if(tempsAvantProchainTir >= 0)
        {
            tempsAvantProchainTir -= Time.deltaTime;
        }
    }
}
