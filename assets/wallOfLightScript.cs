using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallOfLightScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }


    void OnCollisionEnter2D(Collider2D other)
    {
        Debug.Log("Coliision with " + other.gameObject.name);
        if(other.gameObject.CompareTag("Player")){
            PlayerScript p = other.gameObject.GetComponent<PlayerScript>();
            p.Hit(1);
        }
        if(other.gameObject.CompareTag("Enemys")){
            Knife k = other.gameObject.GetComponent<Knife>();
            k.Hit(1);
            EnemyScript e = other.gameObject.GetComponent<EnemyScript>();
            e.Hit(1);
        }
    }
}
