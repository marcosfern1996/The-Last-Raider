using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Atributos
{
    static Atributos _instance;

    public class Eventos
    {
        public static bool curacion;
        public static bool mejoraArma;
        public static bool mejoraArmaVerde;
        public static bool mejoraArmaAmarilla;
        public static bool mejoraArmaRoja;
        public static bool mineral;
        public static bool iniciarPartida;
    }

    public class Mejoras
    {
        public static int ArmaLvl1;
        public static int ArmaLvl2;
        public static int ArmaLvl3;
        public static int Especial;
        public static int Botequines;
        public static int nivelFinal;
    }
    public class level
    {
        public static bool Arrancar = false;
        public static int points = 0;
        public static int NavesDestruidas = 0;
        public static bool activeShip = false;
        public static bool activeMeteoritos = true;

        public static float rotationAmountTravel = 0;
        public static float rotationAmountCombat = 0f;
    }
    public class Jugador
    {
        public int numeroEscena;

        public float[] posicionJugador = new float[3];

        public static int nivelArma = 0;
        public static int mineral;
        public static string dataSave;
        public static float contArma = 12;
        public static float contArmaMax = 12;
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
        public static float powerUp = 0;
        public static float powerUpMax = 100;


    }

    public class Meteorito
    {
        public static float saludMeteoro = 40;
        public static float Size;
        public static float velocidadMeteoro = Random.Range(30f, 300f);
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


    public static void GuardarDatos()
    {
        // Usar PlayerPrefs para guardar la puntuación
        PlayerPrefs.SetInt("Puntuacion", Jugador.mineral);
        PlayerPrefs.SetInt("ArmaLvl1", Mejoras.ArmaLvl1);
        PlayerPrefs.SetInt("ArmaLvl2", Mejoras.ArmaLvl2);
        PlayerPrefs.SetInt("ArmaLvl3", Mejoras.ArmaLvl3);
        PlayerPrefs.SetInt("Especial", Mejoras.Especial);
        PlayerPrefs.SetInt("NivelFinal", Mejoras.nivelFinal);
        PlayerPrefs.SetInt("Botequines", Mejoras.Botequines);
        Debug.Log("Se guararon: " + Jugador.mineral);
        // Guardar los cambios
        PlayerPrefs.Save();
    }

    public static void CargarDatos()
    {
        // Cargar la puntuación guardada (0 si no hay datos guardados)
        Jugador.mineral = PlayerPrefs.GetInt("Puntuacion", 0);
        Mejoras.ArmaLvl1 =PlayerPrefs.GetInt("ArmaLvl1", 0);
        Mejoras.ArmaLvl2 =PlayerPrefs.GetInt("ArmaLvl2", 0);
        Mejoras.ArmaLvl3 =PlayerPrefs.GetInt("ArmaLvl3", 0);
        Mejoras.Especial =PlayerPrefs.GetInt("Especial", 0);
        Mejoras.nivelFinal =PlayerPrefs.GetInt("NivelFinal", 0);
        Mejoras.Botequines = PlayerPrefs.GetInt("Botequines", 0);
        Debug.Log("Se cargaron: " + Jugador.mineral);
    }
}
