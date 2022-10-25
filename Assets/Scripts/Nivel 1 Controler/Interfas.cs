using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;
using TMPro;

public class Interfas : MonoBehaviour
{
    public TextMeshProUGUI municion;
    public Image barraSalud;
    ActivarMenus activarMenus;
    float saludActual;

    // Start is called before the first frame update
    void Start()
    {
        activarMenus = GetComponent<ActivarMenus>();    
    }

    // Update is called once per frame
    void Update()
    {
        if (AtributosArmas.activar9mm)
        {
           if(AtributosArmas.cantidaBalas9mm == 0 && AtributosArmas.cantidadDeCargadores9mm == 0)
            {
                municion.text = "9mm : " + 0 + " / " + 0;
            } else {
                municion.text = "9mm : " +AtributosArmas.cantidaBalas9mm + " / " + AtributosArmas.cantidadDeCargadores9mm;
            }
            
            
            
        }else if (AtributosArmas.activarEscopeta)
        {

            float cartuchoEscopeta = AtributosArmas.cantidadBalasEscopeta % (AtributosArmas.tamanioCargadorEscopeta + 1) ;
            municion.text = "Escopeta : " + AtributosArmas.cantidadBalasEscopeta + " / " + AtributosArmas.cantidadDeCargardoresEscopetas;

        }
        
        saludActual = MoverPersonajeAPie.instance.saludPersanjeIndi;
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
}
