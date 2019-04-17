using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;


    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    public void SpawnEnemy()
    {
        Instantiate(enemy, transform.position, Quaternion.identity);
    }

    IEnumerator EnemyDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        SpawnEnemy();
    }

    public void SpawnEnemyWithDelay(float delay)
    {
        StartCoroutine(EnemyDelay(delay));
    }

}
