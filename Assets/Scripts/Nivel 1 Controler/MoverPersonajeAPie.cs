using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoverPersonajeAPie : MonoBehaviour
{
    public static MoverPersonajeAPie instance; 
    public float saludPersanjeIndi;
    public Joystick joystickMove;
    public Joystick joystickGiro;
    public float doblarV;
    public float doblarH;
    public float rotateV;
    public float rotateH;
    public float rotacionPersonajeIndi;
    public float velocidadPersonajeIndi;
    public LayerMask pared;
    public bool tocandoPared;
    Rigidbody rb;




    void Start()
    {
        
        instance = this;
        AtributosArmas.activarNave = false;
        rb=GetComponent<Rigidbody>();
        saludPersanjeIndi = AtributosPersonaje.salud;
    }

    private void FixedUpdate()
    {
        ModoCombateposiicion();
        ModoCombateRotacion();
        rotacionPersonajeIndi = AtributosPersonaje.rotacionPersonaje;
        velocidadPersonajeIndi = AtributosPersonaje.velocidadPersonaje;
    }
   
    public void RestarVida(float danio)
    {
        saludPersanjeIndi -= danio;

    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, 1f);
    }
    public void ModoCombateposiicion()
    {
        
        tocandoPared = Physics.CheckSphere(transform.position, 0.4f, pared);
        if (!tocandoPared)
        {
            doblarH = joystickMove.Horizontal /** velocidadPersonajeIndi * Time.deltaTime*/;
            doblarV = joystickMove.Vertical /** velocidadPersonajeIndi * Time.deltaTime*/;
            
            
            

            Vector3 direccion = new(doblarH, 0, doblarV);
            transform.position = Vector3.MoveTowards(transform.position, transform.position + direccion, velocidadPersonajeIndi * Time.deltaTime);
        }
        
       

    }

    public void ModoCombateRotacion()
    {
        rotateH = joystickGiro.Horizontal * -rotacionPersonajeIndi * Time.deltaTime;
        rotateV = joystickGiro.Vertical * -rotacionPersonajeIndi * Time.deltaTime;


        Vector2 convertedXY = ConvertWithCamera(transform.position, rotateH, rotateV);

        Vector3 direccion = new(convertedXY.x , 0, convertedXY.y );
        Vector3 lookAtPosicion = transform.position + direccion;
        transform.LookAt(lookAtPosicion);

    }

    private Vector2 ConvertWithCamera(Vector3 cameraPos, float hor, float ver)
    {
        Vector2 joyDirection = new Vector2(hor, ver).normalized;
        Vector2 camera2DPos = new Vector2(cameraPos.x, cameraPos.z);
        Vector2 playerPos = new Vector2(transform.position.x, transform.position.z);
        Vector2 cameraToPlayerDirection = (Vector2.zero - camera2DPos).normalized;
        float angle = Vector2.SignedAngle(cameraToPlayerDirection, new Vector2(0, 0));
        Vector2 finalDirection = RotateVector(-joyDirection, angle);
        return finalDirection;
    }

    public Vector2 RotateVector(Vector2 v, float angle)
    {
        float radian = angle * Mathf.Deg2Rad;
        float _x = v.x * Mathf.Cos(radian) - v.y * Mathf.Sin(radian);
        float _y = v.x * Mathf.Sin(radian) + v.y * Mathf.Cos(radian);
        return new Vector2(_x, _y);
    }
}
