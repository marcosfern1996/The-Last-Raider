using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;

public class MenuManager : MonoBehaviour
{

    public GameObject menuOpciones;
    public GameObject menu;
    public GameObject iniciarPartida;

    public Slider volumenSlider;
    public Slider volumenSliderFx;
    public TextMeshProUGUI volumenTxt;
    public AudioMixer volumenGeneral;
    public AudioMixer volumenFx;
    public AudioSource fxSource;
    public AudioClip boton;


    private void Awake()
    {
        volumenSlider.onValueChanged.AddListener(CambiarVolumenMaestro);
        volumenSliderFx.onValueChanged.AddListener(CambiarVolumenFx);
    }

    private void Start()
    {
        volumenSlider.value = PlayerPrefs.GetFloat("VolumenMusica");
        volumenSliderFx.value = PlayerPrefs.GetFloat("VolumenFX");

    }


    public void ActivarMenuOpciones()
    {
        SonidoDeBoton();
        menuOpciones.SetActive(true);
        menu.SetActive(false); 
    }

    public void DesactivarMenuOpciones()
    {
        SonidoDeBoton();
        menuOpciones.SetActive(false);
        menu.SetActive(true);  
    }

    public void IniciarPartida()
    {
        SonidoDeBoton();
        menu.SetActive(false);
        iniciarPartida.SetActive(true);
    }
    public void IniciarPartidaVolver()
    {
        SonidoDeBoton();
        menu.SetActive(true);
        iniciarPartida.SetActive(false);
    }


    public void CambiarSlider()
    {
        float numVolume=volumenSlider.value ;
        volumenTxt.SetText(Mathf.RoundToInt(numVolume).ToString());
    }

    public void CambiarVolumenMaestro(float v)
    {
        volumenGeneral.SetFloat("VolumenMusic", v);
        PlayerPrefs.SetFloat("VolumenMusica", v);

    }
    public void CambiarVolumenFx(float v)
    {
        volumenFx.SetFloat("VolumenFx", v);
        PlayerPrefs.SetFloat("VolumenFX", v);
    }

    public void Salir()
    {
        SonidoDeBoton();
        Application.Quit();
    }

    public void SonidoDeBoton()
    {
        fxSource.PlayOneShot(boton);
    }
}
