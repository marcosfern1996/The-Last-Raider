using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntrarHabitacion : MonoBehaviour
{
    public GameObject habitacion;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            habitacion.SetActive(false);
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        habitacion.SetActive(true);
    }

}
