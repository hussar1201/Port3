using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] arr_prefabs;

    float time = 0f;
    float afterRespawnTime=5f;
    public Transform[] arr_destination_1;
    public Transform[] arr_destination_2;

    void Update()
    {
        time += Time.deltaTime;
        
        if (time > afterRespawnTime)
        {
            afterRespawnTime = Random.Range(5f, 15f);
            int x = Random.Range(0, arr_prefabs.Length);
                      
            GameObject tmp = Instantiate(arr_prefabs[x], transform.position, Quaternion.identity);
            Enemy_Nav tmp_Nav = tmp.gameObject.GetComponentInChildren<Enemy_Nav>();
            tmp_Nav.arr_destination_1 = arr_destination_1;
            tmp_Nav.arr_destination_2 = arr_destination_2;
            time = 0f;
        }       
    }
}
