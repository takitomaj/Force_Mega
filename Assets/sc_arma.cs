using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class sc_arma : MonoBehaviour
{
    public Transform firepoint;
    public GameObject bullet;
    public float Cadencia = 4f;
    bool disparado = false;
    void Start()
    {
        
    }

    public void Dispara()
    {
        if (!disparado) 
        { 
            Instantiate(bullet, firepoint.position, firepoint.rotation);
            
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
            Debug.Log("Disparando");
            Dispara();
        } 
    }
}
