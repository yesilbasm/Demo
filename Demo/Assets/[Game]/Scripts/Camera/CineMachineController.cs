using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
 
public class CineMachineController : MonoBehaviour
{
 
 
    
    private GameObject tFollowTarget;
    public CinemachineVirtualCamera vCam1;
    public CinemachineVirtualCamera vCam2;
    public CinemachineVirtualCamera vCam3;
    

    private void OnEnable() 
    {
        EventManager.OnGameStart.AddListener(()=>vCam2.enabled=false ); 
        EventManager.OnLevelSucces.AddListener(CloseCams); 
        
    }

    private void OnDisable() 
    {
        EventManager.OnGameStart.RemoveListener(()=> vCam2.enabled=false);
        EventManager.OnLevelSucces.RemoveListener(CloseCams); 
        
        
    }

    private void CloseCams()
    {
        vCam2.enabled=false;
        vCam1.enabled = false;
    }
    
 

  
 
   
}