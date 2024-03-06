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

    public Image barraSalud;
    public GameObject[] arma;
    ActivarMenus activarMenus;
    public TMP_Text tMPro;
    public TMP_Text naves;
    float saludActual;

    // Start is called before the first frame update
    void Start()
    {
        activarMenus = GetComponent<ActivarMenus>();
    }

    // Update is called once per frame
    void Update()
    {
        saludActual = MoverNave.instance.saludNave;
        BarraDeSAlud();
        UpdatePoints();
        SelectGun();

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
                arma[0].SetActive(false);
                arma[1].SetActive(true);
                arma[2].SetActive(false);
                arma[3].SetActive(false);
                break;
            case 2:
                arma[0].SetActive(false);
                arma[1].SetActive(false);
                arma[2].SetActive(true);
                arma[3].SetActive(false);
                break;
            case 3:
                arma[0].SetActive(false);
                arma[1].SetActive(false);
                arma[2].SetActive(false);
                arma[3].SetActive(true);
                break;
        }
    }

    public void BarraDeSAlud()
    {
        barraSalud.fillAmount = saludActual / Atributos.Nave.salud;

        if (MoverNave.instance.saludNave<= 0)
        {

            activarMenus.GameOver();
        }
    }
    public void UpdatePoints()
    {
        tMPro.text = Atributos.level.points.ToString();
        naves.text = Atributos.level.NavesDestruidas.ToString();
    }
}
