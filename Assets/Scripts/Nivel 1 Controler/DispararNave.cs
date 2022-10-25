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



    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        if (contador < 3)
        {
            contador += 6 * Time.deltaTime;
        }



    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawRay(transform.position, transform.forward * AtributosArmas.distanciaNave);
    }




    public void disparar()
    {

       
        if (contador >= 1 && AtributosArmas.activarNave)
        {

            fxSourse.PlayOneShot(disparo);

            if(Physics.Raycast(transform.position,transform.forward * AtributosArmas.distanciaNave, out hit))
            {
                if (hit.transform.tag == "Meteorito")
                {
                    hit.transform.gameObject.GetComponent<Meteoro>().RestarVida(AtributosArmas.danioNave);
                }

            }


           
        }
    }

}