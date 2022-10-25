using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AbrirPuerta : MonoBehaviour
{
    
    public bool Desbloquedo;
    public bool actPuerta;
    public Transform puertaAbierta;
    public static AbrirPuerta instance;

    public string lineasDeDialogos;

    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

    public void Update()
    {
        if (actPuerta == true )
        {
            AbrirLaPuerta();

        }
    }

    public void AbrirLaPuerta()
    {
        transform.position = Vector3.MoveTowards(transform.position, puertaAbierta.position, 0.6f* Time.deltaTime);
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if ((Misiones.instance.consigueLallave == true && other.tag == "Player") ||( Desbloquedo && other.tag == "Player"))
        {

            actPuerta = true;
        }
        else {

            CuadroDeComentario.instance.Comentar(lineasDeDialogos);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        CuadroDeComentario.instance.TerminarComentario();
    }
}
