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
    int vida = 0;
    int Fuerza = 0;
    int Velocidad = 0;
    int Constitucion =0;
    //Equipo
    int armadura = 0;
    int arma_melee = 0;
    int arma_rango = 0;
    int botas = 0;
    int accsesorio1 = 0;
    int accsesorio2 = 0;
    int accsesorio3 = 0;
    //estetico
    string Color1 = "";
    string Color2 = "";
    string Color3 = "";
    //calculados
    int meele = 0;
    int Rango = 0;
    int Movimiento = 0;
    int esquivar = 0;

    public Data_Personaje(string V_nombre ,int V_lvl, int V_Exp, int V_Next_lvl, int V_vida, int V_Fuerza, int V_Velocidad, int V_Constitucion,
                          int V_armadura, int V_arma_melee, int V_arma_rango, int V_botas, int V_accsesorio1, int V_accsesorio2, int V_accsesorio3,
                          string color1, string color2, string color3) {
        Nombre = V_nombre;
        lvl= V_lvl;
        Exp = V_Exp;
        Next_lvl = V_Next_lvl;
        vida = V_vida;
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

        Color1 = color1;
        Color2 = color2;
        Color3 = color3;
    }
    public Data_Personaje()
    {
       
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

        Color1 = personaje.Color1;
        Color2 = personaje.Color2;
        Color3 = personaje.Color3;
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
    public int Movimiento1 { get => Movimiento; set => Movimiento = value; }
    public int Esquivar { get => esquivar; set => esquivar = value; }

    
     public void Calcular() 
     {
         meele = Fuerza * Constitucion;
         Movimiento = Velocidad / Constitucion;
         esquivar= Velocidad / Constitucion;
     }
     


}
