using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EchoScript : MonoBehaviour
{
    private float timeBtwSpawns;
    public float startTimeBtwSpawns;

    public GameObject echo;
    public Rigidbody2D playerRigidbody;
    public float velocityTresh;
  
    void Start()
    {
        

    }
    // Update is called once per frame
    void Update()
    {
        if(playerRigidbody.velocity.sqrMagnitude > velocityTresh*velocityTresh){

            if(timeBtwSpawns <= 0 ){
                GameObject g = Instantiate(echo, playerRigidbody.transform.position,  playerRigidbody.transform.rotation);
                Destroy(g, 1);
                timeBtwSpawns = startTimeBtwSpawns;
                Debug.Log(this);
            }
            else{
                timeBtwSpawns -= Time.deltaTime;
            }
        }
    }
}
