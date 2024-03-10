using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActivarMenus : MonoBehaviour
{
    public GameObject panelJuego;
    public GameObject panelPausa;
    public GameObject panelGameOver;
    public bool cargue = false;
    public bool EstoyEnLapuerta = false;

    public static ActivarMenus Instance;

    public GameObject camaraCombate;
    public GameObject camaraViaje;
    public GameObject camaraInicio;
    public GameObject agujeroDeGusano;

    public bool cambiarEvento;
    public int especial;
    float cont = 0;
    float Comienzo =0 ;

    private void Awake()
    {
        Atributos.level.Arrancar = true;
        especial = Atributos.Mejoras.Especial;
        Atributos.CargarDatos();
        Time.timeScale = 1;
        Atributos.level.points = 0;
        Atributos.level.NavesDestruidas = 0;
        Atributos.Nave.powerUp = 0;
        camaraCombate.SetActive(false);
        camaraInicio.SetActive(false);
        camaraViaje.SetActive(true);
    }
    private void Start()
    {
        Atributos.level.Arrancar = false;
       
    }
    private void Update()
    {
        if (Atributos.Eventos.iniciarPartida)
        {
            Comienzo += 1 * Time.deltaTime;
            if (Comienzo >= 3 && !Atributos.level.Arrancar)
            {
                Atributos.level.Arrancar = true;
            }

            if (Atributos.level.NavesDestruidas >= 50)
            {
                Atributos.Mejoras.nivelFinal = 1;
            }
            Atributos.Mejoras.Especial = especial;
            if (Atributos.level.activeMeteoritos)
            {
                cont += 1 * Time.deltaTime;
                //if(cont >= 3)
                //{
                //    Atributos.level.points++;
                //    cont = 0;
                //  }
                if (cont >= 0.5)
                {
                    camaraViaje.SetActive(true);
                    camaraCombate.SetActive(false);
                    agujeroDeGusano.SetActive(true);
                    cont = 0;
                }
            }
            else if (!Atributos.level.activeMeteoritos)
            {


                camaraViaje.SetActive(false);
                camaraCombate.SetActive(true);
                agujeroDeGusano.SetActive(false);
                cont = 0;


            }
        }
       
    }

    public void ActivarPuerta()
    {
        EstoyEnLapuerta = true;

    }

    public void ActivarPausa()
    {
        panelJuego.SetActive(false);
        panelPausa.SetActive(true);
        Time.timeScale = 0;

    }
    public void DesactivarPausa()
    {
        panelJuego.SetActive(true);
        panelPausa.SetActive(false);
        Time.timeScale = 1;

    }

    public void Reiniciar()
    {
        panelPausa.SetActive(false);
        panelJuego.SetActive(true);
        panelGameOver.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //int indiceDeEscena = SceneManager.GetActiveScene().buildIndex;
        //SceneManager.LoadScene(indiceDeEscena);
        Time.timeScale = 1;

    }
   
    public void IrAlMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;

    }
    public void GameOver()
    {
        panelJuego.SetActive(false);
        panelGameOver.SetActive(true);
        Time.timeScale = 0;

    }

}
