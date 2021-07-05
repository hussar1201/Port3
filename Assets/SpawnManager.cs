using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] arr_prefabs;

    float time = 0f;
    float afterRespawnTime=3f;


    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        
        if (time > afterRespawnTime)
        {
            afterRespawnTime = Random.RandomRange(5f, 15f);
            int x = Random.Range(0, arr_prefabs.Length);
                      
            Instantiate(arr_prefabs[x], transform.position, Quaternion.identity);
                                   
            time = 0f;
        }       


    }

    




}
