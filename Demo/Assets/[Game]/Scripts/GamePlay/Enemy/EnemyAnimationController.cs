using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimationController : MonoBehaviour
{
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
   private void OnEnable() {
       EventManager.OnEnemyTurnRight.AddListener(()=> Animator.SetTrigger("TurnRight"));
       EventManager.OnEnemyTurnLeft.AddListener(()=> Animator.SetTrigger("TurnLeft"));
       EventManager.OnEnemyShoot.AddListener(()=> Animator.SetTrigger("Shoot"));
       EventManager.OnLevelFail.AddListener(()=> Animator.SetTrigger("Dance"));
   }
   private void OnDisable() {
       EventManager.OnEnemyTurnRight.RemoveListener(()=> Animator.SetTrigger("TurnRight"));
       EventManager.OnEnemyTurnLeft.RemoveListener(()=> Animator.SetTrigger("TurnLeft"));
       EventManager.OnEnemyShoot.RemoveListener(()=> Animator.SetTrigger("Shoot"));
       EventManager.OnLevelFail.RemoveListener(()=> Animator.SetTrigger("Dance"));
      }
}
