using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookTowards : MonoBehaviour
{
    // References
    private Transform target;
    public EnemyRadar enemyRadar;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        target = enemyRadar.GetClosestEnemy();

        // Only point towards enemy if it is in range
        if(enemyRadar.enemyContact)
        {
            transform.LookAt(target);
        }
    }
}
