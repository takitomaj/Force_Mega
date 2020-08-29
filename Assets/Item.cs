using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="new Item",menuName ="Inventary/Item")]
[System.Serializable]
public class Item : ScriptableObject
{
    public string nombre = "_";
    public int ID = 0;
    public int IDtipo = 0;
    public String Tipo = "item";

    [SerializeField]
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
    public void SetIcon(Sprite iconoN)
    {
        icono = iconoN;
    }
    public void SerializableToItem(Serialisable_item item)
    {
        nombre = item.nombre;
        ID = item.ID;
        IDtipo = 0;
        Tipo = item.Tipo;

        
        IsDefault = item.IsDefault;
        color = color;
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
