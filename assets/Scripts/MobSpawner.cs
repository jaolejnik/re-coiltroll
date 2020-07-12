using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobSpawner : MonoBehaviour
{
    // Start is called before the first frame update
    // GameObject ga;
    float spawnNext = 2;
    public GameObject _enemy;

    public GameObject spawnDetector;
    public float fireRateTime = 5f;
    public float fireRateLeft;
    public float x1;
    public float x2;
    public float y1;
    public float y2;
    public int maxEnemys;
    private SpawnDetectorScript spawnDetectorScript;
    void Start()
    {
        // Sprite.
        spawnDetectorScript = spawnDetector.GetComponent<SpawnDetectorScript>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(fireRateLeft <= 0 ){
            if(EnemyIsAlive()<maxEnemys)
                StartCoroutine(SpawnWave());
            fireRateLeft = fireRateTime;
        }
        else{
            fireRateLeft -= Time.deltaTime;
        }
    }
    void OnDrawGizmosSelected()
    {
        // Draw a yellow sphere at the transform's position
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(new Vector3(x1,y1,0f),new Vector3(x2,y2,0f));
        // Gizmos.DrawSphere(spawnDetector.transform.position, 1);
    }
    IEnumerator SpawnWave(){

        spawnNext = 1;
        // spawnDetector
        while(true){
            spawnDetector.transform.position = new Vector3(Random.Range(x1, x2), Random.Range(y1,y2), 0f);
            
            Debug.Log(spawnDetector.transform.position);
            while(spawnDetectorScript.canSpawn == 0){}
            if(spawnDetectorScript.canSpawn > 0){
                Instantiate(_enemy, spawnDetector.transform.position, Quaternion.identity);
                break;
            }
        }
        yield return null;
    }

    float EnemyIsAlive(){
        // Debug.Log(GameObject.FindGameObjectsWithTag("Enemy").Length);
        float le = GameObject.FindGameObjectsWithTag("Enemys").Length;
        if(le == 0){
            return 0;
        }
        return le;
    }
    public void SpwanNextSwitch(){
        spawnNext = 2;

    }
}
