using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoDestruerAudios : MonoBehaviour
{

    public static NoDestruerAudios Instance;
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

    }// Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
