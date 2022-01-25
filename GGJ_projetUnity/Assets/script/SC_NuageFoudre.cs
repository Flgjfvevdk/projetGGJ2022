using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_NuageFoudre : MonoBehaviour
{
    public GameObject foudre;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void lauchStorm()
    {
        GameObject fdr = Instantiate(foudre, transform.position, Quaternion.identity);
        if (fdr)
        {
            SC_Foudre fdrScript = fdr.GetComponentInChildren<SC_Foudre>();
            if (fdrScript)
            {
                fdrScript.nuage = this.gameObject;
            }
        }

    }

}
