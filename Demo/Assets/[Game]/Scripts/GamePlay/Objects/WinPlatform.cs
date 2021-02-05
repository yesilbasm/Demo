using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinPlatform : MonoBehaviour
{
  

    private void OnTriggerEnter(Collider other) 
    {   
        if(LevelManager.Instance.IsCharacterAlive)
        {
            EventManager.OnLevelSucces.Invoke();
        }
       
    }
}
