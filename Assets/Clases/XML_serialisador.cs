using System.Collections;
using System.Collections.Generic;
using System;
using System.IO;
using System.Xml.Serialization;
using UnityEngine;
using System.Runtime.InteropServices.WindowsRuntime;

public class XML_serialisador 
{
    // Start is called before the first frame update
    public void EscrivirXML(Item item)
    {
        
        XmlSerializer x = new XmlSerializer(item.GetType());
        string Path = Application.persistentDataPath + "/item_test.sve";
        FileStream stream = new FileStream(Path, FileMode.Create);
        x.Serialize(stream, item);    //(Console.Out, item);
       
    }
    public Item leerXML() 
    {
        Item item = new Item();
        XmlSerializer ser = new XmlSerializer(item.GetType());
        string Path = Application.persistentDataPath + "/item_test.sve";
        using (StreamReader sr = new StreamReader(Path))
        {
            Debug.Log("leer item" );
            item = (Item)ser.Deserialize(sr);
            if (item != null) 
            {
               
                return item;

            }
            else 
            {
                return null;
            }
        }
    }

}
