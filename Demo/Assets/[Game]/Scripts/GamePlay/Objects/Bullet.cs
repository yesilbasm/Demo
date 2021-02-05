using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Bullet : MonoBehaviour
{
    private Rigidbody rigidbody;
    public Rigidbody Rigidbody
    {
        get{
            if(rigidbody==null)
            rigidbody=GetComponent<Rigidbody>();

            return rigidbody;
        }
    }
    public Transform Gun;

    public List<Transform> Targets;

    private void Awake() {
        Targets = FindObjectOfType<FieldOfView>().visibleTargets;
    }
    void Start()
    {
        Fire();
    }

   

    private void Fire()
    {
        
        transform.DOMove(Targets[0].transform.position , 0.05F);
        
    }

    private void OnCollisionEnter(Collision other) 
    {
        
        if(other.gameObject.GetComponent<Animator>())
        {
            other.gameObject.GetComponent<Animator>().SetTrigger("Death");
            if(other.gameObject.tag == "Character")
            {
                EventManager.OnCharacterDie.Invoke();
                EventManager.OnLevelFail.Invoke();
            }
            else
            {
                EventManager.OnFollowerDie.Invoke();
                LevelManager.Instance.DuckCount -- ;
            }

            Instantiate(ParticleManager.Instance.BloodPrefab , transform.position , Quaternion.identity);
            Destroy(other.gameObject, 3);
        }
        
        Destroy(gameObject);

    }


}
