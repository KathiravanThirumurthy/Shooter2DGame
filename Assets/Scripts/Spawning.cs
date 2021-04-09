using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawning : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private GameObject _containerPrefab;
    private bool _stopSpawning = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(startSpawningEnemies());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator startSpawningEnemies()
    {
        while(_stopSpawning == false)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-8.0f, 8.0f), transform.position.y, 0);
            GameObject newEnemy=Instantiate(_enemyPrefab, spawnPos, Quaternion.identity);
            newEnemy.transform.parent = _containerPrefab.transform;
            yield return new WaitForSeconds(4.0f);
        }
        
    }

    public void onPlayerDeath()
    {
        _stopSpawning = true;
    }
}
