using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Nav : MonoBehaviour
{
    public NavMeshAgent pathFinder;
    public PlayerController pc;
    private Transform transform_parent;
    public float distance_fire_range = 300f;
    private float distance = 1000f;
    public Transform[] arr_destination_1;
    public Transform[] arr_destination_2;
    private List<Transform[]> list_arr_destination = new List<Transform[]>();
    private Transform tgt_destination;
    public float speed {
        get;
        private set;
    }
    public float time_for_search = 2f;
    private float time = 0f;
    public bool stopped = false;

    void Start()
    {
        pathFinder = GetComponent<NavMeshAgent>();
        transform_parent = GetComponentInParent<Transform>();
        pc = FindObjectOfType<PlayerController>();
        speed = pathFinder.speed;
        list_arr_destination.Add(arr_destination_1);
        list_arr_destination.Add(arr_destination_2);
        int selected_num = Random.Range(0, arr_destination_1.Length);
        FindNextWayPoint(0);
    }

    void Update()
    {
        
        time += Time.deltaTime;
        distance = Mathf.Abs((pc.transform.position - transform.position).magnitude);

        if (time >= time_for_search)
        {
            time = 0f;
            if (tgt_destination != null) { 
                pathFinder.isStopped = false;
                pathFinder.SetDestination(tgt_destination.position);
            }

            if (pathFinder.velocity == Vector3.zero) { stopped = true; }                    
            transform_parent.LookAt(pc.transform);

            if (distance <= distance_fire_range)
            {
                pathFinder.isStopped = stopped = true;
            }
            else
            {
                pathFinder.isStopped = stopped = false;
            }
        }     
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Beacon"))
        {
            string tmp = other.gameObject.name;

            string[] arr_str = tmp.Split('_');

            int x = int.Parse(arr_str[1]);
            Debug.Log(x);
            FindNextWayPoint(x);
        }
    }

    private void FindNextWayPoint(int x)
    {
        if (x > 1) return;
        Debug.Log(x);
        int selected_num = Random.Range(0, list_arr_destination[x].Length);
        tgt_destination = list_arr_destination[x][selected_num];
        Debug.Log(x + "-" + selected_num);
    }

}
