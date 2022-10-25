using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CuadroDeComentario : MonoBehaviour
{
    float cont = 0f;
     public static CuadroDeComentario instance;
     public GameObject panelDialogo;
    public TMP_Text textoDeDialogo;
    public bool mostrando;
    

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (mostrando)
        {
            cont += 1 * Time.deltaTime;
            if (cont > 2f)
            {
                TerminarComentario();
                cont = 0;
            }
        }
    }


    public void Comentar(string lineasDeDialogos)
    {
        mostrando = true;
        textoDeDialogo.text = lineasDeDialogos;
        panelDialogo.SetActive(true);
        
    }

    public void TerminarComentario()
    {
        panelDialogo.SetActive(false);
        mostrando=false;
    }
    

    
}
