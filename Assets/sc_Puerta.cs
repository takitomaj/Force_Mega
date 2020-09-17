using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_Puerta : MonoBehaviour
{
    public Animator animador;
    public List<GameObject> botones;
    public List<GameObject> enemigos;
    public Collider2D colicion;
    // Start is called before the first frame update
    void Start()
    {
        animador = GetComponent<Animator>(); 
    }
    public bool comprobar_Botones() 
    {
        bool Todos_encendidos = true;
        foreach (var boton in botones)
        {
            if (boton!=null) { 
                sc_boton scbotto = boton.GetComponent<sc_boton>();
                if (!scbotto.estado)
                {
                    Todos_encendidos = false;


                }
            }
        }
        return Todos_encendidos; 
    
    }
    public bool comprobar_Enemigo() 
    {
        bool salida = true;
        foreach (var enemigo in enemigos)
        {
            if (enemigo!=null) 
            {
                salida = false;
            }
            
        }
            return salida;
    }
    // Update is called once per frame
    void Update()
    {
        if (comprobar_Botones() && comprobar_Enemigo()) 
        {
            animador.SetBool("Abierta", true);
            colicion.enabled = false;
        }
        else    
        {
            animador.SetBool("Abierta", false);
            colicion.enabled = true;
        }
    }
    //Caso claro 73245359
}
