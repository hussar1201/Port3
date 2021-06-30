using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotor : MonoBehaviour
{

    public float speed
    {
        get; set;
    }

    public int mode_rotate;


    private Vector3 rotation;

    // Start is called before the first frame update
    void Start()
    {
        speed = 1200f;

        if (mode_rotate == 0) rotation = Vector3.left;
        if (mode_rotate == 1) rotation = Vector3.up;

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotation * speed *Time.deltaTime);
        


    }
}
