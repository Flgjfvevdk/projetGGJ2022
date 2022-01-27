using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Bombe : MonoBehaviour
{
    private float tempsDeVie;
    public GameObject explosion;
    public float rayonExplosion;
    // Start is called before the first frame update
    void Awake()
    {
        tempsDeVie = 3.0f;
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
            Exploser();            
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Boss"))
        {
            Exploser();
        }
    }

    //private void OnTriggerEnter2D(Collider2D collision) 
    //{
    //    if (collision.CompareTag("Boss"))
    //    {
    //        Exploser();
    //    }
    //}

    // Fait l'explosion de la bombe et des dégats aux gens
    public void Exploser()
    {
        Instantiate(explosion, transform.position, Quaternion.identity) ;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, rayonExplosion);
        GameObject bossObj = null;
        foreach(Collider2D c in colliders)
        {
            if (c.gameObject.CompareTag("Boss"))
            {
                bossObj = c.gameObject;
            }
        }
        if (bossObj)
        {
            Debug.Log("Bombe sur le boss");
            bossObj.gameObject.GetComponent<SC_Boss>().getHitBoss(2);
        }

        //Debug.Log("BOUM !!");
        Destroy(this.gameObject);
    }

    void OnDrawGizmos()
    {
        // Draw a red cricle autour de la bombre
        UnityEditor.Handles.color = Color.red;
        UnityEditor.Handles.DrawWireDisc(transform.position, Vector3.back, rayonExplosion);
    }
}
