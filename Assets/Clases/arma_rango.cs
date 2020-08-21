using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class arma_rango : MonoBehaviour
{
    public Boolean equipada = true;
    public Rigidbody2D RB_Arma;
    public float jumpPower = 9.25f;
    // Start is called before the first frame update
    void Start()
    {
        if (!equipada) 
        { 
            RB_Arma = GetComponent<Rigidbody2D>();
            var randomInt = UnityEngine.Random.Range(0, 100);
            int D_I = randomInt;
            if (D_I >= 50)
            {
                RB_Arma.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
                RB_Arma.AddForce((jumpPower / 4) * Vector2.left, ForceMode2D.Impulse);
            }
            else
            {
                RB_Arma.AddForce(Vector2.up * jumpPower * Vector2.left, ForceMode2D.Impulse);
                RB_Arma.AddForce((jumpPower / 3) * Vector2.right, ForceMode2D.Impulse);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
