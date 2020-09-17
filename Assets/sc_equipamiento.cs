using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;
using UnityEngine.UI;

public class sc_equipamiento : MonoBehaviour
{
    #region Singelton
    public static sc_equipamiento Instancia;
    public Transform jugador;
    Personaje Personaje;
    personaje_MP personajeMP;
    public Text statusText;
    public delegate void OnItemChaged();
    public OnItemChaged onItemChangedCallBack;
    public bool isNetWorkPlay= false;
    public Item[] items = new Item[4];  //0: casco
                                        //1: Melee
                                        //2: Peto
                                        //3: arma
    void Awake()
    {
        if (Instancia != null)
        {
            Debug.LogWarning("existe otra instacia del inventario");
            return;
        }
        Instancia = this;
    }
    #endregion Singelton

    

    public void AddCasco(Item Newitem)
    {
        if (items[0] != null)
        {
            Item itemTemp = items[0];
            items[0] = Newitem;
            sc_Inventario.Instancia.AddItem(itemTemp);
        }
        else
        {
            items[0] = Newitem;
        }
    }
    public void AddMelee(Item Newitem)
    {
        if (items[1] != null)
        {
            Item itemTemp = items[1];
            items[1] = Newitem;
            sc_Inventario.Instancia.AddItem(itemTemp);
        }
        else
        {
            items[1] = Newitem;
        }
    }
    public void AddPeto(Item Newitem)
    {
        if (items[2] != null)
        {
            Item itemTemp = items[2];
            items[2] = Newitem;
            sc_Inventario.Instancia.AddItem(itemTemp);
        }
        else
        {
            items[2] = Newitem;
        }
    }
    public void AddArma(Item Newitem)
    {
        if (items[3] != null)
        {
            Item itemTemp = items[3];
            items[3] = Newitem;
            sc_Inventario.Instancia.AddItem(itemTemp);
        }
        else
        {
            items[3] = Newitem;
        }
    }

    /**
     * 0: casco
     * 1: Melee
     * 2: Peto
     * 3: arma
     */
    public void AddItemByID(Item Newitem,int id)
    {
        if (items[id] != null)
        {
            Item itemTemp = items[id];
            items[id] = Newitem;
            sc_Inventario.Instancia.AddItem(itemTemp);
            
        }
        else
        {
            items[id] = Newitem;
            
        }
        //onItemChangedCallBack.Invoke();
    }

