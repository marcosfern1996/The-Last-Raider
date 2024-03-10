using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;




[System.Serializable]
public class Limites
{
    public float xMin, xMax, yMin, yMax, zMin, zMax;
}

public class MoverNave : MonoBehaviour
{
    public Limites limites;

    public static MoverNave instance;
    
    private CharacterController characterController;
    public Joystick joystickMove;
    public Joystick joystickGiro;
    public float doblarV;
    public float doblarH;
    public float girarV;
    public float girarH;
    public float rotarNave=0;
    public float subirNave=0;
    private GameObject jugador;
    public float velocidadIndi;
    public float saludNave;
    public float danioIndi;
    public float rotacionEnvueloIndi;
   
    float cont = 0;
    float contArma = 0;

    public float anguloDeseado = 90f;


    private void Start()
    {
        jugador = this.gameObject;
        instance = this;
        //velocidadIndi = Atributos.Nave.velocidad;
        Atributos.Nave.activarNave = true;
        saludNave = Atributos.Nave.salud;
        
        rotacionEnvueloIndi = Atributos.Nave.rotacionEnvuelo;
        
        characterController = GetComponent<CharacterController>();
    }

    

    public void RestarVida(float danio)
    {
        saludNave -= danio;

    } public void SumarVida(float Cura)
    {
        saludNave += Cura;

    }
    private void Update()
    {
        if (Atributos.Eventos.iniciarPartida)
        {
            if (Atributos.Jugador.nivelArma != 0)
            {
                Atributos.Jugador.contArma -= 1 * Time.deltaTime;

                if (Atributos.Jugador.contArma <= 0)
                {
                    Atributos.Jugador.nivelArma = 0;
                    Atributos.Jugador.contArma = 12;
                }


            }
        }
        
    
    }
    private void FixedUpdate()
    {
        if (Atributos.level.Arrancar)
        {
            ControlNave();
        }
      
       
    }

    private void ControlNave()
    {
        doblarH = joystickMove.Horizontal * rotacionEnvueloIndi * Time.deltaTime;
        doblarV = joystickMove.Vertical * rotacionEnvueloIndi * Time.deltaTime;
        girarH = joystickGiro.Horizontal * rotacionEnvueloIndi * Time.deltaTime;
        girarV = joystickGiro.Vertical * rotacionEnvueloIndi * Time.deltaTime;

        if (girarH < 0 && rotarNave < 1)
        {
            rotarNave += 5 * Time.deltaTime;
            if (rotarNave > 4)
            {
                rotarNave = 4;
            }
            transform.Rotate(Vector3.down * 50 * Time.deltaTime);


        }
        if (girarH > 0 && rotarNave > -1)
        {
            rotarNave -= 5 * Time.deltaTime;
            if (rotarNave < -4)
            {
                rotarNave = -4;
            }
            transform.Rotate(Vector3.up * 50 * Time.deltaTime);


        }
        if (girarV < 0 && subirNave < 1)
        {
            subirNave += 5 * Time.deltaTime;
            if (subirNave > 4)
            {
                subirNave = 4;
            }
            transform.Rotate(Vector3.right * 50 * Time.deltaTime);
        }
        if (girarV > 0 && subirNave > -1)
        {
            subirNave -= 5 * Time.deltaTime;
            if (subirNave < -4)
            {
                subirNave = -4;
            }
            transform.Rotate(Vector3.left * 50 * Time.deltaTime);
        }

        if (!Atributos.level.activeMeteoritos)
        {

            cont += 1 * Time.deltaTime;
            if (cont > 1.5)
            {
                Quaternion rotacionDeseada = Quaternion.Euler(-90f, 0f, 0f);


                transform.rotation = rotacionDeseada;
                cont = 0;
            }

        }if (Atributos.level.activeMeteoritos)
        {
//
           // cont += 1 * Time.deltaTime;
           // if (cont > 2)
          // {
                Quaternion rotacionDeseada = Quaternion.Euler(0f, 0f, 0f);


                transform.rotation = rotacionDeseada;
           //     cont = 0;
         //  }

        }



        characterController.Move(new Vector3(doblarH, doblarV, velocidadIndi * Time.deltaTime));



        transform.position = new(Mathf.Clamp(transform.position.x, limites.xMin, limites.xMax),
             Mathf.Clamp(transform.position.y, limites.yMin, limites.yMax),
             Mathf.Clamp(transform.position.z, limites.zMin, limites.zMax));

    }
}