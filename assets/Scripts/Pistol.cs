﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    public Transform shootPoint;
    public GameObject bulletPrefab;
    [Range(0f, 5f)]
    public float bulletForce;
    [Range(0f, 50f)]
    public float recoilForce;
    public Rigidbody2D pistolBody;
    public Color a;
    public GameObject spawnEffect;

    public AudioClip shotSound;
    public AudioClip spawnSound;
    public AudioClip reloadSound;
    public AudioClip deathSound;

    public float hp = 1;

    public int ammo = 6;
    public int ammoPerShoot = 6;
    public int ammoMagazine = 6;

    public int ammoType = 0;
    private bool canShoot = true;
    public float lastShoot;
    public float fireRateTime;
    public float fireRateLeft;

    void Start(){
        // SpawnEffect();
    }

    public void SpawnEffect(){
        //
        GameObject spawnEff = Instantiate(spawnEffect, gameObject.transform.position, Quaternion.identity);
        AudioSource.PlayClipAtPoint(spawnSound, pistolBody.transform.position);
        spawnEff.transform.SetParent(pistolBody.transform);
        Destroy(spawnEff, 1.5f);
    }

    public bool Shoot(){
        if(canShoot){
            if(ammoType == 0){
                ShootType1();
            }
            else if(ammoType == 1){
                ShootType2();
            }


            return true;
        }
        return false;
    }

    public void ShootType1(){
            GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
            Rigidbody2D rigidbodyBullet = bullet.GetComponent<Rigidbody2D>();
            rigidbodyBullet.AddForce(shootPoint.up*bulletForce, ForceMode2D.Impulse);
            AudioSource.PlayClipAtPoint(shotSound, pistolBody.transform.position, 1.5f);
            RecoilShoot();
            fireRateLeft = fireRateTime;
            ammo -= ammoPerShoot;
    }
    public void ShootType2(){
            GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
            Rigidbody2D rigidbodyBullet = bullet.GetComponent<Rigidbody2D>();
            rigidbodyBullet.AddForce(shootPoint.up*bulletForce, ForceMode2D.Impulse);
            AudioSource.PlayClipAtPoint(shotSound, pistolBody.transform.position, 1.5f);
            RecoilShoot();
            fireRateLeft = fireRateTime;
            ammo -= ammoPerShoot;
    }

    public void FireRate(){
        if(fireRateLeft <= 0 ){
            canShoot = true;
            // fireRateLeft = fireRateTime;
            Debug.Log(this);
        }
        else{
            canShoot = false;
            fireRateLeft -= Time.deltaTime;
        }

    }
    public void RecoilForward(){
        pistolBody.velocity = new Vector2(0,0);
        pistolBody.AddForce(pistolBody.transform.up*recoilForce*0.1f, ForceMode2D.Impulse);

    }

    public void RecoilShoot(){
        pistolBody.velocity = pistolBody.velocity*0.1f;
        pistolBody.AddForce(-shootPoint.up*recoilForce, ForceMode2D.Impulse);
    }

    public bool isAlive(){
        if(hp <= 0){
            Die();
            // hp = 1;
            ammo = ammoMagazine;
            return false;
        }
        return true;
    }
    public void Hit(float damage){
        hp -= damage;
    }
    virtual public void Die(){
         GameObject dieEff = Instantiate(spawnEffect, pistolBody.transform.position, Quaternion.identity);
        AudioSource.PlayClipAtPoint(deathSound, pistolBody.transform.position, 0.5f);
        Destroy(dieEff, 1f);
        Destroy(gameObject);

    }
    public void DieEnd(){
        //  GameObject dieEff = Instantiate(spawnEffect, pistolBody.transform.position, Quaternion.identity);
        // Destroy(dieEff, 1f);
        Destroy(gameObject);

    }

    public void SetAmmo(int ammoNumber){
        ammo = ammoNumber;
    }
    public void AddAmmo(int ammoNumber){
        ammo += ammoNumber;
    }
    public void IsAmmo(){
        if(ammo <= 0){
            canShoot = false;
        }
    }
}
