using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class municion9mm : MonoBehaviour
{
    public string lineasDeDialogos;
    public GameObject pistola;
    public int pistolaTrue;

    private void Awake()
    {
        pistolaTrue = PlayerPrefs.GetInt("TengoLaPistola",0);

        if (pistolaTrue != 0)
        {
            pistola.SetActive(true);
        }
    }

    private void Update()
    {
        if (AtributosArmas.activar9mm == true)
        {
            pistola.GetComponent<Image>().color=Color.blue;
        }
        else
        {
            pistola.GetComponent<Image>().color=Color.red;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            CuadroDeComentario.instance.Comentar(lineasDeDialogos);
            AtributosArmas.cantidadDeCargadores9mm += AtributosArmas.TamanioCargador9mm;

            if (pistolaTrue == 0)
            {
               // GuardarDatos.instance.guardarDatosDePistola(1, AtributosArmas.cantidadDeCargadores9mm += AtributosArmas.TamanioCargador9mm);
                pistola.SetActive(true);
            }


            Destroy(this.gameObject);

        }

    }

   
    
}
