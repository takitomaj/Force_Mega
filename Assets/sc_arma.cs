using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class sc_arma : MonoBehaviour
{
    public Transform firepoint;
    public GameObject bullet;
    Personaje player;
    public float Cadencia = 4f;
    bool disparado = false;
    public float attackrate = 2f;
    float nextAttacktime = 0f;
    public float rotTest = 1f;
    void Start()
    {
        player = gameObject.GetComponent<Personaje>();  
    }

    public void Dispara()
    {
       
        if (Time.time >= nextAttacktime)
        {
            if (!disparado)
            {
                player.Shoot();
                GameObject bala= Instantiate(bullet, firepoint.position, firepoint.rotation);
                bala.GetComponent<sc_bullet>().player = gameObject;
                //player.unShoot();
                if (sc_equipamiento.Instancia.items[3].IDtipo == 1)
                {
                    attackrate = 3f;
                }
                else if (sc_equipamiento.Instancia.items[3].IDtipo == 2)
                {
                    attackrate = 3f;
                }
                else if (sc_equipamiento.Instancia.items[3].IDtipo == 3)
                {
                    attackrate = 2f;
                }
                else if (sc_equipamiento.Instancia.items[3].IDtipo == 4)
                {
                    attackrate = 0.9f;
                }
                else if (sc_equipamiento.Instancia.items[3].IDtipo == 5)
                {
                    
                    //posicion
                    Vector3 pos_bala2 = firepoint.position;
                    pos_bala2.y = pos_bala2.y + 0.3f;
                    Vector3 pos_bala3 = firepoint.position;
                    pos_bala3.y = pos_bala3.y - 0.3f;

                    GameObject bala2 = Instantiate(bullet, pos_bala2, firepoint.rotation);
                    GameObject bala3 = Instantiate(bullet, pos_bala3, firepoint.rotation);
                    attackrate = 1f;
                }
                nextAttacktime = Time.time + 1f / attackrate;
            }

        }

    }
    // Update is called once per frame
    private void Update()
    {
        
    }
    private void FixedUpdate()
    {
        if (Input.GetKeyDown("x")) 
        {
            
            Dispara();
        } 
    }
}
