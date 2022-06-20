using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemiesController : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    public float awaitTime = 5;
    public float maxCount = 2;
    float awaitAux = 0;

    void Start()
    {
        awaitAux = awaitTime;
    }

    void Update()
    {
        if (maxCount > 0)
        {
            awaitAux -= Time.deltaTime;
            if (awaitAux < 0)
            {
                Instantiate(enemy, transform.position, enemy.transform.rotation);
                awaitAux = awaitTime;
                maxCount -= 1;
            }
        }
        
    }
}
