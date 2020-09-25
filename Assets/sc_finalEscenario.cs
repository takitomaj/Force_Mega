using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_finalEscenario : MonoBehaviour
{
    public float Radio = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Collider2D[] hitEnemys = Physics2D.OverlapCircleAll(transform.position, Radio);
        foreach (Collider2D colider in hitEnemys)
        {
            if (colider != null)
            {
                if (colider.tag == "Player")
                {
                    Personaje per = colider.GetComponent<Personaje>();
                    sc_menu menu = new sc_menu();
                    per.saveStatus();
                    menu.PlayTest();
                   
                }
            }
        }
    }

    private void OnDrawGizmosSelected()
    {


        Gizmos.DrawWireSphere(transform.position, Radio);
        


    }
}
