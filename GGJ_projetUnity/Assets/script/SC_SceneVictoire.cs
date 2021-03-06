using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SC_SceneVictoire : MonoBehaviour
{
    public bool isAnimVictory;
    public bool isMenuRejouer;
    private float tempAnimVictoire;
    private RectTransform recTrans;

    public static int nbVictoirePlayer;
    public static int nbVictoireBoss;

    // Start is called before the first frame update
    void Start()
    {
        tempAnimVictoire = 2.5f;
        if(isMenuRejouer)
        {
            recTrans = GetComponent<RectTransform>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(tempAnimVictoire >= 0)
        {
            tempAnimVictoire -= Time.deltaTime;
        }
        else
        {
            appear();
            die();
        }
    }

    private void appear()
    {
        if(isMenuRejouer)
        {
            recTrans.localPosition = new Vector3(0f, recTrans.localPosition.y, 0f);
        }
    }
    private void die()
    {
        if (isAnimVictory)
        {
            Destroy(gameObject);
        }
    }

    public void victoryToGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void goToMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void quitGame()
    {
        Application.Quit();
    }
}
