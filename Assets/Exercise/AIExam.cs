using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class AIExam : MonoBehaviour
{

    private NavMeshAgent na;
    private Transform tgt_destination;
    public Transform[] arr_destination_1;
    public Transform[] arr_destination_2;
    public Transform[] arr_destination_3;
    private List<Transform[]> list_arr_destination = new List<Transform[]>();

    // Start is called before the first frame update
    void Start()
    {
        na = GetComponent<NavMeshAgent>();

        list_arr_destination.Add(arr_destination_1);
        list_arr_destination.Add(arr_destination_2);
        list_arr_destination.Add(arr_destination_3);

        int selected_num = Random.Range(0, arr_destination_1.Length);
        tgt_destination = arr_destination_1[selected_num];
        FindNextWayPoint(0);

    }

    // Update is called once per frame
    void Update()
    {
        na.SetDestination(tgt_destination.position);  
    }

    private void OnTriggerEnter(Collider other)
    {
       if(other.gameObject.CompareTag("Beacon"))
       {
            string tmp = other.gameObject.name;
            
            string[] arr_str = tmp.Split('_');

            int x = int.Parse(arr_str[1]);
            
            FindNextWayPoint(x);
       }

    }

    private void FindNextWayPoint(int x)
    {
        if (x >= 3) return;
        int selected_num = Random.Range(0, list_arr_destination[x].Length);
        tgt_destination = list_arr_destination[x][selected_num];
        Debug.Log(x + "-" + selected_num);
    }







}
