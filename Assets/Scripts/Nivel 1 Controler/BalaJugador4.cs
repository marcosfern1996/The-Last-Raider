using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalaJugador4 : MonoBehaviour
{
    public float velocidad = 80; // Velocidad de la bala
    private Rigidbody rb;
    float cont = 0;
    public int da�o = 25;

    void Start()
    {
        // Obt�n el componente Rigidbody (aseg�rate de que tu objeto tenga un Rigidbody adjunto)
        rb = GetComponent<Rigidbody>();

        // Desactiva la gravedad
        rb.useGravity = false;

        // Aplica una fuerza hacia adelante
        rb.AddForce(this.transform.forward * velocidad, ForceMode.VelocityChange);
    }

    private void Update()
    {
        cont += 1 * Time.deltaTime;
        if (cont > 0.5)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {


        if (other.tag == "Meteorito")
        {
            Meteoro meteoroScript = other.GetComponent<Meteoro>();

            // Verifica si se encontr� el script
            if (meteoroScript != null)
            {
                // Llama a la funci�n RestarVida() en el script Meteoro
                meteoroScript.salud -= da�o;
                Destroy(this.gameObject);
            }
        }
        if (other.tag == "enemyShip")
        {
            BehaviourEnemiShip meteoroScript = other.GetComponent<BehaviourEnemiShip>();

            // Verifica si se encontr� el script
            if (meteoroScript != null)
            {
                // Llama a la funci�n RestarVida() en el script Meteoro
                meteoroScript.salud -= da�o;
                Destroy(this.gameObject);
            }
        }
        if (other.tag == "NaveDeCarga")
        {
            NaveDeCarga naveDeCarfaScript = other.GetComponent<NaveDeCarga>();

            // Verifica si se encontr� el script
            if (naveDeCarfaScript != null)
            {
                // Llama a la funci�n RestarVida() en el script Meteoro
                naveDeCarfaScript.salud -= da�o;
                Destroy(this.gameObject);
            }
        }
        if (other.tag == "Bullet")
        {
            //Destroy(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
