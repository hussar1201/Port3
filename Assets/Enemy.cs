using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent pathFinder;
    private PlayerController pc;


    // Start is called before the first frame update
    void Start()
    {
        pathFinder = GetComponent<NavMeshAgent>();
        pc = FindObjectOfType<PlayerController>();
        pathFinder.speed = 3f;

        StartCoroutine("UpdatePath");
    }

    // Update is called once per frame
    void Update()
    {
                    
    }



    private IEnumerator UpdatePath()
    {
        pathFinder.isStopped = false;
        pathFinder.SetDestination(pc.transform.position);
        yield return new WaitForSeconds(.3f);
    }



}
