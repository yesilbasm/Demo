using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using DG.Tweening;

public class EnemyController : MonoBehaviour
{
    public List<int> Angles;
    private float TurnDuration=1;
    public Transform BulletPrefab;
    public Transform GunEndPosition;
    public List<Transform> Platforms;
    private Vector3 platform1;
    private Vector3 Platform2;
    
    void Start()
    {   
        if(LevelManager.Instance.IsCharacterAlive)
        InvokeRepeating("StartEnemyRoutineMovement",0, 6*TurnDuration);
        platform1 = Platforms[0].transform.position - transform.position  ;
        Platform2 = Platforms[1].transform.position - transform.position;

    }

    
    private void OnEnable() 
    {
        EventManager.OnEnemyShoot.AddListener(InstantiateBullet);
        EventManager.OnLevelSucces.AddListener(()=> Destroy(this));
        EventManager.OnLevelFail.AddListener(()=> Destroy(this));
    }
    private void OnDisable() 
    {
        EventManager.OnEnemyShoot.RemoveListener(InstantiateBullet);
        EventManager.OnLevelSucces.RemoveListener(()=> Destroy(this));
        EventManager.OnLevelFail.RemoveListener(()=> Destroy(this));
    }

   private void StartEnemyRoutineMovement()
   {
       StartCoroutine(EnemyRoutinMovement());
   }
    IEnumerator EnemyRoutinMovement()
    {
        transform.DORotate(new Vector3(transform.rotation.x , -4/2* Vector3.Angle(platform1 , (platform1 + Platform2) /2) + transform.rotation.y , transform.rotation.z) ,TurnDuration);
        EventManager.OnEnemyTurnRight.Invoke();
        yield return  new WaitForSeconds(2*TurnDuration);
        EventManager.OnEnemyTurnLeft.Invoke();
        transform.DORotate(new Vector3(transform.rotation.x ,- 4/2* Vector3.Angle((platform1 + Platform2) /2,Platform2) + transform.rotation.y , transform.rotation.z) ,TurnDuration);
        yield return new WaitForSeconds(2*TurnDuration);
        transform.DORotate(new Vector3(transform.rotation.x , -4/2* Vector3.Angle((Platform2),platform1) + transform.rotation.y , transform.rotation.z) ,TurnDuration);
        EventManager.OnEnemyTurn180.Invoke();
        
    }

    private void InstantiateBullet()
    {
        Instantiate(BulletPrefab , GunEndPosition.position , Quaternion.identity );
        
    }
    
}
