using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtributosArmas : MonoBehaviour
{
    
    // pistola 9mm;
    public static bool TengoLaPistola = false;  
    public static float danio9mm = 8;            //cantidad de daño de la pistola
    public static float distancia9mm = 10;      //distancia de la pistola
    public static int TamanioCargador9mm = 12;  //tamaño del cartucho
    public static int cantidaBalas9mm = 0;      //cantidad de balas en cartucho
    public static int cantidadDeCargadores9mm = 0;  //cantidad debalas en total
    public static bool activar9mm;            //booleano para saber si la pistola esta activa

    //escopeta
    public static bool tengoLaEscopeta=false;
    public static float danioEscopeta = 20;     //cantidad de daño de la escopeta
    public static float distanciaEscopeta = 5;  //distancia de la escopeta
    public static int tamanioCargadorEscopeta = 4;  //tamaño del cartucho
    public static int cantidadBalasEscopeta = 0;    //cantidad de balas en cartucho
    public static int cantidadDeCargardoresEscopetas = 24;  //cantidad debalas en total
    public static bool activarEscopeta ;     //booleano para saber si la escopeta esta activa


    //nave
    public static float danioNave = 200;
    public static float distanciaNave = 70;
    public static bool activarNave=false;

    private void Awake()
    {
         cantidadDeCargadores9mm = PlayerPrefs.GetInt("balas9mm", 0);
    }

}


