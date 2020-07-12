using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallOfForce : MonoBehaviour
{
    // Start is called before the first frame update
    public float forcePush;
    private Vector2 forceVector;
    private Vector2 forceVectorNormal;
    private Rigidbody2D rbCol;

    // Update is called once per frame
    void OnCollisionEnter2D(Collision2D other)
    {
        foreach (ContactPoint2D missileHit in other.contacts)
        {
            forceVectorNormal = missileHit.normal;
            forceVector = missileHit.point;
            PlayerScript p = other.gameObject.GetComponent<PlayerScript>();
            rbCol = p.GetComponent<Rigidbody2D>();
            if(rbCol != null){
                rbCol.velocity = Vector2.Reflect(rbCol.velocity, forceVectorNormal).normalized*forcePush; 
                // rbCol.AddForce(new Vector3(forceVector.x, forceVector.y, 0) - Quaternion.AngleAxis(180, forceVectorNormal) * rbCol.transform.forward * forcePush, ForceMode2D.Impulse);
                // rbCol.velocity = Quaternion.AngleAxis(180, forceVectorNormal) * rbCol.transform.forward * -forcePush;
                Debug.Log("Coliision with " + other.gameObject.name+ rbCol.velocity.ToString());
            }
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
    /// <summary>
    /// Callback to draw gizmos that are pickable and always drawn.
    /// </summary>
    void OnDrawGizmos()
    {
        // Gizmos.DrawLine(forceVector, Quaternion.AngleAxis(180, forceVectorNormal) * rbCol.transform.forward * 1);
    }
}
