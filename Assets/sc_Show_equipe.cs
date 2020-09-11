using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class sc_Show_equipe : MonoBehaviour
{
    public Image casco;
    public Image espada;
    public Image peto;
    //public SpriteRenderer sr_casco;
    //public SpriteRenderer sr_espada;
    //public SpriteRenderer sr_peto;
    public SpriteRenderer sr_arma;
    public float esperaEspada = 0.2f;
    public float esperapintar = 0.1f;
    public float esperaArma = 0.3f;
    
    // Start is called before the first frame update
    void Start()
    {
        espada.enabled = false;
        sr_arma.color = new Color(0, 0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (sc_equipamiento.Instancia.items[0] != null)
        {
            
            
            casco.enabled = true;
            casco.sprite = sc_equipamiento.Instancia.items[0].icono;
            casco.color = new Color(sc_equipamiento.Instancia.items[0].color[0],
                                   sc_equipamiento.Instancia.items[0].color[1],
                                   sc_equipamiento.Instancia.items[0].color[2],
                                   sc_equipamiento.Instancia.items[0].color[3]);
            casco.preserveAspect = true;
            
           
        }
        else{
            
            casco.enabled = false;
            
        }
        if (sc_equipamiento.Instancia.items[2] != null)
        {
           
            peto.enabled = true;
            peto.sprite = sc_equipamiento.Instancia.items[2].icono;
            peto.color = new Color(sc_equipamiento.Instancia.items[2].color[0],
                                   sc_equipamiento.Instancia.items[2].color[1],
                                   sc_equipamiento.Instancia.items[2].color[2],
                                   sc_equipamiento.Instancia.items[2].color[3]);
            
            peto.preserveAspect = true;



        }
        else {
            peto.enabled = false;
          
        }
       
       
    }
    public void showArma() 
    {
        StartCoroutine(EspadaArma());
    }
    public void showEspada()
    {
       


        StartCoroutine(EspadaEsperar(esperaEspada));
       

        

    }
    IEnumerator EspadaEsperar(float segundos)
    {
        yield return new WaitForSeconds(esperapintar);
        if (sc_equipamiento.Instancia.items[1] != null)
        {
          
            espada.enabled = true;
            espada.sprite = sc_equipamiento.Instancia.items[1].icono;
            espada.color = new Color(sc_equipamiento.Instancia.items[1].color[0],
                                    sc_equipamiento.Instancia.items[1].color[1],
                                    sc_equipamiento.Instancia.items[1].color[2],
                                    sc_equipamiento.Instancia.items[1].color[3]);
            espada.preserveAspect = true;

        }
        yield return new WaitForSeconds(segundos);
        espada.enabled = false;
    }
    /*IEnumerator MostrarDano(int i_dano)
    {
        dano.enabled = true;
        dano.text = i_dano + "";
        if (i_dano <= 10) { dano.fontSize = 5; }
        if (i_dano > 10 && i_dano <= 100) { dano.fontSize = 7; }
        if (i_dano > 100) { dano.fontSize = 9; }

        yield return new WaitForSeconds(5);

        //dano.enabled = false;

    }*/
    IEnumerator EspadaArma()
    {
        if (sc_equipamiento.Instancia.items[3] != null)
        {

            sr_arma.sprite = sc_equipamiento.Instancia.items[3].icono;
            sr_arma.color = new Color(sc_equipamiento.Instancia.items[3].color[0],
                                        sc_equipamiento.Instancia.items[3].color[1],
                                        sc_equipamiento.Instancia.items[3].color[2],
                                        sc_equipamiento.Instancia.items[3].color[3]);


        }

        yield return new WaitForSeconds(esperaArma);
        sr_arma.color = new Color(0, 0, 0, 0);

        
    }

}
