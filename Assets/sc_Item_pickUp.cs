using System;
using UnityEngine;

public class sc_Item_pickUp : Interacuar
{
    public Item item;
    
    public override void Interactuar()
    {
        base.Interactuar();
        pickUp();
    }
    public void pickUp()
    {
        
        Destroy(gameObject); 
       
    }
    public void OnMouseDown()
    {
        Debug.Log("Recojiendo" + item.nombre);
        //FindObjectOfType<sc_Inventario>().AddItem(item);// este pedazo del codico sin Singleton
        if (sc_Inventario.Instancia.AddItem(item))
        {
            Destroy(gameObject);
        }
        
    }
}
