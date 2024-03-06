using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala1 : MonoBehaviour
{
    public float velocidad = 800f; // Velocidad de la bala
    private Rigidbody rb;
    float cont = 0;
    public float primerContacto = 0;
    public bool choque = false;
    void Start()
    {
        // Obtén el componente Rigidbody (asegúrate de que tu objeto tenga un Rigidbody adjunto)
        rb = GetComponent<Rigidbody>();

        // Desactiva la gravedad
        rb.useGravity = false;

        // Aplica una fuerza hacia adelante
        rb.AddForce(this.transform.forward * velocidad, ForceMode.VelocityChange);
    }

    private void Update()
    {
       
            Destroy(this.gameObject,10);
       
    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            Choque();
            MoverNave.instance.RestarVida(5);
            if (Atributos.Jugador.nivelArma > 0 && !choque)
            {
                choque = true;
                Atributos.Jugador.nivelArma--;
            }
            Destroy(this.gameObject);
        }
        if(other.tag =="BulletPlayer")
        {
            Destroy(this.gameObject);
        }
    }
    public void Choque()
    {
        CinemachineMovimientoCamara.Instance.MoverCamara(5, 0.5f, 2);
      
        primerContacto = 1;

    }
    /*void OnCollisionEnter(Collision collision)
    {
        
        // Destruye la bala al colisionar con otro objeto
        Destroy(gameObject);
        
    }*/
}
