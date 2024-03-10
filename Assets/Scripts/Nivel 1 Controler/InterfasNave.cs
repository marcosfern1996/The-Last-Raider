using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;
using TMPro;
using System;

public class InterfasNave : MonoBehaviour
{
    public GameObject ButtonShot;
    public Image barraSalud;
    public Image barraPowerUp;
    public Image arma0;
    public Image arma1;
    public Image arma2;
    public Image arma3;
    public GameObject[] arma;
    ActivarMenus activarMenus;
    public TMP_Text tMPro;
    public TMP_Text naves;
    public TMP_Text minerales;
    float saludActual;

    // Start is called before the first frame update
    void Start()
    {
        activarMenus = GetComponent<ActivarMenus>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Atributos.Eventos.iniciarPartida)
        {
            saludActual = MoverNave.instance.saludNave;
            BarraDeSAlud();
            UpdatePoints();
            SelectGun();
            if (Atributos.Nave.powerUp >= 100)
            {
                ButtonShot.SetActive(true);
            }
            else { ButtonShot.SetActive(false); }
        }
       
    }

    private void SelectGun()
    {
        switch (Atributos.Jugador.nivelArma)
        {
            case 0:
                arma[0].SetActive(true);
                arma[1].SetActive(false);
                arma[2].SetActive(false);
                arma[3].SetActive(false);
                break;
            case 1:
                //arma[0].SetActive(false);
                arma[1].SetActive(true);
                arma[2].SetActive(false);
                arma[3].SetActive(false);
                break;
            case 2:
                //arma[0].SetActive(false);
                arma[1].SetActive(false);
                arma[2].SetActive(true);
                arma[3].SetActive(false);
                break;
            case 3:
                //arma[0].SetActive(false);
                arma[1].SetActive(false);
                arma[2].SetActive(false);
                arma[3].SetActive(true);
                break;
        }
    }

    public void BarraDeSAlud()
    {
        barraSalud.fillAmount = saludActual / Atributos.Nave.salud;
        barraPowerUp.fillAmount = Atributos.Nave.powerUp / Atributos.Nave.powerUpMax;
        arma0.fillAmount = Atributos.Jugador.contArma / Atributos.Jugador.contArmaMax;
        /*arma1.fillAmount = Atributos.Jugador.contArma / Atributos.Jugador.contArmaMax;
        arma2.fillAmount = Atributos.Jugador.contArma / Atributos.Jugador.contArmaMax;
        arma3.fillAmount = Atributos.Jugador.contArma / Atributos.Jugador.contArmaMax;*/

        if (MoverNave.instance.saludNave<= 0)
        {

            activarMenus.GameOver();
            Atributos.GuardarDatos();
        }
    }
    public void UpdatePoints()
    {
        tMPro.text = Atributos.level.points.ToString();
        naves.text = Atributos.level.NavesDestruidas.ToString();
        minerales.text = Atributos.Jugador.mineral.ToString();
    }
}
