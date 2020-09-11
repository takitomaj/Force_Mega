using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_Inventario : MonoBehaviour
{
    #region Singelton
    public static sc_Inventario Instancia;
    public int Dineros=0;
    public Transform Droper;
    
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
    public void RemoveItem(Item RemItem, bool drop) 
    {
        items.Remove(RemItem);
        if (drop) {
            DropItem(Droper, RemItem);
        }

        
        if (onItemChangedCallBack != null)
        {
            onItemChangedCallBack.Invoke();
        }
    }


    public void DropItem(Transform Droper, Item item)
    {

        // GameObject itemIp = Instantiate(crearItem(item), posicion.position, Quaternion.identity);
        GameObject salida = new GameObject();
        salida.transform.position = Droper.position;
        salida.name = item.name;
        sc_Item_pickUp scPUI = salida.AddComponent<sc_Item_pickUp>();
        scPUI.item = item;

        
        Rigidbody2D rb_itemp=salida.AddComponent<Rigidbody2D>();
        SpriteRenderer sr_item = salida.AddComponent<SpriteRenderer>();
        sr_item.sprite = item.icono;

        sr_item.color = new Color(item.color[0], item.color[1], item.color[2], 255);

        scPUI.spriteOS = sr_item;

        
        rb_itemp.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
        salida.AddComponent<BoxCollider2D>();
        int ladop = Random.Range(1, 100);
        if (ladop >= 50)
        {
            rb_itemp.AddForce(Vector2.left * 1, ForceMode2D.Impulse);
        }
        else
        {
            rb_itemp.AddForce(Vector2.right * 1, ForceMode2D.Impulse);
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
