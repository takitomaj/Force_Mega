using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_bullet : MonoBehaviour
{
    public int dano = 10;
    public float speed = 20f;
    public Rigidbody2D rb;
    public SpriteRenderer sprite;
    public GameObject explocionffect;
    public float lifeTime= 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        SpriteRenderer S_explo = explocionffect.GetComponent<SpriteRenderer>();
        S_explo.color = new Color(255,255,255,255);
        if (sc_equipamiento.Instancia.items[3] != null)
        {
            Color color_arma = new Color(sc_equipamiento.Instancia.items[3].color[0],
                sc_equipamiento.Instancia.items[3].color[1],
                sc_equipamiento.Instancia.items[3].color[2],
                sc_equipamiento.Instancia.items[3].color[3]);

            dano = sc_equipamiento.Instancia.items[3].Dano;
            sprite.color = color_arma;
            
            S_explo.color = color_arma;
            if (sc_equipamiento.Instancia.items[3].IDtipo == 1)
            {
                //pistola
                lifeTime = 0.3f;
            }
            else if (sc_equipamiento.Instancia.items[3].IDtipo == 2)
            {
                //buster
                lifeTime = 0.4f;
            }
            else if (sc_equipamiento.Instancia.items[3].IDtipo == 3)
            {
                //canon
                lifeTime = 0.2f;
            }
            else if(sc_equipamiento.Instancia.items[3].IDtipo == 4)
            {
                //sniper
                lifeTime = 3.0f;
            }else if (sc_equipamiento.Instancia.items[3].IDtipo==5) 
            {
                //shotgun
                lifeTime = 0.1f;
            }

        }
        else { 
            dano = 1; 
        }
        rb.velocity = transform.right * speed;
        Destroy(gameObject, lifeTime);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Bala") { 
            Instantiate(explocionffect, transform.position, Quaternion.identity);

            Enemy enemy = collision.GetComponent<Enemy>();

            if (enemy != null)
            {
                enemy.takeDamage(dano);
            }

            Destroy(gameObject);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
