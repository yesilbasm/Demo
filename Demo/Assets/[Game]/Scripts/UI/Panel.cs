using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CanvasGroup))]
public class Panel : MonoBehaviour
{
    private CanvasGroup canvasGroup;
    //Use this to access the canvas group.
    public GameObject StartGamePanel;
    public GameObject StartToDrawPanel;
    public GameObject HoldToMovePanel;
    public GameObject WinPanel;
    public GameObject FailPanel;


    private void OnEnable() 
    {
       EventManager.OnPathNewCreated.AddListener(()=>ShowPanel(HoldToMovePanel));
        EventManager.OnLevelSucces.AddListener(()=> ShowPanel(WinPanel));
        EventManager.OnCharacterDie.AddListener(()=> ShowPanel(FailPanel));
        
        
        
    }

    private void OnDisable() 
    {
        
        EventManager.OnPathNewCreated.RemoveListener(()=>ShowPanel(HoldToMovePanel));
        EventManager.OnLevelSucces.RemoveListener(()=> ShowPanel(WinPanel));
        EventManager.OnCharacterDie.RemoveListener(()=> ShowPanel(FailPanel));
        
    }

   public void HidePanel( GameObject Panel)
    {
        Panel.SetActive(false);
    }

    public void ShowPanel(GameObject Panel)
    {
        Panel.SetActive(true);
    }

}
