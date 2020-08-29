using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_equipamiento : MonoBehaviour
{
    #region Singelton
    public static sc_equipamiento Instancia;
    void Awake()
    {
        if (Instancia != null)
        {
            Debug.LogWarning("existe otra instacia del inventario");
            return;
        }
        Instancia = this;
    }
    #endregion Singelton

    public delegate void OnItemChaged();
    public OnItemChaged onItemChangedCallBack;

    public Item[] items = new Item[4];  //0: casco
                                        //1: Melee
                                        //2: Peto
                                        //3: arma

    public void AddCasco(Item Newitem)
    {
        if (items[0] != null)
        {
            Item itemTemp = items[0];
            items[0] = Newitem;
            sc_Inventario.Instancia.AddItem(itemTemp);
        }
        else
        {
            items[0] = Newitem;
        }
    }
    public void AddMelee(Item Newitem)
    {
        if (items[1] != null)
        {
            Item itemTemp = items[1];
            items[1] = Newitem;
            sc_Inventario.Instancia.AddItem(itemTemp);
        }
        else
        {
            items[1] = Newitem;
        }
    }
    public void AddPeto(Item Newitem)
    {
        if (items[2] != null)
        {
            Item itemTemp = items[2];
            items[2] = Newitem;
            sc_Inventario.Instancia.AddItem(itemTemp);
        }
        else
        {
            items[2] = Newitem;
        }
    }
    public void AddArma(Item Newitem)
    {
        if (items[3] != null)
        {
            Item itemTemp = items[3];
            items[3] = Newitem;
            sc_Inventario.Instancia.AddItem(itemTemp);
        }
        else
        {
            items[3] = Newitem;
        }
    }

    /**
     * 0: casco
     * 1: Melee
     * 2: Peto
     * 3: arma
     */
    public void AddItemByID(Item Newitem,int id)
    {
        if (items[id] != null)
        {
            Item itemTemp = items[id];
            items[id] = Newitem;
            sc_Inventario.Instancia.AddItem(itemTemp);
            Debug.Log("equipado:"+ Newitem.name+" en el slot "+id);
        }
        else
        {
            items[id] = Newitem;
            Debug.Log("equipado:" + Newitem.name + " en el slot " + id);
        }
        //onItemChangedCallBack.Invoke();
    }

    public void Remove(int id) 
    {
        sc_equipamiento.Instancia.items[id] = null;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
