using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Meteoro : MonoBehaviour
{
   // public static Meteoro instance;
    CinemachineMovimientoCamara cinemachineMovimientoCamara;
    public float danioANave= 20;
    public float primerContacto=0;
    public bool choque=false;
    public float salud= 20;
    public GameObject[] items;
    public ParticleSystem anim;

    float cont = 0;
    private void Awake()
    {
        //anim = GetComponent<ParticleSystem>();
        float randomSize = Random.Range(0.5f, 2.0f); // Ajusta los valores según tus necesidades
        salud = salud * randomSize;
        transform.localScale = new Vector3(randomSize, randomSize, randomSize);
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
        { int probabilidad = Random.Range(0, 100);
                if (probabilidad < 30) {
                Instantiate(items[0], this.transform.position, this.transform.rotation);
            }else if(probabilidad < 60)
            {
                Instantiate(items[1], this.transform.position, this.transform.rotation);
            }
            Instantiate(anim, this.transform.position, this.transform.rotation);
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
            
           MoverNave.instance.RestarVida(Atributos.Meteorito.danioMeteoro) ;
           Choque();
            if (Atributos.Jugador.nivelArma > 0 && !choque)
            {
                choque = true;
                Atributos.Jugador.nivelArma--;
            }

            Destruir();
                

           
            
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
