using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;
using TMPro;

public class Interfas : MonoBehaviour
{/*
    public TextMeshProUGUI municion;
    public Image barraSalud;
    ActivarMenus activarMenus;
    float saludActual;

    public GameObject[] armas;

    // Start is called before the first frame update
    void Start()
    {
        activarMenus = GetComponent<ActivarMenus>();    
       
    }

    // Update is called once per frame
    void Update()
    {

        if (AtributosArmas.TengoLaPistola)
        {
            armas[0].SetActive(true);

        }
        if (AtributosArmas.tengoLaEscopeta)
        {
            
            armas[1].SetActive ( true);
        }

        if (AtributosArmas.activar9mm)
        {
            armas[1].GetComponent<Image>().color = Color.clear;
            armas[0].GetComponent<Image>().color = Color.grey;

            if (AtributosArmas.cantidaBalas9mm == 0 && AtributosArmas.cantidadDeCargadores9mm == 0)
            {
                municion.text = "9mm : " + 0 + " / " + 0;
            } else {
                municion.text = AtributosArmas.cantidaBalas9mm + " / " + AtributosArmas.cantidadDeCargadores9mm;
            }
            
            
            
        }else if (AtributosArmas.activarEscopeta)
        {
            armas[0].GetComponent<Image>().color = Color.clear;
            armas[1].GetComponent<Image>().color = Color.grey;

            float cartuchoEscopeta = AtributosArmas.cantidadBalasEscopeta % (AtributosArmas.tamanioCargadorEscopeta + 1) ;
            municion.text =  AtributosArmas.cantidadBalasEscopeta + " / " + AtributosArmas.cantidadDeCargardoresEscopetas;

        }
       
      // saludActual = MoverPersonajeAPie.instance.saludPersanjeIndi;
        BarraDeSAlud();

    }
    public void BarraDeSAlud()
    {
        barraSalud.fillAmount = saludActual / AtributosPersonaje.salud;

        if (MoverPersonajeAPie.instance.saludPersanjeIndi <= 0)
        {
            
            activarMenus.GameOver();
        }
    }

    
    */
}
