using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour
{
   

    void Update()
    {   
        if(LevelManager.Instance.IsCharacterAlive)
        {

         
            if(Input.GetMouseButton(0))
            {  if( LevelManager.Instance.isPathDrawed)
                {
                    EventManager.OnTap.Invoke();
                }
            }
                
            else
            {    
                
                    EventManager.OnTapRelease.Invoke();
                
                
            }

            if(Input.GetMouseButtonUp(0))
            {
                if(LevelManager.Instance.IsGameStarted && !LevelManager.Instance.isPathDrawed && LevelManager.Instance.isLevelStarted)
                {
                    LevelManager.Instance.CanDrawe = true;

                }
            }
        }
        
    }


}
