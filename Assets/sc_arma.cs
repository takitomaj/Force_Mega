using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class sc_arma : MonoBehaviour
{
    public Transform firepoint;
    public GameObject bullet;
    public Personaje player;
    public float Cadencia = 4f;
    bool disparado = false;
    public float attackrate = 2f;
    float nextAttacktime = 0f;
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
                Instantiate(bullet, firepoint.position, firepoint.rotation);
                //player.unShoot();
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
