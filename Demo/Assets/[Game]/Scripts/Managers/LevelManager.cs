using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : Singleton<LevelManager>
{
  public bool isPathDrawed;
  public GameObject DuckPrefab;
  public List<Vector3> DuckPath;
  public int PathCount;
  public int DuckCount=1;
    private void OnEnable() 
    {
        EventManager.OnPathNewCreated.AddListener(()=> DuckPath = FindObjectOfType<PathCreator>().GetComponent<PathCreator>().points) ;   
        EventManager.OnEggCollected.AddListener(InstantiateDuck);
    }

    private void OnDisable() 
    {
        EventManager.OnPathNewCreated.RemoveListener(()=> DuckPath = FindObjectOfType<PathCreator>().GetComponent<PathCreator>().points) ;  
        EventManager.OnEggCollected.RemoveListener(InstantiateDuck);
    }

    private void InstantiateDuck()
    {
        
        Instantiate ( DuckPrefab , DuckPath[DuckPath.Count - FindObjectOfType<PathMover>().GetComponent<PathMover>().pathPoints.Count - DuckCount -1] , Quaternion.identity );
        DuckCount --;
    }
}
