using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class municion9mm : MonoBehaviour
{
    public string lineasDeDialogos;
   // public GameObject pistola;
    

    private void Awake()
    {
        

    }

    private void Update()
    {
       
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            CuadroDeComentario.instance.Comentar(lineasDeDialogos);
            AtributosArmas.cantidadDeCargadores9mm += AtributosArmas.TamanioCargador9mm;

            if (AtributosArmas.TengoLaPistola==false)
            {
                AtributosArmas.TengoLaPistola = true;
            }


            Destroy(this.gameObject);

        }

    }

   
    
}
