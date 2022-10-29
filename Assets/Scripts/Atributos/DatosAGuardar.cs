using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class DatosAGuardar : MonoBehaviour
{

    public static DatosAGuardar Instance;

    

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

    public void CargarPartida()
    {

        DatosJugador datosJugador = GuardarDatos.CargarPartida();
        
        
        SceneManager.LoadScene(datosJugador.numeroEscena);
        Time.timeScale = 1;
        ActivarMenus.Instance.cargue = true;
        MoverPersonajeAPie.instance.GetComponent<Transform>().position =new Vector3(datosJugador.posicionJugador[0], datosJugador.posicionJugador[1], datosJugador.posicionJugador[2]);

        MoverPersonajeAPie.instance.saludPersanjeIndi = datosJugador.saludActual;
        //MoverPersonajeAPie.instance.transform.position = 
        AtributosArmas.cantidadDeCargadores9mm = datosJugador.cantidadDeCargadores9mm;
        AtributosArmas.cantidaBalas9mm = datosJugador.cantidadDeBalasPistola;
        AtributosArmas.cantidadDeCargardoresEscopetas = datosJugador.cantidadDeCargadoresEscopeta;
        AtributosArmas.cantidadBalasEscopeta = datosJugador.cantidadDeBalasEscopeta;
        Debug.Log("se cargo la partida");


    }
    public void cargarEscena()
    {

       
        CargarPartida();
        ActivarMenus.Instance.panelPausa.SetActive(false);
        ActivarMenus.Instance.panelJuego.SetActive(true);
    }


    public void GuardarPartida()
    {
        GuardarDatos.GuardarPartida(MoverPersonajeAPie.instance);
        Debug.Log("se guardo la partida");

    }
}
