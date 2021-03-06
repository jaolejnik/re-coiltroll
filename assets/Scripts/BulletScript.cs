﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class BulletScript : MonoBehaviour
{

    public Light2D light2D;
    public GameObject hitEffect;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D hitInfo)
    {

        Debug.Log(hitInfo.name);
        if (hitInfo.CompareTag("Enemys")){
            EnemyScript enemy = hitInfo.GetComponent<EnemyScript>();
            if(enemy != null){
                enemy.Hit(1);
            }
            else{
                Debug.Log("Lel");
            }
            Knife knife = hitInfo.GetComponent<Knife>();
            if(knife != null){
                knife.Hit(1);
            }
            else{
                Debug.Log("Lel knife");
            }
        }
        if(!hitInfo.CompareTag("Players")){
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 4f);
        Destroy(gameObject);
        }
    }
}
