using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class desaparecer : MonoBehaviour
{
    MeshRenderer meshRenderer;
    public bool desapareci;
    float contador;
    public static desaparecer instance;

    void Start()
    {
        instance = this;
        meshRenderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (desapareci)
        {
            contador += 1 * Time.deltaTime;
            if (contador > 1)
            {
                
               Aparecer();
            }
        }
    }

    public void Desaparecer()
    {
        meshRenderer.enabled = false;
        desapareci = true;
        
    }
    public void Aparecer()
    {
        meshRenderer.enabled = true;
        desapareci = false;
    }
}
