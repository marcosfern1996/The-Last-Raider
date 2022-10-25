using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LLave : MonoBehaviour
{


    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Misiones.instance.consigueLallave = true;
            Destroy(this.gameObject);
        }
    }
}
