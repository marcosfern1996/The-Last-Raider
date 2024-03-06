using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class DispararNave : MonoBehaviour
{
    public static DispararNave instance;
    public AudioClip disparo;
    public AudioSource fxSourse;

    public float contador = 0;
    RaycastHit hit;
    public GameObject[] bala;
    public GameObject[] spawn;


    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {

        contador += 3 * Time.deltaTime;
        if (contador >= 1 && Atributos.Nave.activarNave)
        {
            disparar();
        }
    }
    // Update is called once per frame
    private void FixedUpdate()
    {
        


    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, transform.forward * Atributos.Nave.distanciaNave);
    }




    public void disparar()
    {

       
       
            switch (Atributos.Jugador.nivelArma)
            {
                case 0:
                    fxSourse.PlayOneShot(disparo);
                    Instantiate(bala[0], spawn[0].transform.position, spawn[0].transform.rotation);
                    break;
                case 1:
                    fxSourse.PlayOneShot(disparo);
                    Instantiate(bala[1], spawn[1].transform.position, spawn[1].transform.rotation);
                    Instantiate(bala[1], spawn[2].transform.position, spawn[2].transform.rotation);
                    break;
                case 2:
                    fxSourse.PlayOneShot(disparo);
                    Instantiate(bala[2], spawn[0].transform.position, spawn[0].transform.rotation);
                    Instantiate(bala[2], spawn[1].transform.position, spawn[1].transform.rotation);
                    Instantiate(bala[2], spawn[2].transform.position, spawn[2].transform.rotation);
                    break;
                case 3:
                    fxSourse.PlayOneShot(disparo);
                    Instantiate(bala[3], spawn[4].transform.position  , spawn[4].transform.rotation);
                    Instantiate(bala[3], spawn[1].transform.position  , spawn[1].transform.rotation);
                    Instantiate(bala[3], spawn[2].transform.position  , spawn[2].transform.rotation);
                    Instantiate(bala[3], spawn[3].transform.position  , spawn[3].transform.rotation);
                    break;
            }


            contador = 0;
        }
    

}