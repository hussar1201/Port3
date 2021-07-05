using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WEP_Rocket : MonoBehaviour
{
    float speed = 1200f;
    private Rigidbody rb;

    public GameObject effect;

    private bool changed = false;
    private float time_before_tracking = .3f;
    private float time_after_launched = 0f;
    private float[] arr_CEP = { 0f, 0f, 0f };

    Vector3 heading;
    Vector3 CEP;

    float time_passed;
    float time_for_change_route = 0.3f;

    public Transform pos_fall;

    public void Start()
    {
        for (int i = 0; i < arr_CEP.Length; i++)
        {
            arr_CEP[i] = Random.Range(0f, .2f);
        }
        CEP = new Vector3(arr_CEP[0], arr_CEP[1], arr_CEP[2]);

        pos_fall = WeaponManager.instance.pos_fall[0];
        
        heading = (pos_fall.transform.position+CEP) - transform.position;
        //transform.LookAt(heading);
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

    private void ChangeRoute()
    {
        pos_fall = WeaponManager.instance.pos_fall[1];
        heading = (pos_fall.transform.position) - transform.position;
        rb.AddForce(heading.normalized * speed * .7f, ForceMode.Force);
    }





    private void OnCollisionEnter(Collision collision)
    {
 
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy tmp = collision.gameObject.GetComponent<Enemy>();
            tmp.Die();
        }

        Destroy(gameObject, 0.5f);
    }





}


