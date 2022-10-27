
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class GuardarDatos 
{
    
    public static void GuardarPartida(MoverPersonajeAPie jugador)
    {
        DatosJugador datos = new DatosJugador(jugador);
        string dataPath = Application.persistentDataPath + "/Player.save";
        FileStream file =new FileStream(dataPath, FileMode.Create);
        BinaryFormatter binaryFormatter = new BinaryFormatter();
        binaryFormatter.Serialize(file, datos);
        file.Close();
        
    }
    public static DatosJugador CargarPartida()
    {
        string dataPath = Application.persistentDataPath + "/Player.save";
        if (File.Exists(dataPath))
        {
            FileStream file = new FileStream(dataPath, FileMode.Open);
            BinaryFormatter binFormatter = new BinaryFormatter();
            DatosJugador datosJugador = (DatosJugador) binFormatter.Deserialize(file);
            file.Close();
            return datosJugador;
        }
        else { return null; }
        
    }

}
