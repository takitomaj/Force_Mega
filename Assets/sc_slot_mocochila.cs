﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sc_slot_mocochila : MonoBehaviour
{
    public Image icon;
    public Image img_stats;
    public Text txt_status;
    public Button RemoveButton;
    Item item;
    public void AddItem(Item newItem)
    {
        item = newItem;

        icon.sprite = item.icono;
        icon.color = new Color(item.color[0], item.color[1], item.color[2], item.color[3]);
        icon.enabled = true;
        setTxtStatus();


        RemoveButton.enabled = true;
        RemoveButton.interactable = true;
        RemoveButton.image.enabled = true;

    }
    public void Removeitem(Item newItem)
    {
        removeTxtStatus();
        item = null;
        icon.sprite = null;
        icon.enabled = false;

        RemoveButton.enabled = false;
        RemoveButton.interactable = false;
        RemoveButton.image.enabled = false;
        

    }
    public void Removeitem()
    {
        removeTxtStatus();
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
    public void ShowAtrivutes() 
    {
        if(item !=null) 
        {
            img_stats.enabled = true;
            txt_status.enabled = true;
        }
    }
    public void HideAtrivutes()
    {
        img_stats.enabled = false;
        txt_status.enabled = false;
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
        if (img_stats != null && txt_status != null)
        {
            HideAtrivutes();
        }
       
        RemoveButton.enabled = false;
        RemoveButton.interactable = false;
        RemoveButton.image.enabled = false;
    }

    public void setTxtStatus() 
    {
        string status = "";
        //consumible o equipable
        if (item.IsConsumible)
        {
            status = "Consumible";
            if (item.restauraVida!=0) { status = status + "\n" + "Vit: " + item.Dano; }
        }
        else 
        { 
            status = "Equipable";
            if (item.IsCasco) 
            {
                status = status + "\n" + "Casco" ;
            }else if (item.IsMeleeW) 
            {
                status = status + "\n" + "arma" ;
                if (item.Dano >= 1) { status = status + "\n" + "Daño: " + item.Dano; }
            }
            else if (item.IsPeto)
            {
                status = status + "\n" + "Peto";
            } else if (item.IsRangoW)
            {
                status = status + "\n" + "Pistola" ;
                if (item.Dano >= 1) { status = status + "\n" + "Daño: " + item.Dano; }
            }

            if (item.ModConstitucion != 0) { status = status + "\n" + "Con: +" + item.ModConstitucion; }
            if (item.ModFuerza != 0) { status = status + "\n" + "Fue: +" + item.ModFuerza; }
            if (item.ModVelocidad != 0) { status = status + "\n" + "Vel: +" + item.ModVelocidad; }
        }
        

        txt_status.text = status;
    }
    public void removeTxtStatus()
    {
        string status = "-";

        //txt_status.text = status;
    }

    void Update()
    {
        
    }
}
