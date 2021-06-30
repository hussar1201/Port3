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
        speed = e_Nav.speed*0.9f;     
       
    }


    private void Update()
    {
        if (pos_Nav_before == e_Nav.transform.position) return;
        transform.LookAt(e_Nav.transform);
        //Vector3 heading = e_Nav.transform.position - transform.position;
        //transform.position += heading.normalized * speed * Time.deltaTime;
        transform.position += transform.forward * speed * Time.deltaTime;
        pos_Nav_before = e_Nav.transform.position;
    }



}
