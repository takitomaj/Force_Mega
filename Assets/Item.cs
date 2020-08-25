using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="new Item",menuName ="Inventary/Item")]
public class Item : ScriptableObject
{
    public string nombre = "";
    public Sprite icono = null;
    public Boolean IsDefault=false;



}
