using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class borrarPared : MonoBehaviour
{

    
    public LayerMask pared;
    public GameObject jugador;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
       if(Physics.Raycast(transform.position,transform.forward * 5000,out hit,5000,pared)){
            
            hit.collider.GetComponent<desaparecer>().Desaparecer();
        }
        
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position,transform.forward* 5000);
    }
}
