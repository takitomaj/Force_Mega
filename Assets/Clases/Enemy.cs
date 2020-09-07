using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int lvl = 1;
    public int health = 10;
    public int Exp = 1;
    public int dano = 10;
    public GameObject deathWffect;
    public Transform party_players;
    Personaje[] players;
    public GameObject spawm_item;
    sc_Spawm_item loot;
    // Start is called before the first frame update
    public void takeDamage(int damage) 
    {
        health -= damage;

        if (health<=0) 
        {
            Die();
        }
    }

    public void Die() 
    {
        
        Instantiate(deathWffect, transform.position, Quaternion.identity);
        for (int i = 0; i < players.Length; i++)
        {
            players[i].GanarEXP(Exp);
        }
        //spawm item pruebas
        Debug.Log("SpawmItem( "+lvl+" )");
        loot.SpawmItem(5,lvl);
        Destroy(gameObject);
    }

    

    void Start()
    {
        loot = spawm_item.GetComponentInChildren<sc_Spawm_item>();
        players= party_players.GetComponentsInChildren<Personaje>();
        lvl = GetMaxlvl();
        health = lvl*10;
        Exp = lvl;
        dano = lvl * 5;

    }
    public int GetMaxlvl() {
        int salida = 1;
        for (int i = 0; i < players.Length; i++)
        {
            if (salida< players[i].stats.lvl) 
            {
                Debug.Log("nivel: " + players[i].stats.lvl);
                salida = players[i].stats.lvl;   
            }
         
        }

        return salida;
    }
    // Update is called once per frame
    void Update()
    {
       
    }

   

   
}
