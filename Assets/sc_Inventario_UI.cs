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
    public sc_equipamiento equipamiento;
    sc_slot_mocochila[] Slots;
    
    // Start is called before the first frame update
    void Start()
    {
        inventario = sc_Inventario.Instancia;
        inventario.onItemChangedCallBack += UpdateUI;
        
        equipamiento = sc_equipamiento.Instancia;

        Slots = itemParent.GetComponentsInChildren<sc_slot_mocochila>();

        UpdateUI();
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


        if (equipamiento.items[0] != null)
        {
            Slots[15].AddItem(equipamiento.items[0]);
          
        }
        if (equipamiento.items[1] != null)
        {
            Slots[16].AddItem(equipamiento.items[1]);

        }
        if (equipamiento.items[2] != null)
        {
            Slots[17].AddItem(equipamiento.items[2]);

        }
        if (equipamiento.items[3] != null)
        {
            Slots[18].AddItem(equipamiento.items[3]);

        }
    }
}
