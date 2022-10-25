using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Dialogos : MonoBehaviour
{
    public GameObject panelPersonaje1;
    public GameObject panelPersonaje2;

   
    public TMP_Text textoDialogo1;
    public TMP_Text textoDialogo2;

    public GameObject continuar;

    public int[] ordernDialogo;

    [SerializeField, TextArea(8, 6)] private string[] lineasDeDialogos;

    public bool elDIalogoComenso;
    public int lineaDeDialogo;

    public float tiempoDeEspera;



    void Start()
    {
        
    }

   
    void Update()
    {
        if (!elDIalogoComenso)
        {
            IniciarDialogo();
        }
    }

    public void IniciarDialogo()
    {
        if (ordernDialogo[lineaDeDialogo] == 0)
        {
            elDIalogoComenso = true;
            panelPersonaje1.SetActive(true);
            panelPersonaje2.SetActive(false);
            lineaDeDialogo = 0;
            StartCoroutine(ShowLine());
        }
        if (ordernDialogo[lineaDeDialogo] == 1)
        {
            elDIalogoComenso = true;
            panelPersonaje1.SetActive(false);
            panelPersonaje2.SetActive(true);
            lineaDeDialogo = 0;
            StartCoroutine(ShowLine());
        }

    }
    void SiguienteLineaDeCodigo()
    {
        lineaDeDialogo++;

        if (lineaDeDialogo < lineasDeDialogos.Length)
        {
            StartCoroutine(ShowLine());
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
        

    }

    private IEnumerator ShowLine()
    {
        if (ordernDialogo[lineaDeDialogo] == 0)
        {
            panelPersonaje1.SetActive(true);
            panelPersonaje2.SetActive(false);
            textoDialogo1.text = string.Empty;
            foreach (char ch in lineasDeDialogos[lineaDeDialogo])
            {

                textoDialogo1.text += ch;
                yield return new WaitForSeconds(tiempoDeEspera);
            }
        }
        if (ordernDialogo[lineaDeDialogo] == 1)
        {
            panelPersonaje1.SetActive(false);
            panelPersonaje2.SetActive(true);
            textoDialogo2.text = string.Empty;
            foreach (char ch in lineasDeDialogos[lineaDeDialogo])
            {

                textoDialogo2.text += ch;
                yield return new WaitForSeconds(tiempoDeEspera);
            }
        }
        
    }

    public void Continuar()
    {
        if (elDIalogoComenso)
        {
            if (textoDialogo1.text != lineasDeDialogos[lineaDeDialogo]|| textoDialogo2.text != lineasDeDialogos[lineaDeDialogo])
            {
                
                    StopAllCoroutines();
                    textoDialogo1.text = lineasDeDialogos[lineaDeDialogo];
                    textoDialogo2.text = lineasDeDialogos[lineaDeDialogo];

            }
            else
            {
                SiguienteLineaDeCodigo();
            }

        }
    }
}
