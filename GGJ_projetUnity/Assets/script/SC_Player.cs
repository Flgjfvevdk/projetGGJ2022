using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SC_Player : MonoBehaviour
{
    GamepadControler controls;
    public GameObject bouleGO;
    public GameObject bombeGO;

    //private Rigidbody2D rb; probablement inutile

    public GameObject sliderPlayer;
    public int hpPlayerMax;
    public int hpPlayer;

    public Transform livrePosition;
    public float tirRate;
    private float tempsAvantProchainTir;

    public float tempsInvicibilite;
    private float tempsRestantInvincible;
    private SpriteRenderer spritePl;

    public SC_Slider_Float sliderBombe;
    public float delaieRechargeBombe;
    private float timerRechargeBombe;
    public float bombeAngleDegre;
    public float vitesseInit;

    //Boutons pressés ou non
    private bool shotRight;
    private bool shotLeft;
    private bool dropBombe;

    private float tempsAvantResetDirection;

    
    // Créeation des controles 
    void Awake()
    {
        controls = new GamepadControler();

        controls.gamecontroler.ShootRight.performed += ctx => shotPressRight(true);
        controls.gamecontroler.ShootRight.canceled += ctx => shotPressRight(false);

        controls.gamecontroler.ShootLeft.performed += ctx => shotPressLeft(true);
        controls.gamecontroler.ShootLeft.canceled += ctx => shotPressLeft(false);

        controls.gamecontroler.Bombe.performed += ctx => bombepressed(true);
        controls.gamecontroler.Bombe.canceled += ctx => bombepressed(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        tempsAvantProchainTir = 0;

        dropBombe = false;
        timerRechargeBombe = 0.0f;
        sliderBombe.init(delaieRechargeBombe);
        sliderBombe.setValue(delaieRechargeBombe - timerRechargeBombe);

        hpPlayer = hpPlayerMax;
        sliderPlayer.GetComponent<SC_Slider>().init(hpPlayerMax);
        sliderPlayer.GetComponent<SC_Slider>().setValue(hpPlayer);
        tempsRestantInvincible = 0.0f;
        spritePl = GetComponent<SpriteRenderer>();

        tempsAvantResetDirection = 0.0f;
    }

    // Lance les sorts/Objets quand les boutons associers sont pressés
    void Update()
    {
        if ((shotRight|| shotLeft) && tempsAvantProchainTir <= 0)
        {
            
            GameObject bouleTir = Instantiate(bouleGO, livrePosition.position, Quaternion.identity);
            SC_BouleDeFeu scriptBoule = bouleTir.GetComponent<SC_BouleDeFeu>();
            if (scriptBoule)
            {
                if (shotRight)
                {
                    scriptBoule.partir(Vector2.right);
                    //GetComponent<SC_Mouvement>().facingRight = true;
                    GetComponent<SC_Mouvement>().shotRight = true;
                    GetComponent<SC_Mouvement>().shotLeft = false;
                } else
                {
                    scriptBoule.partir(Vector2.left);
                    //GetComponent<SC_Mouvement>().facingRight = false;
                    GetComponent<SC_Mouvement>().shotLeft = true;
                    GetComponent<SC_Mouvement>().shotRight = false;
                }
            }
            tempsAvantResetDirection = tirRate*1.2f; //Delaie avant de se retourner si le player tir dans la direction inverse de laquelle il avance
            tempsAvantProchainTir = tirRate;
        } else
        {
            //On ne tir pas

            //On fait ça pour laisser un petit delaie entre le dernier tir et le fait de se retourner
            if(tempsAvantResetDirection <= 0)
            {
                GetComponent<SC_Mouvement>().shotRight = false;
                GetComponent<SC_Mouvement>().shotLeft = false;
            } else
            {
                tempsAvantResetDirection -= Time.deltaTime;
            }
            
        }

        
        if (dropBombe && timerRechargeBombe <= 0) {
            GameObject bombe = Instantiate(bombeGO,transform.position, Quaternion.identity);
            int dir = 1;
            if (!GetComponent<SC_Mouvement>().facingRight)
            {
                dir = -1;
            }
            bombe.GetComponent<Rigidbody2D>().velocity = vitesseInit * new Vector2(dir * Mathf.Cos(bombeAngleDegre), Mathf.Sin(bombeAngleDegre));
            timerRechargeBombe = delaieRechargeBombe;
        }

        if(tempsAvantProchainTir >= 0)
        {
            tempsAvantProchainTir -= Time.deltaTime;
        }
        if(timerRechargeBombe >= 0)
        {
            timerRechargeBombe -= Time.deltaTime;
            sliderBombe.setValue(delaieRechargeBombe - timerRechargeBombe);
        }
    
        if(tempsRestantInvincible >= 0)
        {

            Color oldColor = spritePl.color;
            if(oldColor.a == 1)
            {
                spritePl.color = new Color(oldColor.r, oldColor.g, oldColor.b, 0.5f);
            }
            tempsRestantInvincible -= Time.deltaTime;
        } else if(spritePl.color.a != 1)
        {
            Color oldColor = spritePl.color;
            spritePl.color = new Color(oldColor.r, oldColor.g, oldColor.b, 1);
        }
    
    }

    // Fonction bool état des boutons
    void shotPressRight(bool b)
    {
        shotRight = b;
    }

    void shotPressLeft(bool b)
    {
        shotLeft = b;
    }

    void bombepressed(bool b)
    {
        dropBombe = b;
    }

    private void OnEnable()
    {
        controls.gamecontroler.Enable();
    }

    private void OnDisable()
    {
        controls.gamecontroler.Disable();
    }


    //Peut être appeler après un dash
    public void resetInvicibility()
    {
        tempsRestantInvincible = tempsInvicibilite;
    }

    //idem que au dessus mais surcharge la méthode pour rendre possible un reset avec un temps différent d'invincibilité
    public void resetInvicibility(float multiplicateur)
    {
        tempsRestantInvincible = multiplicateur * tempsInvicibilite;
    }

    public void getHitPlayer(int value)
    {
        if(tempsRestantInvincible <= 0)
        {
            //Debug.Log("Outch je suis touché ! ");
            tempsRestantInvincible = tempsInvicibilite;
            hpPlayer -= value;
            sliderPlayer.GetComponent<SC_Slider>().setValue(hpPlayer);
            GetComponent<SC_Mouvement>().timerRechargeBlink = 0;

            if(hpPlayer <= 0)
            {
                //Debug.Log("Finito !!! Boss gagne ! GG ! Bravo ! Trop Fort ! ez !");
                SC_SceneVictoire.nbVictoireBoss++;
                SceneManager.LoadScene("VictoireBoss");
            }
        }
    }

    public bool isInvicible()
    {
        return tempsRestantInvincible > 0;
    }

}
