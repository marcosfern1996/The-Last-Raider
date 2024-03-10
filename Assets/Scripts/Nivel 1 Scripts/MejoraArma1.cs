using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MejoraArma1 : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * 40 * Time.deltaTime);
        Destroy(this.gameObject, 50);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
           // if(Atributos.Jugador.nivelArma < 3)
            {
                Atributos.Eventos.mejoraArmaVerde = true;
                Atributos.Eventos.mejoraArma = true;
                Atributos.Jugador.nivelArma= 1;
                Atributos.Jugador.contArma = 12;
                Destroy(this.gameObject);
            }
            
           
        }
    }
}
