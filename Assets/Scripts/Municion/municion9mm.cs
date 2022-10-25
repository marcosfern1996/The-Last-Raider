using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class municion9mm : MonoBehaviour
{
    public string lineasDeDialogos;
    public GameObject pistola;

    // Start is called before the first frame update

    private void OnTriggerEnter(Collider other)
    {
        CuadroDeComentario.instance.Comentar(lineasDeDialogos);
        AtributosArmas.cantidadDeCargadores9mm +=AtributosArmas.TamanioCargador9mm;

        if (AtributosArmas.TengoLaPistola == false)
        {
            AtributosArmas.TengoLaPistola = true;
            pistola.SetActive(true); 
        }
        
        Destroy(this.gameObject);

    }
    
}
