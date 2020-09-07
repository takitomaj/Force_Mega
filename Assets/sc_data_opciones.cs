using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sc_data_opciones : MonoBehaviour
{
    public InputField TF_Nombre;
    
    public GameObject sp_player;
    Personaje personaje;
    void Start()
    {
         personaje = sp_player.GetComponent<Personaje>();
        

    }

    public void cambiarNombre() 
    {
        personaje.stats.Nombre = TF_Nombre.text;
        personaje.stats.getEquipo_to_Serialisable();
        personaje.stats.getInventari_to_serialisable();
        serializador.SavePersonaje(personaje.stats);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
