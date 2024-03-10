using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Base : MonoBehaviour
{
    public GameObject puerta;
    public GameObject explocion;
    public GameObject sonidoExplcion;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Atributos.Eventos.iniciarPartida)
        {
            puerta.transform.Rotate(Vector3.left * 20 * Time.deltaTime);
            puerta.transform.Translate(Vector3.up * 20 * Time.deltaTime);
            transform.Translate(Vector3.back * 20 * Time.deltaTime);
            Destroy(this.gameObject, 5);
        }
       
    }
}
