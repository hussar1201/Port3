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
    private Enemy_Turret turret;
    public ParticleSystem[] ps;
    private bool flag_firing;
    public float time_interval_fire = 5f;
    private float time_after_fire = 0f;
    public GameObject obj_parent;

    public Vector3 enemy_pos_for_body
    {
        get;
        private set;      
    }

    public Vector3 enemy_pos_for_cannon
    {
        get;
        private set;
    }
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        turret = GetComponentInChildren<Enemy_Turret>();
    }

    private void Update()
    {
        speed = e_Nav.speed;
        if (e_Nav.stopped == false)
        {         
            Vector3 heading = e_Nav.transform.position - transform.position;
            rb.MovePosition(transform.position + (heading * speed * Time.deltaTime));
            enemy_pos_for_body = new Vector3(e_Nav.transform.position.x, transform.position.y, e_Nav.transform.position.z);
            transform.LookAt(enemy_pos_for_body);
            ps[0].gameObject.SetActive(true);           
       
        }
        else if (e_Nav.stopped == true)
        {
            ps[0].gameObject.SetActive(false);
            
            flag_firing = true;

            if(time_after_fire >= time_interval_fire)
            {
                time_after_fire = 0f;
                turret.Fire();
            }
                     
            rb.velocity = Vector3.zero;
            rb.position = rb.position + Vector3.zero;
        }
        time_after_fire += Time.deltaTime;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("MSL_AT"))
        {
            ps[1].Play();
            Die();
        }
    }

    public void Die()
    {
       Destroy(obj_parent, .5f);
    }
}


