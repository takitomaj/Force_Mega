using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public int Exp = 10000;
    public GameObject deathWffect;
    public Transform party_players;
    Personaje[] players;
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
            Destroy(gameObject);
    }

    void Start()
    {
        players= party_players.GetComponentsInChildren<Personaje>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
