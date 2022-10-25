using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CambioDeCamara : MonoBehaviour
{
    [SerializeField] private GameObject[] camaras;
    public int camActiva;
    public bool seActivoLaCamara = false;

    public Toggle checkbox;
    public GameObject check;

    void Start()
    {
        camaras[0].SetActive(true);
        checkbox = check.GetComponent<Toggle>();
    }


    private void Update()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player" )
        {
            ActivarCamara1();

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            ActivarCamara0();
        }
    }

    public void CerrarCamaras()
    {
        for (int x = 0; x < camaras.Length; x++)
        {
            camaras[x].SetActive(false);
        }
    }

    public void ActivarCamara0()
    {
       
        seActivoLaCamara = false;
        CerrarCamaras();

        camaras[0].SetActive(true);
    }
    public void ActivarCamara1()
    {
       
        seActivoLaCamara = true;
        CerrarCamaras();

        camaras[1].SetActive(true);
        
    }
    public void ActivarConCheckList()
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
    }
}
