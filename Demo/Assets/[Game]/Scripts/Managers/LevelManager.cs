using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class LevelManager : Singleton<LevelManager>
{
  public bool isPathDrawed;
  public GameObject DuckPrefab;
    public List<Transform> Ducks;
  public List <Vector3> DuckPath = new  List<Vector3>();
  public int PathCount;
  public int DuckCount=0;
  public bool isLevelStarted;
  public bool IsGameStarted;
  public bool CanDrawe;
  public bool IsCharacterAlive;
  public GameObject WinPlatform;
    
  
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
        DuckCount ++;
        Instantiate ( DuckPrefab , DuckPath[DuckPath.Count - FindObjectOfType<PathMover>().GetComponent<PathMover>().pathPoints.Count - 3*DuckCount  ] +Vector3.up*4, Quaternion.identity );
        
        DuckPrefab.transform.DOMove(DuckPath[DuckPath.Count - FindObjectOfType<PathMover>().GetComponent<PathMover>().pathPoints.Count - DuckCount -5 ] , 1F);
    }

    
}
