using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Foudre : MonoBehaviour
{
    public float delaie;
    private float timeBfrStorm;
    private Collider2D hitBox;

    public SpriteRenderer sprite;

    [System.NonSerialized]
    public GameObject nuage;

    // Start is called before the first frame update
    void Start()
    {
        timeBfrStorm = delaie;
        hitBox = GetComponent<Collider2D>();
        sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(timeBfrStorm <= 0)
        {
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 1);
            List<Collider2D> colliders = new List<Collider2D>();
            hitBox.OverlapCollider(new ContactFilter2D(), colliders);
            foreach(Collider2D col in colliders)
            {
                if (col.CompareTag("Player"))
                {
                    Debug.Log(col.gameObject.name);
                }
                
            }
            StartCoroutine(DieWithDelaie(1.0f));
            
        }
        else
        {
            sprite.color = new Color(sprite.color.r, sprite.color.g, sprite.color.b, 0.5f * (delaie - timeBfrStorm)/delaie);
            timeBfrStorm -= Time.deltaTime;
        }
    }

    IEnumerator DieWithDelaie(float d)
    {
        yield return new WaitForSeconds(d);
        if(nuage != null)
        {
            Destroy(nuage);
        }
        Destroy(gameObject);
        
    }
}
