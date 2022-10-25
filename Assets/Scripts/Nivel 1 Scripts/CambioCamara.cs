using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambioCamara : MonoBehaviour
{
    public GameObject[] camaras;
    public bool[] camerasActivas;
    public void CambiarCamara()
    {
        if (camerasActivas[0])
        {
            camerasActivas[1] = true;
            camerasActivas[0] = false;
            camaras[1].SetActive(true);
            camaras[0].SetActive(false);
        }
        if (camerasActivas[1])
        {
           
            camerasActivas[0] = true;
            camerasActivas[1] = false;
            camaras[0].SetActive(true);
            camaras[1].SetActive(false);
        }

    }
}
