using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

[System.Serializable]
public class Serialisable_item
{
    public string nombre = "_";
    public int ID = 0;
    public int IDtipo = 0;
    public string Tipo = "item";
    
    //public Sprite icono = null;
    public Boolean IsDefault = false;
    public int[] color = { 255, 255, 255, 0 };
    // consumibles
    public Boolean IsConsumible = false;
    public int restauraVida = 0;
    //equipables
    public Boolean IsEquipable = false;
    public Boolean IsCasco = false;
    public Boolean IsPeto = false;
    public Boolean IsMeleeW = false;
    public Boolean IsRangoW = false;
    //modificadores
    public int ModFuerza = 0;
    public int ModConstitucion = 0;
    public int ModVelocidad = 0;
    //dano
    public int Dano = 0;

    public void itemToSerializable(Item item) {
         nombre = item.name;
         ID = item.ID;
         IDtipo = 0;
         Tipo = item.Tipo;

         //icono = item.icono;
         IsDefault = item.IsDefault;
         color =color;
        // consumibles
         IsConsumible = item.IsConsumible;
         restauraVida = item.restauraVida;
        //equipables
         IsEquipable = item.IsEquipable;
         IsCasco = item.IsCasco;
         IsPeto = item.IsPeto;
         IsMeleeW = item.IsMeleeW;
         IsRangoW = item.IsRangoW;
        //modificadores
         ModFuerza = item.ModFuerza;
         ModConstitucion = item.ModConstitucion;
         ModVelocidad = item.ModVelocidad;
        //dano
         Dano = item.Dano;



    }
}
