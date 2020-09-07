using System.IO;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.InteropServices.WindowsRuntime;

public static class serializador 
{

    public static void SavePersonaje(Data_Personaje personaje)
    {
        if (personaje!=null) {
            
            BinaryFormatter formatter = new BinaryFormatter();
            string Path = Application.persistentDataPath + "/Jugador.sve";
            //Debug.Log(Path);
            FileStream stream = new FileStream(Path, FileMode.Create);

            Data_Personaje data = personaje;

            formatter.Serialize(stream, data);
            stream.Close();
        }
    }
    public static Data_Personaje LoadPersonaje()
    {
        
        string Path = Application.persistentDataPath + "/Jugador.sve";
        if (File.Exists(Path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(Path, FileMode.Open);

            Data_Personaje data= formatter.Deserialize(stream) as Data_Personaje;
            stream.Close();
            
            return data;

        }
        else 
        {
            Debug.LogError("el archivo: "+" Jugador.sve"+"NO EXISTE");
            return null;
        }
        
    }

    public static void SaveItem(Item item,int Numero,string InventarioOEquipo)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string Path = Application.persistentDataPath + "/"+InventarioOEquipo+"_"+ Numero + ".sve";
        FileStream stream = new FileStream(Path, FileMode.Create);

        Serialisable_item S_item = new Serialisable_item();
        S_item.itemToSerializable(item);
        //Data_Personaje data = new Data_Personaje(S_item);

        formatter.Serialize(stream, S_item);
        stream.Close();
    }
    public static Item LoadItem(int Numero, string InventarioOEquipo)
    {

        string Path = Application.persistentDataPath + "/" + InventarioOEquipo + "_" + Numero + ".sve";
        if (File.Exists(Path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(Path, FileMode.Open);

            Serialisable_item S_data = formatter.Deserialize(stream) as Serialisable_item;
            stream.Close();
            Item data = new Item();
            data.SerializableToItem(S_data);
            return data;
        }
        else
        {
            //Debug.LogError("el archivo: " + InventarioOEquipo + "_" + Numero + ".sve" + "NO EXISTE");
            return null;
        }

    }
    public static void saveInventario()
    {
        List<Item> items = sc_Inventario.Instancia.items;
        for(int i=0;i< items.Count;i++)
        {
            SaveItem(items[i], i,Constantes._Inventario);
        }
    }
    public static void loadInventario()
    {
        for (int i = 0; i < 15; i++)
        {
            Item item=LoadItem(i,Constantes._Inventario);
            
            if (item != null) 
            {
                Debug.Log("cargado :{" + item.name + "}");
                sc_Inventario.Instancia.AddItem(item);
                
                Debug.Log("cargadoC:{" + sc_Inventario.Instancia.items[i].name + "}");

            }
        }
    }
    public static void saveEquipo()
    {
        Item[] items = sc_equipamiento.Instancia.items;
        for (int i = 0; i < items.Length; i++)
        {
            SaveItem(items[i], i, Constantes._Equipo);
        }
    }
    public static void loadEqipo()
    {
        for (int i = 0; i < 4; i++)
        {
            Item item = LoadItem(i, Constantes._Inventario);
            if (item != null)
            {
                if (i == 0) { 
                    sc_equipamiento.Instancia.AddCasco(item);
                }
                if (i == 1)
                {
                    sc_equipamiento.Instancia.AddMelee(item);
                }
                if (i == 2)
                {
                    sc_equipamiento.Instancia.AddPeto(item);
                }
                if (i == 3)
                {
                    sc_equipamiento.Instancia.AddArma(item);
                }
            }
        }
    }

}
