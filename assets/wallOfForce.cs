using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallOfForce : MonoBehaviour
{
    // Start is called before the first frame update
    public float forcePush;

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Coliision with " + other.gameObject.name);
        foreach (ContactPoint2D missileHit in other.contacts)
        {
            Vector2 forceVector = missileHit.point;
            Rigidbody2D rbCol = other.gameObject.GetComponent<Rigidbody2D>();
            if(rbCol != null){
                rbCol.AddForce(-forceVector*forcePush, ForceMode2D.Impulse);
            }
            Gizmos.DrawLine(forceVector, )
            // if(other.gameObject.CompareTag("Player")){
            //     PlayerScript p = other.gameObject.GetComponent<PlayerScript>();
            //     p.GetComponent<Rigidbody2D>().AddForce(forceVector, ForceMode2D.Impulse);
            // }
            // if(other.gameObject.CompareTag("Enemys")){
            //     Knife k = other.gameObject.GetComponent<Knife>();
            //     k.GetComponent<Rigidbody2D>().AddForce(forceVector, ForceMode2D.Impulse);
            //     EnemyScript e = other.gameObject.GetComponent<EnemyScript>();
            //     e.Hit(1);
            // }

        }
    }
}
