using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Data_Personaje 
{  
    string Nombre = "";
    //niveles
    int lvl;
    int Exp = 0;
    int Next_lvl = 0;
    
    //Status

    public int vida_maxima=0;
    int perisia_vitalidad;//entre 0 a 10
    int Fuerza = 0;
    int perisia_Fuerza;//entre 0 a 10
    int Velocidad = 0;
    int perisia_Velocidad;//entre 0 a 10
    int Constitucion =0;
    int perisia_constitucion;//entre 0 a 10
    //Equipo
    int armadura = 0;
    int arma_melee = 0;
    int arma_rango = 0;
    int botas = 0;
    int accsesorio1 = 0;
    int accsesorio2 = 0;
    int accsesorio3 = 0;
    //estetico
    public int[,] colores;

    //calculados
    int vida = 0;
    int meele = 0;
    int Rango = 0;
    float Movimiento = 0;
    int esquivar = 0;

    public Data_Personaje(string V_nombre ,int V_lvl, int V_Exp, int V_Next_lvl, int V_vida,int V_VidaMaxima, int V_Fuerza, int V_Velocidad, int V_Constitucion,
                          int V_armadura, int V_arma_melee, int V_arma_rango, int V_botas, int V_accsesorio1, int V_accsesorio2, int V_accsesorio3,
                          int[,] V_Colores) {
        Nombre = V_nombre;
        lvl= V_lvl;
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
            Next_lvl = 100;

            vida_maxima = 150;
            vida = 100;
            Fuerza = 1;
            Velocidad = 10;
            Constitucion = 2;

            perisia_vitalidad=1;//entre 0 a 10
           
            perisia_Fuerza = 1;//entre 0 a 10
           
            perisia_Velocidad = 1;//entre 0 a 10
            
            perisia_constitucion = 1;//entre 0 a 10



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
            //cargar_datos();
        }
    }
    public Data_Personaje()
    {
       
    }
    public void Lvl_UP() {
        Next_lvl = Next_lvl * (1 + (lvl / 10));
        lvl++;
        Exp = 0;

        perisia_vitalidad = 1;//entre 0 a 10

        perisia_Fuerza = 1;//entre 0 a 10

        perisia_Velocidad = 1;//entre 0 a 10

        perisia_constitucion = 1;//entre 0 a 10

        var vitalidad = UnityEngine.Random.Range(1, perisia_vitalidad) *10;
        var esfuerzo = UnityEngine.Random.Range(1, perisia_Fuerza) ;
        var sprint = UnityEngine.Random.Range(1, perisia_Velocidad) ;
        var corpulencia = UnityEngine.Random.Range(1, perisia_constitucion) ;

        vida_maxima = vida_maxima + vitalidad;
        Fuerza = Fuerza + esfuerzo;
        Velocidad = Velocidad + sprint;
        Constitucion = Constitucion + corpulencia;
    }
    public Data_Personaje(Data_Personaje personaje)
    {
        Nombre =personaje.Nombre;
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

    public string Nombre1 { get => Nombre; set => Nombre = value; }
    public int Lvl { get => lvl; set => lvl = value; }
    public int Exp1 { get => Exp; set => Exp = value; }
    public int Next_lvl1 { get => Next_lvl; set => Next_lvl = value; }
    public int Vida { get => vida; set => vida = value; }
    public int Fuerza1 { get => Fuerza; set => Fuerza = value; }
    public int Velocidad1 { get => Velocidad; set => Velocidad = value; }
    public int Constitucion1 { get => Constitucion; set => Constitucion = value; }
    public int Armadura { get => armadura; set => armadura = value; }
    public int Arma_melee { get => arma_melee; set => arma_melee = value; }
    public int Arma_rango { get => arma_rango; set => arma_rango = value; }
    public int Botas { get => botas; set => botas = value; }
    public int Accsesorio1 { get => accsesorio1; set => accsesorio1 = value; }
    public int Accsesorio2 { get => accsesorio2; set => accsesorio2 = value; }
    public int Accsesorio3 { get => accsesorio3; set => accsesorio3 = value; }
    public int Meele { get => meele; set => meele = value; }
    public int Rango1 { get => Rango; set => Rango = value; }
    public float Movimiento1 { get => Movimiento; set => Movimiento = value; }
    public int Esquivar { get => esquivar; set => esquivar = value; }

    
     public void Calcular() 
     {
         meele = Fuerza * Constitucion;
         Movimiento = Velocidad / Constitucion;
         esquivar= Velocidad / Constitucion;
     }
     


}
