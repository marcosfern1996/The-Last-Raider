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
    public float rotarNave=0;
    public float subirNave=0;

    public float velocidadIndi;
    public float saludNave;
    public float danioIndi;
    public float rotacionEnvueloIndi;

    private void Start()
    {
       
        instance = this;
        velocidadIndi = AtributosNaves.velocidad;
        AtributosArmas.activarNave = true;
        saludNave = AtributosNaves.salud;

        rotacionEnvueloIndi = AtributosNaves.rotacionEnvuelo;

        characterController = GetComponent<CharacterController>();
    }

    

    public void RestarVida(float danio)
    {
        saludNave -= danio;

    }

    private void FixedUpdate()
    {

        
        

        doblarH = joystickMove.Horizontal * rotacionEnvueloIndi * Time.deltaTime;
        doblarV = joystickMove.Vertical * rotacionEnvueloIndi * Time.deltaTime;

        if(doblarH < 0 && rotarNave < 2)
        {
            rotarNave += 5  * Time.deltaTime;
            if (rotarNave > 2)
            {
                rotarNave = 2;
            }
            transform.Rotate(Vector3.back * 40 * Time.deltaTime);
        }else if(doblarH > 0 && rotarNave > -2)
        {
            rotarNave -= 5 * Time.deltaTime;
            if(rotarNave < -2)
            {
                rotarNave = -2;
            }
            transform.Rotate(Vector3.forward * 40 * Time.deltaTime);
        }
        if (doblarV < 0 && subirNave < 2)
        {
            subirNave += 5 * Time.deltaTime;
            if (subirNave > 2)
            {
                subirNave = 2;
            }
            transform.Rotate(Vector3.right * 10 * Time.deltaTime);
        }
        else if (doblarV > 0 && subirNave > -2)
        {
            subirNave -= 5 * Time.deltaTime;
            if (subirNave < -2)
            {
                subirNave = -2;
            }
            transform.Rotate(Vector3.left * 10 * Time.deltaTime);
        }
        
        characterController.Move(new Vector3(doblarH, doblarV, velocidadIndi * Time.deltaTime));



        transform.position = new(Mathf.Clamp(transform.position.x, limites.xMin, limites.xMax),
             Mathf.Clamp(transform.position.y, limites.yMin, limites.yMax),
             Mathf.Clamp(transform.position.z, limites.zMin, limites.zMax));

    }
}