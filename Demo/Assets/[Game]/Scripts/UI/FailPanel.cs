using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailPanel : MonoBehaviour
{
    // Start is called before the first frame update
  public  void RestartGame()
  {
      EventManager.OnLevelRestart.Invoke();
  }
}
