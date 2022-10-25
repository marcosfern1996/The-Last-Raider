using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MunicionEscopeta : MonoBehaviour
{
    public string lineasDeDialogos;
    public GameObject escopeta;

    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        CuadroDeComentario.instance.Comentar(lineasDeDialogos);
        AtributosArmas.cantidadDeCargardoresEscopetas += AtributosArmas.tamanioCargadorEscopeta;

        if (AtributosArmas.TengoLaPistola == false)
        {
            AtributosArmas.tengoLaEscopeta = true;
            escopeta.SetActive(true);
        }

        Destroy(this.gameObject);

    }
}
