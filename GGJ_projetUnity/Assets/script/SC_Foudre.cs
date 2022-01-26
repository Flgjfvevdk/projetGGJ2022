using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Foudre : MonoBehaviour
{
    private Collider2D hitBox;


    [System.NonSerialized]
    public GameObject nuage;

    
    public bool estActif;

    // Start is called before the first frame update
    void Start()
    {
        hitBox = GetComponent<Collider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(estActif)
        {
            List<Collider2D> colliders = new List<Collider2D>();
            hitBox.OverlapCollider(new ContactFilter2D(), colliders);
            foreach(Collider2D col in colliders)
            {
                if (col.CompareTag("Player"))
                {
                    SC_Player plScript = col.gameObject.GetComponent<SC_Player>();
                    if (plScript != null)
                    {
                        plScript.getHit();
                    } else
                    {
                        Debug.LogWarning("Ya très probablement un problème");
                    }
                }
                
            }
            
        }
    }

    public void die()
    {
        if (nuage != null)
        {
            Destroy(nuage);
        }
        Destroy(transform.parent.gameObject);
        //Destroy(gameObject);
    }


}
