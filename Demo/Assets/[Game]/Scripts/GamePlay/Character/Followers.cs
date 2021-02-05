using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Followers : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    private Queue<Vector3> pathPoints;
    private Transform target;
    private Transform EscapeTarget;
    private Transform cam;
    public Material material;
    private int index;
    
    private void OnEnable() 
    {
        EventManager.OnTap.AddListener(Follow);
        EventManager.OnLevelSucces.AddListener(()=> SetWinState());
        EventManager.OnCharacterDie.AddListener(SetFailState );
        EventManager.OnLevelFail.AddListener(()=>Destroy(this)); 
    }

    private void OnDisable() 
    {
        EventManager.OnTap.RemoveListener(Follow); 
        EventManager.OnLevelSucces.RemoveListener(()=> SetWinState()); 
        EventManager.OnCharacterDie.RemoveListener(SetFailState); 
        EventManager.OnLevelFail.RemoveListener(()=>Destroy(this)); 
    }
    private void Awake() 
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        
       
    }
    private void Start() {
         target = LevelManager.Instance.Ducks[LevelManager.Instance.Ducks.Count -1];
        LevelManager.Instance.Ducks.Add(transform); 
        EscapeTarget =GameObject.FindWithTag("EscapeTarget").transform; 
        cam = GameObject.FindWithTag("FinishCam").transform;
        
                                        
         
    }

    private void Update() 
    {
        SetFailState();
    }

    private void Follow()
    {   
        if(LevelManager.Instance.isLevelStarted)
        {
            navMeshAgent.SetDestination(target.position);
            transform.LookAt(target);
        }
        
    }

    IEnumerator SetWinState()
    {
        transform.LookAt(cam.transform);
        yield return new WaitForSeconds(3);
        Destroy(GetComponent<NavMeshAgent>());
        Destroy(this);
    }

    private void SetFailState()
    {   
        if(!LevelManager.Instance.IsCharacterAlive)
        navMeshAgent.SetDestination(EscapeTarget.transform.position);
    }

    
}
    
   

