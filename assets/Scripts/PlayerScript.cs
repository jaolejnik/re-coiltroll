using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : Pistol
{
    // Start is called before the first frame update
    private Vector2 mousePos;
    public Camera cam;
    public SimpleCameraShakeInCinemachine shaker;

    private float reloadDirection = 1;
    private Quaternion reloadLastDirection = new Quaternion();
    private float reloadAngel = 0;
    private int highScore = 0;
    private int score = 0;
    
    void Start(){
        
        highScore = PlayerPrefs.GetInt("Score", 0);
        StartCoroutine(RotateToReload());
    }

    void Update()
    {
        MousePosition();
        KeyHandler();     
          
    }

    void FixedUpdate() {
        FireRate();
        IsAmmo();
        LookAtMouse();
        isAlive();
        // RotateToReload();
    }

    IEnumerator RotateToReload(){
        while(true){
        Quaternion rotated = Quaternion.Inverse(reloadLastDirection)*transform.rotation;
        Vector3 angelBetween = rotated.eulerAngles;
        reloadLastDirection = transform.rotation;

        if (angelBetween .z<-180)angelBetween.z +=360;
        if (angelBetween.z>180) angelBetween.z -=360;
        // float angelBetween = Vector2.Angle(reloadLastDirection, pistolBody.transform.position);
        // reloadLastDirection = pistolBody.transform.position;
        if(angelBetween.z*reloadDirection>=0){
            reloadAngel += Mathf.Abs(angelBetween.z);
        }
        else{
            reloadDirection *= -1;
            reloadAngel = 0;
        }
        if(reloadAngel > 360){
            Debug.Log("OBROCIK");
            SpawnEffect();
            SetAmmo(ammoMagazine);
            // Shoot();
            reloadAngel = 0;
        }
        Debug.Log("OBRO"+ reloadAngel.ToString()+" "+ reloadDirection.ToString()+" "+ angelBetween.ToString());
        yield return new WaitForSeconds(0.1f);
        // yield return null;
        }
    }
    void KeyHandler(){
        if(Input.GetButtonDown("Fire1")){
            if(Shoot()){
             shaker.ShakeShoot();

            }
        }
        if(Input.GetButtonDown("Fire2")){
            RecoilForward();
        }
    }
    void MousePosition(){
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }
    void LookAtMouse(){
        Vector2 lookDir = mousePos - pistolBody.position;
        float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;
        pistolBody.rotation = angle;
    }
    public void addPoint(){
        score += 1;
        if(score>highScore){
            highScore = score;
            PlayerPrefs.SetInt("Score", highScore);
        }
    }

     public override void Die(){
        hp = 1;
        Debug.Log("I died");
        pistolBody.position  = new Vector3(0f,0f,0f);
        pistolBody.velocity  = new Vector3(0f,0f,0f);
        // pistolBody.rotation  = Quaternion.identity;
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemys");

        foreach (GameObject enemyT in enemys)
        {
            EnemyScript e = enemyT.GetComponent<EnemyScript>();
            if(e!=null)
                e.DieEnd();
            Knife e1 = enemyT.GetComponent<Knife>();
            if(e1!=null)
                e1.DieEnd();
        }        

        GameObject[] collects = GameObject.FindGameObjectsWithTag("Collect");
        foreach (GameObject collectT in collects)
        {
            ChangeAmmo e = collectT.GetComponent<ChangeAmmo>();
            if(e!=null)
                e.DieEnd();
        }        


        if(score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("Score", highScore);
        }
        hp = 1;
        score = 0;
    }

    public void SetAmmoType(int typeAmmo){

    }
    
}
