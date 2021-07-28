using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotorforCine : MonoBehaviour
{

    private const float speed_normal = 1000f;
    private float speed;
    public int mode_rotate;
    
    private Vector3 rotation;

    // Start is called before the first frame update
    void Start()
    {
        speed = speed_normal;

        if (mode_rotate == 0) rotation = Vector3.left;
        if (mode_rotate == 1) rotation = Vector3.up;

    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(rotation * speed * Time.deltaTime);
    }

}


