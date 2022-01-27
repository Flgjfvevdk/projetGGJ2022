using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_Boss : MonoBehaviour
{
    GamepadControler controls;

    //Boss
    private Rigidbody2D rb;
    private bool bossFacingRight;

    //pv
    public SC_Slider sliderBoss;
    public int hpBossMax;
    public int hpBoss;
   
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

    //Sort Charge Bas
    private bool chargeBasEnCour;

    //Sort Cac
    public float hitboxSize;

    //Boutons pressés ou non
    private bool qPress;
    private bool sPress;
    private bool dPress;
    private bool jumpPress;


    public float speed;
    public float jumpVelocity;
    private float defValueGavity;
    public float maxHeight;
    private Animator anim;

    public GameObject groupNuagePrefab;
    public float tempsRechargeFoudre;
    private float cooldownFoudre;
    private GameObject groupNuage;
    public float tempsDeplacementNuage;
    private float tempsAvantFinDeplNuage;
    public SpriteRenderer elecSprite;

    public SpriteRenderer mainGaucheRougeSprite;
    public Transform boutMainGauche;
    public GameObject mainGaucheGO;
    private bool attCacCharge;
    public float delaieAttCac;
    private float timeBfrAttCac;

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
        controls.ClavierSouris.CacPouvoir.performed += ctx => chargeSpellCac();
        controls.ClavierSouris.s.performed += ctx => spellChargeBas();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        defValueGavity = rb.gravityScale;
        bossFacingRight = false;
        anim = GetComponent<Animator>();
        attCacCharge = false;
        hpBoss = hpBossMax;
        sliderBoss.init(hpBossMax);
        sliderBoss.setValue(hpBoss);
        // Debug.Log(sliderBoss.);
        chargeBasEnCour = false;
        cooldownFoudre = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        //Deplacement nuages
        Rigidbody2D rbTarget;
        if (groupNuage)
        {
            rbTarget = groupNuage.GetComponent<Rigidbody2D>();
        } else
        {
            rbTarget = rb;
        }

        //Deplacement boss
        if (qPress)
        {
            rbTarget.velocity = new Vector2(-speed, rbTarget.velocity.y);
            bossFacingRight = false;
            bossMajDirection();
        }
        else if(dPress) {
            rbTarget.velocity = new Vector2(speed, rbTarget.velocity.y);
            bossFacingRight = true;
            bossMajDirection();
        }
        else {
            rbTarget.velocity = new Vector2(0, rbTarget.velocity.y);
        } 

        // Levitation boss
        rb.gravityScale = defValueGavity;
        float dist = distToSol();
        if(jumpPress && dist < maxHeight){
            
            if(dist > (maxHeight - 1))
            {
                rb.gravityScale = 0;
                rb.velocity = new Vector2(rb.velocity.x, 0);
            }
            else {
                rb.velocity = new Vector2(rb.velocity.x, jumpVelocity);
            }
        }

        //Foudre
        if (groupNuage)
        {
            if(tempsAvantFinDeplNuage <= 0)
            {
                foreach(Transform child in groupNuage.transform)
                {
                    child.gameObject.GetComponent<SC_NuageFoudre>().lauchStorm();
                }
                groupNuage.transform.DetachChildren();
                Destroy(groupNuage);
                elecSprite.enabled = false;
            } else
            {
                tempsAvantFinDeplNuage -= Time.deltaTime;
            }
        }

        //Precharge de l'attaque Corps à Corps
        if (attCacCharge) 
        { 
            if(timeBfrAttCac <= 0)
            {
                spellCac();
                attCacCharge = false;
                mainGaucheRougeSprite.color = new Color(1, 1, 1, 0);
            } else
            {
                mainGaucheRougeSprite.color = new Color(1,1,1, Mathf.Min( (2.0f*(delaieAttCac - timeBfrAttCac) / delaieAttCac), 1.0f));
                //mainGaucheRougeSprite.color = Color.white;
                timeBfrAttCac -= Time.deltaTime;
            }
        }


        //Cooldown des Attaques

        //Cooldown de la foudre
        if(cooldownFoudre >= 0)
        {
            cooldownFoudre -= Time.deltaTime;
        }
    
    }

    void spellFoudre()
    {
        if(cooldownFoudre <= 0)
        {
            float xGauche = bordHautGauche.transform.position.x;
            float xDroit = bordHautDroit.transform.position.x;
            float yPos = bordHautGauche.transform.position.y - 1.5f;
            groupNuage = Instantiate(groupNuagePrefab, Vector3.zero, Quaternion.identity);
            rb.velocity = Vector2.zero;
            elecSprite.enabled = true;
            for (int k = 0; k < nbNuage; k++)
            {
                GameObject nf = Instantiate(nuageFoudre, new Vector2((k + 1) * (xDroit - xGauche) / (nbNuage + 1) + xGauche, yPos), Quaternion.identity);
                nf.transform.parent = groupNuage.transform;
                //nf.GetComponent<SC_NuageFoudre>().lauchStorm();
            }
            tempsAvantFinDeplNuage = tempsDeplacementNuage;
            cooldownFoudre = tempsRechargeFoudre;
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

            tirEnCour = true;
        }
    }

    void spellChargeBas()
    {
        jumpPressed(false); //Permet de faire en sorte que la charge force le boss a descendre

        rb.velocity = new Vector2(rb.velocity.x, -2*jumpVelocity);

        float distance = distToSol();
        if (distance > 6)
        {
            //Dégat / grosse animation
            Debug.Log("Grosse chute");
            anim.SetBool("SmashBas", true);
            chargeBasEnCour = true;            
        }
    }
    

    void chargeSpellCac()
    {
        attCacCharge = true;
        timeBfrAttCac = delaieAttCac;
    }

    void spellCac()
    {
        Collider2D[] colliders;
        if (bossFacingRight)
        {
            colliders = Physics2D.OverlapBoxAll(transform.position + new Vector3(hitboxSize/2.0f, 0, 0), new Vector2(hitboxSize,2) , 0f);
            mainGaucheGO.GetComponent<SC_BossMainGauche>().dash(transform.position + new Vector3(hitboxSize + boutMainGauche.localPosition.x, 0, 0) );
        } else {
            colliders = Physics2D.OverlapBoxAll(transform.position - new Vector3(hitboxSize/2.0f, 0, 0), new Vector2(hitboxSize,2), 0f);
            mainGaucheGO.GetComponent<SC_BossMainGauche>().dash(transform.position - new Vector3(hitboxSize + boutMainGauche.localPosition.x, 0, 0));
        }
        
        collidersWithPlayer(colliders);
    }

    //Regarde si le joueur est dans le colliders, si oui le hit sinon rien
    private void collidersWithPlayer(Collider2D[] colliders)
    {
        GameObject playerGO = null;
        foreach(Collider2D c in colliders)
        {
            if (c.gameObject.CompareTag("Player"))
            {
                playerGO = c.gameObject;
            }
        }

        if (playerGO)
        {
            // Debug.Log("J'ai touché le Player");
            //Faire des degats au Player;
            playerGO.GetComponent<SC_Player>().getHitPlayer(1);
        }
    }

    // Orientation du boss en fonction de ses mouvements
    void bossMajDirection()
    {
        if (bossFacingRight)
        {
            transform.localScale = new Vector2(- Mathf.Abs(transform.localScale.x), transform.localScale.y);
        } else
        {
            transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x), transform.localScale.y);
        }
        
    }

    private float distToSol(){
        RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, Vector2.down);
        foreach (RaycastHit2D hit in hits)
        {
            LayerMask hitlayer = hit.transform.gameObject.layer;
            if ((hitlayer == LayerMask.NameToLayer("Ground") || hitlayer == LayerMask.NameToLayer("Plateforme")) && hit.collider != null)
            {
                float distance = Mathf.Abs(hit.point.y - transform.position.y);
                return distance;
            }
        }
        return Mathf.Infinity;
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

        
    // Fonction pour le GamepadControler
    private void OnEnable()
    {
        controls.ClavierSouris.Enable();
    }

    private void OnDisable()
    {
        controls.ClavierSouris.Disable();
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Surface") || collision.gameObject.CompareTag("Plateforme"))
        {
            anim.SetBool("SmashBas", false);

            if(chargeBasEnCour)
            {
                Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, new Vector2(hitboxSize/1.5f, 2.5f) , 0f);
                collidersWithPlayer(colliders);
                chargeBasEnCour = false;
            }
        }
    }


    public void getHitBoss(int value)
    {
        Debug.Log("-1hp Boss ! ");
        hpBoss -= value;
        sliderBoss.setValue(hpBoss);

        if (hpBoss <= 0)
        {
            Debug.Log("Player gagne ! Mais comment a t'il fait face a un tel monstre !?! C'est un cheater !");
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<SC_Player>().getHitPlayer(1);
        }
    }

    // Aide visualisation hitbox
    // void OnDrawGizmos()
    // {
    //     UnityEditor.Handles.color = Color.red;
    //     //hitbox charge bas
    //     UnityEditor.Handles.DrawWireCube(transform.position, new Vector3(hitboxSize/1.5f, 2.5f, 0));
    //     //hitbox cac
    //     UnityEditor.Handles.DrawWireCube(transform.position + new Vector3(hitboxSize/2.0f, 0, 0), new Vector2(hitboxSize,2));
    // }


}
