using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(LineRenderer))]

public class LaserArma : MonoBehaviour
{
    LineRenderer ln;
    public GameObject arma;
    // Start is called before the first frame update
    void Start()
    {
        ln = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if( Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if(hit.collider)
            {
                ln.startColor = Color.red;
                ln.endColor = Color.red;
                ln.SetPosition(0, transform.position);
                ln.SetPosition(1, hit.point);
            }
            else
            {
                ln.SetPosition(0, transform.position);
                ln.SetPosition(1, transform.forward);
            }
        }
        

    }
}
