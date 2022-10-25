using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animacion : MonoBehaviour
{   
    public Animator animator;
    public float x;
    public float y;
    public static Animacion instance;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        x = MoverPersonajeAPie.instance.doblarH;
        y = MoverPersonajeAPie.instance.doblarV;

       
        
            animator.SetFloat("velX", x);
            animator.SetFloat("velY", y);

        

    }
}
