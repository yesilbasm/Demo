using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene : MonoBehaviour
{
  private void OnEnable() 
  {
      EventManager.OnLevelRestart.AddListener(LoadScene);
  }
  private void OnDisable() 
  {
      EventManager.OnLevelRestart.RemoveListener(LoadScene);
  }

  private void LoadScene()
  {
      SceneManager.LoadScene(0);
  }

}
