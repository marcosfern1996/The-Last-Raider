using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class InterfasNave : MonoBehaviour
{

    public Image barraSalud;
    ActivarMenus activarMenus;
    float saludActual;

    // Start is called before the first frame update
    void Start()
    {
        activarMenus = GetComponent<ActivarMenus>();
    }

    // Update is called once per frame
    void Update()
    {
        saludActual = MoverNave.instance.saludNave;
        BarraDeSAlud();
    }
    public void BarraDeSAlud()
    {
        barraSalud.fillAmount = saludActual / AtributosNaves.salud;

        if (MoverNave.instance.saludNave<= 0)
        {

            activarMenus.GameOver();
        }
    }
}
