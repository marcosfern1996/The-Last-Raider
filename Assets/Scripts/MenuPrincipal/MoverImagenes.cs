using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoverImagenes : MonoBehaviour
{
    public Scrollbar scrollbar;
    public MenuManager menuManager;
    public float valor;
    public Imagenes imagenes;


    public void Start()
    {
        
    }


    void Update()
    {
        valor = scrollbar.value;
        if(valor <= 1)
        {
            scrollbar.value += 0.1f * Time.deltaTime;
        }
        else if (valor >= 1 && imagenes.cambiarImagen == false)
        {
            scrollbar.value = 0;
            imagenes.cambiarImagen = true;
        }
       

    }
}
