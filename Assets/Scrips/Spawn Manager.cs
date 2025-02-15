using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _enemyContainer; 
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private bool _stopSpwaning = false;
    [SerializeField]
    private GameObject _tripleShotPowerupPrefab; 
    void Start()
    {
      StartCoroutine(SpawnEnemyRoutine()); 
      StartCoroutine(SpawnPowerupRoutine());
    }

    // Update is called once per frame
    void Update() 
    {
        
    }

      IEnumerator SpawnEnemyRoutine()
      {
        while(_stopSpwaning == false) 
      {
        Vector3 posToSpawn = new Vector3(Random.Range(-9.5f, 9.5f), 7, 0);
        GameObject newEnemy = Instantiate(_enemyPrefab, posToSpawn, Quaternion.identity);
        newEnemy.transform.parent = _enemyContainer.transform;
         yield return new WaitForSeconds(6f);
      }
    
    }

    IEnumerator SpawnPowerupRoutine()
    {
        while (_stopSpwaning == false)
        {
            Vector3 posToSpawn = new Vector3(Random.Range(-8f, 8f), 7, 0);
            Instantiate(_tripleShotPowerupPrefab, posToSpawn, Quaternion.identity);
            yield return new WaitForSeconds(Random.Range(3, 8)); 
        }
    }

    public void OnPlayerDeath()
    {
       _stopSpwaning = true;
    }
}
