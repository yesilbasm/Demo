using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{

    private void OnEnable() 
    {
        EventManager.OnPathNewCreated.AddListener(()=> LevelManager.Instance.isLevelStarted = true);
        
    }
    private void OnDisable() 
    {
        EventManager.OnPathNewCreated.RemoveListener(()=> LevelManager.Instance.isLevelStarted = true);
    }
    private void OnCollisionEnter(Collision other) 
    {   
        
        ICollectable iCollectable = other.gameObject.GetComponent<ICollectable>();
        if(iCollectable != null)
        {
            iCollectable.Collected();
            
        } 
        
        
    }

     
     
}
