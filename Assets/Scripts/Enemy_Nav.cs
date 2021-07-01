using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Nav : MonoBehaviour
{
    private NavMeshAgent pathFinder;
    public PlayerController pc;
    private Transform transform_parent;

    public float speed {

        get;
        private set;
    }

    public bool stopped = false;


    // Start is called before the first frame update
    void Start()
    {
        pathFinder = GetComponent<NavMeshAgent>();
        transform_parent = GetComponentInParent<Transform>();
  
        pc = FindObjectOfType<PlayerController>();
        speed = pathFinder.speed;       
    }

    // Update is called once per frame
    void Update()
    {
        pathFinder.isStopped = false;

        if (pathFinder.velocity == Vector3.zero) { stopped = true;}
        else stopped = false;
      
        pathFinder.SetDestination(pc.transform.position);
        transform_parent.LookAt(pc.transform);
        

        
    }


}