    public void Remove(int id) 
    {
        sc_equipamiento.Instancia.items[id] = null;
    }
    void Start()
    {
        //items[0] = null;
        //items[1] = null;
        //items[2] = null;
        //items[3] = null;

    }
    public int getModConstitucion()
    {
        int salida = 0;
        for (int i = 0; i <= 3; i++)
        {
            if (items[i] != null)
            {
                salida = salida + items[i].ModConstitucion;
            }
        }
        return salida;
    }
    public int getModVelocidad()
    {
        int salida = 0;
        for (int i = 0; i <= 3; i++)
        {
            if (items[i] != null)
            {
                salida = salida + items[i].ModVelocidad;
            }
        }
        return salida;
    }
    public int getModFuerza() 
    {
        int salida = 0;
        for (int i = 0; i <= 3; i++)
        {
            if (items[i] != null) { 
            salida = salida + items[i].ModFuerza; 
            }
        }
        return salida;
    }
    public void UpdateStatus()
    {
        Personaje = jugador.GetComponent<Personaje>();
        int sumaFuerza = Personaje.stats.Fuerza + getModFuerza();
        int sumaConstitucion = Personaje.stats.Constitucion + getModConstitucion();
        int sumaVel = Personaje.stats.Velocidad + getModVelocidad();
        int rango = 1;
        int melee = Personaje.stats.Fuerza + Personaje.stats.Constitucion + getModFuerza();
        int melee_total = 0;
        int dano_arma_melee = 0;
        if (sc_equipamiento.Instancia.items[3] != null) 
        {
            rango = sc_equipamiento.Instancia.items[3].Dano; 
        }
        if (sc_equipamiento.Instancia.items[1] != null) 
        {
            dano_arma_melee = sc_equipamiento.Instancia.items[1].Dano;
        }
        melee_total = melee + dano_arma_melee;
        statusText.text = Personaje.stats.Nombre+" lvl. "+Personaje.stats.lvl+"";
        statusText.text = statusText.text + "\n  Exp:  " + Personaje.stats.Exp + " / " + Personaje.stats.Next_lvl;
        statusText.text = statusText.text + "\n  Vida:  " + Personaje.stats.vida + " / " + Personaje.stats.vida_maxima ;

        statusText.text = statusText.text+  "\n  frz: "   + getModFuerza() +" + "+ Personaje.stats.Fuerza + "  = "+sumaFuerza+ "" ;
        statusText.text = statusText.text + "\n  def: " + getModConstitucion() + " + " + Personaje.stats.Constitucion + "  = " + sumaConstitucion + "";
        statusText.text = statusText.text + "\n  vel: " + getModVelocidad() + " + " + Personaje.stats.Velocidad + "  = " + sumaVel + "";
        statusText.text = statusText.text + "\n";
        statusText.text = statusText.text + "\n  Rango: " + rango;
        statusText.text = statusText.text + "\n  melee: " +dano_arma_melee+ " + "+ melee+ "  = " + melee_total;




    }
    // Update is called once per frame
    public void UpdateStatus(bool multiplayer)
    {
        if (multiplayer) { 
            personajeMP = jugador.GetComponent<personaje_MP>();
            int sumaFuerza = personajeMP.stats.Fuerza + getModFuerza();
            int sumaConstitucion = personajeMP.stats.Constitucion + getModConstitucion();
            int sumaVel = personajeMP.stats.Velocidad + getModVelocidad();
            int rango = 1;
            int melee = personajeMP.stats.Fuerza + personajeMP.stats.Constitucion + getModFuerza();
            int melee_total = 0;
            int dano_arma_melee = 0;
            if (sc_equipamiento.Instancia.items[3] != null)
            {
                rango = sc_equipamiento.Instancia.items[3].Dano;
            }
            if (sc_equipamiento.Instancia.items[1] != null)
            {
                dano_arma_melee = sc_equipamiento.Instancia.items[1].Dano;
            }
            melee_total = melee + dano_arma_melee;
            statusText.text = personajeMP.stats.Nombre + " lvl. " + personajeMP.stats.lvl + "";
            statusText.text = statusText.text + "\n  Exp:  " + personajeMP.stats.Exp + " / " + personajeMP.stats.Next_lvl;
            statusText.text = statusText.text + "\n  Vida:  " + personajeMP.stats.vida + " / " + personajeMP.stats.vida_maxima;

            statusText.text = statusText.text + "\n  frz: " + getModFuerza() + " + " + personajeMP.stats.Fuerza + "  = " + sumaFuerza + "";
            statusText.text = statusText.text + "\n  def: " + getModConstitucion() + " + " + personajeMP.stats.Constitucion + "  = " + sumaConstitucion + "";
            statusText.text = statusText.text + "\n  vel: " + getModVelocidad() + " + " + personajeMP.stats.Velocidad + "  = " + sumaVel + "";
            statusText.text = statusText.text + "\n";
            statusText.text = statusText.text + "\n  Rango: " + rango;
            statusText.text = statusText.text + "\n  melee: " + dano_arma_melee + " + " + melee + "  = " + melee_total;
        }
        else 
        {
            Personaje = jugador.GetComponent<Personaje>();
            int sumaFuerza = Personaje.stats.Fuerza + getModFuerza();
            int sumaConstitucion = Personaje.stats.Constitucion + getModConstitucion();
            int sumaVel = Personaje.stats.Velocidad + getModVelocidad();
            int rango = 1;
            int melee = Personaje.stats.Fuerza + Personaje.stats.Constitucion + getModFuerza();
            int melee_total = 0;
            int dano_arma_melee = 0;
            if (sc_equipamiento.Instancia.items[3] != null)
            {
                rango = sc_equipamiento.Instancia.items[3].Dano;
            }
            if (sc_equipamiento.Instancia.items[1] != null)
            {
                dano_arma_melee = sc_equipamiento.Instancia.items[1].Dano;
            }
            melee_total = melee + dano_arma_melee;
            statusText.text = Personaje.stats.Nombre + " lvl. " + Personaje.stats.lvl + "";
            statusText.text = statusText.text + "\n  Exp:  " + Personaje.stats.Exp + " / " + Personaje.stats.Next_lvl;
            statusText.text = statusText.text + "\n  Vida:  " + Personaje.stats.vida + " / " + Personaje.stats.vida_maxima;

            statusText.text = statusText.text + "\n  frz: " + getModFuerza() + " + " + Personaje.stats.Fuerza + "  = " + sumaFuerza + "";
            statusText.text = statusText.text + "\n  def: " + getModConstitucion() + " + " + Personaje.stats.Constitucion + "  = " + sumaConstitucion + "";
            statusText.text = statusText.text + "\n  vel: " + getModVelocidad() + " + " + Personaje.stats.Velocidad + "  = " + sumaVel + "";
            statusText.text = statusText.text + "\n";
            statusText.text = statusText.text + "\n  Rango: " + rango;
            statusText.text = statusText.text + "\n  melee: " + dano_arma_melee + " + " + melee + "  = " + melee_total;
        }



    }
    public void Consumir(Item item) 
    {
        if (item.IsConsumible) 
        {
            Personaje.Recibir_vida(item.restauraVida);
        }
    }
    void Update()
    {
        UpdateStatus(isNetWorkPlay);
        
    }
}
