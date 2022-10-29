using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MunicionEscopeta : MonoBehaviour
{
    public string lineasDeDialogos;
    
    private void Update()
    {
       
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            CuadroDeComentario.instance.Comentar(lineasDeDialogos);
            AtributosArmas.cantidadDeCargardoresEscopetas += AtributosArmas.tamanioCargadorEscopeta;

            if (AtributosArmas.tengoLaEscopeta == false)
            {
                AtributosArmas.tengoLaEscopeta = true;
              
            }

            Destroy(this.gameObject);
        }
        

    }
}
