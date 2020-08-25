using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_Inventario : MonoBehaviour
{
    #region Singelton
    public static sc_Inventario Instancia;
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


    public List<Item> items = new List<Item>();
    public int Capacidad = 15;
    public bool AddItem(Item Newitem) 
    {
        if (items.Count >= Capacidad)
        {
            Debug.Log("Inventario Lleno");
            return false;
        }
        else
        {
            items.Add(Newitem);
            if (onItemChangedCallBack != null)
            {
                onItemChangedCallBack.Invoke();
            }

            return true;
        }
    }
    public void RemoveItem(Item RemItem) 
    {
        items.Remove(RemItem);

        if (onItemChangedCallBack != null)
        {
            onItemChangedCallBack.Invoke();
        }
    }
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void updateUI() 
    { 
    
    }
}
