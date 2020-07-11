using System.Collections;
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
    
    public float hp = 1;

    void Start(){
        SpawnEffect();

    }
    public void SpawnEffect(){
        // 
        GameObject spawnEff = Instantiate(spawnEffect, gameObject.transform.position, Quaternion.identity);
    
        spawnEff.transform.SetParent(pistolBody.transform);
        Destroy(spawnEff, 1.5f);
    }

    public void Shoot(){
        GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
        Rigidbody2D rigidbodyBullet = bullet.GetComponent<Rigidbody2D>();
        rigidbodyBullet.AddForce(shootPoint.up*bulletForce, ForceMode2D.Impulse);
    
        RecoilShoot();
    }

    public void RecoilForward(){
        pistolBody.velocity = new Vector2(0,0);
        pistolBody.AddForce(pistolBody.transform.up*recoilForce*0.1f, ForceMode2D.Impulse);
    
    }
    
    public void RecoilShoot(){
        pistolBody.velocity = pistolBody.velocity*0.1f;
        pistolBody.AddForce(-shootPoint.up*recoilForce, ForceMode2D.Impulse);
    }

    public void isAlive(){
        if(hp <= 0){
            Die();
        }
    }
    public void Hit(float damage){
        hp -= damage;
    }
    public void Die(){
         GameObject dieEff = Instantiate(spawnEffect, pistolBody.transform.position, Quaternion.identity);
        Destroy(dieEff, 1f);    
        Destroy(gameObject);
   
    }
    
}
