using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Nav : MonoBehaviour
{
    private NavMeshAgent pathFinder;
    private PlayerController pc;

    public float speed {

        get;
        private set;
    }
    // Start is called before the first frame update
    void Start()
    {
        pathFinder = GetComponent<NavMeshAgent>();
        pc = FindObjectOfType<PlayerController>();
        speed = pathFinder.speed;

        StartCoroutine("UpdatePath");
    }

    // Update is called once per frame
    void Update()
    {
                    
    }

    private IEnumerator UpdatePath()
    {
        pathFinder.isStopped = false;
        Debug.Log("TRACKING");
                
        pathFinder.SetDestination(pc.transform.position);
                
        yield return new WaitForSeconds(.1f);
    }






}
