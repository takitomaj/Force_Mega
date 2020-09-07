using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sc_Spawm_item : MonoBehaviour
{
    public GameObject[] objetos = new GameObject[12];
    // Start is called before the first frame update
    public void SpawmItem(int Cantidad, int Nivel)
    {

        //////////////////



        crearItem(0, Nivel);
        
       
        for (int i = 0; i < Cantidad; i++)
        {
            int item_s = Random.Range(0, objetos.Length);
            if (item_s <= 9)
            {
                crearItem(item_s, Nivel);
            }
        }
        
    
    }


    public void crearItem(int indexItem, int Nivel)
    {
        Item itemp = new Item();

        itemp.color[0] = Random.Range(0, 255);
        itemp.color[1] = Random.Range(0, 255);
        itemp.color[2] =  Random.Range(0, 255);
        itemp.color[3] = 255;
        itemp.color[Random.Range(0, 2)] = 0;

        //inicio Caracteristicas item
        if (indexItem == 0) {//dinero
            itemp.IsDefault = true;
            itemp.restauraVida = Random.Range(Nivel, Nivel * 5);
            itemp.color[0] = 255;
            itemp.color[1] = 255;
            itemp.color[2] = 255;
            itemp.color[3] = 255;


        } else if (indexItem == 1) 
        {//curacion
            itemp.IsConsumible = true;
            itemp.restauraVida = Random.Range(Nivel, Nivel * 5);
        }
        else if (indexItem == 2)
        {//casco
            itemp.IsEquipable = true;
            itemp.IsCasco = true;
            itemp.ModConstitucion= Random.Range(1, Nivel + 5);
            itemp.ModVelocidad = Random.Range(-1*Nivel, Nivel );
        }
        else if (indexItem == 3)
        {//peto
            itemp.IsEquipable = true;
            itemp.IsPeto = true;
            itemp.ModConstitucion = Random.Range(1, Nivel + 5);
            itemp.ModVelocidad = Random.Range(-1 * Nivel, 0);
        }
        else if (indexItem == 4)
        {//espada
            itemp.IsEquipable = true;
            itemp.IsMeleeW = true;
            itemp.Dano = Random.Range(Nivel, Nivel * 2);
        }
        else if (indexItem == 5)
        {//pistola
            itemp.IsEquipable = true;
            itemp.IsRangoW = true;
            itemp.IDtipo = 1;
            itemp.Dano =  Random.Range(1, Nivel );//pistola rapides normal
        }
        else if (indexItem == 6)
        {//booster
            itemp.IsEquipable = true;
            itemp.IsRangoW = true;
            itemp.IDtipo = 2;
            itemp.Dano =  Random.Range(1, Nivel-1);//debe ser mas rapida que pistola
        }
        else if (indexItem == 7)
        {//canon
            itemp.IsEquipable = true;
            itemp.IsRangoW = true;
            itemp.IDtipo = 3;
            itemp.Dano =  Random.Range(1, Nivel*2);
            itemp.ModVelocidad= Random.Range(Nivel * -1 , 0 );//debe dispara muy lento y corto alcance
        }
        else if (indexItem == 8)
        {//sniper
            itemp.IsEquipable = true;
            itemp.IsRangoW = true;
            itemp.IDtipo = 4;//alcance super largo -muy lento disparo
            itemp.Dano =  Random.Range(Nivel, Nivel*2);
            itemp.ModVelocidad =  Random.Range(Nivel / 2, 0);//debe dispara muy lento y corto alcance
        }
        else if (indexItem == 9)
        {//shotgun
            itemp.IsEquipable = true;
            itemp.IsRangoW = true;
            itemp.IDtipo = 5;//alcance super corto- dispara 3 proyectiles
            itemp.Dano =  Random.Range(1, Nivel/2);
        }
        
        GameObject itemIp = Instantiate(objetos[indexItem], transform.position, Quaternion.identity);
        SpriteRenderer sr_item = itemIp.GetComponent<SpriteRenderer>();
        //sr_item.color=new Color(255, 255,0,255);
        sr_item.color = new Color(itemp.color[0], itemp.color[1], itemp.color[2], 255);
        


        itemp.icono = sr_item.sprite;
        Rigidbody2D rb_itemp = itemIp.GetComponent<Rigidbody2D>();
        sc_Item_pickUp IPU_itemp = itemIp.GetComponent<sc_Item_pickUp>();
        IPU_itemp.item = itemp;


        rb_itemp.AddForce(Vector2.up * 5, ForceMode2D.Impulse);
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
    void Start()
    {
        
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
