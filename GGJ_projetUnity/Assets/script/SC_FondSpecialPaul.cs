using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SC_FondSpecialPaul : MonoBehaviour
{

    public static bool fondPaulActif = false;
    public Text texte;
    // Start is called before the first frame update
    void Start()
    {
        majtext();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void switchMode()
    {
        fondPaulActif = !fondPaulActif;
        majtext();
    }

    private void majtext()
    {
        if (fondPaulActif)
        {
            texte.text = "Fond special Paul : Oui";
        }
        else
        {
            texte.text = "Fond special Paul : Non";
        }
    }
}
