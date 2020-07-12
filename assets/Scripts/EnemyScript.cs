using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyScript : Pistol
{

    GameObject playerPrefab;
    private Vector2 playerPos;
    private Rigidbody2D playerRigidbody;

    void Start()
    {
        playerPrefab = GameObject.FindWithTag("Player");
        // SpawnEffect();
        playerRigidbody = playerPrefab.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        PlayerPosition();
    }

    void FixedUpdate() {
        LookAtPlayer();
        isAlive();
    }

    void PlayerPosition(){
        playerPos = playerRigidbody.transform.position;
    }

    void LookAtPlayer(){
        Vector2 lookDir = playerPos - pistolBody.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        pistolBody.rotation = angle;
    }

    void OnCollisionEnter2D(Collision2D hitInfo)
    {
        Debug.Log(hitInfo.gameObject.name);
        if(hitInfo.gameObject.CompareTag("Player")){
            PlayerScript player = hitInfo.gameObject.GetComponent<PlayerScript>();
            player.Hit(1);
        }
    }
    
     public override void Die(){
        playerPrefab.GetComponent<PlayerScript>().addPoint();
        GameObject dieEff = Instantiate(spawnEffect, pistolBody.transform.position, Quaternion.identity);
        Destroy(dieEff, 1f);
        Destroy(gameObject);

    }

}
