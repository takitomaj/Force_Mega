using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_plataforma : MonoBehaviour
{
    public Vector3 Velocidad;
    public bool Se_mueveve =false;
    public bool TieneComportamiento = false;
    int limInferior = 0;
    public int contador = 0;
    public int limSuperiro =1000;
    public bool horizontal = false;
    public bool vertical = true;
    public bool subiendo = true;
    public List<GameObject> botones;
    public List<GameObject> enemigos;
    // Start is called before the first frame update
    void Start()
    {
        SetDireccion();
    }

    // Update is called once per frame
    void Update()
    {
        if (TieneComportamiento)
        {
            if (comprobar_Botones() && comprobar_Enemigo())
            {

                Se_mueveve = true;
            }
            else
            {

                Se_mueveve = false;
            }
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        collision.collider.transform.SetParent(transform);
        
        
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.collider.transform.SetParent(null);
    }
    public void SetDireccion() 
    {
        if (vertical)
        {
            Velocidad = new Vector3(0, 1, 0);
        }
        else if (horizontal)
        {
            Velocidad = new Vector3(1, 0, 0);
        }

    }

    private void FixedUpdate()
    {
        SetDireccion();
        if (Se_mueveve) 
        {
            if (subiendo) { 

                if (contador<=(limSuperiro*100) ) {
                    transform.position += (Velocidad * Time.deltaTime);
                }
                else { 
                    subiendo = false; 
                }
                contador++;
            }
            else 
            {
                if (contador > 0)
                {
                    transform.position -= (Velocidad * Time.deltaTime);
                }
                else { subiendo = true; }
                contador--;
            }
           
        }
    }
    public bool comprobar_Botones()
    {
        bool Todos_encendidos = true;
        foreach (var boton in botones)
        {
            if (boton != null)
            {
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
            if (enemigo != null)
            {
                salida = false;
            }

        }
        return salida;
    }
}
