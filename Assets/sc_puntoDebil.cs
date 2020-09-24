using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_puntoDebil : MonoBehaviour
{
    public GameObject boss;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public int RecivirDanoCritico(int dano) 
    {
        sc_boss_lvl1 bosslvl1 = boss.GetComponent<sc_boss_lvl1>();
        if (bosslvl1!=null) 
        {
            int danoAumentado = Convert.ToInt32(dano * 1.5f);
            return bosslvl1.recivirDano(danoAumentado);
        }
        else
        {
            return 0;
        }
    }
}
