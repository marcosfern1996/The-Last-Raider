using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemyShip : MonoBehaviour
{
    public GameObject enemyShip;
    float cont = 00;
    bool aparicion = true;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }
    public void ApareceAhora()
    {
        aparicion = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Atributos.level.activeShip)
        {
            cont += 1 * Time.deltaTime;
            if (cont > 10)
            {
                CallEnemys();
                cont = 0;
            }

        }
      /*  GameObject[] EnemyShip = GameObject.FindGameObjectsWithTag("enemyShip");

        // Verificar si hay algún objeto con la etiqueta
        if (EnemyShip.Length == 0 && Atributos.level.activeShip)
        {
            Debug.Log("no hay mas enemigos");
            Atributos.level.activeMeteoritos = true;
            Atributos.level.activeShip = false;

        }
      */
    }

    public void CallEnemys()
    {

        
            Instantiate(enemyShip, this.transform.position,this.transform.rotation);
       
     
       
    }

    

}
