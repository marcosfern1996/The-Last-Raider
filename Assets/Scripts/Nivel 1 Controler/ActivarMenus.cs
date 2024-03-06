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
    public GameObject agujeroDeGusano;

    public bool cambiarEvento;

    float cont = 0;

    private void Awake()
    {
        Time.timeScale = 1;
        Atributos.level.points = 0;
        /*
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {

            if (Instance != null)
            {
                Destroy(gameObject);
            }
        }*/
    }

    private void Update()
    {
        if (Atributos.level.activeMeteoritos)
        {
            cont += 1 * Time.deltaTime;
            if(cont >= 3)
            {
                Atributos.level.points++;
                cont = 0;
            }
          
            camaraViaje.SetActive(true);
            camaraCombate.SetActive(false);
            agujeroDeGusano.SetActive(true);

        }
        else if (!Atributos.level.activeMeteoritos)
        {
          
           
            camaraViaje.SetActive(false);
            camaraCombate.SetActive(true);
            agujeroDeGusano.SetActive(false);
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
        // cargarEscena();
        int indiceDeEscena = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(indiceDeEscena);
        Time.timeScale = 1;

    }
    /* public void cargarEscena()
     {


         CargarPartida();
         ActivarMenus.Instance.panelPausa.SetActive(false);
         ActivarMenus.Instance.panelJuego.SetActive(true);
     }*/
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

   public void ActivarModoCombate()
    {

    }
    public void ActivarModoViaje()
    {

    }

}
