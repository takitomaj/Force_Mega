using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="new Item",menuName ="Inventary/Item")]
public class Item : ScriptableObject
{
    public string nombre = "_";
    public int ID = 0;
    public int IDtipo = 0;
    public String Tipo = "item";
    public Sprite icono = null;
    public Boolean IsDefault=false;
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

    public virtual void Use()
    {
        //agrebar lo que pasa
        Debug.Log("usaste Item : " + nombre);
    }
   





}
