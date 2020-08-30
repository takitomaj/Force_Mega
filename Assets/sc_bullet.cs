using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_bullet : MonoBehaviour
{
    public int dano = 10;
    public float speed = 20f;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        if (sc_equipamiento.Instancia.items[3] != null)
        {
            dano = sc_equipamiento.Instancia.items[3].Dano;
        }
        else { 
            dano = 1; 
        }
        rb.velocity = transform.right * speed;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {

        Enemy enemy = collision.GetComponent<Enemy>();

        if(enemy != null) 
        {
            enemy.takeDamage(dano);
        }
        Destroy(gameObject);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
