﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScene : MonoBehaviour
{
  public string scene_name;

  public void OnMouseClick()
  {
      SceneManager.LoadScene(scene_name);
  }

}
