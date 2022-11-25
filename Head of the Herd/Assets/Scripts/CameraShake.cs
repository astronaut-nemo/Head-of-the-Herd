using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening; 

public class CameraShake : MonoBehaviour
{
    // Variables
    public static CameraShake Instance;
    public bool shakeOn;

    public void Update()
    {
        if(shakeOn){
            
            Shake(0.5f, 0.5f);
            shakeOn = false;
        }
    }
    
    private void Awake()
    {
        Instance = this;
    }

    private void OnShake(float duration, float strength)
    {
        transform.DOShakePosition(duration, strength);
        transform.DOShakeRotation(duration, strength);
    }

    public static void Shake(float duration, float strength)
    {
        Instance.OnShake(duration, strength);
    }
}
