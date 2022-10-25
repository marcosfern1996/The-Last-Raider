using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SiguienteNivelPorColicion : MonoBehaviour
{

    public static SiguienteNivelPorColicion instance;

    private void Awake()
    {
        instance = this;
       
    }

    private void OnTriggerEnter(Collider other )
    {
        
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
        
    }
}
