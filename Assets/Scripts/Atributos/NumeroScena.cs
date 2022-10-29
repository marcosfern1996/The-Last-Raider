using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NumeroScena : MonoBehaviour
{
    
    public static NumeroScena instance;
    public int numeroDeScena;
    private void Awake()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
