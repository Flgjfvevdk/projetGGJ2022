using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Player : MonoBehaviour
{
    public GameObject bouleGO;

    private Rigidbody2D rb;


    public float tirRate;
    private float tempsAvantProchainTir;

    private bool shotRight;
    private bool shotLeft;
    //private bool tirDroite;

    GamepadControler controls;

    void Awake()
    {
        controls = new GamepadControler();

        controls.gamecontroler.ShootRight.performed += ctx => shotPressRight(true);
        controls.gamecontroler.ShootRight.canceled += ctx => shotPressRight(false);

        controls.gamecontroler.ShootLeft.performed += ctx => shotPressLeft(true);
        controls.gamecontroler.ShootLeft.canceled += ctx => shotPressLeft(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        //tirDroite = true;
        //rb = GetComponent<Rigidbody2D>();
        tempsAvantProchainTir = 0;
    }

    // Update is called once per frame
    void Update()
    {
        //if(rb.velocity.x != 0)
        //{
        //    tirDroite = rb.velocity.x > 0;
        //}

        //if (Input.GetButton("Fire1") && tempsAvantProchainTir <= 0)
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

        }

        if(tempsAvantProchainTir >= 0)
        {
            tempsAvantProchainTir -= Time.deltaTime;
        }
    }


    void shotPressRight(bool b)
    {
        shotRight = b;
    }

    void shotPressLeft(bool b)
    {
        shotLeft = b;
    }

    private void OnEnable()
    {
        controls.gamecontroler.Enable();
    }

    private void OnDisable()
    {
        controls.gamecontroler.Disable();
    }
}
