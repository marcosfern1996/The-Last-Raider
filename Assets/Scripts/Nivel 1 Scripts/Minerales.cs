using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Minerales : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        transform.Translate(Vector3.back * 40 * Time.deltaTime);
        Destroy(this.gameObject, 50);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Atributos.Eventos.mineral = true;
            Atributos.Jugador.mineral++;
            Destroy(this.gameObject);



        }
    }
}

