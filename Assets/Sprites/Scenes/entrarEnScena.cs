using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class entrarEnScena : MonoBehaviour
{
    public string ultimaSalidaNombre;
    Transform posicion;
    public string nombreGuardado;

    private void Awake()
    {
        posicion = GetComponent<Transform>();
        nombreGuardado = PlayerPrefs.GetString("ultimaSalidaNombre");

    }
    void Start()
    {
      if (ActivarMenus.Instance.cargue == false)
        {
            if (nombreGuardado==ultimaSalidaNombre)
            {
           
              //  MoverPersonajeAPie.instance.GetComponent<Transform>().position = posicion.transform.position;
              //  MoverPersonajeAPie.instance.GetComponent<Transform>().eulerAngles = posicion.transform.eulerAngles;
            
            }
        }
        
       

    }

   

    // Update is called once per frame
    void Update()
    {
        
    }
}
