using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : MonoBehaviour
{
    public Transform shootPoint;
    public GameObject bulletPrefab;
    [Range(0f, 20f)]
    public float bulletForce;
    public Rigidbody2D pistolBody;
    
    public void Shoot(){
        GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
        Rigidbody2D rigidbodyBullet = bullet.GetComponent<Rigidbody2D>();
        rigidbodyBullet.AddForce(shootPoint.up*bulletForce, ForceMode2D.Impulse);
    
        RecoilShoot();
    }
    
    public void RecoilShoot(){
        pistolBody.velocity = pistolBody.velocity*0.1f;
        pistolBody.AddForce(-shootPoint.up*bulletForce, ForceMode2D.Impulse);
    }
}
