using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDetectorScript : MonoBehaviour
{
    public float canSpawn = 1;
    // Start is called before the first frame update
    /// <summary>
    /// OnCollisionStay is called once per frame for every collider/rigidbody
    /// that is touching rigidbody/collider.
    /// </summary>
    /// <param name="other">The Collision data associated with this collision.</param>
    /// <summary>
    /// Update is called every frame, if the MonoBehaviour is enabled.
    /// </summary>
    void Update()
    {
        canSpawn = 1;
    }
    void OnCollisionStay(Collision other)
    {
        canSpawn = -1;
    }
    float CanSpawn(){
        float ret = canSpawn;
        canSpawn = 0;
        return ret;
    }
}
