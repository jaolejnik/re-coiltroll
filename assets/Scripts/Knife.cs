using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class Knife : MonoBehaviour
{
    public Rigidbody2D knifeRigidBody;
    public GameObject spawnEffect;
    Rigidbody2D playerRigidbody;
    public float dashForce = 10f;
    public float minDistance = 10f;
    public float hp = 1;
    public float chargeTime = 1;
    public float dashVelocityTresh = 1;
    public int destroyMeter = 3;
    GameObject playerPrefab;
    public Transform rayPoint;
    Transform playerTransform;
    Transform knifeTransformT;
    int charging = -1;

    public AudioClip aimSound;
    public AudioClip chargeSound;
    public AudioClip collisionSound;

    // Start is called before the first frame update
    void Start()
    {
      playerPrefab = GameObject.FindWithTag("Player");
      playerRigidbody = playerPrefab.GetComponent<Rigidbody2D>();
      playerTransform = playerRigidbody.transform;
      knifeTransformT = knifeRigidBody.transform;
    }

    // Update is called once per frame
    void Update()
    {      Vector2 laserHit = new Vector2(0,0);
      RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up);
      laserHit= hit.point;
      LineRenderer lineRend = GetComponent<LineRenderer>();
      lineRend.enabled = true;
      // lineRend.useWorldSpace = true;
      lineRend.SetPosition(0, transform.position);
      lineRend.SetPosition(1, laserHit);
    }

    void FixedUpdate()
    {
      if (charging == -1){
        LookAtPlayer();
        Charge();
      }
      else if(charging == 1){
        StartCoroutine(Dash());
        charging = 0;
      }
      isAlive();
    }

/// <summary>
/// Callback to draw gizmos that are pickable and always drawn.
/// </summary>
void OnDrawGizmos()
{
      Gizmos.color = Color.yellow;
      Gizmos.DrawLine(rayPoint.position, rayPoint.up*minDistance);
    
}
    void Charge()
    {
      RaycastHit2D hitInfo = Physics2D.Raycast(rayPoint.position, rayPoint.up, Vector2.Distance(rayPoint.position, playerTransform.position));
      // Debug.Log("LEEEEEEEL"+ hitInfo.rigidbody.GetComponent<PlayerScript>());
      if(hitInfo){
      GameObject gb = hitInfo.collider.gameObject;
      if (gb.tag == "Player")
      {
        charging = 1;
        // float distance = Vector2.Distance(rayPoint.position, playerTransform.position);
        // if (distance <= minDistance)
        // {
        //   charging = 1;
        // }
      }
      }
    }

    IEnumerator Dash()
    {
      // AudioSource.PlayClipAtPoint(aimSound, knifeRigidBody.transform.position, 1f);
      Vector2 laserHit = new Vector2(0,0);
      RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up);
      laserHit= hit.point;
      LineRenderer lineRend = GetComponent<LineRenderer>();
      lineRend.enabled = true;
      // lineRend.useWorldSpace = true;
      lineRend.SetPosition(0, transform.position);
      lineRend.SetPosition(1, laserHit);
      Debug.DrawLine(transform.position, laserHit);
    
      yield return new WaitForSeconds(chargeTime);
      knifeRigidBody.AddForce(dashForce*knifeTransformT.up, ForceMode2D.Impulse);
      while(knifeRigidBody.velocity.SqrMagnitude() > dashVelocityTresh*dashVelocityTresh)
      {yield return new WaitForSeconds(0.1f);}
      charging = -1;
      yield return null;
    }

    void OnCollisionEnter2D(Collision2D col)
    {
      destroyMeter -= 1;
      if(destroyMeter>0){      
        Instantiate(spawnEffect, transform.position, Quaternion.identity);
      Destroy(spawnEffect,1.2f);
        Destroy(gameObject);
          // Destroy()
      }

      if(col.gameObject.CompareTag("Player")){
        col.gameObject.GetComponent<PlayerScript>().Hit(1);
      }
    }

    void LookAtPlayer()
    {
      Vector2 lookDir = playerTransform.position - knifeTransformT.position;
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
    public void Die(){
      Instantiate(spawnEffect, transform.position, Quaternion.identity);
      Destroy(spawnEffect,1.2f);
        Destroy(gameObject);
        playerPrefab.GetComponent<PlayerScript>().addPoint();
    }
    
    public void DieEnd(){
        //  GameObject dieEff = Instantiate(spawnEffect, pistolBody.transform.position, Quaternion.identity);
        // Destroy(dieEff, 1f);
        Destroy(gameObject);

    }
}
