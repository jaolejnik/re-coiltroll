using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform shootPoint;
    public GameObject bulletPrefab;
    [Range(0f, 20f)]
    public float bulletForce;
    public Rigidbody2D playerBody;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        KeyHandler();
    }

    void KeyHandler(){
        if(Input.GetButtonDown("Fire1")){
            Shoot();
        }
    }

    void Shoot(){
        GameObject bullet = Instantiate(bulletPrefab, shootPoint.position, shootPoint.rotation);
        Rigidbody2D rigidbodyBullet = bullet.GetComponent<Rigidbody2D>();
        rigidbodyBullet.AddForce(shootPoint.up*bulletForce, ForceMode2D.Impulse);
    
        RecoilShoot();
    }
    
    void RecoilShoot(){
        playerBody.velocity = playerBody.velocity*0.1f;
        playerBody.AddForce(-shootPoint.up*bulletForce, ForceMode2D.Impulse);
    }

}
