using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CambioDeCamara : MonoBehaviour
{
    public static CambioDeCamara instance;
    public  GameObject camaras;
    public int camActiva;
    public bool seActivoLaCamara = false;
    public int numeroDeCamara;
    

    void Start()
    {
        instance = this;
        
    }


    private void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            ActivarCamara();
            
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            CerrarCamaras();
        }
    }

    public void CerrarCamaras()
    {

        camaras.SetActive(false);



    }

    public void ActivarCamara()
    {
            
                camaras.SetActive(true);
              
               // CerrarCamaras();
       


            // camaras[0].SetActive(true);
     }
        /* public void ActivarCamara1()
         {

             seActivoLaCamara = true;
             CerrarCamaras();

             camaras[1].SetActive(true);

         }*/
        /* public void ActivarConCheckList()
         {
             if (checkbox.isOn)
             {
                 ActivarCamara0();
                 AtributosPersonaje.rotacionPersonaje = AtributosPersonaje.rotacionPersonaje * -1;
                 AtributosPersonaje.velocidadPersonaje=AtributosPersonaje.velocidadPersonaje  *-1;
             }
             else if(!checkbox.isOn)
             {
                 ActivarCamara1();
                 AtributosPersonaje.rotacionPersonaje = AtributosPersonaje.rotacionPersonaje * -1;
                 AtributosPersonaje.velocidadPersonaje = AtributosPersonaje.velocidadPersonaje * -1;

             }
         }*/
    
}
