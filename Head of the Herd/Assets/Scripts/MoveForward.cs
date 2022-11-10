using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    // References
    [SerializeField] private GameObject player;

    // Variables
    [SerializeField] private float flightSpeed = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * flightSpeed * Time.deltaTime);
    }
}
