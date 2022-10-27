using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(LineRenderer))]

public class LaserArma : MonoBehaviour
{
    LineRenderer ln;
    public GameObject arma;
    public Renderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        ln = GetComponent<LineRenderer>();
        renderer=GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        if( Physics.Raycast(transform.position, transform.forward, out hit))
        {
            if(hit.collider)
            {
                if (hit.collider.tag == "Enemigo")
                {
                    //ln.startColor = Color.red;
                   // ln.endColor = Color.red;
                    renderer.material.color = new Color(0.07f, 0, 1,0.8f);
                   // renderer.material.color = ln.endColor;
                }
                else
                {
                   // ln.startColor = Color.green;
                    //ln.endColor = Color.green;
                   renderer.material.color = new Color(0.064f,1,0,0.8f);
                    //renderer.material.color = ln.endColor;
                }
                    
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
