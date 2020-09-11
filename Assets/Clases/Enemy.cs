using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int lvl = 1;
    public int health = 10;
    public int Exp = 1;
    public int dano = 10;
    public int tipo = 1;
    public GameObject deathWffect;
    
    public GameObject spawm_item;
    sc_Spawm_item loot;
    // Start is called before the first frame update
    public int takeDamage(int damage) 
    {
        health -= damage;

        if (health<=0) 
        {
            return Die();
        }
        return 0;
    }

    public int Die() 
    {
        
        Instantiate(deathWffect, transform.position, Quaternion.identity);
       
        //spawm item pruebas
        Debug.Log("SpawmItem( "+lvl+" )");
        if (tipo == 1)//minion
        {
            loot.SpawmItem(1, lvl);
        }
        else if (tipo == 2)//medio
        {
            loot.SpawmItem(3, lvl+1);
        }
        else if (tipo == 3)//medio
        {
            loot.SpawmItem(6, lvl+2);
        }

        Destroy(gameObject);
        return Exp;
    }

    

    void Start()
    {
        loot = spawm_item.GetComponentInChildren<sc_Spawm_item>();
        
        lvl = 1;
        if (tipo == 1)//minion
        {
            
            health = lvl * 10;
            Exp = lvl;
            dano = lvl * 5;
        }
        else if (tipo == 2) //medio o subjefe
        {
           
            health = lvl * 20;
            Exp = lvl * 2;
            dano = lvl * 10;
        }
        else if (tipo == 3)//jefe de nivel
        {
            
            health = lvl * 80;
            Exp = lvl + 5;
            dano = lvl * 20;
        }

    }
    public void setStatus(int NewLevel) 
    {
        if (tipo == 1)//minion
        {
            lvl = NewLevel;
            health = lvl * 10;
            Exp = lvl;
            dano = lvl * 5;
        }else if(tipo == 2) //medio o subjefe
        {
            lvl = NewLevel;
            health = lvl * 20;
            Exp = lvl*2;
            dano = lvl * 10;
        }
        else if (tipo == 3)//jefe de nivel
        {
            lvl = NewLevel;
            health = lvl * 80;
            Exp = lvl+5;
            dano = lvl * 20;
        }
    }
    // Update is called once per frame
    void Update()
    {
       
    }

   

   
}
