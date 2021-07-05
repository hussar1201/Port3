using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_cannon : MonoBehaviour
{
    float speed = 2200f;
    private Rigidbody rb;
   
    private int changed = 0;
    private float time_before_tracking = .3f;
    private float time_after_launched = 0f;   
    
    private float[] arr_CEP = { 0f, 0f, 0f };
    Vector3 CEP;
    Vector3 heading;  

    float time_passed;
    float[] time_for_change_route = { 0.3f, .6f, .9f };

    private Transform pos_fall;

    public void Start()
    {
        SetCEP();             
        pos_fall = WeaponManager.instance.pos_fall[0];
        heading = (pos_fall.transform.position) - transform.position;       
        rb = GetComponent<Rigidbody>();
        rb.AddForce(heading.normalized * speed, ForceMode.Force);
    }

    private void SetCEP()
    {
        for (int i = 0; i < arr_CEP.Length; i++)
        {
            arr_CEP[i] = Random.Range(0f, .1f);
        }
        CEP = new Vector3(arr_CEP[0], arr_CEP[1], arr_CEP[2]);
    }

    private void Update()
    {
        time_passed += Time.deltaTime;
        if (time_passed >= time_for_change_route[changed])
        {
            if(changed<2) ChangeRoute(++changed);
        }
    }

    private void ChangeRoute(int num)
    {
        pos_fall = WeaponManager.instance.pos_fall[num];
        SetCEP();
        rb.velocity = Vector3.zero;
        heading = (pos_fall.transform.position+ CEP) - transform.position;
        rb.AddForce(heading.normalized * speed, ForceMode.Force);
    }
}
