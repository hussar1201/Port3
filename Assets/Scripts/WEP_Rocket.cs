using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WEP_Rocket : MonoBehaviour
{
    float speed = 1200f;
    private Rigidbody rb;

    public ParticleSystem[] effects;

    private bool changed = false;
    private float[] arr_CEP = { 0f, 0f, 0f };

    Vector3 heading;
    Vector3 CEP;

    float time_passed;
    float time_for_change_route = 0.3f;
    public bool flag_left;

    public Transform pos_fall;
    private Collider collider_Explode;

    
    public void Awake()
    {
        collider_Explode = GetComponent<Collider>();
        collider_Explode.enabled = false;
    }


    public void Start()
    {


        for (int i = 0; i < arr_CEP.Length; i++)
        {
            arr_CEP[i] = Random.Range(0f, .2f);
        }
        CEP = new Vector3(arr_CEP[0], arr_CEP[1], arr_CEP[2]);

        pos_fall = WeaponManager.instance.pos_fall[1];


        CalLR();
        
        rb = GetComponent<Rigidbody>();
        rb.AddForce(heading.normalized * speed, ForceMode.Force);
    }

    private void Update()
    {
        time_passed += Time.deltaTime;
        if(time_passed >= time_for_change_route)
        {

            if (!changed)
            {
                ChangeRoute();
                changed = true;
            }          
        }
    }

    private void CalLR()
    {
        if (flag_left == true) heading = (pos_fall.transform.position + new Vector3(-2.3f, -0.69f, 0.0f) + CEP) - transform.position;
        else heading = (pos_fall.transform.position + new Vector3(2.3f, -0.69f, 0.0f) + CEP) - transform.position;
    }


    private void ChangeRoute()
    {
        pos_fall = WeaponManager.instance.pos_fall[0];
        
        collider_Explode.enabled = true;
        CalLR();
        rb.AddForce(heading.normalized * speed * .7f, ForceMode.Force);
    }





    private void OnCollisionEnter(Collision collision)
    {
        effects[0].Stop();
        effects[1].Play();

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy tmp = collision.gameObject.GetComponent<Enemy>();
            tmp.Die();
        }
        rb.isKinematic = true;

        Destroy(gameObject, 0.5f);
    }





}


