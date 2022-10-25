using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SigienteNivel : MonoBehaviour
{
   
   
    public void SiguienteNivel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void SeleccionDeNivel( int numIndiceNivel)
    {
        
    SceneManager.LoadScene(numIndiceNivel);
    }
        
 }
  

