using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sc_slot_mocochila : MonoBehaviour
{
    public Image icon;
    public Button RemoveButton;
    Item item;
    public void AddItem(Item newItem)
    {
        item = newItem;
        icon.sprite = item.icono;
        icon.enabled = true;
        RemoveButton.enabled = true;
        RemoveButton.interactable = true;
        RemoveButton.image.enabled = true;

    }
    public void Removeitem(Item newItem)
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;

        RemoveButton.enabled = false;
        RemoveButton.interactable = false;
        RemoveButton.image.enabled = false;
      

    }
    public void Removeitem()
    {
        item = null;
        icon.sprite = null;
        icon.enabled = false;
        RemoveButton.enabled = false;
        RemoveButton.interactable = false;
        RemoveButton.image.enabled = false;

    }
    public void OnRemoveButton() 
    {
        sc_Inventario.Instancia.RemoveItem(item);
        
    }
    public void UseItem() 
    {
        if (item != null) 
        {
            item.Use();
        }    
    }

    void Start()
    { 
        
        RemoveButton.enabled = false;
        RemoveButton.interactable = false;
        RemoveButton.image.enabled = false;
    }

   
    void Update()
    {
        
    }
}
