using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;


public class PathCreator : MonoBehaviour
{
    private LineRenderer lineRenderer;
    public List<Vector3> points = new List<Vector3>();
    
    
    private void Awake() 
    {
        lineRenderer = GetComponent<LineRenderer>();    
    }

    // Update is called once per frame
    void Update()
    {
       if(!LevelManager.Instance.isPathDrawed)
       {        
            if(Input.GetMouseButton(0))
            {
            
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hitInfo;
                if(Physics.Raycast(ray , out hitInfo))
                {   
                    

                    if(DistanceToLastPoint(hitInfo.point)>1F)
                    {
                        
                        points.Add(hitInfo.point);
                        
                        lineRenderer.positionCount = points.Count;
                        lineRenderer.SetPositions(points.ToArray());
                    }
                }
            }

            else if (Input.GetMouseButtonUp(0))
            {
                EventManager.OnPathNewCreated.Invoke();
                LevelManager.Instance.isPathDrawed=true;
            }
        }
        
    }

    private float DistanceToLastPoint(Vector3 point)
    {
        if(!points.Any())
            return Mathf.Infinity;

        return Vector3.Distance(points.Last() , point);

        
    }
}
