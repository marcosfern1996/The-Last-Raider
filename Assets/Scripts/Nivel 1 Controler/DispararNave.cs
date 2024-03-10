using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class DispararNave : MonoBehaviour
{
    public static DispararNave instance;
    public AudioClip disparo;
    public AudioSource fxSourse;
    public AudioSource agarrarArmaNueva;
    public AudioSource agarrarMineral;
    public GameObject ondaExpanciva;
    public ParticleSystem agarrarCuracion;
    public ParticleSystem MejoraVerde;
    public ParticleSystem MejoraAAmarilla;
    public ParticleSystem MejoraRoja;

    public float contador = 0;
    RaycastHit hit;
    public GameObject[] bala;
    public GameObject[] spawn;


    private void Awake()
    {
        
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        if (Atributos.Eventos.iniciarPartida)
        {
            agarrarBotequin();

            AgarrarMineral();
            agarrarArma();
            agarrarArmaVerde();
            agarrarArmaAmarilla();
            agarrarArmaRoja();


            contador += 3 * Time.deltaTime;
            if (contador >= 1 && Atributos.Nave.activarNave && Atributos.level.Arrancar)
            {
                disparar();
            }

        }

    }

    private void agarrarArmaVerde()
    {
        if (Atributos.Eventos.mejoraArmaVerde)
        {
            MejoraVerde.Play();
            Atributos.Eventos.mejoraArmaVerde = false;
        }
    }

    private void agarrarArmaAmarilla()
    {
        if (Atributos.Eventos.mejoraArmaAmarilla)
        {
            MejoraAAmarilla.Play();
            Atributos.Eventos.mejoraArmaAmarilla = false;
        }
    }

    private void agarrarArmaRoja()
    {
        if (Atributos.Eventos.mejoraArmaRoja)
        {
            MejoraRoja.Play();
            Atributos.Eventos.mejoraArmaRoja = false;
        }
    }

    private void agarrarBotequin()
    {
        if (Atributos.Eventos.curacion)
        {
            agarrarCuracion.Play();
            Atributos.Eventos.curacion = false;
        }
       
    }

    private void AgarrarMineral()
    {
    if (Atributos.Eventos.mineral)
    {
        agarrarMineral.Play();
        Atributos.Eventos.mineral = false;
        }
    }

    private void agarrarArma()
{
    if (Atributos.Eventos.mejoraArma)
    {
        agarrarArmaNueva.Play();
        Atributos.Eventos.mejoraArma = false;
        }
    }


    // Update is called once per frame
    private void FixedUpdate()
    {
        


    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, transform.forward * Atributos.Nave.distanciaNave);
    }


    public void escudo()
    {
        if(Atributos.Nave.powerUp >= 100)
        {
            Instantiate(ondaExpanciva, this.transform.position, this.transform.rotation);
            Atributos.Nave.powerUp = 0;
        }
    }

    public void disparar()
    {

       
       
            switch (Atributos.Jugador.nivelArma)
            {
                case 0:
                    fxSourse.PlayOneShot(disparo);
                    Instantiate(bala[0], spawn[0].transform.position, spawn[0].transform.rotation);
                    break;
                case 1:
                    fxSourse.PlayOneShot(disparo);
                    Instantiate(bala[1], spawn[1].transform.position, spawn[1].transform.rotation);
                    Instantiate(bala[1], spawn[2].transform.position, spawn[2].transform.rotation);
                    break;
                case 2:
                    fxSourse.PlayOneShot(disparo);
                    Instantiate(bala[2], spawn[0].transform.position, spawn[0].transform.rotation);
                    Instantiate(bala[2], spawn[1].transform.position, spawn[1].transform.rotation);
                    Instantiate(bala[2], spawn[2].transform.position, spawn[2].transform.rotation);
                    break;
                case 3:
                    fxSourse.PlayOneShot(disparo);
                    Instantiate(bala[3], spawn[4].transform.position  , spawn[4].transform.rotation);
                    Instantiate(bala[3], spawn[1].transform.position  , spawn[1].transform.rotation);
                    Instantiate(bala[3], spawn[2].transform.position  , spawn[2].transform.rotation);
                    Instantiate(bala[3], spawn[3].transform.position  , spawn[3].transform.rotation);
                    break;
            }


            contador = 0;
        }
    

}