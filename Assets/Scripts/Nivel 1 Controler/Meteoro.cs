using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Meteoro : MonoBehaviour
{
    public static Meteoro instance;
    CinemachineMovimientoCamara cinemachineMovimientoCamara;
    public float danioANave= 20;
    public float primerContacto=0;
    public bool chocque;
    public float salud= 20000;
   

    private void Awake()
    {
       
        instance = this;
       // salud = AtributosEnemigos.saludMeteoro;
        cinemachineMovimientoCamara = GetComponent<CinemachineMovimientoCamara>();
    }
    void Start()
    {
       
    }

    
    void Update()
    {
        if(salud <= 0)
        {
            Destruir();
        }

        

    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other.tag == "Player")
        {
            
            chocque = true;
            if (chocque && primerContacto == 0)
            {
                
                   MoverNave.instance.RestarVida(AtributosEnemigos.danioMeteoro) ;
                    Choque();
                    Destruir();
                

            }
           
            
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
        chocque = false;
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
