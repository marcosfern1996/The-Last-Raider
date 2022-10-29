using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
//using UnityEditorInternal;
using UnityEngine.SceneManagement;

public class SalirDeScena : MonoBehaviour
{
    public string escenaACargar;
    public string salidaDeEscena;
    public GameObject puertaMapa;
    
    

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if(ActivarMenus.Instance.EstoyEnLapuerta == true)
            {
                
            ActivarMenus.Instance.cargue = false;
            PlayerPrefs.SetString("ultimaSalidaNombre", salidaDeEscena);
            SceneManager.LoadScene(escenaACargar);

             }
      }


    }
    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            ActivarMenus.Instance.EstoyEnLapuerta = false;
        }
        
    }

    
}
