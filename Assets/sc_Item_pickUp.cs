using System;
using UnityEngine;


public class sc_Item_pickUp : Interacuar
{
    public Item item;
    SpriteRenderer sprite;
    public GameObject objetoselect;
    public SpriteRenderer spriteOS;
    public int lifeTime = 100;

    public void Start()
    {
        if (objetoselect != null)
        {
            spriteOS = objetoselect.GetComponent<SpriteRenderer>();
        }

        sprite = GetComponent<SpriteRenderer>();
        sprite.color = new Color(item.color[0], item.color[1], item.color[2], item.color[3]);
        Destroy(gameObject, lifeTime);

    }
    public void Update()
    {
        if (Input.GetAxis("Horizontal") != 0) 
        {
            //sprite.color = new Color(0, 0, 0, item.color[3]);
            setcolor();
            Debug.Log("setColor");
        }
    }
    public void setcolor()
    {

        sprite.color = new Color(item.color[0], item.color[1], item.color[2], item.color[3]);
    }
    public void setcolor(int R,int G,int B)
    {
        
        sprite.color = new Color(R, G, B, 255);
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
        if (!item.IsDefault)
        {
            if (sc_Inventario.Instancia.AddItem(item))
            {
                Destroy(gameObject);
            }
        }
        else 
        {
            sc_Inventario.Instancia.Dineros += item.restauraVida;
            Destroy(gameObject);
        }
        
    }
}
