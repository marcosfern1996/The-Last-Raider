using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DesctivarAgujero : MonoBehaviour
{

    public GameObject agujeroGusano;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Destroy(agujeroGusano);
        }
    }
}
