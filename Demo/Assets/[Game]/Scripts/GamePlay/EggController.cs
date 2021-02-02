using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EggController : MonoBehaviour , ICollectable
{
    
    public void Collected()
    {
        EventManager.OnEggCollected.Invoke();
        Destroy(gameObject);
    }
}
