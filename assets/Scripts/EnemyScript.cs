﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : Pistol
{

    private Vector2 playerPos;
    public GameObject playerPrefab;
    private Rigidbody2D playerRigidbody;

    void Start()
    {
        SpawnEffect();
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
}
