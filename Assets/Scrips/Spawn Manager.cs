using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private GameObject _Enemy_Container;
    [SerializeField]
    private GameObject _enemyPrefab;
    [SerializeField]
    private bool _stopSpwaning = false;
    // Start is called before the first frame update
    void Start()
    {
      StartCoroutine(SpawnRoutine());  
    }

    // Update is called once per frame
    void Update() 
    {
        
    }

      IEnumerator SpawnRoutine()
      {
        while(_stopSpwaning == false) 
      {
        Vector3 posToSpawn = new Vector3(Random.Range(-8f, 8f), 8, 0);
        GameObject newEnemy = Instantiate(_enemyPrefab, posToSpawn, Quaternion.identity);
        newEnemy.transform.parent = _Enemy_Container.transform;
         yield return new WaitForSeconds(6f);
      }
    
    }

    public void OnPlayerDeath()
    {
       _stopSpwaning = true;
    }
}
