using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GampleyUIScript : MonoBehaviour
{
    public GameObject player;
    public Texture2D bulletIcon;
    PlayerScript playerScript;

    float iconWidth;
    float iconHeight;
    float iconXOffset;
    float iconX;
    float iconY;

    // Start is called before the first frame update
    void Start()
    {
      iconWidth = 0.1f*Screen.height;
      iconHeight = 0.1f*Screen.height;
      iconXOffset = 0.6f * iconWidth;
      iconX = Screen.width/2 - 2*iconWidth;
      iconY = Screen.height - 1.2f*iconHeight;
      playerScript = player.GetComponent<PlayerScript>();
    }

    void OnGUI()
    {
      for (int i = 0; i < playerScript.ammo; i++)
      {
        Rect imRect = new Rect(iconX+i*iconXOffset, iconY, iconWidth, iconHeight);
        Debug.Log(imRect);
        // Debug.Log("RECT SIE RYSUJE ASDJAKLDAKSJDKJASDKJKALJSDLKADLJKLADKJ");
        GUI.DrawTexture(imRect, bulletIcon);
      }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
      Debug.Log("AMMO:" + playerScript.ammo);
    }
}
