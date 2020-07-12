using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wallOfLightScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        Debug.Log("Coliision with " + other.gameObject.name);
        if(other.gameObject.CompareTag("Player")){
            PlayerScript p = other.gameObject.GetComponent<PlayerScript>();
            if(p != null)
                p.Hit(1);
        }
        if(other.gameObject.CompareTag("Enemys")){
            Knife k = other.gameObject.GetComponent<Knife>();
            if(k != null)
                k.Hit(1);
            EnemyScript e = other.gameObject.GetComponent<EnemyScript>();
            if(e != null)
                e.Hit(1);
        }
    }
}
