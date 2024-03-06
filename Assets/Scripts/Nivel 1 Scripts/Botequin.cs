using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botequin : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.back * 40 * Time.deltaTime);
        Destroy(this.gameObject, 50);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            if (MoverNave.instance.saludNave < 100)
            {
                MoverNave.instance.SumarVida(20);
                Destroy(this.gameObject);
            }


        }
    }


}
