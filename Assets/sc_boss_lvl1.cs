using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_boss_lvl1 : MonoBehaviour
{
    public int lvl = 10;
    public int vida = 500;
    public int exp = 300;
    public float RadioVision = 17.15f;
    public float rangoAtaque = 1.91f;
    Transform player;
    public bool derecha = true;
    public bool inicia_giro = false;
    public Transform attackPoint;
    public Animator animador;
    public int danoGarra = 100;
    public bool EstaAtacando = false;
    public bool EstaCorriendo = false;
    public int danoCarrera = 200;
    public GameObject deathWffect;
    public GameObject spawm_item;
    sc_Spawm_item loot;
    //-3.08,-1.86

    // Start is called before the first frame update
    void Start()
    {
        loot = spawm_item.GetComponentInChildren<sc_Spawm_item>();
    }

    // Update is called once per frame
    void Update()
    {

        Collider2D[] atackRage = Physics2D.OverlapCircleAll(attackPoint.position, rangoAtaque);
        foreach (Collider2D colider in atackRage)
        {
            if (colider != null)
            {
                if (colider.tag == "Player")
                {
                    if (!EstaAtacando) { 
                        animador.SetTrigger("Atack");
                        Personaje objetivo = colider.GetComponent<Personaje>();
                        StartCoroutine(atacar(0.25f,objetivo,danoGarra));
                    }
                }
            }
        }


        Collider2D[] hitEnemys = Physics2D.OverlapCircleAll(transform.position, RadioVision);
        foreach (Collider2D colider in hitEnemys)
        {
            if (colider != null)
            {
                if (colider.tag == "Player")
                {
                    player = colider.transform;

                    if (player.position.x>transform.position.x && !derecha && !inicia_giro) 
                    {

                        StartCoroutine(voltear(4f));
                    }
                    else if (player.position.x < transform.position.x && derecha && !inicia_giro)
                    {
                        StartCoroutine(voltear(4f));
                    }
                }
            }
        }


    }
    IEnumerator voltear(float segundos)
    {
        inicia_giro = true;

        yield return new WaitForSeconds(segundos);
       
        transform.Rotate(0f, 180f, 0f);
        derecha = !derecha;
        inicia_giro = false;
        
    }
    public int recivirDano(int dano) 
    {
        vida = vida - dano;
        if (vida<=0) 
        { 

            die();
            return exp;
        }
        else
        {
            return 0;
        }

    }

    public void die()
    {
        GameObject party = GameObject.FindGameObjectWithTag("Player");
        Personaje per = party.GetComponent<Personaje>();
        if (per.stats.escenario<2) 
        {
            per.stats.escenario = 2;
        }

        Vector3 ex1 = new Vector3(transform.position.x+1, transform.position.y);
        Vector3 ex2 = new Vector3(transform.position.x - 1, transform.position.y + 0.025f);
        Vector3 ex3 = new Vector3(transform.position.x + 0.25f, transform.position.y + 0.25f);

        Instantiate(deathWffect, ex1, Quaternion.identity);
        Instantiate(deathWffect, ex2, Quaternion.identity);
        Instantiate(deathWffect, ex3, Quaternion.identity);
        Instantiate(deathWffect, transform.position, Quaternion.identity);
        loot.SpawmItem(6, lvl + 2);
        Destroy(gameObject);
    }


    IEnumerator atacar(float segundos,Personaje personaje,int dano)
    {
        EstaAtacando = true;

        yield return new WaitForSeconds(segundos);
        personaje.Recibir_Dano(dano);

        EstaAtacando = false;

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (EstaCorriendo) {

            Personaje personaje= collision.gameObject.GetComponent<Personaje>();
            if (personaje!=null) 
            {
                personaje.Recibir_Dano(danoCarrera);     
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
       

        Gizmos.DrawWireSphere(transform.position, RadioVision);
        Gizmos.DrawWireSphere(attackPoint.position, rangoAtaque);


    }
}
