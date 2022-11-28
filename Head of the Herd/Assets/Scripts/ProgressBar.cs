using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ProgressBar : MonoBehaviour
{
    // References
    private Slider slider;
    public ParticleSystem particles;
    public GameManager gameManager;

    // Variables
    private float targetProgress = 0;
    public float fillSpeed = 0.5f;
    
    private void Awake(){
        slider = gameObject.GetComponent<Slider>();
        gameManager = GameManager.instance;
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        targetProgress = ((float)gameManager.highScore);

        if(slider.value < targetProgress){
            slider.value += fillSpeed * Time.deltaTime;
        }
        
    }
}