using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sc_select_level : MonoBehaviour
{
    public Button lvl1;
    public Button lvl2;
    public Button lvl3;
    public Button lvl4;
    public Button lvl5;
    public int lvl = 1;
    void Start()
    {
        
        Data_Personaje data= serializador.LoadPersonaje();
        lvl = data.escenario;
        lvl1.interactable = true;
        if (lvl >= 2) { lvl2.interactable = true; }
        if (lvl >= 3) { lvl3.interactable = true; }
        if (lvl >= 4) { lvl4.interactable = true; }
        if (lvl >= 5) { lvl5.interactable = true; }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
