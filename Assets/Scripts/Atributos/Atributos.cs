using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atributos 
{
    static Atributos _instance;

    public class level
    {
        public static int points = 0;
        public static int NavesDestruidas = 0;
        public static bool activeShip= false;
        public static bool activeMeteoritos =true;

        public static float rotationAmountTravel = 0;
        public static float rotationAmountCombat = 0f;
    }
    public class Jugador
    {
          public int numeroEscena;

         public float[] posicionJugador=new float[3];
        
        public static int nivelArma =0 ;

    }
    
    public class Nave
    {
       // public static float velocidad = 0;
       // public static float rotacionEnModoCombate = 1;
       // public static float saludPersonaje = 50;

        public static float salud = 100;        
        public static float rotacionEnvuelo = 80;
        public static float velocidadEnvuelo = 80;
        
        public static float saludDNave;
        public static float danioNave = 22200;
        public static float distanciaNave = 70;
        public static bool activarNave = false;

    }

    public class Meteorito
    {
        public static float saludMeteoro = 40;
        public static float Size ;
        public static float velocidadMeteoro = Random.Range(30f,300f);
        public static float danioMeteoro = 5;
        public static float timeLife = 10f;

        
    }
    public class contador
    {
        public bool conta(float time)
        {
            float cont = 0;
            while (cont < time)
            {
                cont += 1 * Time.deltaTime;

            }
            return true;
        }
    }
   

}
