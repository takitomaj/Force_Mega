using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
[System.Serializable]
public class Data_Personaje
{
    public string Nombre = "";
    //niveles
    public int lvl=1;
    public int Exp = 0;
    public int Next_lvl = 0;
    //Dinero
    public int dinero = 0;
    //Status
    public int vida_maxima = 100;
    public int perisia_vitalidad=1;//entre 0 a 10
    public int Fuerza = 0;
    public int perisia_Fuerza = 1;//entre 0 a 10
    public int Velocidad = 0;
    public int perisia_Velocidad=1;//entre 0 a 10
    public int Constitucion = 0;
    public int perisia_constitucion=1;//entre 0 a 10
    //Equipo
    public int armadura = 0;
    public int arma_melee = 0;
    public int arma_rango = 0;
    public int botas = 0;
    public int accsesorio1 = 0;
    public int accsesorio2 = 0;
    public int accsesorio3 = 0;
    //estetico
    public int[,] colores;

    //calculados
    public int vida = 10;
    public int meele = 0;
    public int Rango = 0;
    public float Movimiento = 0;
    public int esquivar = 0;
    public sc_Serializable_Item[] equipo = new sc_Serializable_Item[4];
    public List<sc_Serializable_Item> inventario = new List<sc_Serializable_Item>();
    

  
    public Data_Personaje(string V_nombre, int V_lvl, int V_Exp, int V_Next_lvl, int V_vida, int V_VidaMaxima, int V_Fuerza, int V_Velocidad, int V_Constitucion,
                          int V_armadura, int V_arma_melee, int V_arma_rango, int V_botas, int V_accsesorio1, int V_accsesorio2, int V_accsesorio3,
                          int[,] V_Colores) {
        Nombre = V_nombre;
        lvl = V_lvl;
        Exp = V_Exp;
        Next_lvl = V_Next_lvl;
        vida = V_vida;
        vida_maxima = V_VidaMaxima;
        Fuerza = V_Fuerza;
        Velocidad = V_Velocidad;
        Constitucion = V_Constitucion;
        armadura = V_armadura;
        arma_melee = V_arma_melee;
        arma_rango = V_arma_rango;
        botas = V_botas;
        accsesorio1 = V_accsesorio1;
        accsesorio2 = V_accsesorio2;
        accsesorio3 = V_accsesorio3;

        colores = V_Colores;// new int[3,3] { { 1, 2 ,1}, { 3, 4,1 }, { 5, 6,1 }};
        Calcular();
    }
   
