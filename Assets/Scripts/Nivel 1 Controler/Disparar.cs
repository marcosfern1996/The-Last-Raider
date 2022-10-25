using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using static Unity.VisualScripting.Member;

public class Disparar : MonoBehaviour
{
    public static Disparar instance;
    public AudioSource fxSource;
    public AudioClip bala9mm;
    public GameObject[] Armas;

    public AudioClip balaEscopeta;
    public GameObject personaje;
    public float contador = 0;
    public LayerMask objetivo;
    RaycastHit hit;
    public float faltante;




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
        if (AtributosArmas.activar9mm)
        {
            Gizmos.color = Color.green;
            Debug.DrawRay(transform.position, transform.forward * AtributosArmas.distancia9mm, Color.green);
        }
        if (AtributosArmas.activarEscopeta)
        {
            Debug.DrawRay(transform.position, transform.forward * AtributosArmas.distanciaEscopeta, Color.blue);
        }
        
    }

    public void activar9mm()
    {
        AtributosArmas.activar9mm = true;
        AtributosArmas.activarEscopeta = false;
        DesactivarArmas();
        Armas[0].SetActive(true);

    }
    public void activarEscopeta()
    {
        AtributosArmas.activar9mm = false;
        AtributosArmas.activarEscopeta = true;
        DesactivarArmas();
        Armas[1].SetActive(true);
    }

    public void DesactivarArmas()
    {
        for (int i = 0; i < Armas.Length ; i++)
        {
            Armas[i].SetActive(false);
        }

    }


    public void recargar()
    {
        if(AtributosArmas.activar9mm && AtributosArmas.cantidadDeCargadores9mm  >= 0)
        {
            
            faltante = AtributosArmas.TamanioCargador9mm - AtributosArmas.cantidaBalas9mm;
            if (AtributosArmas.cantidadDeCargadores9mm  - faltante > 0)
            {
                
                AtributosArmas.cantidadDeCargadores9mm -= faltante;
                AtributosArmas.cantidaBalas9mm += faltante;
            }
            else{
                AtributosArmas.cantidaBalas9mm += AtributosArmas.cantidadDeCargadores9mm;
                AtributosArmas.cantidadDeCargadores9mm = 0;
            }
            
        }
        if (AtributosArmas.activarEscopeta && AtributosArmas.cantidadDeCargardoresEscopetas >= 0)
        {
            faltante = AtributosArmas.tamanioCargadorEscopeta - AtributosArmas.cantidadBalasEscopeta;
            if (AtributosArmas.cantidadDeCargardoresEscopetas - faltante > 0)
            {
                
                AtributosArmas.cantidadDeCargardoresEscopetas -= faltante;
                AtributosArmas.cantidadBalasEscopeta += faltante;
            }
            else
            {
                AtributosArmas.cantidadBalasEscopeta += AtributosArmas.cantidadDeCargardoresEscopetas;
                AtributosArmas.cantidadDeCargardoresEscopetas = 0;
            }

        }


    }
    public void disparar()
    {

        if (contador >= 2 && AtributosArmas.activar9mm)
        {
            
            if (AtributosArmas.cantidaBalas9mm > 0 && AtributosArmas.cantidadDeCargadores9mm >= 0)
            {
                Animacion.instance.animator.SetTrigger("disparo pistola");
                AtributosArmas.cantidaBalas9mm--;
                /*if(AtributosArmas.cantidaBalas9mm == 0)
                {
                    recargar();
                }*/
                fxSource.PlayOneShot(bala9mm);

                if (Physics.Raycast(transform.position, transform.forward * AtributosArmas.distancia9mm, out hit))
                {
                    if (hit.transform.tag == "Sangria")
                    {

                        hit.transform.gameObject.GetComponent<Sangria>().RestarVida(AtributosArmas.danio9mm);

                    }
                }
            }
            

            
        }
        if (contador >= 3 && AtributosArmas.activarEscopeta)
        {
            if (AtributosArmas.cantidadBalasEscopeta > 0)
            {
                Animacion.instance.animator.SetTrigger("disparo Escopeta");
                AtributosArmas.cantidadBalasEscopeta--;
                fxSource.PlayOneShot(balaEscopeta);

                if (Physics.Raycast(transform.position, transform.forward * AtributosArmas.distanciaEscopeta, out hit))
                {
                    if (hit.transform.tag == "Sangria")
                    {
                        // hit.transform.gameObject.GetComponent<Meteoro>().RestarVida(AtributosArmas.danioEscopeta);
                        hit.transform.gameObject.GetComponent<Sangria>().RestarVida(AtributosArmas.danioEscopeta);
                    }
                }
            }
            
        }
    }
}
   

