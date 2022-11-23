using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookTowards : MonoBehaviour
{
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
        transform.LookAt(target);
    }
}
