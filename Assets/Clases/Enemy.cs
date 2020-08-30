using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 100;

    public GameObject deathWffect;
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
        Destroy(gameObject);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
