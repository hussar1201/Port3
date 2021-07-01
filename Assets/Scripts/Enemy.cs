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
    private ParticleSystem ps;
    private bool flag_firing;

    private float time_interval_fire = 5f;
    private float time_after_fire = 0f;


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

    // Start is called before the first frame update
    void Start()
    {
        ps = GetComponentInChildren<ParticleSystem>();
        rb = GetComponent<Rigidbody>();
        speed = e_Nav.speed * 0.95f;
        turret = GetComponentInChildren<Enemy_Turret>();
        
  

    }


    private void Update()
    {

        

        if (e_Nav.stopped == false)
        {

            Vector3 heading = e_Nav.transform.position - transform.position;

            rb.MovePosition(transform.position + (heading * speed * Time.deltaTime));

            //transform.position += Vector3.forward * speed * Time.deltaTime;
            enemy_pos_for_body = new Vector3(e_Nav.transform.position.x, transform.position.y, e_Nav.transform.position.z);
            transform.LookAt(enemy_pos_for_body);
            ps.gameObject.active = true;                          

        }


        else if (e_Nav.stopped == true)
        {
            
            flag_firing = true;

            if(time_after_fire >= time_interval_fire)
            {
                time_after_fire = 0f;
                turret.Fire();
            }
            ps.gameObject.active = false;
            rb.velocity = Vector3.zero;
            rb.position = rb.position + Vector3.zero;
        }
        time_after_fire += Time.deltaTime;
    }

  
      
 

    



}
