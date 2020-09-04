
using System;
using UnityEngine;

public class Interacuar : MonoBehaviour
{
    public float radioInteraccion = 1.5f;

    Boolean IsFocus = false;
    Boolean estaInteractuando = false;
    public Transform player;
    public Transform InteraccionTransform;

    private void Update()
    {
        if (IsFocus && !estaInteractuando) 
        {
            float distancia = Vector3.Distance(player.position, transform.position);
            if (distancia<=radioInteraccion) 
            {
                
                Interactuar();
                estaInteractuando = true;
            }
        }
    }

    public void OnFocus(Transform T_player) 
    {
        player = T_player;
        estaInteractuando = false;
    }
    public void NoFocus()
    {
        IsFocus = false;
        player = null;
        estaInteractuando = false;
    }
    public virtual void Interactuar() { 
        //este metodo se reescribira dependiendo de con que interactue
       // Debug.Log("Interactuar con"+ transform.name); 
    }

    
}
