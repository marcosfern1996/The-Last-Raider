using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animacion : MonoBehaviour
{   
     public Animator animator;
    public float x;
    public float y;
    public static Animacion Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {

            if (Instance != null)
            {
                Destroy(gameObject);
            }
        }
    }

        // Start is called before the first frame update
        void Start()
    {
        Instance = this;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        animator.SetFloat("velX", x);
        animator.SetFloat("velY", y);


        if (MoverPersonajeAPie.instance.caminando)
        {
            y = 1;
        }
        if (MoverPersonajeAPie.instance.retroceso)
        {
            y = -1;
        }
        if(MoverPersonajeAPie.instance.retroceso==false && MoverPersonajeAPie.instance.caminando==false )
        {
            y = 0; 
        }
        if (MoverPersonajeAPie.instance.derecha)
        {
            x = 1;
        }
        
        if (MoverPersonajeAPie.instance.izquierda)
        {
            x = -1;
        }
         if(MoverPersonajeAPie.instance.izquierda == false && MoverPersonajeAPie.instance.derecha == false)
        {
            x = 0;
        }



        
        

        

    }

    public void DispararSonido(string nombre)
    {
        animator.SetTrigger(""+ nombre);
    }
}
