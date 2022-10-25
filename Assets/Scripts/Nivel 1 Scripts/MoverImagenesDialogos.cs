using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MoverImagenesDialogos : MonoBehaviour
{
    public Scrollbar scrollbar;
    public float velocidadDolly;

    void Update()
    {
        if (scrollbar.value <= 1)
        {
            scrollbar.value += velocidadDolly * Time.deltaTime;
        }
    }
}
