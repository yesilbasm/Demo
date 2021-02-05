using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartPanel : MonoBehaviour
{
 

  public void StartGame()
  {
      EventManager.OnGameStart.Invoke();
      LevelManager.Instance.IsGameStarted=true;
  }
}
