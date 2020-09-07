using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_espada : MonoBehaviour
{
    public Transform swordPoint;
    public float radio_espada = 0.5f;
    public LayerMask enemylayer;
    public int dano = 1;
    public Personaje player;

    public float attackrate = 2f;
    float nextAttacktime = 0f;
    // Start is called before the first frame update
    void Start()
    {
        player = gameObject.GetComponent<Personaje>();
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void atack()
    {
        if (Time.time>=nextAttacktime) { 
            player.melee_atack();
            ///////////////////
            dano = player.stats.Fuerza + player.stats.Constitucion;

            if (sc_equipamiento.Instancia.items[1] != null)
            {
                dano = dano + sc_equipamiento.Instancia.items[1].Dano;
            }

            //////////////////

            Collider2D[] hitEnemys = Physics2D.OverlapCircleAll(swordPoint.position, radio_espada);

            foreach (Collider2D colider in hitEnemys)
            {

                Enemy enemy = colider.GetComponent<Enemy>();

                if (enemy != null)
                {

                    enemy.takeDamage(dano);
                }
            }
            nextAttacktime = Time.time + 1f / attackrate;
        }
    }
    
    private void OnDrawGizmosSelected()
    {
        if (swordPoint == null)
            return;

        Gizmos.DrawWireSphere(swordPoint.position, radio_espada);
    }
}
