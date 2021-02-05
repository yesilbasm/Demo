using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : Singleton<ParticleManager>
{
    public GameObject FirePrefab;
    public GameObject BloodPrefab;
    public GameObject ScarPrefab;
    public GameObject ConfetiPrefab;
    public Transform WinPlatform;
    private void OnEnable() 
    {
        EventManager.OnLevelSucces.AddListener(()=> StartCoroutine(InstantiateConfeti()) );    
    }

    private void OnDisable() 
    {
        EventManager.OnLevelSucces.RemoveListener(()=>  StartCoroutine(InstantiateConfeti()));
    }

    IEnumerator InstantiateConfeti()
    {   
        yield return new WaitForSeconds(1f);
        Instantiate(ConfetiPrefab , WinPlatform.transform.position + Vector3.up*4 , Quaternion.identity );
    }
}
