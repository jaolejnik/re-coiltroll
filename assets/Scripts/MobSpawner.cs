using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    // GameObject ga;
    float spawnNext = 2;
    public GameObject _enemy;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(spawnNext == 2){
            StartCoroutine(SpawnWave());
            Debug.Log("StartCoutine");
        }
        if(!EnemyIsAlive() && spawnNext == 0){
            spawnNext = 2;
            Debug.Log("EnemyIsAlive");
        }

    }

    IEnumerator SpawnWave(){

        spawnNext = 1;

        yield return new WaitForSeconds(5);
        Instantiate(_enemy, gameObject.transform.position, Quaternion.identity);
        spawnNext = 0;
        yield break;
    }

    bool EnemyIsAlive(){
        // Debug.Log(GameObject.FindGameObjectsWithTag("Enemy").Length);
        if(GameObject.FindGameObjectWithTag("Enemys") == null){
            return false;
        }
        return true;
    }
    public void SpwanNextSwitch(){
        spawnNext = 2;

    }
}
