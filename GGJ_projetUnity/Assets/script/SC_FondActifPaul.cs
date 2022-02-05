using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_FondActifPaul : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (SC_FondSpecialPaul.fondPaulActif)
        {
            GetComponent<SpriteRenderer>().enabled = true;
        } else
        {
            GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
