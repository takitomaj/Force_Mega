using System;
using UnityEngine;


public class sc_Item_pickUp : Interacuar
{
    public Item item;
    SpriteRenderer sprite;
    public GameObject objetoselect;
    SpriteRenderer spriteOS;

    public void Start()
    {
        if (objetoselect != null) 
        {
            spriteOS = objetoselect.GetComponent<SpriteRenderer>();
        }
        
        sprite = GetComponent<SpriteRenderer>();
        sprite.color = new Color(item.color[0], item.color[1], item.color[2], item.color[3]);

    }
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
        
        base.Interactuar();

        //FindObjectOfType<sc_Inventario>().AddItem(item);// este pedazo del codico sin Singleton
        if (sc_Inventario.Instancia.AddItem(item))
        {
            Destroy(gameObject);
        }
        
    }
}
