using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Player : MonoBehaviour
{
    GamepadControler controls;
    public GameObject bouleGO;
    public GameObject bombeGO;

    //private Rigidbody2D rb; probablement inutile


    public float tirRate;
    private float tempsAvantProchainTir;

    public float tempsInvicibilite;
    private float tempsRestantInvincible;
    private SpriteRenderer spritePl;

    //Boutons pressés ou non
    private bool shotRight;
    private bool shotLeft;
    private bool dropBombe;

    
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

        tempsRestantInvincible = 0.0f;
        spritePl = GetComponent<SpriteRenderer>();
    }

    // Lance les sorts/Objets quand les boutons associers sont pressés
    void Update()
    {
        if ((shotRight|| shotLeft) && tempsAvantProchainTir <= 0)
        {
            
            GameObject bouleTir = Instantiate(bouleGO, transform.position, Quaternion.identity);
            SC_BouleDeFeu scriptBoule = bouleTir.GetComponent<SC_BouleDeFeu>();
            if (scriptBoule)
            {
                if (shotRight)
                {
                    scriptBoule.partir(Vector2.right);
                } else
                {
                    scriptBoule.partir(Vector2.left);
                }
            }
            tempsAvantProchainTir = tirRate;
        } else if (dropBombe && tempsAvantProchainTir <= 0) {
            GameObject bombe = Instantiate(bombeGO,transform.position, Quaternion.identity);
            tempsAvantProchainTir = tirRate;
        }

        if(tempsAvantProchainTir >= 0)
        {
            tempsAvantProchainTir -= Time.deltaTime;
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

    public void getHit()
    {
        if(tempsRestantInvincible <= 0)
        {
            Debug.Log("Outch je suis touché ! ");
            tempsRestantInvincible = tempsInvicibilite;
        }
    }
}
