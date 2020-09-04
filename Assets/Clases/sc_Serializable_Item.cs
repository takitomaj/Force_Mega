using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


[System.Serializable]
public class sc_Serializable_Item 
{
    public string nombre = "_";
    public int ID = 0;
    public int IDtipo = 0;
    public string Tipo = "item";

    public string icon_name=" ";
    public string icon_url="";
    public bool IsDefault = false;
    public int[] color = { 255, 255, 255, 0 };
    // consumibles
    public bool IsConsumible = false;
    public int restauraVida = 0;
    //equipables
    public bool IsEquipable = false;
    public bool IsCasco = false;
    public bool IsPeto = false;
    public bool IsMeleeW = false;
    public bool IsRangoW = false;
    //modificadores
    public int ModFuerza = 0;
    public int ModConstitucion = 0;
    public int ModVelocidad = 0;
    //dano
    public int Dano = 0;

    public sc_Serializable_Item(Item item) 
    {
        nombre = item.nombre;
        ID = item.ID;
        IDtipo = item.IDtipo;
        Tipo = item.Tipo;

        icon_name = item.icono.name;
        

        icon_url = Get_nombreSprite(item.icono.name);
        
        IsDefault = item.IsDefault;
        color = item.color;
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
    public string Get_nombreSprite(string nombreSprite) 
    {
        string[] nombre_list = nombreSprite.Split('_');
        string nombre_sprite_multipe = "";
        for (int i = 0; i <= nombre_list.Length - 2; i++)
        {
            if (i == 0)
            {
                nombre_sprite_multipe = nombre_list[i];
            }
            else
            {
                nombre_sprite_multipe = nombre_sprite_multipe + "_" + nombre_list[i];
            }


        }
        return nombre_sprite_multipe;

    }
    public Item GetItem() 
    {
        Item salida= new Item();

        salida.nombre = nombre;
        salida.ID = ID;
        salida.IDtipo = IDtipo;
        salida.Tipo = Tipo;
        
        
        //Icono
        Sprite[] sprites = Resources.LoadAll<Sprite>(icon_url);
        
       
        foreach (Sprite asprite in sprites)
        {
            if (asprite.name == icon_name)
            {
                salida.icono = asprite;
            }
        }
        
        salida.IsDefault = IsDefault;
        salida.color = color;
        // consumibles
        salida.IsConsumible = IsConsumible;
        salida.restauraVida = restauraVida;
        //equipables
        salida.IsEquipable = IsEquipable;
        salida.IsCasco = IsCasco;
        salida.IsPeto = IsPeto;
        salida.IsMeleeW =IsMeleeW;
        salida.IsRangoW = IsRangoW;
        //modificadores
        salida.ModFuerza = ModFuerza;
        salida.ModConstitucion = ModConstitucion;
        salida.ModVelocidad = ModVelocidad;
        //dano
        salida.Dano = Dano;

        return salida;
    }
}
