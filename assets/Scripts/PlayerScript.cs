using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : Pistol
{
    // Start is called before the first frame update
    private Vector2 mousePos;
    public Camera cam;
    public SimpleCameraShakeInCinemachine shaker;
    
    void Update()
    {
        MousePosition();
        KeyHandler();     
          
    }

    void FixedUpdate() {
        LookAtMouse();
    }

    void KeyHandler(){
        if(Input.GetButtonDown("Fire1")){
            Shoot();
            shaker.ShakeShoot();
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
}
