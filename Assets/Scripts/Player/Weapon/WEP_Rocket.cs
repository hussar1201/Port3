using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WEP_Rocket : MonoBehaviour
{
    float speed = 1500f;
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
            arr_CEP[i] = Random.Range(0f, .1f);
        }
        CEP = new Vector3(arr_CEP[0], arr_CEP[1], arr_CEP[2]);

        pos_fall = WeaponManager.instance.pos_fall[0];


        CalLR();
                
        rb = GetComponent<Rigidbody>();
        rb.AddForce(heading.normalized * speed, ForceMode.Force);
        Destroy(gameObject, 4f);
        StartCoroutine(EnableCollider());
    }


    private void CalLR()
    {
        Transform[] arr_aims = pos_fall.GetComponentsInChildren<Transform>(); // 자신에게 포함된 컴포넌트까지 가져온다. 주의할 것.
        
        Debug.Log(arr_aims.Length + ": " +pos_fall.name);
        if (flag_left == true)
        {
            //heading = pos_fall.transform.position- transform.position + CEP; 
            heading = arr_aims[1].position - transform.position + CEP;
            Debug.Log("Left");
        }
        else 
        {
            //heading = pos_fall.transform.position- transform.position + CEP; 
            heading = arr_aims[2].position - transform.position + CEP;
            Debug.Log("Right");
        }
    }


    private void ChangeRoute()
    {
        pos_fall = WeaponManager.instance.pos_fall[1];
        
        collider_Explode.enabled = true;
        CalLR();
        rb.AddForce(heading.normalized * speed * .7f, ForceMode.Force);
    }


    private void OnCollisionEnter(Collision collision)
    {
        rb.velocity = Vector3.zero;
        rb.isKinematic = true;
        effects[0].Stop();
        effects[1].Play();
        
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Enemy tmp = collision.gameObject.GetComponent<Enemy>();
            tmp.Die();
        }
        

        Destroy(gameObject, 0.5f);
    }


    IEnumerator EnableCollider()
    {

        yield return new WaitForSeconds(.1f);
        Debug.Log("XXXXXX");
        collider_Explode.enabled = true;       
    }



}


