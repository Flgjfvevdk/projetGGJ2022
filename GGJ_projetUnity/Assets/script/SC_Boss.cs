using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Boss : MonoBehaviour
{
    public Transform bordHautGauche;
    public Transform bordHautDroit;

    public GameObject nuageFoudre;
    public int nbNuage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            spellFoudre();
        }
    }

    void spellFoudre()
    {
        float xGauche = bordHautGauche.transform.position.x;
        float xDroit = bordHautDroit.transform.position.x;
        float yPos = bordHautGauche.transform.position.y;
        for (int k = 0; k < nbNuage; k++)
        {
            GameObject nf = Instantiate(nuageFoudre, new Vector2( (k+1) * (xDroit - xGauche) / (nbNuage + 1) + xGauche, yPos), Quaternion.identity);
            nf.GetComponent<SC_NuageFoudre>().lauchStorm();
        }
        
    }
}
