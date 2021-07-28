using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QExam : MonoBehaviour
{
    public GameObject tgt;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        Vector3 direction = tgt.transform.position - transform.position;
        direction.Normalize();
        Quaternion dirRotation = Quaternion.LookRotation(direction);
        rb.MoveRotation(Quaternion.RotateTowards(transform.rotation, dirRotation, 30.0f * Time.deltaTime)); //test1
        rb.MovePosition(transform.position + (transform.forward * 30f * Time.deltaTime)); //Move Method 1

        //transform.rotation = Quaternion.RotateTowards(transform.rotation, dirRotation, 30.0f * Time.deltaTime); //M1, M2
        //rb.MoveRotation(Quaternion.RotateTowards(transform.rotation, dirRotation, 30.0f * Time.deltaTime)); //test1
        //rb.MovePosition(transform.position+(transform.forward * 30f * Time.deltaTime)); //Move Method 1

        //transform.position += transform.forward * 30f *Time.deltaTime; //Move Method 2

   


    }
}
