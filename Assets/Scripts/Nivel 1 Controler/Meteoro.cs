using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Meteoro : MonoBehaviour
{
   // public static Meteoro instance;
    CinemachineMovimientoCamara cinemachineMovimientoCamara;
    public int proBotequin;
    public int proMejora;
    public int proMinerales;
    public float danioANave= 20;
    public float primerContacto=0;
    public bool choque=false;
    public float salud= 2;
    public GameObject[] items;
    public ParticleSystem anim;
    public float randomSize1;
    public float randomSize2;
    public AudioSource explocion;
    bool activar = false;
    float cont = 0;
    bool deadforshield;
    private void Awake()
    {
        
        //anim = GetComponent<ParticleSystem>();
        float randomSize3 = Random.Range(randomSize1, randomSize2); // Ajusta los valores según tus necesidades
        salud = salud * (randomSize3/20);
        transform.localScale = new Vector3(randomSize3, randomSize3, randomSize3);
        // salud = AtributosEnemigos.saludMeteoro;
        cinemachineMovimientoCamara = GetComponent<CinemachineMovimientoCamara>();
        
    }
    void Start()
    {
       
    }

    
    void Update()
    {
        transform.Translate(Vector3.back * Random.Range(50f, 300f) * Time.deltaTime);

        if (salud <= 0)
        {
            
            int probabilidad = Random.Range(0, 100);
           /* if (probabilidad < proMejora) {
                int probMejoras = Random.Range(0, 100);
                if(probMejoras < 33 && Atributos.Mejoras.ArmaLvl3 == 1)
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
            else if(probabilidad < proBotequin)
            {
                Instantiate(items[3], this.transform.position, this.transform.rotation);
            }else */if(probabilidad < proMinerales)
            {
                Instantiate(items[0], this.transform.position, this.transform.rotation);
            }


            if (!deadforshield && Atributos.Mejoras.Especial ==1)
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
        if(cont > Atributos.Meteorito.timeLife)
        {
            Destroy(this.gameObject);
        }
        
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Player")
        {
            
           MoverNave.instance.RestarVida(danioANave) ;
           Choque();
            if (Atributos.Jugador.nivelArma > 0 && !choque)
            {
                choque = true;
              //  Atributos.Jugador.nivelArma--;
            }
            if (!activar)
            {
                Instantiate(anim, this.transform.position, this.transform.rotation);
                Instantiate(explocion, this.transform.position, this.transform.rotation);

                activar = true;
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
