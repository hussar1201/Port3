using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private ColliderCollecter colliderCollecter;

    // Start is called before the first frame update
    void Start()
    {
        colliderCollecter = GetComponentInChildren<ColliderCollecter>();       
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
