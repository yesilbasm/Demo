using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PathMover : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    public Queue<Vector3> pathPoints = new Queue<Vector3>();
    public float speed;
    public Transform cam;
    
    private void OnEnable() 
    {
        EventManager.OnPathNewCreated.AddListener(()=> SetPoints(FindObjectOfType<PathCreator>().points));
        EventManager.OnTap.AddListener(UpdatePathing);
        EventManager.OnLevelSucces.AddListener(()=> StartCoroutine( SetSucessState()));
    }

    private void OnDisable() 
    {
        EventManager.OnPathNewCreated.RemoveListener(()=> SetPoints(FindObjectOfType<PathCreator>().points));
        EventManager.OnTap.RemoveListener(UpdatePathing);
        EventManager.OnLevelSucces.AddListener(()=> StartCoroutine( SetSucessState()));
    }
    private void Awake() 
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
         
    }
    private void Start() {
       // navMeshAgent.speed=0;
        
    }

    private void SetPoints(IEnumerable <Vector3> points)
    {
        pathPoints =  new Queue<Vector3>(points);
    }

    private void Update() {
      speed=  navMeshAgent.speed;
    }
 
   

    private void UpdatePathing()
    {   if(LevelManager.Instance.isLevelStarted && LevelManager.Instance.isPathDrawed)
        {
            
            if(ShouldSetDestination())
            {
                navMeshAgent.SetDestination(pathPoints.Dequeue());
                
            }
        }
    }

    

    IEnumerator SetSucessState()
    {   navMeshAgent.SetDestination(LevelManager.Instance.WinPlatform.transform.position);
        transform.LookAt(cam.transform);
        yield return new WaitForSeconds(3);
        Destroy(GetComponent<NavMeshAgent>());
        Destroy(this);
    }    

    private bool ShouldSetDestination()
    {
       
       if(pathPoints.Count == 0)
            return false;
        if(navMeshAgent.hasPath == false || navMeshAgent.remainingDistance < 0.5f)
        {
            return true;
        }
        

        return false;
    }
}
