using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SC_nbVictoire : MonoBehaviour
{
    private string nbVictoire;
    // Start is called before the first frame update
    void Start()
    {
        nbVictoire = SC_SceneVictoire.nbVictoirePlayer + " - " + SC_SceneVictoire.nbVictoireBoss;
        GetComponent<Text>().text = nbVictoire;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
