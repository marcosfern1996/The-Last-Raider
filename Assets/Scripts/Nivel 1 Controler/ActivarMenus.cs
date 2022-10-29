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

    private void Awake()
    {
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
        panelJuego.SetActive(true );
        panelPausa.SetActive(false);
        Time.timeScale = 1;

    }

    public void Reiniciar()
    {
        panelPausa.SetActive(false); 
        panelJuego.SetActive(true ) ;
        panelGameOver.SetActive(false);
        DatosAGuardar.Instance.cargarEscena();
        Time.timeScale = 1;
       
    }
    public void IrAlMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;

    }
    public void GameOver()
    {
        panelJuego.SetActive(false );
        panelGameOver.SetActive(true);
        Time.timeScale = 0;

    }




}
