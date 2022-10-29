using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.AI;
using JetBrains.Annotations;

public class Sangria : MonoBehaviour
{
    NavMeshAgent NavMeshAgent;
    public float velocidad;
    public Vector3 posicionInicial;

    public static Sangria instance;
    public bool detectado;
    public bool atacar;
    public LayerMask lmJugador;

    public GameObject ubicacionJugador;

    public float salud;
    public Transform jugador;
    public Vector3 ubicacion;
    public bool frenteAjugador;

    Vector3 rayoOrigen;
    Vector3 rayodestino;


    // Start is called before the first frame update
    private void Awake()
    {
        
        NavMeshAgent = GetComponent<NavMeshAgent>();
        instance = this;
        salud = AtributosEnemigos.saludSangria;
        NavMeshAgent.speed = AtributosEnemigos.velocidadSangria;
        
    }
    void Start()
    {
        posicionInicial = new Vector3(transform.position.x,transform.position.y,transform.position.z);
        ubicacionJugador = GameObject.Find("Personaje Pie");
        jugador = ubicacionJugador.transform;
    }

    // Update is called once per frame
    void Update()

    {
        RaycastHit hit;
        frenteAjugador = Physics.Raycast(transform.position, transform.forward, out hit, 8f, lmJugador);
        ubicacion = new Vector3(jugador.transform.position.x, transform.position.y, jugador.transform.position.z);
        detectado = Physics.CheckSphere(transform.position, 8f, lmJugador);
        atacar = Physics.CheckSphere(transform.position, 1.3f, lmJugador);


        rayoOrigen = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        rayodestino=new Vector3(ubicacionJugador.transform.position.x, ubicacionJugador.transform.position.y, ubicacionJugador.transform.position.z);
        rayodestino -= rayoOrigen;
        Ray ray = new Ray(rayoOrigen,rayodestino);
        

        
        if(Physics.Raycast(ray,out hit)){

            if(hit.collider.tag == "Player")
            {
                 if (atacar)
                    {
                         transform.position = Vector3.MoveTowards(transform.position, transform.position, 0f);
                    }

                    if (detectado && !atacar)
                    {

                        if (  frenteAjugador)
                        {
                            NavMeshAgent.SetDestination(jugador.transform.position);

                        }
                        transform.LookAt(ubicacion);

                    }

            
                     else
                    {
                      NavMeshAgent.SetDestination(posicionInicial);
                     }


        }


            if (salud <= 0)
            {
                Destroy(this.gameObject);
            }
        }



    }

    public void RestarVida(float danio)
    {
        salud -= danio;

    }

    private void OnDrawGizmos()
    {
        Gizmos.color=Color.red;
        Gizmos.DrawWireSphere(transform.position, 8f);
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, 2f);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, 1f);
        Gizmos.DrawRay(rayoOrigen, rayodestino);

    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            MoverPersonajeAPie.instance.RestarVida(AtributosEnemigos.danioEnemigoSangria);
        }
    }
}
