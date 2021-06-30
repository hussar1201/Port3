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
        speed = e_Nav.speed * 0.92f;

    }


    private void Update()
    {

        if (e_Nav.stopped == false)
        {


            Vector3 heading = e_Nav.transform.position - transform.position;

            rb.MovePosition(transform.position + (heading * speed * Time.deltaTime));
            //rb.rotation = Quaternion.FromToRotation( e_Nav.transform.position, transform.position);

            transform.LookAt(e_Nav.transform);

            //transform.position += heading.normalized * speed * Time.deltaTime;
            //transform.position += transform.forward * speed * Time.deltaTime;
            //pos_Nav_before = e_Nav.transform.position;
        }
        else if (e_Nav.stopped == true)
        {

            rb.velocity = Vector3.zero;
            rb.position = rb.position + Vector3.zero;
        }


    }


    private IEnumerator UpdatePath()
    {


        yield return new WaitForSeconds(.1f);
    }



}
