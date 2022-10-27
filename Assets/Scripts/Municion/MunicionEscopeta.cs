using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MunicionEscopeta : MonoBehaviour
{
    public string lineasDeDialogos;
    public GameObject escopeta;

    // Start is called before the first frame update
    private void Update()
    {
        if (AtributosArmas.activarEscopeta == true)
        {
            escopeta.GetComponent<Image>().color = Color.blue;
        }
        else
        {
            escopeta.GetComponent<Image>().color = Color.red;
        }
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
                escopeta.SetActive(true);
            }

            Destroy(this.gameObject);
        }
        

    }
}
