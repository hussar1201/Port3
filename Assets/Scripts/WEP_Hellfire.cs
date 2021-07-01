using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WEP_Hellfire : MonoBehaviour
{

    float speed = 50f;
    private Rigidbody rb;

    public GameObject effect;

    private bool fired = false;
    private GameObject target;
    private float time_before_tracking = .3f;
    private float time_after_launched = 0f;
    private Vector3 point_start;
    private bool tgt_set;
    
    public void Start()
    {
        rb = GetComponent<Rigidbody>();
        effect.SetActive(false);

        tgt_set = false;

    }

    public void Fire(GameObject target)
    {
        if (target == null) return;
        this.target = target;
        fired = true;
        effect.SetActive(true);
        transform.SetParent(GameManager.instance.transform);
        point_start = transform.position;
    }
        
    void Update()
    {
        if (!fired) return;
              
        time_after_launched += Time.deltaTime;
      
        if (time_before_tracking <= time_after_launched)
        {
            Vector3 los = target.transform.position - transform.position + new Vector3(0f, 2f, 0f);

            Vector3 heading = target.transform.position;

            if (!tgt_set)
            {
                transform.SetParent(target.transform);
                heading += new Vector3(0f, 2f, 0f);
                tgt_set = true;
            }

            transform.LookAt(heading);       

            transform.position += los.normalized * speed * Time.deltaTime;
        } 
        else
        {
            transform.position += transform.forward * speed * Time.deltaTime;
            //transform.position += (transform.position - point_start).normalized * speed * Time.deltaTime;           
        }

    }

    private void OnCollisionEnter(Collision collision)
    {
        effect.SetActive(false);
        Destroy(gameObject,0.2f);
        Destroy(collision.gameObject, 0.2f);
    }



}
