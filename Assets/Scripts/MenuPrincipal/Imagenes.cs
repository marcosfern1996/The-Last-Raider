using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Imagenes : MonoBehaviour
{
    public GameObject[] imagenes;
    public int numeroImagen;
    public bool cambiarImagen;
   // public MoverImagenes moverImagenes;

    // Start is called before the first frame update
    void Start()
    {
        imagenes[0].SetActive(false);
        imagenes[1].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(cambiarImagen)
        {
            
            numeroImagen = Random.Range(0, numeroImagen);

            switch (numeroImagen)
            {
                case 0:
                    DesactivarImagenes();
                    imagenes[0].SetActive(true);
                   
                   cambiarImagen = false;

                    break;

                case 1:
                    DesactivarImagenes();
                    imagenes[1].SetActive(true);
                    
                    cambiarImagen = false;
                    break;
                    /*case 2:
                        DesactivarImagenes();
                        imagenes[2].SetActive(true);

                        cambiarImagen = false;
                        break;
                    case 3:
                        DesactivarImagenes();
                        imagenes[3].SetActive(true);
                        cambiarImagen = false;
                        break;*/
            }
        }
        


    }

    public void DesactivarImagenes()
    {
       for (int x = 0; x < imagenes.Length; x++)
        {
            imagenes[x].SetActive(false);
        }


    }
}
