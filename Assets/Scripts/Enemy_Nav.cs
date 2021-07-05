using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Nav : MonoBehaviour
{
    public NavMeshAgent pathFinder;
    public PlayerController pc;
    private Transform transform_parent;
    public float distance = 1000f;


    public float speed {

        get;
        private set;
    }


    public float time_for_search = 2f;
    private float time = 0f;

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
        time += Time.deltaTime;
        distance = Mathf.Abs((pc.transform.position - transform.position).magnitude);
        
        if (time >= time_for_search)
        {
            time = 0f;
            pathFinder.isStopped = false;

            if (pathFinder.velocity == Vector3.zero) { stopped = true; }
            else stopped = false;

            pathFinder.SetDestination(pc.transform.position);
            transform_parent.LookAt(pc.transform);

            
        }


    }


}