    public Data_Personaje(bool ModoPrueba)
    {
        if (ModoPrueba) {
            Nombre = "test";
            lvl = 1;
            Exp = 10;
            Next_lvl = 30;

            vida_maxima = 150;
            vida = 100;
            Fuerza = 1;
            Velocidad = 10;
            Constitucion = 2;

            perisia_vitalidad = 5;//entre 0 a 10

            perisia_Fuerza = 5;//entre 0 a 10

            perisia_Velocidad = 7;//entre 0 a 10

            perisia_constitucion = 10;//entre 0 a 10



            armadura = 1;
            arma_melee = 1;
            arma_rango = 1;
            botas = 0;
            accsesorio1 = 0;
            accsesorio2 = 0;
            accsesorio3 = 0;
            colores = new int[3, 3]
            {
              {   0,   0, 255 },
              {   0, 255,   0 },
              { 255,   0,   0 }
            };
            Calcular();
        }
        else
        {
            //niveles
            lvl = 1;
            Exp = 0;
            Next_lvl = 30;
            //perisias
            perisia_vitalidad =Random.Range(1, 11);
            perisia_constitucion = Random.Range(1, 11);
            perisia_Fuerza = Random.Range(1, 11);
            perisia_Velocidad = Random.Range(1, 11);
            //stats
            vida_maxima = Random.Range(100, 200);
            vida = vida_maxima;
            Fuerza = perisia_Fuerza;
            Velocidad = perisia_Velocidad;
            Constitucion = perisia_constitucion;
            colores = new int[3, 3]
            {
              {Random.Range(0, 255),Random.Range(0, 255),Random.Range(0, 255)},
              {Random.Range(0, 255),Random.Range(0, 255),Random.Range(0, 255)},
              {Random.Range(0, 255),Random.Range(0, 255),Random.Range(0, 255)}
            };


        }
    }
    public Data_Personaje()
    {

    }
    public void SetDineroos(int dineros) 
    {
        dinero = dineros;
    }
    public void ganaDinero(int dineros) 
    {
        dinero += dineros;
    }
    public void getEquipo_to_Serialisable() 
    {
        if (sc_equipamiento.Instancia.items[0] != null) {

            sc_Serializable_Item casco = new sc_Serializable_Item(sc_equipamiento.Instancia.items[0]);
            equipo[0] = casco;
        }
        else { equipo[0] = null; }
        if (sc_equipamiento.Instancia.items[1] != null)
        {

            sc_Serializable_Item espada = new sc_Serializable_Item(sc_equipamiento.Instancia.items[1]);
            equipo[1] = espada;
        }
        else { equipo[1] = null; }
        if (sc_equipamiento.Instancia.items[2] != null)
        {

            sc_Serializable_Item peto = new sc_Serializable_Item(sc_equipamiento.Instancia.items[2]);
            equipo[2] = peto;
        }
        else { equipo[2] = null; }
        if (sc_equipamiento.Instancia.items[3] != null)
        {

            sc_Serializable_Item arma = new sc_Serializable_Item(sc_equipamiento.Instancia.items[3]);
            equipo[3] = arma;
        }
        else { equipo[3] = null; }
    }

    public void getInventari_to_serialisable() 
    {
        inventario =  new List<sc_Serializable_Item>();
        foreach (Item item in sc_Inventario.Instancia.items) 
        {
            sc_Serializable_Item itemSerializable = new sc_Serializable_Item(item);
            
            inventario.Add(itemSerializable);
        }
    }
    public void setEquipo() 
    {
        for (int i=0;i<=3; i++) 
        {
            if (equipo[i] != null) 
            {

                sc_equipamiento.Instancia.items[i] = equipo[i].GetItem();
            }
        }
    }
    public void setInventario()
    {
        foreach (sc_Serializable_Item s_item in inventario)
        {
            sc_Inventario.Instancia.AddItem(s_item.GetItem());
        }
    }

    public void Lvl_UP() {
       
        Next_lvl = (lvl+1) *30;
        
        lvl++;
        Exp = 0;
        
        

        var vitalidad = UnityEngine.Random.Range(1, perisia_vitalidad) * 20;
        var esfuerzo = UnityEngine.Random.Range(1, perisia_Fuerza);
        var sprint = UnityEngine.Random.Range(1, perisia_Velocidad);
        var corpulencia = UnityEngine.Random.Range(1, perisia_constitucion);

        vida_maxima = vida_maxima + vitalidad;
        Fuerza = Fuerza + esfuerzo;
        Velocidad = Velocidad + sprint;
        Constitucion = Constitucion + corpulencia;
    }
    public Data_Personaje(Data_Personaje personaje)
    {
        Nombre = personaje.Nombre;
        lvl = personaje.lvl;
        Exp = personaje.Exp;
        Next_lvl = personaje.Next_lvl;
        vida = personaje.vida;
        Fuerza = personaje.Fuerza;
        Velocidad = personaje.Velocidad;
        Constitucion = personaje.Constitucion;
        armadura = personaje.armadura;
        arma_melee = personaje.arma_melee;
        arma_rango = personaje.arma_rango;
        botas = personaje.botas;
        accsesorio1 = personaje.accsesorio1;
        accsesorio2 = personaje.accsesorio2;
        accsesorio3 = personaje.accsesorio3;
        colores = personaje.colores;
        Calcular();
    }

   

    public void Calcular()
    {
        meele = Fuerza * Constitucion;
        Movimiento = Velocidad / Constitucion;
        esquivar = Velocidad / Constitucion;
    }
   


}
