using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_boton : MonoBehaviour
{
    public bool estado = false;
    public Sprite apagado;
    public Sprite Encendido;
    public SpriteRenderer sr_boton;

    void Start()
    {
        //sr_boton = GetComponent<SpriteRenderer>();
        if (estado)
        {
            sr_boton.sprite = Encendido;
        }
        else
        {
            sr_boton.sprite = apagado;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (estado)
        {
            estado = false;
            sr_boton.sprite = apagado;
        }
        else 
        {
            estado = true;
            sr_boton.sprite = Encendido;
        }
    }
}
