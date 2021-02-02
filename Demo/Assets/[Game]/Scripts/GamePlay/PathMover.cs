using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PathMover : MonoBehaviour
{
    private NavMeshAgent navMeshAgent;
    public Queue<Vector3> pathPoints = new Queue<Vector3>();
    
    private void OnEnable() 
    {
        EventManager.OnPathNewCreated.AddListener(()=> SetPoints(FindObjectOfType<PathCreator>().points));
    }

    private void OnDisable() 
    {
        EventManager.OnPathNewCreated.RemoveListener(()=> SetPoints(FindObjectOfType<PathCreator>().points));
    }
    private void Awake() 
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
         
    }

    private void SetPoints(IEnumerable <Vector3> points)
    {
        pathPoints =  new Queue<Vector3>(points);
    }
 
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        UpdatePathing();
    }

    private void UpdatePathing()
    {
        if(ShouldSetDestination())
        {
            navMeshAgent.SetDestination(pathPoints.Dequeue());
            Debug.Log(pathPoints.Count);
        }
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
