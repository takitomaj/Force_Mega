using System.IO;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;

public static class serializador 
{
    public static void SavePersonaje(Data_Personaje personaje) 
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string Path = Application.persistentDataPath +"/Jugador.sve";
        FileStream stream = new FileStream(Path, FileMode.Create);

        Data_Personaje data = new Data_Personaje(personaje);

        formatter.Serialize(stream,data);
        stream.Close();
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

}
