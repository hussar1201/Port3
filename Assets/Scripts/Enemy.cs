using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public Enemy_Nav e_Nav;
    private PlayerController pc;
    private Rigidbody rb;
    private float speed;
    private Vector3 pos_Nav_before;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        speed = e_Nav.speed * 0.95f;

    }


    private void Update()
    {

        if (e_Nav.stopped == false)
        {

            Vector3 heading = e_Nav.transform.position - transform.position;

            rb.MovePosition(transform.position + (heading * speed * Time.deltaTime));

            //transform.position += Vector3.forward * speed * Time.deltaTime;


            transform.LookAt(new Vector3(e_Nav.transform.position.x, transform.position.y, e_Nav.transform.position.z));

            

        }
        else if (e_Nav.stopped == true)
        {

            rb.velocity = Vector3.zero;
            rb.position = rb.position + Vector3.zero;
        }





    }


    



}
