using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_cannon : MonoBehaviour
{
    float speed = 80f;
    private Rigidbody rb;
   
    private int changed = 0;
    
    
    private float[] arr_CEP = { 0f, 0f, 0f };
    Vector3 CEP;
    Vector3 heading;  

    float time_passed;
    float[] time_for_change_route = { 0.3f, .6f, .9f };

    Collider cc;

    public Transform pos_fall;

    public void CheckType() { }

    public void Start()
    {
        SetCEP();
        /*
       
        heading = (pos_fall.transform.position) - transform.position;       
        
        rb.AddForce(heading.normalized * speed, ForceMode.Force);
        */
        //rb.AddForce(transform.forward+CEP * speed, ForceMode.Force);
        cc = GetComponent<Collider>();
        cc.enabled = false;

        pos_fall = WeaponManager.instance.pos_fall[0];
        heading = (pos_fall.transform.position) - transform.position;

        rb = GetComponent<Rigidbody>();
        rb.AddForce(10000f * heading.normalized, ForceMode.Force);
        
        StartCoroutine(EnableCollider());
        
        Destroy(gameObject, 3f);

    }

    private void SetCEP()
    {
        for (int i = 0; i < arr_CEP.Length; i++)
        {
            arr_CEP[i] = Random.Range(0f, .05f);
        }
        CEP = new Vector3(arr_CEP[0], arr_CEP[1], arr_CEP[2]);
    }

    private void Update()
    {

        //transform.position += transform.forward * speed * Time.deltaTime;        

    }

    private void ChangeRoute(int num)
    {
        pos_fall = WeaponManager.instance.pos_fall[num];
        SetCEP();
        rb.velocity = Vector3.zero;
        heading = (pos_fall.transform.position+ CEP) - transform.position;
        rb.AddForce(heading.normalized * speed, ForceMode.Force);
    }


    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy tmp = collision.gameObject.GetComponent<Enemy>();
            tmp.Die();
        }
        Destroy(gameObject);
    }


    IEnumerator EnableCollider()
    {
        yield return new WaitForSeconds(.1f);
        cc.enabled = true;
    }



}
