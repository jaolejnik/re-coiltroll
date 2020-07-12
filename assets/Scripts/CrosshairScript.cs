using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrosshairScript : MonoBehaviour
{
    public Camera cam;
    public GameObject crossHair;

    // Start is called before the first frame update
    void Start()
    {
      Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
      crossHair.transform.position = cam.ScreenToWorldPoint(Input.mousePosition);
    }
}
