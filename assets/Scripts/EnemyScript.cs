using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class EnemyScript : Pistol
{

    GameObject playerPrefab;
    private Vector2 playerPos;
    private Rigidbody2D playerRigidbody;

    // Pathfinding vars
    Transform target;
    public float speed = 200f;
    public float nextWaypointDistance = 3f;
    Path path;
    int currentWaypoint;
    bool reachedEndOfPath = false;
    Seeker seeker;
    Rigidbody2D rb;

    void OnPathComplete(Path p)
    {
      if (!p.error)
      {
        path = p;
        currentWaypoint = 0;
      }
    }

    void Start()
    {
        playerPrefab = GameObject.FindWithTag ("Player");
        if (playerPrefab == null)
        {
          Debug.Log("player is null");
        }
        target = GameObject.FindWithTag ("Player").transform;
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        seeker.StartPath(rb.position, target.position, OnPathComplete);
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
        target = GameObject.FindWithTag ("Player").transform;

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
