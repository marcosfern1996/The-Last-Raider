using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Audio;
using System;

public class MenuManager : MonoBehaviour
{

    public GameObject menuOpciones;
    public GameObject menu;
    public GameObject menuCanvas;
    public GameObject iniciarPartida;
    public GameObject creditos;
    public GameObject bloqueo;

    public GameObject[] itemsComprados;
    public GameObject[] BloqitemsComprados;

    public Slider volumenSlider;
    public Slider volumenSliderFx;
    public TextMeshProUGUI volumenTxt;
    public AudioMixer volumenGeneral;
    public AudioMixer volumenFx;
    public AudioSource fxSource;
    public AudioClip boton;
    public TMP_Text minerales;

    private void Awake()
    {
        Atributos.Eventos.iniciarPartida = false;
        Atributos.CargarDatos();
        volumenSlider.onValueChanged.AddListener(CambiarVolumenMaestro);
        volumenSliderFx.onValueChanged.AddListener(CambiarVolumenFx);
    }

    private void Start()
    {
        volumenSlider.value = PlayerPrefs.GetFloat("VolumenMusica");
        volumenSliderFx.value = PlayerPrefs.GetFloat("VolumenFX");

    }

    private void Update()
    {
        MostrarMejoras();
        BloquearCompradas();
        if (Atributos.Mejoras.nivelFinal == 1)
        {
            bloqueo.SetActive(false);
        }
        minerales.text = Atributos.Jugador.mineral.ToString();
    }

    private void BloquearCompradas()
    {
        if (Atributos.Mejoras.ArmaLvl1 == 1)
        {
            BloqitemsComprados[0].SetActive(true);
        }
        else { BloqitemsComprados[0].SetActive(false); }
        if (Atributos.Mejoras.ArmaLvl2 == 1)
        {
            BloqitemsComprados[1].SetActive(true);
        }
        else { BloqitemsComprados[1].SetActive(false); }
        if (Atributos.Mejoras.ArmaLvl3 == 1)
        {
            BloqitemsComprados[2].SetActive(true);
        }
        else { BloqitemsComprados[2].SetActive(false); }
        if (Atributos.Mejoras.Botequines == 1)
        {
            BloqitemsComprados[3].SetActive(true);
        }
        else { BloqitemsComprados[3].SetActive(false); }
        if (Atributos.Mejoras.Especial == 1)
        {
            BloqitemsComprados[4].SetActive(true);
        }
        else { BloqitemsComprados[4].SetActive(false); }
    }

    private void MostrarMejoras()
    {
        if (Atributos.Mejoras.ArmaLvl1==1)
        {
            itemsComprados[0].SetActive(true);
        }
        else { itemsComprados[0].SetActive(false); }
        if (Atributos.Mejoras.ArmaLvl2==1)
        {
            itemsComprados[1].SetActive(true);
        }
        else { itemsComprados[1].SetActive(false); }
        if (Atributos.Mejoras.ArmaLvl3==1)
        {
            itemsComprados[2].SetActive(true);
        }
        else { itemsComprados[2].SetActive(false); }
        if (Atributos.Mejoras.Botequines==1)
        {
            itemsComprados[3].SetActive(true);
        }
        else { itemsComprados[3].SetActive(false); }
        if (Atributos.Mejoras.Especial==1)
        {
            itemsComprados[4].SetActive(true);
        }
        else { itemsComprados[4].SetActive(false); }
    }

    public void ComprarArma1()
    {
        if(Atributos.Jugador.mineral >= 40)
        {
            Atributos.Jugador.mineral -= 40;
            Atributos.Mejoras.ArmaLvl1 = 1;
            Atributos.GuardarDatos();
        }
       

    }
    public void ComprarArma2()
    {
        if (Atributos.Jugador.mineral >= 80)
        {
            Atributos.Jugador.mineral -= 80;
            Atributos.Mejoras.ArmaLvl2 = 1;
            Atributos.GuardarDatos();
        }
       
    }
    public void ComprarArma3()
    {
        if (Atributos.Jugador.mineral >= 120)
        {
            Atributos.Jugador.mineral -= 120;
            Atributos.Mejoras.ArmaLvl3 = 1;
            Atributos.GuardarDatos();
        }
       

    }
    public void ComprarBotequines()
    {
        if (Atributos.Jugador.mineral >= 140)
        {
            Atributos.Jugador.mineral -= 140;
            Atributos.Mejoras.Botequines = 1;
            Atributos.GuardarDatos();
        }
       

    }
    public void Especial()
    {
        if (Atributos.Jugador.mineral >= 200)
        {
            Atributos.Jugador.mineral -= 200;
            Atributos.Mejoras.Especial = 1;
            Atributos.GuardarDatos();
        }
       

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
        menuCanvas.SetActive(false);
        Atributos.Eventos.iniciarPartida=true;
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

    public void MostrarCreditos()
    {
        SonidoDeBoton();
        menu.SetActive(false);
        creditos.SetActive(true);
    }
    public void OcultarCreditos()
    {
        SonidoDeBoton();
        menu.SetActive(true);
        creditos.SetActive(false);
    }

    public void SonidoDeBoton()
    {
        fxSource.PlayOneShot(boton);
    }
}
