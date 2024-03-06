using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BehaviourEnemiShip : MonoBehaviour
{
   

    float cont = 0;
    bool Aparicion = true;
    public float salud = 20;
    GameObject[] objetosConEtiqueta;
    public GameObject bala;
    public GameObject spawn;
    private float conta=0;
    public GameObject mejora;
    float contador = 0;
    public ParticleSystem anim;


    // Start is called before the first frame update
    void Start()
    {
       // anim = GetComponent<ParticleSystem>();
        objetosConEtiqueta = GameObject.FindGameObjectsWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        conta += 1 * Time.deltaTime;
        if (Atributos.level.activeMeteoritos)
        {
            transform.Translate(Vector3.back * Random.Range(30, 50) * Time.deltaTime);
            
              Destroy(this.gameObject,4);
           
           
        }
        if (Atributos.level.activeShip && conta > 10)
        {
            transform.Translate(Vector3.back * Random.Range(30, 50) * Time.deltaTime);

            Destroy(this.gameObject, 4);

        }


        if (Atributos.level.activeShip && conta < 10)
        {

            cont += 1 * Time.deltaTime;
            if (cont < 1.5)
            {
                transform.Translate(Vector3.back * Random.Range(30, 50) * Time.deltaTime);
            }

            if (cont > 1.5)
            {
                transform.Rotate(Vector3.down * 600 * Time.deltaTime);
            }
            if (cont > 8)
            {
                transform.Rotate(Vector3.up * 600 * Time.deltaTime);
                cont = 1.5f;
            }

            contador += 2 * Time.deltaTime;
            if (contador >= 1 && Atributos.Nave.activarNave)
            {
                Instantiate(bala, spawn.transform.position, spawn.transform.rotation);
                contador = 0;
            }
          
        }
        if (salud <= 0)
        {
            int probabilidad = Random.Range(0, 100);
            if (probabilidad < 30)
            {
                
                Instantiate(mejora, spawn.transform.position, spawn.transform.rotation);
               
            }
            
            Destruir();
            Atributos.level.NavesDestruidas++;

        }
    }
    void CambiarDireccion()
    {
       
    }
    public void Destruir()
    {
        Instantiate(anim, this.transform.position, this.transform.rotation);
        Destroy(this.gameObject);
    }

    public void RestarVida(float cantidad)
    {
        salud -= cantidad;
    }
}
