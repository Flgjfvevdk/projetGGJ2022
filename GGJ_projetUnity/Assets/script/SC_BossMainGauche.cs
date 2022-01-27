using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_BossMainGauche : MonoBehaviour
{
    public float tempsDash;
    private float tempsAvantFin;
    private Vector3 posTarget;
    private Vector3 initialPos;
    private bool mustGo;
    // Start is called before the first frame update
    void Start()
    {
        tempsAvantFin = tempsDash;
    }

    private void Update()
    {
        if(mustGo )
        {
            if(tempsAvantFin <= 0)
            {
                transform.position = posTarget;
                mustGo = false;
                tempsAvantFin = tempsDash;
                initialPos = transform.position;
            } else
            {
                transform.position = initialPos * tempsAvantFin/tempsDash + posTarget * (tempsDash - tempsAvantFin)/tempsDash;
                tempsAvantFin -= Time.deltaTime;
            }

        }

        if (!mustGo)
        {
            if(Vector2.Distance(transform.position, transform.parent.position) != 0f)
            {
                if(tempsAvantFin <= 0)
                {
                    transform.position = transform.parent.position;
                    tempsAvantFin = tempsDash;
                    transform.parent.gameObject.GetComponent<SC_Boss>().cacDispo = true;
                }
                else
                {
                    transform.position = initialPos * tempsAvantFin/ tempsDash + transform.parent.position * (tempsDash - tempsAvantFin) / tempsDash;
                    tempsAvantFin -= Time.deltaTime;
                }
            }
        }
        
    }

    public void dash(Vector2 pos)
    {
        mustGo = true;
        posTarget = new Vector3(pos.x, pos.y, 0);
        initialPos = transform.position;
        tempsAvantFin = tempsDash;
    }
}
