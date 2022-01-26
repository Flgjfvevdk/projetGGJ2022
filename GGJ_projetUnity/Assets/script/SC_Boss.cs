using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Boss : MonoBehaviour
{
    GamepadControler controls;

    //Boss
    private Rigidbody2D rb;
   
    //Sort foudre
    public Transform bordHautGauche;
    public Transform bordHautDroit;
    public GameObject nuageFoudre;
    public int nbNuage;

    //Sort BdF
    public GameObject BdFGO;
    public float tirRate;
    private float tempsAvantProchainTir;
    public bool tirEnCour;

    //Boutons pressés ou non
    private bool qPress;
    private bool sPress;
    private bool dPress;
    private bool jumpPress;


    public float speed;
    public float jumpVelocity;
    private float defValueGavity;
    public float maxHeight;
    void Awake()
    {
        controls = new GamepadControler();
        controls.ClavierSouris.q.performed += ctx => qPressed(true);
        controls.ClavierSouris.q.canceled += ctx => qPressed(false);

        controls.ClavierSouris.d.performed += ctx => dPressed(true);
        controls.ClavierSouris.d.canceled += ctx => dPressed(false);
        
        controls.ClavierSouris.Jump.performed += ctx => jumpPressed(true);
        controls.ClavierSouris.Jump.canceled += ctx => jumpPressed(false);

        controls.ClavierSouris.BdFPouvoir.performed += ctx => spellBdF();
        controls.ClavierSouris.FoudrePouvoir.performed += ctx => spellFoudre();
        controls.ClavierSouris.s.performed += ctx => spellChargeBas();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        defValueGavity = rb.gravityScale;
    }

    // Update is called once per frame
    void Update()
    {
        if(qPress)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
        }else if(dPress) {
            rb.velocity = new Vector2(speed, rb.velocity.y);
        }
        else {
            rb.velocity = new Vector2(0, rb.velocity.y);
        } 

        rb.gravityScale = defValueGavity;
        if(jumpPress && transform.position.y < maxHeight){
            
            if(transform.position.y > (maxHeight - 1))
            {
                rb.gravityScale = 0;
                rb.velocity = new Vector2(rb.velocity.x, 0);
            }
            else {
                rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);
            }
        }
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

    // BdF controlable
    void spellBdF()
    {
        if(!tirEnCour)
        {    
            GameObject bdf = Instantiate(BdFGO, transform.position, Quaternion.identity);
            SC_BouleDeFeu scriptBoule = bdf.GetComponent<SC_BouleDeFeu>();
            if (scriptBoule)
            {
                scriptBoule.partirControlable(rb);
            }
        }
    }

    void spellChargeBas()
    {
        rb.velocity = new Vector2(rb.velocity.x, -2*jumpVelocity);

        // Alors j'avait toujours 0 en distance car il se tirer dessus le boss
        // Donc au final j'ai passer le boss dans un layout ou il ignore les raycast donc pas besoins de layer mask
        // Cependant, c'est probablement plus propre avec ...
        // LayerMask mask = LayerMask.GetMask("Surface");   
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down);
        if (hit.collider != null)
        {
            float distance = Mathf.Abs(hit.point.y - transform.position.y);
            if(distance > 5)
            {
                //Dégat / grosse animation
                Debug.Log("Grosse chute");
            } else {
                //Pas de dégats / petit anim ?
                Debug.Log("Petit chute");
            }
        }
    }

    // Fonction bool état des touches
    void qPressed(bool b)
    {
        qPress = b;
    }
    void dPressed(bool b)
    {
        dPress = b;
    }
    void jumpPressed(bool b)
    {
        jumpPress = b;
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
