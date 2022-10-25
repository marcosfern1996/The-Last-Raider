using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Misiones : MonoBehaviour
{
    public static Misiones instance;
    public TextMeshProUGUI objetivo;
    public bool consigueLallave=false;
    public bool veALaPuerta=false;
    
    void Start()
    {
        instance=this;
    }

    // Update is called once per frame
    void Update()
    {
        if (!consigueLallave)
        {
            objetivo.text = "Consigue la llave De la Entrada";
        }
        if (consigueLallave)
        {
            objetivo.text = "Habre la puerta";
        }

    }
}
