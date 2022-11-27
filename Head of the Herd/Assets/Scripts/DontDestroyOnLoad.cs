using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyOnLoad : MonoBehaviour
{
    // Prevent new instances of the game manager from being created
    public static DontDestroyOnLoad instance;

    private void Awake()
    {
        if(instance==null){
            instance = this;
        }
        else{
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }
    
}
