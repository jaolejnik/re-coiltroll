using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeAmmo : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject playerObject;
    public Color[] colorsT;
    public int typeAmmo = 0;
    ParticleSystem ps;
    
    void Start()
    {
        typeAmmo = (int)Random.Range(0,3);
        ps = GetComponent<ParticleSystem>();
        var ma = ps.main;
        ma.startColor = colorsT[typeAmmo];
        // Instantiate(ps, transform.position, Quaternion.identity);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player")){
            other.gameObject.GetComponent<PlayerScript>().SetAmmoType(typeAmmo);
            Destroy(gameObject);
        }
    }
    public void DieEnd(){
        Destroy(gameObject);
    }
}
