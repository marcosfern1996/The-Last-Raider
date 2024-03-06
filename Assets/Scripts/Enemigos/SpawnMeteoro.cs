using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SpawnMeteoro : MonoBehaviour
{

    public GameObject meteoro;
    public GameObject Naves;
    public GameObject[] spawnMeteoro;
    public GameObject[] spawnNaves;
    public int evento=0;
    float cont = 0;
    float contb = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    { ConsultarEvento();

        ActivarEvento();
       
     
    }

    private void ActivarEvento()
    {
        contb += 1 * Time.deltaTime;

        switch (evento)
        {
            case 0:
                if (contb > UnityEngine.Random.Range(1, 5))
                {
                    Debug.Log("level 1");

                    Atributos.level.activeShip = false;
                    Atributos.level.activeMeteoritos = true;
                    for (int i = 0; i < 8; i++)
                    {
                        InstaciaMeteoritos();
                    }


                    // Atributos.level.points++;
                    contb = 0;

                }
                break;
            case 1:
                if (contb > UnityEngine.Random.Range(5, 15))
                {
                    Debug.Log("level 2");
                    //Atributos.level.rotationAmountCombat = 0;
                    Atributos.level.activeShip = true;
                    Atributos.level.activeMeteoritos = false;

                    for (int i = 0; i < 3; i++)
                    {
                        InstaciaNaves();
                    }
                    contb = 0;

                }
                break;

            case 2:
                if (contb > UnityEngine.Random.Range(1, 3))
                {
                    Debug.Log("level 1");

                    Atributos.level.activeShip = false;
                    Atributos.level.activeMeteoritos = true;
                    for (int i = 0; i < 12; i++)
                    {
                        InstaciaMeteoritos();
                    }
                    contb = 0;

                }
                break;
            case 3:
                if (contb > UnityEngine.Random.Range(8, 15))
                {
                    Debug.Log("level 2");
                    //Atributos.level.rotationAmountCombat = 0;
                    Atributos.level.activeShip = true;
                    Atributos.level.activeMeteoritos = false;
                    for (int i = 0; i < 5; i++)
                    {
                        InstaciaNaves();
                    }
                    contb = 0;

                }
                break;
            case 4:
                if (contb > UnityEngine.Random.Range(1, 3))
                {
                    Debug.Log("level 1");

                    Atributos.level.activeShip = false;
                    Atributos.level.activeMeteoritos = true;
                    for (int i = 0; i < 18; i++)
                    {
                        InstaciaMeteoritos();
                    }
                    contb = 0;

                }
                break;
            case 5:
                if (contb > UnityEngine.Random.Range(8, 15))
                {
                    Debug.Log("level 2");
                    //Atributos.level.rotationAmountCombat = 0;
                    Atributos.level.activeShip = true;
                    Atributos.level.activeMeteoritos = false;
                    for (int i = 0; i < 8; i++)
                    {
                        InstaciaNaves();
                    }
                    contb = 0;

                }
                break;



            default:
                break;
        }

    }

    private void ConsultarEvento()
    {
        cont += 1 * Time.deltaTime;
        if (cont > UnityEngine.Random.Range(10, 20) && evento == 0)
        {
            evento = 1;
            Debug.Log("el evento es " + evento);
            cont = 0;
        }
        if (cont > UnityEngine.Random.Range(30, 40) && evento == 1)
        {
            evento = 2;
            Debug.Log("el evento es " + evento);
            cont = 0;
        }
        if (cont > UnityEngine.Random.Range(50, 70) && evento == 2)
        {
            evento = 3;
            Debug.Log("el evento es " + evento);
            cont = 0;
        }
        if (cont > UnityEngine.Random.Range(30, 40) && evento == 3)
        {
            evento = 4;
            Debug.Log("el evento es " + evento);
            cont = 0;
        }
        if (cont > UnityEngine.Random.Range(50, 70) && evento == 4)
        {
            evento = 5;
            Debug.Log("el evento es " + evento);
            cont = 0;
        }
        if (cont > UnityEngine.Random.Range(30, 40) && evento == 5)
        {
            evento = 4;
            Debug.Log("el evento es " + evento);
            cont = 0;
        }
        
    }

    public void InstaciaNaves()
    {
        int ubicacion = UnityEngine.Random.Range(0, 7);
        generarNave(ubicacion);

    }
    public void generarNave(int ubicacion)
    {
        try
        {
            Instantiate(Naves, spawnNaves[ubicacion].transform.position, spawnNaves[ubicacion].transform.rotation);
        }catch
        {

        }
    }
    public void InstaciaMeteoritos()
    {
        int ubicacion = UnityEngine.Random.Range(0, 19);
        generarMeteoro(ubicacion);
        
    }
    public void generarMeteoro( int ubicacion)
    {
        try { 
            Instantiate(meteoro, spawnMeteoro[ubicacion].transform.position, spawnMeteoro[ubicacion].transform.rotation);
        }
        catch
        {
           
        }
        
    }
}
