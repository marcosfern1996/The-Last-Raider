using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotacionAgujero : MonoBehaviour
{
    public Color nuevoColor;
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Obtén el componente Renderer del objeto

      

        transform.Rotate ( Vector3.up * 100 * Time.deltaTime);
    
    }
}
