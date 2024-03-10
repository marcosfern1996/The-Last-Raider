using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class NaveDeCarga : MonoBehaviour
{
   // public static Meteoro instance;
    CinemachineMovimientoCamara cinemachineMovimientoCamara;
    public int proBotequin;
    public int proMejora;
    public int velociadMin;
    public int velociadMax;
    public float danioANave= 20;
    public float primerContacto=0;
    public bool choque=false;
    public float salud= 20;
    public GameObject[] items;
    public ParticleSystem anim;    
    public AudioSource explocion;
    bool activar = false;
    float cont = 0;
    bool deadforshield;
    private void Awake()
    {
        cinemachineMovimientoCamara = GetComponent<CinemachineMovimientoCamara>();
    }
    void Start()
    {
       
    }

    
    void Update()
    {
        if (Atributos.Eventos.iniciarPartida)
        {
            transform.Translate(Vector3.back * Random.Range(velociadMin, velociadMax) * Time.deltaTime);

            if (salud <= 0)
            {

                int probabilidad = Random.Range(0, 100);
                if (probabilidad < proMejora)
                {
                    int probMejoras = Random.Range(0, 100);
                    if (probMejoras < 33 && Atributos.Mejoras.ArmaLvl3 == 1)
                    {
                        Instantiate(items[2], this.transform.position, this.transform.rotation);
                    }
                    else if (probMejoras < 66 && Atributos.Mejoras.ArmaLvl2 == 1)
                    {
                        Instantiate(items[1], this.transform.position, this.transform.rotation);
                    }
                    else if (probMejoras < 99 && Atributos.Mejoras.ArmaLvl1 == 1)
                    {
                        Instantiate(items[0], this.transform.position, this.transform.rotation);
                    }

                }
                else if (probabilidad < proBotequin && Atributos.Mejoras.Botequines == 1)
                {
                    Instantiate(items[3], this.transform.position, this.transform.rotation);
                }


                if (!deadforshield && Atributos.Mejoras.Especial == 1)
                {
                    Atributos.Nave.powerUp += Random.Range(5, 15);
                }
                //Atributos.Jugador.mineral++;
                if (!activar)
                {
                    Instantiate(anim, this.transform.position, this.transform.rotation);
                    Instantiate(explocion, this.transform.position, this.transform.rotation);

                    activar = true;
                }

                Destruir();
                //Atributos.level.points++;

            }

            cont += 1 * Time.deltaTime;
            Destroy(this.gameObject, 15);


        }

    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Player")
        {
            
           MoverNave.instance.RestarVida(Atributos.Meteorito.danioMeteoro) ;
           Choque();
            if (Atributos.Jugador.nivelArma > 0 && !choque)
            {
                choque = true;
              //  Atributos.Jugador.nivelArma--;
            }

            Destruir();
                

           
            
        }
        if (other.tag == "PowerUp")
        {
            deadforshield = true;
            salud = 0;
        }
    }

        private void OnTriggerExit(Collider other)
        {
            if (other.tag == "Player")
            {
                primerContacto = 0;
                

            }
        }

    public void Choque()
    {
        CinemachineMovimientoCamara.Instance.MoverCamara(5, 0.5f, 2);
        
        primerContacto = 1;
        
    }
    public void Destruir()
    {
        Destroy(this.gameObject);
    }

    public void RestarVida(float cantidad)
    {
        salud -= cantidad;
    }
    
}
