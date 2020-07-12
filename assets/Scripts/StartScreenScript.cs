using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreenScript : MonoBehaviour
{
    // public startBlock;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter2D(Collision2D hitInfo)
    {
      Debug.Log(hitInfo.gameObject.name);
      // if(hitInfo.gameObject.name == "StartBlock")
      // {
      //   Debug.Log("ŚCIANA UDERZONA");
      //   Invoke("ChamgeScene", 1f);
      // }
    }

    void ChangeScene()
    {
      SceneManager.LoadScene("main", LoadSceneMode.Additive);
    }
}
