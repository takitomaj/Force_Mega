using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using UnityEngine.UI;


public class sc_Inventario_UI : MonoBehaviour
{

    public Transform itemParent;
    public Canvas InventaryUI;
    public sc_Inventario inventario;
    sc_slot_mocochila[] Slots;
    
    // Start is called before the first frame update
    void Start()
    {
        inventario = sc_Inventario.Instancia;
        inventario.onItemChangedCallBack += UpdateUI;

        Slots = itemParent.GetComponentsInChildren<sc_slot_mocochila>();
        

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Inventario")) 
        {
            if (InventaryUI.isActiveAndEnabled)
            {
                InventaryUI.enabled = false;
                
            }
            else
            {
                InventaryUI.enabled = true;
                
            }
        }  
    }
   public void UpdateUI()
    {
        Debug.Log("INventary actualizado");
        for (int i=0;i<Slots.Length;i++) 
        {
            if (i< inventario.items.Count) 
            {
                Slots[i].AddItem(inventario.items[i]);
            }
            else 
            {
                Slots[i].Removeitem();
            }
        }
    }
}
