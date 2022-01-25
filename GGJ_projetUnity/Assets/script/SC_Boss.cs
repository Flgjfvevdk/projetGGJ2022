using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Boss : MonoBehaviour
{
    public Transform bordHautGauche;
    public Transform bordHautDroit;

    public GameObject nuageFoudre;
    public int nbNuage;

    GamepadControler controls;
    void Awake()
    {
        controls = new GamepadControler();

        controls.ClavierSouris.FoudrePouvoir.performed += ctx => spellFoudre();
    }

    // Update is called once per frame
    void Update()
    {
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

    private void OnEnable()
    {
        controls.ClavierSouris.Enable();
    }

    private void OnDisable()
    {
        controls.ClavierSouris.Disable();
    }
}
