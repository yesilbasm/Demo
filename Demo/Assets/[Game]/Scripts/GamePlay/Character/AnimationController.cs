using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public float movetime;
    private Animator animator;
    public Animator Animator
    {
        get 
        {
            if(animator == null)
                animator = GetComponent<Animator>();
            
            return animator;
        }
    }

    private void OnEnable() 
    {
        EventManager.OnTap.AddListener(SetTap);
        EventManager.OnTapRelease.AddListener(UnSetTap);
        EventManager.OnLevelSucces.AddListener(()=>Animator.SetTrigger("Dance"));
        EventManager.OnCharacterDie.AddListener(()=> Animator.SetTrigger("Scared"));
        
    }

    private void OnDisable() 
    {
        EventManager.OnTap.RemoveListener(SetTap);
        EventManager.OnTapRelease.RemoveListener(UnSetTap);
        EventManager.OnLevelSucces.RemoveListener(()=> Animator.SetTrigger("Dance"));
        EventManager.OnCharacterDie.RemoveListener(()=> Animator.SetTrigger("Scared"));
        
    }
    
    private void Update() 
    {
        Animator.SetFloat("Speed" , movetime); 
    }

    private void UnSetTap()
    {   
        if(LevelManager.Instance.isLevelStarted)
        {
            if(movetime>0) { movetime -= Time.deltaTime;}
        }
        
    }

    private void SetTap()
    {   
         if(LevelManager.Instance.isLevelStarted)
        {
            if(movetime<1)
            {
                movetime+=Time.deltaTime;
            }
        }
        
    }

    

    
}
