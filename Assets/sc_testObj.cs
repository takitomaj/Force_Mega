using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class sc_testObj : MonoBehaviour
{
    SpriteRenderer sr;
    public string url = "";
    public string nombre = "Items"; 
    // Start is called before the first frame update
    void Start()
    {
        sr = gameObject.GetComponent<SpriteRenderer>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("t"))
        {


            string[] nombre_list = nombre.Split('_');
            //foreach (string s in nombre_list)
            //{
            // Debug.Log(s);
            //}
            //string[] nombre_list = nombre.Split('_');
            string nombre_sprite_multipe = "";
            for (int i = 0; i <= nombre_list.Length-2; i++)
            {
                if (i == 0) 
                {
                    nombre_sprite_multipe = nombre_list[i];
                }
                else 
                {
                    nombre_sprite_multipe = nombre_sprite_multipe + "_"+ nombre_list[i];
                }

                
            }
            
            //Sprite sprites = Resources.Load<Sprite>("Armas_rango_2") as Sprite;
            /*Sprite[] sprites_a= Resources.LoadAll<Sprite>(nombre);

            Debug.Log("cargado_sprite");
            for (int i=0;i<=4;i++) 
            {
                if (sprites_a[i].name=="Armas_rango_2") {
                    sr.sprite = sprites_a[i];
                }
            }
            */
            //sr.sprite = sprites.;


            Debug.Log("sprite render echo");
        }
    }
}
