using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Knife : MonoBehaviour
{
    public Rigidbody2D knifeRigidBody;
    public Rigidbody2D playerRigidbody;
    public float dashForce = 10f;
    public float minDistance = 10f;
    public float hp = 1;
    GameObject playerPrefab;
    Transform playerTransform;
    Transform knifeTransform;
    bool charging = false;

    public AudioClip aimSound;
    public AudioClip chargeSound;
    public AudioClip collisionSound;

    // Start is called before the first frame update
    void Start()
    {
      playerPrefab = GameObject.FindWithTag("Player");
      playerRigidbody = playerPrefab.GetComponent<Rigidbody2D>();
      playerTransform = playerRigidbody.transform;
      knifeTransform = knifeRigidBody.transform;
    }

    // Update is called once per frame
    void Update()
    {
      Charge();
    }

    void FixedUpdate()
    {
      if (!charging)
        LookAtPlayer();
      isAlive();
    }

    void Charge()
    {
      RaycastHit2D hitInfo = Physics2D.Raycast(knifeTransform.position, Vector2.up);

      if (hitInfo)
      {
        float distance = Vector2.Distance(knifeTransform.position, playerTransform.position);
        if (distance <= minDistance)
        {
          charging = true;

          Invoke("Dash", 1.5f);
        }
      }
    }

    void Dash()
    {
      // AudioSource.PlayClipAtPoint(aimSound, knifeRigidBody.transform.position, 1f);
      knifeRigidBody.AddForce(0.1f*dashForce*knifeTransform.up, ForceMode2D.Impulse);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
      Destroy(gameObject);
    }

    void LookAtPlayer()
    {
      Vector2 lookDir = playerTransform.position - knifeTransform.position;
      float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
      knifeRigidBody.rotation = angle;
    }

    void isAlive(){
        if(hp <= 0){
            Die();
        }
    }
    public void Hit(float damage){
        hp -= damage;
    }
    void Die(){
        Destroy(gameObject);
    }
}
