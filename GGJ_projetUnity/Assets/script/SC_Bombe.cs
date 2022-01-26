using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Bombe : MonoBehaviour
{
    private float tempsDeVie;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Boss"))
        {
            Exploser();
        }
    }

    // Fait l'explosion de la bombe et des dégats aux gens
    public void Exploser()
    {
        Debug.Log("BOUM !!");
        Destroy(this.gameObject);
    }
}
