using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OndaExpanciva : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale += new Vector3(1,1,1);

        Destroy(this.gameObject, 3);
    }
    /*
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Meteorito"||other.tag=="enemyShip")
        {
            Destroy(other.gameObject);

        }
    }*/
}
