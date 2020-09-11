using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;
using UnityEngine.UI;

public class sc_equipamientoUI : MonoBehaviour
{
    
    
    public sc_equipamiento equipamiento;
    public sc_slot_mocochila[] Slots;// = new sc_slot_mocochila[4];
    public Transform itemParent;
    public Transform tnf_casco;
    public Transform tnf_melee;
    public Transform tnf_peto;
    public Transform tnf_arma;
    public Item Prueba;

    sc_slot_mocochila casco;
    sc_slot_mocochila melee;
    sc_slot_mocochila peto;
    sc_slot_mocochila arma;
    // Start is called before the first frame update
    void Start()
    {
        equipamiento = sc_equipamiento.Instancia;
        equipamiento.onItemChangedCallBack += UpdateUI;
        //remplazar la linea de abajo por los cuatro slots
        //Slots[]
        Slots = itemParent.GetComponentsInChildren<sc_slot_mocochila>();
        casco = tnf_casco.GetComponentInChildren<sc_slot_mocochila>();
        melee = tnf_melee.GetComponentInChildren<sc_slot_mocochila>();
        peto = tnf_peto.GetComponentInChildren<sc_slot_mocochila>();
        arma = tnf_arma.GetComponentInChildren<sc_slot_mocochila>();
        

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void UpdateUI()
    {
        
        
        if (equipamiento.items[0] != null) 
        {
            Slots[8].AddItem(equipamiento.items[0]);
            casco.AddItem(equipamiento.items[0]);
        }
        if (equipamiento.items[1] != null) 
        {
            Slots[16].AddItem(equipamiento.items[1]);
            melee.AddItem(equipamiento.items[1]);
        }
        if (equipamiento.items[2] != null) {
            Slots[17].AddItem(equipamiento.items[2]);
            peto.AddItem(equipamiento.items[2]);
        }
        if (equipamiento.items[3] != null) 
        {
            Slots[18].AddItem(equipamiento.items[3]);
            arma.AddItem(equipamiento.items[3]);
        }
       

    }
   
}
