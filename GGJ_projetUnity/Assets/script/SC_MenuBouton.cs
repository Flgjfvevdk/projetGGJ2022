using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SC_MenuBouton : MonoBehaviour
{
    public void MenuToGame()
    {
        //Debug.Log("Redirection vers le jeu");
        SceneManager.LoadScene("SampleScene");
    }
}
